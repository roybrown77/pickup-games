appRoot.factory('gameService', function ($q, $http, $resource) {
    return $resource('/api/games/:id', null, {
        'update': { method: 'PUT' }
    });
});