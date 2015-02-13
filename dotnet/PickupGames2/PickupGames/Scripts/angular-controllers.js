var gamesApp = angular.module('gamesApp', [])
    .directive('myMap', function () {

        var link = function (scope, element, attrs) {
        var map, infoWindow;
        var markers = [];
        var enableRecenter = false;

        var mapOptions = {
            zoom: 6,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            scrollwheel: false
        };

        function initMap() {
            if (map === void 0) {
                map = new google.maps.Map(element[0], mapOptions);
            }
        }

        function setMapBounds() {
            var geocoder = new google.maps.Geocoder();
            geocoder.geocode({ 'address': 'usa' }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    enableRecenter = false;
                    map.fitBounds(results[0].geometry.viewport);
                }
            });
        }

        function setMarker(map, position, title, content) {
            var marker;
            var markerOptions = {
                position: position,
                map: map,
                title: title,
                icon: 'https://maps.google.com/mapfiles/ms/icons/green-dot.png'
            };

            marker = new google.maps.Marker(markerOptions);
            markers.push(marker); // add marker to array

            google.maps.event.addListener(marker, 'click', function () {
                // close window if not undefined
                if (infoWindow !== void 0) {
                    infoWindow.close();
                }
                // create new window
                var infoWindowOptions = {
                    content: content
                };
                infoWindow = new google.maps.InfoWindow(infoWindowOptions);
                infoWindow.open(map, marker);
            });
        }

        initMap();
        setMapBounds();

        //setMarker(map, new google.maps.LatLng(51.508515, -0.125487), 'London', 'Just some content');
        //setMarker(map, new google.maps.LatLng(52.370216, 4.895168), 'Amsterdam', 'More content');
        //setMarker(map, new google.maps.LatLng(48.856614, 2.352222), 'Paris', 'Text here');
    };

    return {
        restrict: 'A',
        template: '<div id="map-canvas"></div>',
        replace: true,
        link: link
    };
});

gamesApp.controller('GameController', function ($scope, $http) {
    var gamesMap;
    var markers = [];
    var enableRecenter = false;
    var zoomValue = 8;

    $http.post("api/Tests")
        .success(function (data) {
            $scope.games = data.GameListModel;
        });

    //$scope.map = { center: { latitude: 45, longitude: -73 }, zoom: 8 };

    //$scope.submit = function ($searchgamesform) {
    //};
});

//gamesApp
//    .controller('GameController', function ($scope, gameService) {
//        (function (service) {
//            return function () {
//                var resultPromise = service.getGames();
//                resultPromise.success(function(data) {
//                    $scope.games = data;
//                });
//            };
//        })(gameService);
//    }).factory('gameService', function ($http) {
//        return ({ getGames: getGames });
//        function getGames() {
//            var request = $http.post("Games/GetGames");
//            return request;
//        }
//    });