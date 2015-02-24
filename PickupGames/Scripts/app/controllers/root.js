appRoot.controller('RootController', ['$scope', '$route', '$routeParams', '$location', function($scope, $route, $routeParams, $location) {
    $scope.$on('$routeChangeSuccess', function(e, current, previous) {
        $scope.activeViewPath = $location.path();
        $('.navbar-collapse').removeClass('in').addClass('collapse');
    });
}]);