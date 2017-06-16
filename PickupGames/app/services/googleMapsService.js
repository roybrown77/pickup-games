app.factory('googleMapsService', ['$q', function ($q) {
    var service = {};
    var _autocomplete;
    var _markers = [];

    function deleteMarkers() {
        try {
            for (var i = 0; i < _markers.length; i++) {
                _markers[i].setMap(null);
            }

            _markers = [];
        } catch (e) {
            var temp = e;
        }         
    }

    service.createMap = function (mapCanvasId) {
        try {
            var mapOptions = {
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };

            var map = new google.maps.Map(document.getElementById(mapCanvasId), mapOptions);
            return map;
        } catch (e) {
            var temp = e;
        }

        return null;
    }

    service.setMapBounds = function (map, location, zoom) {
        var deferred = $q.defer();

        try {            
            _autocomplete.bindTo('bounds', map);

            var geocoder = new google.maps.Geocoder();
            geocoder.geocode({ 'address': location }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    map.fitBounds(results[0].geometry.viewport);
                    if (zoom !== 'undefined' && zoom !== undefined && zoom !== "") {
                        map.setZoom(parseInt(zoom));
                    }                    
                }

                return deferred.resolve();
            });
            
        } catch (e) {
            var temp = e;
        }

        return deferred.promise;
    }

    service.setAutocomplete = function (locationId) {
        try {
            var input = (document.getElementById(locationId));
            _autocomplete = new google.maps.places.Autocomplete(input);
        } catch (e) {
            var temp = e;
        }         
    }

    service.setAddressOnlyAutocomplete = function (locationId) {
        try {
            var input = (document.getElementById(locationId));
            var options = {
                types: ['address']
            };
            _autocomplete = new google.maps.places.Autocomplete(input, options);
        } catch (e) {
            var temp = e;
        }         
    }

    service.refreshMarkers = function (map, locations) {
        try {
            deleteMarkers();
            addMarkers(map, locations);
        } catch (e) {
            var temp = e;
        }         
    }

    service.addMarkers = function (map, locations, icon) {
        try {
            var marker;

            for (var index in locations) {
                marker = new google.maps.Marker({
                    position: new google.maps.LatLng(locations[parseInt(index)].location.lat, locations[parseInt(index)].location.lng),
                    map: map,
                    title: 'time to ball!',
                    draggable: true,
                    icon : icon
                });

                //google.maps.event.addListener(marker, 'click', (function (marker, i) {
                //    return function () {
                //    }
                //})(marker, i));

                _markers.push(marker);
            };
        } catch (e) {
            var temp = e;
        }         
    }    

    return service;
}]);