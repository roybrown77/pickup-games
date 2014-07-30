'use strict';

/* Controllers */

angular.module('myApp.controllers', [])
	.controller('MyCtrl1', ['$scope','$http', function($scope,$http) {
		var resultPromise = $http.get("/Home/GetGames");
	    	resultPromise.success(function (data) {
	        	$scope.games = data.Games;
    		});

    	$scope.createGame = (function (formData) {
    	    var resultPromise = $http.post("/Home/CreateGame", formData);
			resultPromise.success(function (data) {
				$scope.games = data.Games;
    		});
		});
    }])

    .controller('MyCtrl2', ['$scope', function ($scope) {

    }]);
