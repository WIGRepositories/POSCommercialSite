// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $uibModal, $localStorage) {

   
    $scope.save = function (FleetOwnerRequest1, flag) {
        if (FleetOwnerRequest1 == null) {
            alert('Please enter FirstName.');
            return;
        }
        if (FleetOwnerRequest1.FirstName == null) {
            alert('Please enter FirstName.');
            return;
        }
        if (FleetOwnerRequest1.LastName == null) {
            alert('Please enter LastName.');
            return;
        }
        if (FleetOwnerRequest1.CompanyName == null) {
            alert('Please enter CompanyName.');
            return;
        }
        if (FleetOwnerRequest1.PhoneNo == null) {
            alert('Please enter PhoneNo.');
            return;
        }
        var fleetOwnerRequest = {
            //user details            
            FirstName: FleetOwnerRequest1.FirstName,
            LastName: FleetOwnerRequest1.LastName,
            MiddleName: FleetOwnerRequest1.MiddleName,
            EmailAddress: FleetOwnerRequest1.EmailAddress,
            PhoneNo: FleetOwnerRequest1.PhoneNo,
            AltPhoneNo: FleetOwnerRequest1.AltPhoneNo,
            Gender: FleetOwnerRequest1.Gender,
            Address: FleetOwnerRequest1.Address,


            userPhoto: $scope.imageUserSrc,
            //company details
            CompanyName: FleetOwnerRequest1.CompanyName,
            CmpEmailAddress: FleetOwnerRequest1.CmpEmailAddress,
            Title: FleetOwnerRequest1.CmpTitle,
            CmpCaption: FleetOwnerRequest1.CmpCaption,
            FleetSize: FleetOwnerRequest1.FleetSize,
            StaffSize: FleetOwnerRequest1.StaffSize,
            Country: FleetOwnerRequest1.Country,
            state: FleetOwnerRequest1.state,

            Code:  $scope.GetUID(),
            CmpFax: FleetOwnerRequest1.CmpFax,
            CmpPhoneNo: FleetOwnerRequest1.CmpPhoneNo,
            CmpAltPhoneNo: FleetOwnerRequest1.CmpAltPhoneNo,

            CmpAddress: FleetOwnerRequest1.CmpAddress,
            CmpAltAddress: FleetOwnerRequest1.CmpAltAddress,

            ZipCode: FleetOwnerRequest1.ZipCode,
            CmpLogo: $scope.imageSrc,

            //General details        
            CurrentSystemInUse: FleetOwnerRequest1.CurrentSystemInUse,
            SentNewProductsEmails: 1,
            howdidyouhearaboutus: FleetOwnerRequest1.howdidyouhearaboutus,
            Agreetotermsandconditions: 1,

            insupdflag: 'I',


        }
        $http({
            url: 'http://localhost:52800/api/FleetOwnerLicense/CreateNewFOR',
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            data: fleetOwnerRequest
        })   
            .success(function (data, status, headers, config) {
                //if (data[0]['status'] == "0") {
                //    alert(data[0]['details']);
                //    return;
                //}

             //   $localStorage.code = data[0].FleetOwnerCode;
                $scope.showDialog('saved successfully. The fleet owner code is ' + data[0].FleetOwnerCode + '.\n please use the code to buy license.\n The same has been sent to the given e-mailid:' + FleetOwnerRequest1.EmailAddress+'.',0);

                
           // window.location.href = "http://localhost:52800/UI/LicenseConfirmation.html";
        }).error(function (ata, status, headers, config) {
            $scope.showDialog(ata.ExceptionMessage,1);
        });

        $scope.clearFleetOwnerRequest1 = function () {
            $scope.FleetOwnerRequest1 = null;
        };
    }

    $scope.showDialog = function (message,status) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'statusPopup.html',
            controller: 'ModalInstanceCtrl',
            resolve: {
                mssg: function () {
                    return message;
                },
                status: function () {
                    return status;
                }
            }
        });
    }

    $scope.filterValue = function ($event) {
        if (isNaN(String.fromCharCode($event.keyCode))) {
            $event.preventDefault();
        }
    };

    $scope.GetUID = function () {      

        var date = new Date();
        var components = [
            date.getHours(),
            date.getMinutes(),
            date.getSeconds()
        ];

        var id = components.join("");
        return 'CMP' + id;
    }

});
app.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg,status) {

    $scope.mssg = mssg;
    $scope.status = status;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});

      







    
   