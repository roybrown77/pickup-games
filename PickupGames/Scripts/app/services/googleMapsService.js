appRoot.factory('googleMapsService', function ($q) {
    var service = {};
    var _map;
    var _geocoder = new google.maps.Geocoder();
    var _zoom;
    var _autocomplete;
    var _markers = [];
    var _formattedAddress;

    service.createMap = function (mapCanvasId) {
        var mapOptions = {
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };

        _map = new google.maps.Map(document.getElementById(mapCanvasId), mapOptions);
    }

    service.setMapBounds = function (location, zoom) {
        var deferred = $q.defer();

        _autocomplete.bindTo('bounds', _map);

        _geocoder.geocode({ 'address': location }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                _map.fitBounds(results[0].geometry.viewport);
                if (zoom !== 'undefined' && zoom !== undefined && zoom !== "") {
                    _map.setZoom(parseInt(zoom));
                }

                _zoom = _map.getZoom();
                //_formattedAddress = results[1].formatted_address;

                deferred.resolve();
            }
        });

        return deferred.promise;
    }

    service.setMapAutocomplete = function(locationId) {
        var input = (document.getElementById(locationId));
        _autocomplete = new google.maps.places.Autocomplete(input);
    }

    service.getZoom = function() {
        return _zoom;
    }

    service.getFormattedAddress = function () {
        return _formattedAddress;
    }

    service.setMapEvents = function () {
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

    service.refreshMarkers = function(locations) {
        deleteMarkers();
        this.addMarkers(locations);
    }

    service.addMarkers = function(locations) {
        var marker;

        for (var index in locations) {
            marker = new google.maps.Marker({
                position: new google.maps.LatLng(locations[parseInt(index)].locationLat, locations[parseInt(index)].locationLng),
                map: _map,
                title: 'time to ball!',
                draggable: true
            });

            //google.maps.event.addListener(marker, 'click', (function (marker, i) {
            //    return function () {
            //    }
            //})(marker, i));

            _markers.push(marker);
        };
    }

    function deleteMarkers() {
        for (var i = 0; i < _markers.length; i++) {
            _markers[i].setMap(null);
        }

        _markers = [];
    }

    return service;
});