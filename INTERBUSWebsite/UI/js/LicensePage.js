// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http,$localstorage) {

    $scope.GetLicense = function () {

        $http.get('http://localhost:52800/api/LicensePage/GetLicense?catId=8').then(function (response, req) {
            $scope.License = response.data;
        })
      
    }

   $scope.GoToConfirmation = function (txt) {
      
        if (code == null) {
            alert('please enter valid fleet owner code or contact administrator.');
            return false;
        }
        else {
   $http.get('http://localhost:52800/api/fleetownerlicense/validatefleetowner?fleetownercode=' + code).then(function (response, req) {
       $scope.result = response.data;
       save();

                if ($scope.result > 0)
                    window.location.href = "http://localhost:52800/UI/LicenseConfirmation.html";
                else
                    alert('invalid fleet owner code');

            });
        }
       
       
   };
   $scope.save = function (License, flag) {

       var License = {
           LicenseType: License.LicenseType,
           Id: License.Id,
           Unitprice: License.Unitprice,
           FeatureName: License.FeatureName,
           FeatureValue: License.FeatureValue,


       };
       $localstorage.value = License;
       window.location.href = "Cartdetails.html";
       

       var req = {
           method: 'POST',
           url: 'http://localhost:52800/api/LicensePage/SaveLicence',
           data: License
       }
       $http(req).then(function (response) {

       });
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
                $http.get('http://localhost:52800/api/fleetownerlicense/updatebtpos?fleetownercode=' + code+ '&units='+units).then(function (response, req) {
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