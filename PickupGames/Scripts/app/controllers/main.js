angular.module('main')
    .controller('MainController', ['$scope', function ($scope, $location) {
        $scope.searchgames = function () {
            window.location = "/#/games/" + $scope.Location + "/1";
        };
    }]);