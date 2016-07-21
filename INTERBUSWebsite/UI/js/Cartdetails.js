var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {


    

    
    $scope.FillDetails = function () {
        
            $scope.licenseCatId = $localStorage.LicenseTypeId;
            $scope.focode = $localStorage.FleetOwnerCode;

            //displaying the current fleet owner code
            var fodetails = $localStorage.FleetOwnerCode;
            $scope.selFleetOwnerCode = "";
         
            var ldetails = $localStorage.License;
            $scope.selLicense = "";
            $scope.selLicensePrice = "";
             

            //identify the selected license and display the properties
            for (ltCnt = 0; ltCnt < ldetails.Table.length; ltCnt++) {
                if (ldetails.Table[ltCnt].Id == $scope.licenseCatId) {
                    $scope.selLicense = ldetails.Table[ltCnt];
                    break;
                }
            }

            for (ltCnt = 0 ; ltCnt < ldetails.Table2.length; ltCnt++) {
                if (ldetails.Table2[ltCnt].LicenseId == $scope.selLicense.Id) {
                    $scope.selLicensePrice = ldetails.Table2[ltCnt]
                }
            }


        //if (FleetOwnerCode != null) {
        //    $scope.selFleetOwnerCode = fodetails.FleetOwnerCode;
        //    document.getElementById("Id").innerHTML = localStorage.getItem("FleetOwnerCode");
        //}

    }
    var checkoutsv = [];
    var focheckout = new Object();
    $scope.CheckOut = function () {

        $localStorage.Isrenewal = 1;

        //get other details
        //insert the details int UserLicensePayments
        //if saved successfully
        //in return get the fo details

        $localStorage.focheckoutDetails = <output>;

        //now go to checkout page


        window.location.href = "http://localhost:52800/UI/CheckOut.html";

        var userlicense = {

                   UserId: ch.UserId,
                   FOId:ch.FOId,
                   FOCode:ch.FOCode,
                   LicenseTypeId:ch.LicenseTypeId,
                   StartDate:ch.StartDate,
                   ExpiryOn:ch.ExpiryOn,
                   GracePeriod:ch.GracePeriod,
                   ActualExpiry:ch.ActualExpiry,
                   LastUpdatedOn:ch.LastUpdatedOn,
                   Active:ch.Active,
                   RenewFreqTypeId:ch.RenewFreqTypeId,
                  StatusId: ch.StatusId,
                   
                  ULId:ch.ULId,
                   CreatedOn:ch.CreatedOn,
                   Amount:ch.Amount,
                   UnitPrice:ch.UnitPrice,
                   StatusId:ch.StatusId,
                   LicensePymtTransId:ch.LicensePymtTransId,
                   IsRenewal:ch.IsRenewal,

                   insupddelflag: 'I'

            }
                checkoutsv.push(CheckOut);
        
                focheckout.checkSchedule = checkoutsv;
       $http({
           url: 'http://localhost:52800/api/UserLicenses/SaveUserLicenseDetails',
          method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            data: focheckout,

        }).success(function (data, status, headers, config) {
            alert('Fleet owner Vehicle Schedule Saved successfully');
            $scope.GetFORoutes();
        }).error(function (ata, status, headers, config) {
            alert(ata);
        });

        window.location.href = "http://localhost:52800/UI/CheckOut.html";
    }
       
        //window.location.href = "http://localhost:52800/UI/LicenseConfirmation.html";

});


            //save the details into db for user license
            //if ($scope.qty <= 0)
            //{
            //    alert("please select the month(s)");
            //}
            //else {

            //    alert('Payment gateway integration will done here and on successful payment fleet owner will be sent a confirmation email with dashboard login details.')
            //    window.location.href = "http://localhost:52800/UI/LicenseConfirmation.html";

            //    $scope.Licensepayments = function () {

            //        var pmnt = {
            //            LicenseTypeId: LicenseTypeId,
            //            fleetownercode:code 
            //        };
            //        $localstorage.value = pmnt;
            //        var req = {
            //            method: 'POST',
            //            url: 'http://localhost:52800/api/LicensePage/SaveLicence',
            //            data: pmnt
            //        }
            //        $http(req).then(function (response) {
            //            alert(response.data);
            //            window.location.href = "http://localhost:52800/UI/LicenseConfirmation.html";
            //        })
            ////create a user login for the fleet owner
            ////communicate the same to user


            //            }
            //create a user login for the fleet owner
            //communicate the same to user

           // window.location.href = "http://localhost:52800/UI/LicenseConfirmation.html";
