// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {

    $scope.licenseCatId = $localStorage.licenseId;
    $scope.FleetOwnerCode = $localStorage.code;
   
    /*the below function gets all the configured licenses for the given category*/
    $scope.GetLicense = function () {

        if($scope.licenseCatId == null || $scope.licenseCatId.Id == null)
        {
            $scope.showVDialog('No license details configured for the selected license category. Please contact INTERBUS administartor.');
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

    $scope.showBuyBtn = 0;
    $scope.showRenewBtn = 0;

    $scope.ValidateLicenseCode = function (lcode) {

    }

    $scope.ValidateFOCode = function (code, License, Lid) {

        if (code == null) {
           
            $scope.showVDialog('please enter valid fleet owner code or contact administrator.');
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
                    $scope.saveUserLicense(License, Lid);
                    //$scope.showBuyBtn = ($scope.foLicenseDetails.Table == null) ? 1 : 0;
                    //$scope.showRenewBtn = ($scope.foLicenseDetails.Table == null) ? 0 : 1;
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

     
    $scope.licenseId = '';
    $scope.ShowHide = function () {
        //If DIV is hidden it will be visible and vice versa.
        $scope.licenseId = $scope.licenseId ? true : false;
        
        
    }
   
    $scope.SetLicensedetails = function (License, Lid) {


        $localStorage.License = License;
        $localStorage.LicenseTypeId = Lid;



        //insert the details into UserLicense table
        //get back the id
        //store the id in localstorage
        $localStorage.Isrenewal = 0;

      
        
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

   $scope.saveUserLicense = function (License, Lid) {

       var userlicense = {

           UserId: $localStorage.foLicenseDetails.Table[0].userid,
           FOId: $localStorage.foLicenseDetails.Table[0].foid,
           FOCode: $localStorage.foLicenseDetails.Table[0].FleetOwnerCode,
           LicenseTypeId: $localStorage.LicenseTypeId,
           StartDate: $localStorage.StartDate,
           ExpiryOn: $localStorage.ExpiryOn,
           GracePeriod: 7,//$localStorage.GracePeriod,
           ActualExpiry: $localStorage.ActualExpiry,
           LastUpdatedOn: $localStorage.LastUpdatedOn,
           StatusId: 1,//$localStorage.StatusId,
           RenewFreqTypeId: 1,//$localStorage.foLicenseDetails.Table[1].RenewFreqTypeId,
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
           data: userlicense
       }
       $http(req).then(function (response) {          
           $localStorage.UselicenseRecord = response.data;
           window.location.href = "Cartdetails.html";
       });

       //
   };
      

   $scope.showVDialog = function (message) {

       var modalInstance = $uibModal.open({
           animation: $scope.animationsEnabled,
           templateUrl: 'statusPopup.html',
           controller: 'ModalInstanceCtrl',
           resolve: {
               mssg: function () {
                   return message;
               }
           }
       });
   }
   
});

app.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});