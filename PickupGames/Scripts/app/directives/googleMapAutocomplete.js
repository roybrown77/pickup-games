appRoot.directive('google-map-autocomplete', function () {
        var link = function (scope, element) {
            var input = (element);
            new google.maps.places.Autocomplete(input);
        return {
            restrict: 'A',
            link: link,
        };
    }
});