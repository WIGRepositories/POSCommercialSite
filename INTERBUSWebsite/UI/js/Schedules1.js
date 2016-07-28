var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {
   
    $scope.GetSchedules = function () {

        $http.get('http://localhost:52800/api/Schedules/GetSchedules').then(function (response, req) {
            $scope.Schedules = response.data;
        });
    }

});