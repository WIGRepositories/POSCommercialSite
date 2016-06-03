
var app = angular.module('myApp', ['ngStorage'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {

    $scope.GetStops = function () {

        $http.get('http://localhost:52800/api/Stops/GetStops').then(function (response, req) {
            $scope.Stops = response.data;
        })
    }

    $scope.GetServices = function () {
        $localStorage.srcId = $scope.S.Id;
        $localStorage.destId = $scope.D.Id; 

        window.location.href = "booking.html";
    }
   
});
    


function fun() {
    if (document.getElementById("ddlBusType").value == 2) {//if Booking Type
        window.location.href = "booking.html";
        
    } else if (document.getElementById("ddlBusType").value == 3) {//if Hiring Type
               
        window.location.href = "vehicleavailability.html";
    }
}


