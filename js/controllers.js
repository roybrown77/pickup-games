define(['angular'] , function (angular) {
  return angular.module('app.Controllers', [])
      .controller('HomeCtrl', ['$scope',
        function($scope) {
            $scope.name = "hi";
        }
  ]);
});
