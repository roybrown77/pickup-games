appRoot.factory('gamesService', function ($q, $http, $resource) {
    var service = {};

    service.getGames = function(model) {
        var deferred = $q.defer();

        var resource = $resource('/api/games', model, {
            'get': { method: 'GET', isArray: false }
        });

        resource.get(function (response) {
            deferred.resolve(response.gameListModel);            
        });

        return deferred.promise;
    }

    service.getSports = function (model) {
        var deferred = $q.defer();

        var resource = $resource('/api/sports', {
            'get': { method: 'GET', isArray: false }
        });

        resource.get(function (response) {
            deferred.resolve(response.sports);
        });

        return deferred.promise;
    }

    return service;
});