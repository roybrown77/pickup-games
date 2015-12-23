'use strict';
app.controller('gamesController', ['$scope', '$http', '$q', '$location', '$resource', '$routeParams', 'googleMapsService', 'gamesService', function ($scope, $http, $q, $location, $resource, $routeParams, googleMapsService, gamesService) {
    var _map;
    
    function updateUrl(location, index, zoom) {
        try {
            //var urlSearchParameterArray = getUrlSearchParameterArray();

            //if (urlSearchParameterArray.length > 0) {
            $location.path("/games/" + location + "/" + index, false).search({ 'zoom': zoom }); //=" + 2 + "&" + urlSearchParameterArray.join("&"));            
            //} else {
            //    $location.path("/games/1", false).search({ 'zoom' : 6 });;
            //}  
        } catch (e) {
            var temp = e;
        }         
    }

    function initializeGames() {
        try {
            $scope.games = [];
            gamesService.getGames($routeParams).then(function (response) {
                $scope.games = response.gameListModel;
                $scope.placesToPlayGames = response.placesToPlayGamesModel;
                googleMapsService.addMarkers(_map, $scope.games);
                $scope.displayGamesLoading = "display:none";
                $scope.displayGames = "display:block";
            });
        } catch (e) {
            var temp = e;
        }         
    }

    function initializeVariables() {
        try {
            if ($routeParams.location === 'undefined' || $routeParams.location === undefined || $routeParams.location === "") {
                $routeParams.location = 'usa';
            }

            if ($routeParams.index === 'undefined' || $routeParams.index === undefined || $routeParams.index === "") {
                $routeParams.index = 1;
            }

            $scope.gamesearch = {};
            $scope.gamesearch.location = $routeParams.location;
        } catch (e) {
            var temp = e;
        }         
    }

    function initialize() {
        try {
            initializeVariables();
            _map = googleMapsService.createMap('map-canvas');
            google.maps.event.addListener(_map, 'drag', onDragEnd);
            google.maps.event.addListener(_map, 'zoom_changed', onDragEnd);
            googleMapsService.setAutocomplete('search-location');
            $scope.displayGamesLoading = "display:block";
            $scope.displayGames = "display:none";
            googleMapsService.setMapBounds(_map, $routeParams.location, $routeParams.zoom).then(function () {
                initializeGames();
            });            
        } catch (e) {
            var temp = e;
        }         
    }

    function onDragEnd() {
        try {
            var latlng = _map.getCenter();
            var _geocoder = new google.maps.Geocoder();
            _geocoder.geocode({ 'latLng': latlng }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    if (results[1]) {
                        $routeParams.location = results[1].formatted_address;
                        $routeParams.index = 1;
                        $routeParams.zoom = _map.getZoom();

                        googleMapsService.setMapBounds(_map, $routeParams.location, $routeParams.zoom).then(function () {                            
                            updateUrl($routeParams.location, 1, $routeParams.zoom);
                            initializeGames();
                            $scope.gamesearch = {};
                            $scope.gamesearch.location = $routeParams.location;
                        });                    
                    }
                }
            });
        } catch (e) {
            var temp = e;
        }             
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

    $scope.searchgames = function () {
        try {
            $routeParams.location = $scope.gamesearch.location;
            $routeParams.index = 1;
            $routeParams.zoom = undefined;

            googleMapsService.setMapBounds(_map, $routeParams.location, $routeParams.zoom).then(function () {
                $routeParams.zoom = _map.getZoom();
                updateUrl($routeParams.location, 1, $routeParams.zoom);
            });
        } catch (e) {
            var temp = e;
        }         
    };

    $scope.deletegame = function (id) {
        gamesService.deleteGame(id).then(function () {
        });
    };

    initialize();    
}]);