appRoot.controller('GamesController', function ($scope, $http, $q, $location, $resource, $routeParams, googleMapsService, gamesService) {
    $scope.searchgames = function () {
        $routeParams.location = $scope.gamesearch.location;
        $routeParams.index = 1; // pagination will change this
        $routeParams.zoom = undefined;

        googleMapsService.setMapBounds($routeParams.location, $routeParams.zoom).then(function () {
            $routeParams.zoom = googleMapsService.getZoom();
            gamesService.getGames($routeParams).then(function (games) {
                $scope.games = games;
                googleMapsService.refreshMarkers(games);
                updateUrl();
            });
        });
    };

    initialize();

    function initialize() {
        initializeVariables();
        googleMapsService.createMap('map-canvas');
        //googleMapsService.setMapEvents();
        googleMapsService.setMapAutocomplete('search-location');
        googleMapsService.setMapBounds($routeParams.location, $routeParams.zoom).then(function () {
            $routeParams.zoom = googleMapsService.getZoom();
            updateUrl();
            initializeGames();
        });
    }

    function initializeVariables() {
        if ($routeParams.location === 'undefined' || $routeParams.location === undefined || $routeParams.location === "") {
            $routeParams.location = 'usa';
        }

        if ($routeParams.index === 'undefined' || $routeParams.index === undefined || $routeParams.index === "") {
            $routeParams.index = 1;
        }

        $scope.gamesearch = [];
        $scope.gamesearch.location = $routeParams.location;
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

    function initializeGames() {
        $scope.games = [];
        gamesService.getGames($routeParams).then(function (games) {
            $scope.games = games;
            googleMapsService.addMarkers(games);
        });
    }           
});