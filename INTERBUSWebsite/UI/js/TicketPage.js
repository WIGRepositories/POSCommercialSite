var app = angular.module('myApp', ['ngStorage'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {

   

    $scope.GetDetails = function () {
        $scope.source = $localStorage.srcId;
        $scope.destination = $localStorage.destId;
        $scope.details = $localStorage.book;
        $scope.firstName = $scope.details.No_Seats;
        $scope.NoofSeats = $scope.details.NoofSeats;
        $scope.JourneyType = $scope.details.JourneyType;


        //$http.get('http://localhost:52800/api/TicketBooking/GetCities?srcId=' + $scope.source + '&destId=' + $scope.destination).then(function (response, req) {
        //    $scope.services = response.data;
        //    $scope.From = $scope.services.source;
        //    $scope.To = $scope.services.destination;
        //})
    }

   
});