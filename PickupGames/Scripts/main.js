angular.module('main')
    .controller('MainController', ['$scope', function ($scope) {
        function initialize() {
            var input = (document.getElementById('Location'));
            new google.maps.places.Autocomplete(input);
        }

        google.maps.event.addDomListener(window, 'load', initialize);

        $scope.searchgames = function () {
            window.location = "Games/" + this.Location + '/#/home';
        };
    }]);