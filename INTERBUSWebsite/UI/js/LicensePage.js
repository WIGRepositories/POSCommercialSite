﻿// JavaScript source code
var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {

    $scope.licenseCatId = $localStorage.licenseId;
    $scope.FleetOwnerCode = $localStorage.code;

    $scope.GetLicense = function () {

        if($scope.licenseCatId == null || $scope.licenseCatId.Id == null)
        {
            alert('No license details configured for the selected license category. Please contact INTERBUS administartor.');
            return;
        }
        $http.get('http://localhost:52800/api/LicensePage/GetLicense?LicenseCatId=' + $scope.licenseCatId.Id).then(function (response, req) {
            $scope.License = response.data;
            if ($scope.License == null) {
                alert('No license details configured for the selected license category. Please contact INTERBUS administartor.');
                return;
            }
            
        });
      
    }

    $scope.getUserLicenses = function () {

        $http.get('http://localhost:52800/api/UserLicenses/getUserLicenses').then(function (response, req) {
            $scope.License = response.data;
            if ($scope.License == null) {
                alert('No license details configured for the selected license category. Please contact INTERBUS administartor.');
                return;
            }
        })

    }

    $scope.GoToConfirmation = function (code, License, Lid) {

        if (code == null) {
            alert('please enter valid fleet owner code or contact administrator.');
            return false;
        }
        else {           
            $localStorage.License = License;
            $localStorage.LicenseTypeId = Lid;
            $localStorage.FleetOwnerCode = code;          

            $http.get('http://localhost:52800/api/fleetownerlicense/validatefleetowner?fleetownercode=' + code).then(function (response, req) {
                $scope.result = response.data;

                if ($scope.result < 0) {
                    alert('invalid fleet owner code');
                }
                else {
                    $localStorage.License = License;
                    $localStorage.LicenseTypeId = Lid;                   
                    window.location.href = "http://localhost:52800/UI/Cartdetails.html";
                }
            });
        }
    };

    $scope.GoToConfirmation1 = function (code, License, Lid) {

        if (code == null) {
            alert('please enter valid fleet owner code or contact administrator.');
            return false;
        }
        else {           
            $localStorage.License = License;
            $localStorage.LicenseTypeId = Lid;
            $localStorage.FleetOwnerCode = code;    

            $http.get('http://localhost:52800/api/fleetownerlicense/validatefleetowner?fleetownercode=' + code).then(function (response, req) {
                $scope.result1 = response.data;

                if ($scope.result1 < 0) {
                    alert('invalid fleet owner code');
                }
                else {
                    $localStorage.License = License;
                    $localStorage.LicenseTypeId = Lid;
                    window.location.href = "http://localhost:52800/UI/Cartdetails.html";
                }
            });
        }
    };

   $scope.save = function (LicenseTypeId, code) {

       var License = {
           LicenseTypeId: LicenseTypeId,
           fleetownercode:code 
       };
       $localstorage.value = License;
       var req = {
           method: 'POST',
           url: 'http://localhost:52800/api/LicensePage/SaveLicence',
           data: License
       }
       $http(req).then(function (response) {
           alert(response.data);
           window.location.href = "Cartdetails.html";
       });

       //
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