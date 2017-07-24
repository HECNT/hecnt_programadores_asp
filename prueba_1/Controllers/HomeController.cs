using prueba_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prueba_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            agendaEntities2 db = new agendaEntities2();
            Persons persons = db.Persons.SingleOrDefault(x => x.ID == 1);

            EmployeeViewModel vm = new EmployeeViewModel();

            vm.ID = persons.ID;
            vm.LastName = persons.LastName;
            vm.FirstName = persons.FirstName;
            vm.Age = persons.Age;

            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult setNuevo()
        {

            int res = 1;
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult init()
        {
            

            agendaEntities2 db = new agendaEntities2();

            List<Persons> personList = db.Persons.ToList();

            EmployeeViewModel personVM = new EmployeeViewModel();

            List<EmployeeViewModel> personVMList = personList.Select(x => new EmployeeViewModel { 
                LastName = x.LastName, 
                FirstName = x.FirstName, 
                Age = x.Age, 
                ID = x.ID 
            }).ToList();

            return Json(personVMList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Developer()
        {
            return View();
        }

        public JsonResult PersonDetail(int id)
        {
            agendaEntities2 db = new agendaEntities2();

            Persons person = db.Persons.SingleOrDefault(x => x.ID == id);

            EmployeeViewModel personVM = new EmployeeViewModel();

            personVM.ID = person.ID;
            personVM.FirstName = person.FirstName;
            personVM.LastName = person.LastName;
            personVM.Age = person.Age;

            return Json(personVM, JsonRequestBehavior.AllowGet);
        }
    }
}