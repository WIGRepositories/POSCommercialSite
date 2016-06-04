var app = angular.module('myApp', ['ngStorage'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    //$http.get('http://localhost:52800/api/Booking/commericialsite').then(function (response, req) {
    //    $scope.routes = response.data;

    // })

    $scope.GetAvailableServices = function ()
    {
        $scope.srcId = $localStorage.srcId;
        $scope.destId = $localStorage.destId;

        //make a get request to database and show in a tabular form

        $http.get('http://localhost:52800/api/TicketBooking/GetAvailableServices?srcId=' + $scope.srcId + '&destId=' + $scope.destId).then(function (response, req) {
            $scope.services = response.data;
        })

    }

    $scope.savedata = function (Booking) {
        var book = {
            Fname: Booking.fname1,
            Lname: Booking.lname1,
          
        };

        var req = {
            method: 'POST',
            url: 'http://localhost:52800/api/TicketBooking/SaveBookingDetails',
            data: book
        }

        $http(req).then(function (res) {
            alert('saved successfully');
        });
    }

    });