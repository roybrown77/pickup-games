appRoot.factory('gamesService', function ($q, $http) {
    var service = {};

    service.getGames = function (params) {
        var deferred = $q.defer();

        $http.post("api/games/", params).success(function (response) {
            deferred.resolve(response.games);
        });

        return deferred.promise;
    }

    return service;
});