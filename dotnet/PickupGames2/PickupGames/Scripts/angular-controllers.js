angular.module('gamesApp', [])
    .controller('HomeController', function ($scope, $http) {
        function initialize() {
            var input = (document.getElementById('Location'));
            new google.maps.places.Autocomplete(input);
        }

        google.maps.event.addDomListener(window, 'load', initialize);

        $scope.searchgames = function($searchgamesform) {
            $http.post("api/Tests/Get/" + $searchgamesform.serialize).success(function(data) {
                var x = 1;
            });
        };
    })

    .controller('GameController', function ($scope, $http) {
        this.Location = 'usa';

        $http.post("api/Tests/Get").success(function (data) {
            $scope.games = data.GameListModel;
        });

        $scope.searchgames = function ($searchgamesform) {
            $http.post("api/Tests/Get/" + $searchgamesform.serialize).success(function (data) {
                $scope.games = data.GameListModel;
                refreshMarkers();
            });
        };
    })

    .directive('myMap', function () {
        var link = function(scope, element) {
            var map;
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
                var location = $('#Location').val();
                if (location == "") {
                    location = 'usa';
                }

                var geocoder = new google.maps.Geocoder();
                geocoder.geocode({ 'address': location }, function (results, status) {
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

            initMap();
            setMapBounds();
            addMarkers();
            setMapAutocomplete();
            setMapEvents();

        };

        return {
            restrict: 'A',
            template: '<div id="map-canvas"></div>',
            replace: true,
            link: link,
            map: map
        };
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