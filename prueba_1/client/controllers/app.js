var app = angular.module('home', [])

app.controller('homeCtrl', function ($scope, $http) {
    $scope.test = "Hola";

    $http.get('/Home/setNuevo')
    .then(function(result){
      console.log(result,'aqui result')
    })

    $http.get('/Home/init')
    .then(function (result) {
      $scope.dataInit = result.data
      console.log(result,'data bd')
    })

    $scope.btnEdit = function (item) {
        location.href = "/Home/Developer?id=" + item.ID 
    }

    $scope.initDev = function () {
        var id = getParameterByName('id')
        $http.get('/Home/PersonDetail?id=' + id)
        .then(function (result) {
            console.log(result, 'result get details person')
            var arr = [result.data]
            $scope.s_developer = arr
        })
    }

    function getParameterByName(name, url) {
        if (!url) url = window.location.href;
        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
            results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, " "));
    }
})
