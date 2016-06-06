var myapp1 = angular.module('myApp',[])
var mycrtl1 = myapp1.controller('Mycntrlr', function ($scope, $http) {


    $scope.save = function (register) {


        var register = {
            firstname: register.firstname,
            lastname: register.lastname,
            username: register.username,

            Password: register.Password,
            Emailaddress: register.Emailaddress,
            ConfirmPassword: register.ConfirmPassword,
            Gender: register.gender,

        };

        var req = {
            method: 'POST',
            url: 'http://localhost:52800/api/UserInfo/saveUserInfo',
            //headers: {
            //    'Content-Type': undefined
            data: register
        }
        $http(req).then(function (res) {
            alert('saved successfully');
        });
    }
});