// JavaScript source code
// JavaScript source code
var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http) {

    $scope.getdata = function () {
        $http.get('http://localhost:52800/api/WebsiteUserInfo/GetWebsiteUserInfo').then(function (res, data) {
            $scope.type = res.data;

            //alerts("hi");
        });
    }
    $scope.save = function (type) {

        var userinfo = {
            FirstName: type.FirstName,
            LastName: type.LastName,
            UserName: type.UserName,
            Password: type.Password,
            EmailAddress: type.EmailAddress,
            Mobile:type.Mobile  

        };

        var req = {
            method: 'POST',
            url: 'http://localhost:52800/api/WebsiteUserInfo/pos',
            //headers: {
            //    'Content-Type': undefined

            data: userinfo


        }
        $http(req).then(function (response) { });

    }
    $scope.filterValue = function ($event) {
        if (isNaN(String.fromCharCode($event.keyCode))) {
            $event.preventDefault();
        }
    };

});