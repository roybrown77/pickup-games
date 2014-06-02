define(['angular', 'angular.route', 'controllers'] , function (angular) {
	angular.module('app.Routes',['ngRoute', 'app.Controllers','ui.router']).config(function($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/home');

        $stateProvider

            // HOME STATES AND NESTED VIEWS ========================================
            .state('home', {
                url: '/home',
                templateUrl: 'partial-home.html'
            })

            // ABOUT PAGE AND MULTIPLE NAMED VIEWS =================================
            .state('about', {
                // we'll get to this in a bit
            });
  });
});