var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {

    

    $scope.getCancellationHistory = function () {

        if ($localStorage.uname) {
            $scope.username = $localStorage.uname;
        }
        else {
            window.location.href = "../index.html";
        }

        $scope.emailid = $localStorage.userdetails[0].EmailAddress;

        $http.get('/api/WebsiteUserInfo/GetCancellationHistory?emailid=' + $scope.emailid).then(function (response, data) {
            $scope.bookedHistory = response.data;
        });
    }


    $scope.LogoutUser = function () {
        $localStorage.uname = null;
        $scope.username = null;
        $localStorage.userdetails = null;

        window.location.href = "../index.html";
    }
    $scope.GetTicketsForCancellation = function () {
        //get the ticket details and show

    }
});
