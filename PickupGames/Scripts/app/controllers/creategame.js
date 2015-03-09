appRoot.controller('CreateGameController', function ($scope, $http, $q, $location, $resource, googleMapsService, ngDialog) {
    googleMapsService.setMapAutocomplete('CreateGameLocation');

    var _lastgame = {};
    var _formDirty = false;

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

    ///$scope.creategame.date = '03-08-2015'; //new Date().toISOString().split("T")[0];

    //ngDialog.open({
    //    template: '<div><div class="row"><div class="col-xs-12"><label>Game Created!</label></div></div></div>',
    //    plain: true
    //});

    $scope.creategameglyph = "glyphicon-plus";

    $scope.original = angular.copy($scope.creategame);

    $scope.initialComparison = angular.equals($scope.creategame, $scope.original);
    $scope.dataHasChanged = angular.copy($scope.initialComparison);

    $scope.$watch('creategame', function (newValue, oldValue) {
        if (newValue != oldValue) {
            $scope.dataHasChanged = angular.equals($scope.creategame, $scope.original);
            _formDirty = true;
            $scope.creategameglyph = "glyphicon-plus";
            $('#createbutton').css('background-color', '#375a7f');
            $('#createbutton').css('border-color', '#375a7f');
        }
    }, true);

    //$scope.$watchCollection('creategameform', function (newNames, oldNames) {
    //    var game = {}
    //    //game.sport = $scope.creategame.sportSelected.value;
    //    //game.dateTime = new Date($scope.creategame.date + " " + $scope.creategame.time + "+0").toISOString();
    //    //game.location = $scope.creategame.location;

    //    if (JSON.stringify(_lastgame) !== JSON.stringify(game)) {
    //        _formDirty = true;
    //        $scope.creategameglyph = "glyphicon-plus";
    //        $('#createbutton').css('background-color', '#375a7f');
    //        $('#createbutton').css('border-color', '#375a7f');
    //    }
    //});
    
    $scope.creategame = function () {
        var game = {}

        game.sport = $scope.creategame.sportSelected.value;
        game.dateTime = new Date($scope.creategame.date + " " + $scope.creategame.time + "+0").toISOString();
        game.location = $scope.creategame.location;

        //if (!_formDirty) {
        if (JSON.stringify(_lastgame) === JSON.stringify(game)) {
            $scope.creategameglyph = "glyphicon-plus";
            $('#createbutton').css('background-color', '#375a7f');
            $('#createbutton').css('border-color', '#375a7f');
            return;
        }

        $scope.createbuttontext = "Creating Game...";
        $scope.creategameglyph = "glyphicon-refresh spin";

        $http.post("api/games", game)
        .success(function () {
            _lastgame = game;
            //_formDirty = false;
            $scope.creategameglyph = "glyphicon-ok";
            $('#createbutton').css('background-color', '#00bc8c');
            $('#createbutton').css('border-color', '#00bc8c');
            })
        .error(function (response) {
            $scope.creategameglyph = "glyphicon-remove";
            $('#createbutton').css('background-color', '#ff0000');
            $('#createbutton').css('border-color', '#ff0000');
        });
    };
});