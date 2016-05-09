var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {
    $http.get('http://localhost:52800/api/VehicleAvailability/commericialsite').then(function (response, req) {
        $scope.Hiring = response.data;

    })
});