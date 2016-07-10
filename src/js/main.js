var app = angular.module('myApp', ['ngRoute']);

app.config(['$routeProvider',
  function($routeProvider) {
    $routeProvider.
      when('/home', {
        templateUrl: 'views/inicial.html',
        controller: 'mainController'
      }).
      when('/cuentas', {
        templateUrl: 'views/cuentas.html',
        controller: 'mainController'
      }).
      when('/documentos', {
        templateUrl: 'views/documentos.html',
        controller: 'mainController'
      }).
      otherwise({
        redirectTo: '/home'
      });
}]);
