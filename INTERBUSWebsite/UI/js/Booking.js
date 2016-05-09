var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {
    $http.get('http://localhost:52800/api/Booking/commericialsite').then(function (response, req) {
        $scope.routes = response.data;

    })
    });