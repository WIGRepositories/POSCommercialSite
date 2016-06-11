var app = angular.module('myApp', ['ngStorage'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {

    $scope.GetDetails = function () {
        $scope.details = $localStorage.book;
        $scope.firstName = $scope.details.No_Seats;
        $scope.NoofSeats = $scope.details.NoofSeats;
        $scope.JourneyType = $scope.details.JourneyType;
       
    }
});