appRoot.factory('gamesService', function ($q, $http, $resource) {
    var service = {};

    service.getGames = function(model) {
        var deferred = $q.defer();

        //$http.post("api/games", gameSearchModel).success(function (response) {
        //    deferred.resolve(response.games);
        //});

        var resource = $resource('/api/games', model, { TypeGetCategoryAndBrand: { method: 'GET', isArray: false } });
        resource.get(function (response) {
            deferred.resolve(response.gameListModel);            
        });

        return deferred.promise;
    }

    return service;
});