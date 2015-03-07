appRoot.controller('CreateGameController', function ($scope, $http, $q, $location, $resource) {
    var input = (document.getElementById('CreateGameLocation'));
    new google.maps.places.Autocomplete(input);

    $scope.sports = [
        { label: 'Basketball', value: 0 },
        { label: 'Football', value: 1 },
        { label: 'Hockey', value: 2 },
        { label: 'Baseball', value: 3 },
        { label: 'Soccer', value: 4 },
        { label: 'Tennis', value: 5 },
        { label: 'Cricket', value: 6 },
        { label: 'Lacrosse', value: 7 },
        { label: 'Field Hockey', value: 8 },
        { label: 'Rugby', value: 9 },
        { label: 'Ping Pong', value: 10 },
        { label: 'Volleyball', value: 11 },
        { label: 'Kickball', value: 12 },
        { label: 'Chess', value: 13 }
    ];

    $scope.creategame = {};
    $scope.creategame.sportSelected = $scope.sports[0];

    $scope.creategame = function () {
        var game = {}

        game.sport = $scope.creategame.sportSelected.value;
        game.gameDateTime = new Date($scope.creategame.gameDate + " " + $scope.creategame.gameTime + "+0").toISOString();
        game.location = $scope.creategame.location;

        $http.post("api/games", game)
        .success(function (response) {
            $('#create-status').show().text("Game Created!").css("color", "#00bc8c");
        })
        .error(function (response) {
            $('#create-status').show().text("Try again. Error: " + response).css("color", "#ff0000");
        });
    };
});