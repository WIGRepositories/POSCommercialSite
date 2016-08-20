// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $uibModal, $localStorage) {

    //app.controller('showHide', function ($scope) {
    //  $scope.toggle = function () {
    //    if (!$scope.myForm.email - input.$valid) {
    //     alert(valid);
    //}
    //};

    //$scope.save = function (Fleet, flag) {

        


    //    var Fleet = {
    //        //Id: Fleet.Id,
    //        FirstName: Fleet.FirstName,
    //        LastName: Fleet.LastName,

    //        //UserTypeId: (role) ? 2 : User.UserType,

    //        Email: Fleet.Email,

    //        MobileNo: Fleet.MobileNo,
    //        //RoleId: (role) ? 2 : User.Role,

    //        CompanyName: Fleet.CompanyName,
    //        Description: Fleet.Description,
    //        insupdflag: flag           
    //    }

    //    $http({
    //        url: 'http://localhost:52800/api/FleetOwnerLicense/CreateNewFO',
    //        method: 'POST',
    //        headers: { 'Content-Type': 'application/json' },
    //        data: Fleet
    //    }).success(function (data, status, headers, config) {
    //        alert('saved successfully');
    //        window.location.href = "http://localhost:52800/UI/LicenseConfirmation.html";
    //    }).error(function (ata, status, headers, config) {
    //        alert(ata);
    //    });

    //    $scope.User1 = null;
    //};

    //$scope.setUsers = function (usr) {
    //    $scope.User1 = usr;

    //};

    //$scope.clearUsers = function () {
    //    $scope.User1 = null;
    //} 


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
        var FleetOwnerRequest1 = {
            //Id: Fleet.Id,
            
            FirstName: FleetOwnerRequest1.FirstName,
            LastName: FleetOwnerRequest1.LastName,

            //UserTypeId: (role) ? 2 : User.UserType,

            EmailAddress: FleetOwnerRequest1.EmailAddress,

            PhoneNo: FleetOwnerRequest1.PhoneNo,
            //RoleId: (role) ? 2 : User.Role,

            CompanyName: FleetOwnerRequest1.CompanyName,
            Description: FleetOwnerRequest1.Description,
            Title: FleetOwnerRequest1.Title,
            CompanyEmployeSize: FleetOwnerRequest1.CompanyEmployeSize,
            FleetSize: FleetOwnerRequest1.FleetSize,
            CurrentSystemInUse: FleetOwnerRequest1.CurrentSystemInUse,
            SentNewProductsEmails: 1,
            Gender: FleetOwnerRequest1.Gender,
            howdidyouhearaboutus: FleetOwnerRequest1.howdidyouhearaboutus,
            Agreetotermsandconditions: 1,
            Address: FleetOwnerRequest1.Address,
            FleetStaff:FleetOwnerRequest1.FleetStaff,
      Country:FleetOwnerRequest1.Country,
            Code:FleetOwnerRequest1.Code,
      Fax:FleetOwnerRequest1.Fax,
            PermanentAddress:FleetOwnerRequest1.PermanentAddress,
      TemporaryAddres:FleetOwnerRequest1.TemporaryAddres,
            state:FleetOwnerRequest1.state,
             insupdflag: 'I',
       
        }
        $http({
            url: 'http://localhost:52800/api/FleetOwnerLicense/CreateNewFOR',
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            data: FleetOwnerRequest1
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

      







    
   