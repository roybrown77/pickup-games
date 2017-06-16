'use strict';
app.controller('homeController', ['$scope', 'googleMapsService', function ($scope, googleMapsService) {
    googleMapsService.setAutocomplete('Location');

    $scope.searchgames = function () {
        var location = $.trim($scope.Location);
        if (location === "" || location === null) {
            window.location = "#/games/usa/1?zoom=4";

        } else {
            window.location = "#/games/" + location + "/1";  // get zoom level
        }
    };
}]);