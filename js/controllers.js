define(['angular'] , function (angular) {
  return angular.module('app.Controllers', [])
      .controller('HomeCtrl', ['$scope',
        function($scope) {
            $scope.name = "hi";
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
