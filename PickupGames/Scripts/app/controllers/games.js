appRoot.controller('GamesController', function ($scope, $http, $location, $resource, $routeParams) {
    var map;
    var geocoder = new google.maps.Geocoder();;
    var markers = [];
    var enableRecenter = false;

    function initializeRouteParams() {
        if ($routeParams.location === 'undefined' || $routeParams.location === undefined || $routeParams.location === "") {
            $routeParams.location = 'usa';
            $routeParams.zoom = 3;
        }

        if ($routeParams.index === 'undefined' || $routeParams.index === undefined || $routeParams.index === "") {
            $routeParams.index = 1;
        }
    }

    function initializeMap() {
        createMap();
        setMapBoundsAndUrl();
        setMapEvents();
        setMapAutocomplete();
    }

    function createMap() {
        var mapOptions = {
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
    }

    function setMapBoundsAndUrl() {
        if ($routeParams.zoom === 'undefined' || $routeParams.zoom === undefined || $routeParams.zoom === "") {
            geocoder.geocode({ 'address': $routeParams.location }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    map.fitBounds(results[0].geometry.viewport);
                    $routeParams.zoom = map.zoom;
                    updateUrl();
                }
            });
        } else {
            geocoder.geocode({ 'address': $routeParams.location }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    enableRecenter = false;
                    map.fitBounds(results[0].geometry.viewport);
                    map.setZoom(parseInt($routeParams.zoom));
                    updateUrl();
                }
            });
        }
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
        //if (enableRecenter === true) {
            var latlng = map.getCenter();
            geocoder.geocode({ 'latLng': latlng }, function (results, status) {
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

    function initializeGames() {
        $scope.games = [];
        $http.post("api/games/", $routeParams).success(function (response) {
            $scope.games = response.games;
            addMarkers(response.games);
        });

        //var resource = $resource('api/games/', $scope.gamesearch, { method: 'POST' });
        //resource.query(function (data) {
        //    $scope.games = data;
        //});
    }

    function updateUrl() {
        //var urlSearchParameterArray = getUrlSearchParameterArray();

        //if (urlSearchParameterArray.length > 0) {
        $location.path("/games/" + $routeParams.location + "/" + $routeParams.index, false).search({ 'zoom': $routeParams.zoom }); //=" + 2 + "&" + urlSearchParameterArray.join("&"));
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

    function refreshMarkers(games) {
        deleteMarkers();
        addMarkers(games);
    }

    function addMarkers(games) {
        var marker;
        for (var elem in games) {
            marker = new google.maps.Marker({
                position: new google.maps.LatLng(games[parseInt(elem)].locationLat, games[parseInt(elem)].locationLng),
                map: map,
                title: 'time to ball!',
                draggable: true
            });

            //google.maps.event.addListener(marker, 'click', (function (marker, i) {
            //    return function () {
            //    }
            //})(marker, i));

            markers.push(marker);
        };
    }

    function deleteMarkers() {
        for (var i = 0; i < markers.length; i++) {
            markers[i].setMap(null);
        }

        markers = [];
    }

    function initializeScope() {
        $scope.gamesearch = [];
        $scope.gamesearch.location = $routeParams.location;
    }

    initializeRouteParams();
    initializeMap();
    initializeGames();
    initializeScope();

    $scope.searchgames = function () {
        $routeParams.location = $scope.gamesearch.location;
        $routeParams.index = 1;

        geocoder.geocode({ 'address': $routeParams.location }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                map.fitBounds(results[0].geometry.viewport);
                $routeParams.zoom = map.zoom;

                $http.post("api/games/", $routeParams).success(function (response) {
                    $scope.games = response.games;
                    updateUrl();
                    refreshMarkers(response.games);
                });

                enableRecenter = false;
            }
        });
    };
});