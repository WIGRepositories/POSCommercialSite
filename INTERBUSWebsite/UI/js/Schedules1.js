var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {
   
    $scope.GetSchedules = function () {

        $http.get('/api/Schedules/GetSchedules').then(function (response, req) {
            $scope.Schedules = response.data;
        });
    }

});