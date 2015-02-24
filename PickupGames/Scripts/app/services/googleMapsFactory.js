appRoot.factory('googleMapsFactory', function ($q) {
    var service = {};
    var _map;
    var _geocoder = new google.maps.Geocoder();
    var _markers = [];
    var _zoom;

    service.createMap = function (mapCanvasId) {
        var mapOptions = {
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };

        _map = new google.maps.Map(document.getElementById(mapCanvasId), mapOptions);
    }

    service.setMapBounds = function (location, zoom) {
        var deferred = $q.defer();

        _geocoder.geocode({ 'address': location }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                _map.fitBounds(results[0].geometry.viewport);
                if (zoom !== 'undefined' && zoom !== undefined && zoom !== "") {
                    _map.setZoom(parseInt(zoom));
                }

                _zoom = _map.getZoom();
                deferred.resolve();
            }
        });

        return deferred.promise;
    }

    service.setMapAutocomplete = function(locationId) {
        var input = (document.getElementById(locationId));
        var autocomplete = new google.maps.places.Autocomplete(input);
        autocomplete.bindTo('bounds', _map);
    }

    service.getZoom = function() {
        return _zoom;
    }

    service.setMapEvents = function() {
        google.maps.event.addListener(_map, 'bounds_changed', onBoundsChanged);
    }

    function onBoundsChanged() {
        //if (enableRecenter === true) {
        var latlng = map.getCenter();
        _geocoder.geocode({ 'latLng': latlng }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                if (results[1]) {
                    //$('#Location').val(results[1].formatted_address);
                    //$location.path("/games/" + results[1].formatted_address + "/" + $routeParams.index, false).search({ 'zoom': map.getZoom() });
                    //$scope.gamesearch.location = results[1].formatted_address;
                    //$routeParams.zoom = map.getZoom();
                }
            }
        });
        //} else {
        //    enableRecenter = true;
        //}
    }

    return service;
});