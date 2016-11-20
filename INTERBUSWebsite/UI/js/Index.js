
var app = angular.module('myApp', ['ngStorage'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {

    $scope.carouselImages = [{ "ID": 1, "Name": "TRAVEL WITH INTERBUS", "Caption": "Every Journey Matters....", "Path": "UI/Images/promos/11.jpg" }
        , { "ID": 2, "Name": "Customer satisfaction", "Caption": "The comfort and convienience of travelling with INTERBUS", "Path": "/UI/Images/promos/12.png" }
        , { "ID": 3, "Name": "Online Ticket Booking", "Caption": "Automated ticketing increases performance and convienience", "Path": "/UI/Images/promos/13.jpg" }
        , { "ID": 4, "Name": "Hassel free travel", "Caption": "Get online tickets to make the journey hassel free", "Path": "/UI/Images/promos/14.png" }
        , { "ID": 5, "Name": "Extensive coverage", "Caption": "Wide network taking you to various destinations", "Path": "/UI/Images/promos/2.png" }
    ];
    $scope.triptype = "oneway";

    $scope.timing = "Now";

    $scope.ChangeTravelType = function (travelTime) {
        $scope.timing = (travelTime == 0) ? "Now" : "Later";
    }

    $scope.RadioChange = function (s) {
        $scope.triptype = s;
    };

    $scope.GetStops = function () {

        $http.get('/api/Stops/GetStops').then(function (response, req) {
            $scope.Stops = response.data;
            $localStorage.Stops = $scope.Stops;
        }, function (data) {
            alert(data);
        });
       
        $http.get('/api/Stops/TypesByGroupId?groupid=3').then(function (res, data) {
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
        $localStorage.timing = ($scope.timing == 'Now')? Date() : $scope.timing;
        $localStorage.triptype = $scope.triptype;
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
        url: '/api/ValidateCredentials/ValidateCredentials',
        data: inputcred
    }

    $http(req).then(function (res) {
        if (res.data.length == 0) {
            alert('invalid credentials');
        }
        else {
            //if the user has role, then get the details and save in session
            $localStorage.uname = res.data[0].name;
            $scope.username = $localStorage.uname;
            $localStorage.userdetails = res.data;
          //  window.location.href = "UI/BookedTicketHistory.html";
        }
    });
}

    $scope.SignOutUser = function () {
        $localStorage.uname = null;
        $scope.username = null;
        $localStorage.userdetails = null;
    }

    $scope.GotToLicensePage = function (t) {
        $localStorage.licenseId = t;
        window.location.href = "UI/LicensePage.html";
    }
});


function fun() {
    if (document.getElementById("ddlBusType").value == 2) {//if Booking Type
        window.location.href = "booking.html";
        
    } else if (document.getElementById("ddlBusType").value == 3) {//if Hiring Type
               
        window.location.href = "vehicleavailability.html";
    }
}


