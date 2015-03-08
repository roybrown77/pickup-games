angular.module('googleMapAutocompleteDirective', [])
    .directive('google-map-autocomplete', function () {
        var link = function (scope, element) {
            var input = (document.getElementById(scope.locationId));
            new google.maps.places.Autocomplete(input);
        return {
            restrict: 'A',
            link: link,
        };
    }
});