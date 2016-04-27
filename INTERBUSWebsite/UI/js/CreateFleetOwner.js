// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('Mycntrlr', function ($scope, $http) {

    //app.controller('showHide', function ($scope) {
    //  $scope.toggle = function () {
    //    if (!$scope.myForm.email - input.$valid) {
    //     alert(valid);
    //}
    //};

    $scope.save = function (Fleet, flag) {

        var Fleet = {
            Id: Fleet.Id,
            FirstName: Fleet.FirstName,
            LastName: Fleet.LastName,

            //UserTypeId: (role) ? 2 : User.UserType,

            Email: Fleet.Email,

            MobileNo: Fleet.MobileNo,
            //RoleId: (role) ? 2 : User.Role,

            CompanyName: Fleet.CompanyName,
            Description: Fleet.Description,
            insupdflag: flag

        }
      
        $http({
            url: 'http://localhost:52800/api/fleetownerlicense/CreateNewFO',
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            data: Fleet
        }).success(function (data, status, headers, config) {
            alert('saved successfully');
        }).error(function (ata, status, headers, config) {
            alert(ata);
        });

        $scope.User1 = null;
    };

    $scope.setUsers = function (usr) {
        $scope.User1 = usr;

    };

    $scope.clearUsers = function () {
        $scope.User1 = null;
    }


});
