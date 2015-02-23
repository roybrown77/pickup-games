appRoot.factory('googleMapsFactory', function ($scope, $http, $location, $resource, $routeParams) {
    var service = {};
    //var _map;
    var geocoder = new google.maps.Geocoder();;
    var markers = [];

    service.createMap = function (mapCanvas) {
        var mapOptions = {
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        return new google.maps.Map(document.getElementById(mapCanvas), mapOptions);
    }

    return service;
});