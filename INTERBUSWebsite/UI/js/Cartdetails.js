var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {

    
        $scope.FillDetails = function () {
            $scope.licenseCatId = $localStorage.LicenseTypeId;
            $scope.fodetails = $localStorage.FleetOwnerCode;

            var ldetails = $localStorage.License;
            $scope.selLicense = "";
            $scope.selLicensePrice = "";
   
          
            //displaying the current fleet owner code
            var fodetails = $localStorage.FleetOwnerCode;
            $scope.selFleetOwnerCode = "";
         
            if (FleetOwnerCode != null)
            {
                $scope.selFleetOwnerCode = fodetails.FleetOwnerCode;
                }
             

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

        }

        
        $scope.processPymt = function () {

        
            var processPymt1 =
             [
                 
                 {
                     LicenseType: 'BTPOS1',
                     Frequency: '2333',
                     UnitPrice: '12.2',
                     FleetOwner: '002',
                     NoOfMonths: '4Months',
                     TotalAmount: '2345',
                     CreateDate: '01/01/2016',
                     TransId: 'we34'
                }
             ];
           
            var req = {
                method: 'POST',
                url: 'http://localhost:52800/api/CartPaymentDetails/SaveType',
                //headers: {
                //    'Content-Type': undefined
                data: processPymt1[0]
            }

            $http(req).then(function (res) {
                if (res.data.length == 0) {
                    alert('invalid credentials');
                }
                else {
                    //if the user has role, then get the details and save in session
                    $localStorage.uname = res.data[0].name;
                    $localStorage.userdetails = res.data;
                    window.location.href = "LicenseConfirmation.html";
                }
            });

        }
        //window.location.href = "http://localhost:52800/UI/LicenseConfirmation.html";

});


//save the details into db for user license
            // if(No. of Months < 0)
            //  {
            //      alert("Invalid data");
            //   }
            //   else{
            //        $scope.Licensepayments = function () {

            //            var pmnt = {
            //                LicenseTypeId: LicenseTypeId,
            //                fleetownercode:code 
            //            };
            //           
            //            }
            //            $http(req).then(function (response) {
            //                alert(response.data);

            //            }
            //create a user login for the fleet owner
            //communicate the same to user

           // window.location.href = "http://localhost:52800/UI/LicenseConfirmation.html";
