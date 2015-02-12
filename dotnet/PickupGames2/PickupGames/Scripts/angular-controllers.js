var gamesApp = angular.module('gamesApp', []);

gamesApp.controller('GameController', function ($scope, $http) {
    var resultPromise = $http.post("api/Tests");
    resultPromise.success(function (data) {
        $scope.games = data.GameListModel;
    });
});

//gamesApp
//    .controller('GameController', function ($scope, gameService) {
//        (function (service) {
//            return function () {
//                var resultPromise = service.getGames();
//                resultPromise.success(function(data) {
//                    $scope.games = data;
//                });
//            };
//        })(gameService);
//    }).factory('gameService', function ($http) {
//        return ({ getGames: getGames });
//        function getGames() {
//            var request = $http.post("Games/GetGames");
//            return request;
//        }
//    });