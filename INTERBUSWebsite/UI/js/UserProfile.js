var app = angular.module('myApp', ['ngStorage'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {

    if ($localStorage.uname) {
        $scope.username = $localStorage.uname;

        $scope.userdetails = $localStorage.userdetails[0];
    }

});