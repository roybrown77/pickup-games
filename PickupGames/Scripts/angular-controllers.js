appRoot.controller('MainController', function ($scope, $http, $routeParams) {
    function initialize() {
        var input = (document.getElementById('Location'));
        new google.maps.places.Autocomplete(input);
    }

    google.maps.event.addDomListener(window, 'load', initialize);

    $scope.searchgames = function () {
        window.location = "#/games/" + $scope.Location + "/1";
    };
});

appRoot.controller('GamesController', function ($scope, $http, $location, $resource, $routeParams) {
    $scope.gamesearch = [];
    $scope.gamesearch.location = $routeParams.location;

    var map;
    var geocoder;
    var markers = [];

    function initializeMap() {
        createMap();
        setMapBounds();
        setMapEvents();
        addMarkers();
        setMapAutocomplete();
    }

    function createMap() {
        var mapOptions = {
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            zoom: parseInt($routeParams.zoom),
            maxZoom: parseInt($routeParams.zoom)
        };
        map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
    }

    function setMapBounds() {
        geocoder = new google.maps.Geocoder();
        geocoder.geocode({ 'address': $routeParams.location }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                map.fitBounds(results[0].geometry.viewport);
                map.setZoom($routeParams.zoom);
            }
        });
    }

    function setMapAutocomplete() {
        var input = (document.getElementById('Location'));
        var autocomplete = new google.maps.places.Autocomplete(input);
        autocomplete.bindTo('bounds', map);
    }

    function addMarkers() {
        var coordinates = [];
        $('.location').each(function (i) {
            coordinates[i] = [parseFloat($(this).attr('data-lat')), parseFloat($(this).attr('data-lng'))];
        });

        var marker;
        $(coordinates).each(function (i, elem) {
            marker = new google.maps.Marker({
                position: new google.maps.LatLng(elem[0], elem[1]),
                map: map,
                title: 'time to ball!',
                draggable: true
            });

            google.maps.event.addListener(marker, 'click', (function () {
                return function () {
                }
            })(marker, i));

            markers.push(marker);
        });
    }

    function setMapEvents() {
        google.maps.event.addListener(map, 'bounds_changed', onBoundsChanged);
    }

    function onBoundsChanged() {
        //if (enableRecenter === true) {
            var latlng = map.getCenter();
            geocoder = new google.maps.Geocoder();
            geocoder.geocode({ 'latLng': latlng }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    if (results[1]) {
                        $('#Location').val(results[1].formatted_address);
                        $routeParams.zoom = map.getZoom();
                    }
                }
            });
        //} else {
        //}
    }

    function initializeGames() {
        $scope.games = [];
        $http.post("api/games/", $routeParams).success(function (data) {
            $scope.games = data;
            //refreshMarkers();
        });

        //var resource = $resource('api/games/', $scope.gamesearch, { method: 'POST' });
        //resource.query(function (data) {
        //    $scope.games = data;
        //});
    }

    function updateUrl(pageIndex) {
        //var urlSearchParameterArray = getUrlSearchParameterArray();

        //if (urlSearchParameterArray.length > 0) {
        $location.path("/games/" + $routeParams.location + "/" + pageIndex, false).search({ 'zoom': $routeParams.zoom, 'sport': $scope.gamesearch.sport }); //=" + 2 + "&" + urlSearchParameterArray.join("&"));
        //} else {
        //    $location.path("/games/1", false).search({ 'zoom' : 6 });;
        //}
    }

    function getUrlSearchParameterArray() {
        var urlSearchParameterArray = [];

        var searchFormParameters = $("#searchgamesextraform").serializeArray();
        var encodedSearchFormParameters = $.param(searchFormParameters);
        var encodedSearchFormParametersArray = encodedSearchFormParameters.split('&');

        $.each(encodedSearchFormParametersArray, function (i, elem) {
            if (elem.split("=")[1] != "" && elem.split("=")[0].toLowerCase() != "location") {
                elem = elem.split("=")[0].toLowerCase() + '=' + elem.split("=")[1];
                urlSearchParameterArray.push(elem);
            }
        });

        return urlSearchParameterArray;
    }

    function initializeScope() {
        $scope.map = map;
        $scope.markers = markers;
    }

    initializeMap();
    initializeGames();
    initializeScope();

    $scope.searchgames = function () {
        $routeParams.location = $scope.gamesearch.location;
        $routeParams.index = 1;
        $routeParams.zoom = $scope.map.getZoom();

        geocoder.geocode({ 'address': $routeParams.location }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                map.fitBounds(results[0].geometry.viewport);
            }
        });        

        $http.post("api/games/", $routeParams).success(function (data) {
            $scope.games = data;
            updateUrl(1);
            //refreshMarkers();
        });
    };
});

appRoot.directive('myMap2', function () {
    var link = function(scope, element) {
        var map;
        var markers = [];
        var enableRecenter = false;
        var zoomValue;

        var mapOptions = {
            zoom: scope.zoom,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            scrollwheel: false
        };

        function initMap() {
            if (map === void 0) {
                map = new google.maps.Map(element[0], mapOptions);
            }
        }

        function setMapBounds() {
            var location = scope.location;
            if (location === undefined || location == "") {
                location = 'usa';
            }

            var geocoder = new google.maps.Geocoder();
            geocoder.geocode({ 'address': location }, function(results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    enableRecenter = false;
                    map.fitBounds(results[0].geometry.viewport);
                }
            });
        }

        function addMarkers() {
            var coordinates = [];
            $('.location').each(function(i) {
                coordinates[i] = [parseFloat($(this).attr('data-lat')), parseFloat($(this).attr('data-lng'))];
            });

            var marker;
            $(coordinates).each(function(i, elem) {
                marker = new google.maps.Marker({
                    position: new google.maps.LatLng(elem[0], elem[1]),
                    map: map,
                    title: 'time to ball!',
                    draggable: true
                });

                google.maps.event.addListener(marker, 'click', (function() {
                    return function() {
                    }
                })(marker, i));

                markers.push(marker);
            });
        }

        function setMapAutocomplete() {
            var input = (document.getElementById('Location'));
            var autocomplete = new google.maps.places.Autocomplete(input);
            autocomplete.bindTo('bounds', map);
        }

        function setMapEvents() {
            google.maps.event.addListener(map, 'bounds_changed', onBoundsChanged);
        }

        function onBoundsChanged() {
            if (enableRecenter === true) {
                var latlng = map.getCenter();
                var geocoder = new google.maps.Geocoder();
                geocoder.geocode({ 'latLng': latlng }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        if (results[1]) {
                            $('#Location').val(results[1].formatted_address);
                            zoomValue = map.getZoom();
                            //searchGamesByAjax(1);
                        }
                    }
                });
            } else {
                enableRecenter = true;
            }
        }

        initMap();
        setMapBounds();
        //addMarkers();
        //setMapAutocomplete();
        //setMapEvents();

    };

    return {
        restrict: 'A',
        template: '<div id="map-canvas"></div>',
        replace: true,
        link: link,
        scope: {
            zoom: "=",
            location: "=",
            map: "=",
        }
    };
});
