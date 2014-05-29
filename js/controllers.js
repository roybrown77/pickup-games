define(['angular'] , function (angular) {
  return angular.module('app.Controllers', [])
      .controller('HomeCtrl', ['$scope', 'Parse',
        function($scope, Parse) {
            $scope.name = "hi";
            Parse.initialize("or64vkbsU1pD7nzPQ5CZATtD4YB8aAeF9IMDzuFr", "cniYXQH5P0MB76wHfCZ2puiV1w4HMoen2DFixx4k");
            var Game = Parse.Object.extend("Game");
            var game = new Game();
            game.save({objectId: 1}).then(function(object) {
                alert("yay! it worked");
            });
        }
  ]);
});
