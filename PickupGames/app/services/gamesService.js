app.factory('gamesService', ['$q', '$http', '$resource', 'ngAuthSettings', function ($q, $http, $resource, ngAuthSettings) {
    var service = {};
    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    service.getGames = function (model) {
        var deferred = $q.defer();

        var resource = $resource(serviceBase + 'api/games', model, {
            'get': { method: 'GET', isArray: false }
        });

        resource.get(function (response) {
            deferred.resolve(response);
        });

        return deferred.promise;
    }

    service.getGame = function (id) {
        var deferred = $q.defer();

        var resource = $resource(serviceBase + 'api/games', id);

        resource.get(function (response) {
            deferred.resolve(response.game);
        });

        return deferred.promise;
    }

    service.deleteGame = function (id) {
        var deferred = $q.defer();

        var resource = $resource(serviceBase + 'api/games/' + id.toString());

        resource.delete(function (response) {
            deferred.resolve(response);
        });

        return deferred.promise;
    }

    service.addGame = function (model) {
        var deferred = $q.defer();

        var resource = $resource(serviceBase + 'api/games', model);

        resource.save(function (response) {
            deferred.resolve(response);
        });

        return deferred.promise;
    }

    service.updateGame = function (id, model) {
        var deferred = $q.defer();

        var resource = $resource(serviceBase + 'api/games/:id', null,
                        {
                            'update': { method: 'PUT' }
                        });

        resource.update({ id: id }, model, function (response) {
            deferred.resolve(response);
        });

        return deferred.promise;
    }

    return service;
}]);