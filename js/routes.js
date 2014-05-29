define(['angular', 'angular.route', 'controllers'] , function (angular) {
	angular.module('app.Routes',['ngRoute', 'app.Controllers']).config(function($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);
    $routeProvider.
      when('/', {
          templateUrl: '/index.html',
          controller: 'HomeCtrl',
          title: 'Home'
      }).
      otherwise({
        redirectTo: '/index.html'
      });
  });
});