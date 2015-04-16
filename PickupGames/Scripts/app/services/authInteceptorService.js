appRoot.factory('sportsService', function ($q, $http, $resource) {
    var service = {};

    service.getSports = function () {
        var deferred = $q.defer();

        var resource = $resource('/api/v1/sports', {
            'get': { method: 'GET', isArray: false }
        });

        resource.get(function (response) {
            deferred.resolve(response.sports);
        });

        return deferred.promise;
    }

    return service;
});