angular.module('main')
    .controller('MainController', ['$scope', function ($scope, $location) {
        var input = (document.getElementById('Location'));
        new google.maps.places.Autocomplete(input);

        $scope.searchgames = function () {
            window.location = "/#/games/" + $scope.Location + "/1";
        };
    }]);