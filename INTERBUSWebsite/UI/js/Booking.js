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
            "No_Seats": "5",
            "cost": "1500",
            "passengersList": [
                 { "SeatId": 1,
                     "Fname": Lokesh,
                     "Lname": Godem,
                     "Age": 30,
                     "Sex": 0,
                     "Identityproof": adhar
                 },
                 {
                     "SeatId": 2,
                     "Fname": Sanjay,
                     "Lname": Gandham,
                     "Age": 33,
                     "Sex": 0,
                     "Identityproof": pan
                 }
            ]
            };

        /*
        {
  "Pnr_ID": 0,
  "Pnr_No": null,
  "No_Seats": 0,
  "cost": 0,
  "dateandtime": "0001-01-01T00:00:00",
  "src": null,
  "dest": null,
  "vehicle_No": null,
  "PassengerId": 0,
  "Fname": "srujan",
  "Lname": null,
  "Age": 0,
  "Sex": 0,
  "Identityproof": null,
  "TransactionId": 0,
  "Transaction_Number": null,
  "Amount": 0,
  "Paymentmode": 0,
  "Gateway_transId": null,
  "PSID": 0,
  "SeatNo": null,
  "passengersList": [
    {
      "SeatId": null,
      "Fname": null,
      "Lname": null,
      "Age": 30,
      "Sex": 0,
      "Identityproof": null
    },
    {
      "SeatId": null,
      "Fname": null,
      "Lname": null,
      "Age": 33,
      "Sex": 0,
      "Identityproof": null
    }
  ]
}
        */

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