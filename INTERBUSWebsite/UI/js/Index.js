
var app = angular.module('myApp', [])
var ctrl = app.controller('MyCtrl', function ($scope, $http) {
    $scope.GetStops = function () {
        $http.get('http://localhost:52800/api/Stops/StopsData').then(function (response, req) {
            $scope.SrcStops = response.data;

            $scope.DestStops = response.data;
        });
    }
    $scope.GoToConfirmation = function (code) {

        if (code == null) {
            alert('please enter valid fleet owner code or contact administrator.');
            return false;
        }
        else {
            $http.get('http://localhost:52800/api/fleetownerlicense/validatefleetowner?fleetownercode=' + code).then(function (response, req) {
                $scope.result = response.data;

                if ($scope.result > 0)
                    window.location.href = "http://localhost:52800/CommercialSite/LicenseConfirmation.html";
                else
                    alert('invalid fleet owner code');

            });
        }
    };

    $scope.GoTobuy = function (code, units) {

        if (code == null) {
            alert('please enter valid fleet owner code or contact INTERBUS administrator.');
            return false;
        } else {
            if (units == null) {
                alert('please enter valid no. of units.');
                return false;
            }
            else {
                $http.get('http://localhost:52800/api/fleetownerlicense/updatebtpos?fleetownercode=' + code + '&units=' + units).then(function (response, req) {
                    $scope.result = response.data;

                    if ($scope.result == 0)
                        alert('invalid fleet owner code or BT POS units not available. Please contact INTERBUS admin');
                    else
                        alert('Please login into BT POS dashboard and activate the BT POS ' + units + ' unit(s)');

                });
            }
        }
    };
});
    


function fun() {
    if (document.getElementById("ddlBusType").value == 2) {//if Booking Type
        window.location.href = "booking.html";
        
    } else if (document.getElementById("ddlBusType").value == 3) {//if Hiring Type
               
        window.location.href = "vehicleavailability.html";
    }
}
