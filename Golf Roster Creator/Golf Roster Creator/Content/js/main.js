'use strict';

function GolferCtrl($scope, $http) {
    $http.get('/Golfer').success(function (data) {
        $scope.golfers = data;
    });

    $http.get('/scripts/courses.json').success(function (data) {
        $scope.courses = data;
    });

    $scope.add = function ($scope) {
        this.group.push({

        });
    };
}