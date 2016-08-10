
var app = angular.module('myApp', ['ngStorage'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {

    $scope.GetStops = function () {

        $http.get('http://localhost:52800/api/Stops/GetStops').then(function (response, req) {
            $scope.Stops = response.data;
        })
       
        $http.get('http://localhost:52800/api/Stops/TypesByGroupId?groupid=3').then(function (res, data) {
            $scope.licenses = res.data;

        });
    }

    $scope.GetServices = function () {
        if ($scope.S == null)
        {
            alert('Please select source.');
            return;
        }

        if ($scope.D == null)
        {
            alert('Please select destination.');
            return;
    }

        $localStorage.src = $scope.S;
        $localStorage.dest = $scope.D;
        //$rootscope.src = $scope.RS;
        //$rootscope.dest = $scope.RD;
        $scope.way1 = $scope.result ;
        $localStorage.waytype = $scope.way1;
        window.location.href = "UI/booking.html";
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

    $scope.GotToLicensePage = function (t) {
        $localStorage.licenseId = t;
        window.location.href = "LicensePage.html";
    }
});


function fun() {
    if (document.getElementById("ddlBusType").value == 2) {//if Booking Type
        window.location.href = "booking.html";
        
    } else if (document.getElementById("ddlBusType").value == 3) {//if Hiring Type
               
        window.location.href = "vehicleavailability.html";
    }
}


