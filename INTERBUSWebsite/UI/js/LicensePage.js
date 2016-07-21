// JavaScript source code
var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {

    $scope.licenseCatId = $localStorage.licenseId;
    $scope.FleetOwnerCode = $localStorage.code;

    /*the below function gets all the configured licenses for the given category*/
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

    

    $scope.ValidateFOCode = function (code) {

        if (code == null) {
            alert('please enter valid fleet owner code or contact administrator.');
            return false;
        }
        else {            

            $http.get('http://localhost:52800/api/fleetownerlicense/validatefleetowner?fleetownercode=' + code).then(function (response, req) {
                $scope.foLicenseDetails = response.data;

                if ($scope.foLicenseDetails.Table2[0].result == 0) {
                    alert('invalid fleet owner code');
                }
                else {
                    $localStorage.foLicenseDetails = $scope.foLicenseDetails;
                }
            });
        }

        //if ($localStorage.License == '') {
        //    $("#buy").show();
        //}
        //else {
        //    $("#Renew").show();
        //}

    };

    $scope.buy = true;
    $scope.Renew = true;
    $scope.ShowHide = function () {
        //If DIV is hidden it will be visible and vice versa.
        $scope.buy = $scope.buy ? false : true;
        $scope.Renew = $scope.Renew ? false : true;
    }

     
   // $scope.licenseId = '';
    //$scope.ShowHide = function () {
    //    //If DIV is hidden it will be visible and vice versa.
    //    $scope.licenseId = $scope.licenseId ? true : false;
        
        
    //}
        
    $scope.saves = function () {

        var License = {
      
            UserId: $localStorage.UserId,
            FOId: $localStorage.FOId,
            LicenseTypeId: $localStorage.LicenseTypeId,
            StartDate: $localStorage.StartDate,
            ExpiryOn: $localStorage.ExpiryOn,
            GracePeriod: $localStorage.GracePeriod,
            ActualExpiry: $localStorage.ActualExpiry,
            LastUpdatedOn: $localStorage.LastUpdatedOn,
            StatusId: $localStorage.StatusId,
            RenewFreqTypeId:$localStorage.RenewFreqTypeId,
           // ULId:$localStorage.ULId,
          //  CreatedOn:$localStorage.CreatedOn,
          //  Amount: $localStorage.Amount,
          //  UnitPrice: $localStorage.UnitPrice,
           // Units: $localStorage.Units,
           // LicensePymtTransId: $localStorage.LicensePymtTransId,
          //  IsRenewal: $localStorage.IsRenewal,
            insupddelflag: 'I'

        }
       var req = {
           method: 'POST',
           url: 'http://localhost:52800/api/UserLicenses/SaveUserLicenseDetails',
           data: License
       }
       $http(req).then(function (response) {
           alert(response.data);
           window.location.href = "Cartdetails.html";
       });

       //
   };
    $scope.GoTobuy = function (code, License, Lid) {


        $localStorage.License = License;
        $localStorage.LicenseTypeId = Lid;



        //insert the details into UserLicense table
        //get back the id
        //store the id in localstorage
        $localStorage.Isrenewal = 0;

       // $scope.UselicenseRecord = <output>
        window.location.href = "http://localhost:52800/UI/Cartdetails.html";
        
    };

    $scope.GoToConfirmation1 = function (code, License, Lid) {

        $localStorage.Isrenewal = 1;
        $scope.UselicenseRecord = $localStorage.foLicenseDetails.Table1;

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



    //$scope.GoTobuy = function (code, units) {

    //    if (code == null) {
    //        alert('please enter valid fleet owner code or contact INTERBUS administrator.');
    //        return false;
    //    } else {
    //        if (units == null) {
    //            alert('please enter valid no. of units.');
    //            return false;
    //        }
    //        else {
    //            $http.get('http://localhost:52800/api/fleetownerlicense/updatebtpos?fleetownercode=' + code+ '&units='+units).then(function (response, req) {
    //                $scope.result = response.data;

    //                if ($scope.result == 0)
    //                    alert('invalid fleet owner code or BT POS units not available. Please contact INTERBUS admin');
    //                else
    //                    alert('Please login into BT POS dashboard and activate the BT POS ' + units + ' unit(s)');
                    
    //            });
    //        }
    //    }
    //};

   
});