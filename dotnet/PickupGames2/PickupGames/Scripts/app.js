var gamesApp = angular.module('gamesApp', [
    'ngRoute',
    'gameAppControllers'
]);

//gamesApp.config(['$routeProvider',
//  function ($routeProvider) {
//      $routeProvider.
//        when('/', {
//            templateUrl: 'Home/Index.cshtml',
//            controller: 'HomeController'
//        }).
//        when('/About', {
//            templateUrl: 'Home/About.cshtml',
//            controller: 'HomeController'
//        }).
//        when('/Contact', {
//            templateUrl: 'Home/Contact.cshtml',
//            controller: 'HomeController'
//        }).
//        when('/Games', {
//            templateUrl: 'Games/Index.cshtml',
//            controller: 'GameController'
//        }).
//        otherwise({
//            redirectTo: '/'
//        });
//  }]);