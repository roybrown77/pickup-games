appRoot.controller('CreateGameController', function ($scope, $http, $q, $location, $resource) {
    $scope.creategame = function () {
        var game = {}
        game.sport = $scope.creategame.sport;
        game.location = $scope.creategame.location;
        $http.post("api/games", game).success(function () {
            var temp = 1;
        });
    };
});