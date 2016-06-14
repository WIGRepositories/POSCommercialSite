
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
        $scope.way1 = $scope.result ;
        $localStorage.waytype = $scope.way1;
        window.location.href = "booking.html";
    }
$scope.Signin = function () {

    var u = $scope.UserName;
    var p = $scope.Password

    if (u == null) {
        alert('Please enter username');
        return;
    }

    if (p == null) {
        alert('Please enter password');
        return;
    }

    var inputcred = { LoginInfo: u, Passkey: p }


    var req = {
        method: 'POST',
        url: 'http://localhost:52800/api/ValidateCredentials/ValidateCredentials',
        data: inputcred
    }

    $http(req).then(function (res) {
        if (res.data.length == 0) {
            alert('invalid credentials');
        }
        else {
            //if the user has role, then get the details and save in session
            $localStorage.uname = res.data[0].name;
            $localStorage.userdetails = res.data;
            window.location.href = "BookedTicketHistory.html";
        }
    });
}

});


function fun() {
    if (document.getElementById("ddlBusType").value == 2) {//if Booking Type
        window.location.href = "booking.html";
        
    } else if (document.getElementById("ddlBusType").value == 3) {//if Hiring Type
               
        window.location.href = "vehicleavailability.html";
    }
}


