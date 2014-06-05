define(['angular'] , function (angular) {
  return angular.module('app.Controllers', ['ngAutocomplete'])
      .controller('HomeCtrl', ['$scope', '$window',
        function($scope, $window) {

            $scope.result = '';
//    $scope.details = ''
            $scope.options = {};

            $scope.form = {
                type: 'geocode',
                bounds: {SWLat: 49, SWLng: -97, NELat: 50, NELng: -96},
                country: 'ca',
                typesEnabled: false,
                boundsEnabled: false,
                componentEnabled: false,
                watchEnter: true
            };

            //watch form for changes
            $scope.watchForm = function () {
                return $scope.form
            };
            $scope.$watch($scope.watchForm, function () {
                $scope.checkForm()
            }, true);


            //set options from form selections
            $scope.checkForm = function() {

                $scope.options = {};

                $scope.options.watchEnter = $scope.form.watchEnter

                if ($scope.form.typesEnabled) {
                    $scope.options.types = $scope.form.type
                }
                if ($scope.form.boundsEnabled) {

                    var SW = new google.maps.LatLng($scope.form.bounds.SWLat, $scope.form.bounds.SWLng)
                    var NE = new google.maps.LatLng($scope.form.bounds.NELat, $scope.form.bounds.NELng)
                    var bounds = new google.maps.LatLngBounds(SW, NE);
                    $scope.options.bounds = bounds

                }
                if ($scope.form.componentEnabled) {
                    $scope.options.country = $scope.form.country
                }
            };

            $scope.creategame = function ($game) {
                var location = $game.location;
                var date = $game.date;
            };
        }
      ])

      .controller('scotchController', function($scope) {
        $scope.message = 'test';

        $scope.scotches = [
            {
                name: 'Macallan 12',
                price: 50
            },
            {
                name: 'Chivas Regal Royal Salute',
                price: 10000
            },
            {
                name: 'Glenfiddich 1937',
                price: 20000
            }
        ];
    });
});
