var app = angular.module('home', [])

app.controller('homeCtrl', function ($scope, $http) {
    $scope.test = "Hola";

    $http.get('/Home/setNuevo')
    .then(function(result){
      console.log(result,'aqui result')
    })
})
