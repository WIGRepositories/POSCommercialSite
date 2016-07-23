var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {

    $scope.GetDetails = function (TicketDetails)
    {
        $scope.details = $localStorage.book;
        $scope.FirstName = $scope.details.No_Seats;
    }

   

    $scope.processPymt = function () {
        $('#Modal-header-new').modal('show');
       

        //$scope.modal_instance = $uibModal.open({
        //    animation: $scope.animationsEnabled,
        //    backdrop:false,
        //    templateUrl: 'http://localhost:52800/UI/PopupTest.html',
        //    // controller: 'ModalInstanceCtrl',
        //    resolve: {
        //        mssg: function () {
        //            return 'test';
        //        }
        //    }
        //    backdrop: 'static',
        //    keyboard: false,
        //    animation: $scope.animationsEnabled,
        //templateUrl: '/Scripts/angularApp/views/user-modal.html',
        //controller: 'UserModalCtrl',

        //});

        //$http.get('http://localhost:52800/api/Payments/MakePayment').then(function (response, req) {
        //    $scope.transDetails = response.data;

        //});

        //$http({
        //    url: 'http://localhost:52800/api/Payments/MakePayment',
        //    method: 'GET'
        //}).success(function (data, status, headers, config) {
        //    alert('Saved successfully');
        //    //do the post payment updates

        //}).error(function (ata, status, headers, config) {
        //    alert(ata);
        //    //insert the failed transaction details
        //});

        //$scope.modal_instance.close();
        //$scope.modal_instance.dismiss();
       
        $('#Modal-header-new').modal('hide');
        
    }

    $scope.popupTest = function () {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'http://localhost:52800/UI/PopupTest.html',
           // controller: 'ModalInstanceCtrl',
            resolve: {
                mssg: function () {
                    return 'test';
                }
            }
        });
    }


    $scope.getcheckdetails = function () {
        
        $scope.c = $localStorage.focheckoutDetails[0];
        $scope.ld = $localStorage.selLicense;
        $scope.ld.amt = $localStorage.UselicensePymtRecord.Amount;

        //$http.get('http://localhost:52800/api/Checkout/getcheckdetails').then(function (response, req) {
        //    $scope.check = response.data;

        //})

    }    
});