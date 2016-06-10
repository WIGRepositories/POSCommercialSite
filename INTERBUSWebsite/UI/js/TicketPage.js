var app = angular.module('myApp', ['ngStorage'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {

    $scope.GetDetails = function () {
        $scope.details = $localStorage.book;
        $scope.firstName = $scope.details.No_Seats;
        $scope.NoofSeats = $scope.details.NoofSeats;
        $scope.JourneyType = $scope.details.JourneyType;
        //var i = to; var k = from;

        //if ($scope.details.JourneyType == 1) {
        //    $scope.JourneyType = i;
        //} else
        //{
        //    $scope.JourneyType = k;
        //}
        for (var v in $scope.details) {
            $scope.Names = $scope.details.fname;
        }
    }
});