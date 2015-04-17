var app = angular.module('AngularAuthApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar', 'ngResource']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    });

    $routeProvider.when("/games/new", {
        controller: "createGameController",
        templateUrl: "/app/views/createGame.html"
    });

    $routeProvider.when("/games", {
        controller: "gamesController",
        templateUrl: "/app/views/games.html"
    });

    $routeProvider.when("/games/:location", {
        controller: "gamesController",
        templateUrl: "/app/views/games.html"
    });

    $routeProvider.when("/games/:location/:index", {
        controller: "gamesController",
        templateUrl: "/app/views/games.html"
    });

    $routeProvider.when("/refresh", {
        controller: "refreshController",
        templateUrl: "/app/views/refresh.html"
    });

    $routeProvider.when("/tokens", {
        controller: "tokensManagerController",
        templateUrl: "/app/views/tokens.html"
    });

    $routeProvider.when("/associate", {
        controller: "associateController",
        templateUrl: "/app/views/associate.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });
});

//var serviceBase = 'http://qpiga.apphb.com/';
var serviceBase = 'http://localhost:59512/';

app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);


