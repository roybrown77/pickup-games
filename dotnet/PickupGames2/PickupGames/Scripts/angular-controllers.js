var gamesApp = angular.module('gamesApp', []);

gamesApp.controller('GamesController', function ($scope, $http) {
    var resultPromise = $http.post("/Games2/GetGames");
    resultPromise.success(function (data) {
        $scope.games = data;
    });
});