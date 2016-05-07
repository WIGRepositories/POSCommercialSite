
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {
    $http.get('http://localhost:52800/api/Stops/commericialsite').then(function (response, req) {
        $scope.Stops = response.data;

        
    })

    $scope.routes = [{
        Tn: 'Star Travels',
        Time: '0:00 PM -05:45 AM',
        Seats: '9 Seats',
        Price: '500'

    },
    {
        Tn:'OVR Travels',
        Time:'0:00 PM -05:45 AM',
        Seats:'30 Seats',
        Price: '400'
    
        
    }];
});
    


function fun() {
    if (document.getElementById("ddlBusType").value == 2) {//if Booking Type
        window.location.href = "booking.html";
        
    } else if (document.getElementById("ddlBusType").value == 3) {//if Hiring Type
               
        window.location.href = "vehicleavailability.html";
    }
}
