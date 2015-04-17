app.controller('createGameController', function ($scope, $http, $q, $location, $resource, googleMapsService, gamesService, sportsService, $filter) {
    googleMapsService.setMapAutocomplete('CreateGameLocation');

    var _lastgame = {};
    var _formDirty = false;

    $scope.creategame = {};
    
    $scope.toggleMin = function () {
        $scope.minDate = $scope.minDate ? null : new Date();
    };

    $scope.open = function ($event) {
        $event.preventDefault();
        $event.stopPropagation();

        $scope.opened = true;
    };

    $scope.dateOptions = {
        formatYear: 'yy',
        startingDay: 1
    };

    $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
    $scope.format = $scope.formats[0];




    $scope.hstep = 1;
    $scope.mstep = 15;

    $scope.options = {
        hstep: [1, 2, 3],
        mstep: [0, 15, 30, 45]
    };

    $scope.ismeridian = true;

    $scope.toggleMode = function () {
        $scope.ismeridian = !$scope.ismeridian;
    };

    $scope.changed = function () {
        //$log.log('Time changed to: ' + $scope.creategame.time);
    };

    function getDateSetting() {
        var dateSetting = new Date();
        var currentMinuteValue = dateSetting.getMinutes();

        var minuteValue = 0;

        if (currentMinuteValue >= 0 && currentMinuteValue < 15) {
            minuteValue = 15;
        }

        if (currentMinuteValue >= 15 && currentMinuteValue < 30) {
            minuteValue = 30;
        }

        if (currentMinuteValue >= 30 && currentMinuteValue < 45) {
            minuteValue = 45;
        }

        if (currentMinuteValue >= 45 && currentMinuteValue < 59) {
            dateSetting.setHours(dateSetting.getHours() + 1);
        }

        dateSetting.setMinutes(minuteValue);

        return dateSetting;
    }

    function getDateTime() {
        var d = $scope.creategame.date;
        var t = $scope.creategame.time;
        var createdatetime = d.getFullYear() + "-" + (d.getMonth() + 1) + "-" + d.getDate() + "T" + t.getHours() + ":" + t.getMinutes() + ":00Z";
        return createdatetime;
    }

    initialize();

    function initialize() {
        sportsService.getSports().then(function (sports) {
            $scope.sports = sports;
            $scope.creategame.sportSelected = sports[0];

            var dateSetting = getDateSetting();

            $scope.creategame.time = dateSetting;
            $scope.creategame.date = dateSetting;
            $scope.toggleMin();
        });

        $scope.creategameglyph = "glyphicon-plus";

        //$scope.sports = [
        //   { label: 'Basketball', value: 0 },
        //   { label: 'Football', value: 1 },
        //   { label: 'Hockey', value: 2 },
        //   { label: 'Baseball', value: 3 },
        //   { label: 'Soccer', value: 4 },
        //   { label: 'Tennis', value: 5 },
        //   { label: 'Cricket', value: 6 },
        //   { label: 'Lacrosse', value: 7 },
        //   { label: 'Field Hockey', value: 8 },
        //   { label: 'Rugby', value: 9 },
        //   { label: 'Ping Pong', value: 10 },
        //   { label: 'Volleyball', value: 11 },
        //   { label: 'Kickball', value: 12 },
        //   { label: 'Chess', value: 13 }
        //];
    }

    ///$scope.creategame.date = '03-08-2015'; //new Date().toISOString().split("T")[0];

    //ngDialog.open({
    //    template: '<div><div class="row"><div class="col-xs-12"><label>Game Created!</label></div></div></div>',
    //    plain: true
    //});

    //$scope.original = angular.copy($scope.creategame);

    //$scope.initialComparison = angular.equals($scope.creategame, $scope.original);
    //$scope.dataHasChanged = angular.copy($scope.initialComparison);

    //$scope.$watch('creategame', function (newValue, oldValue) {
    //    if (newValue != oldValue) {
    //        $scope.dataHasChanged = angular.equals($scope.creategame, $scope.original);
    //        _formDirty = true;
    //        $scope.creategameglyph = "glyphicon-plus";
    //        $('#createbutton').css('background-color', '#375a7f');
    //        $('#createbutton').css('border-color', '#375a7f');
    //    }
    //}, true);

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

        game.SportId = $scope.creategame.sportSelected.id;
        game.DateTime = getDateTime();
        game.Location = $scope.creategame.location;

        //if (!_formDirty) {
        if (JSON.stringify(_lastgame) === JSON.stringify(game)) {
            $scope.creategameglyph = "glyphicon-plus";
            $('#createbutton').css('background-color', '#375a7f');
            $('#createbutton').css('border-color', '#375a7f');
            return;
        }

        $scope.createbuttontext = "Creating Game...";
        $scope.creategameglyph = "glyphicon-refresh spin";

        //gameService.save({ gameCreateModel: game })
        //.$promise.then(function (response) {
        //});

        $http.post('/api/v1/games', game)
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