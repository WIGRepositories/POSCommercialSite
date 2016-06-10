var myapp1 = angular.module('myApp', [])
var mycrtl1 = myapp1.controller('Mycntrl', function ($scope, $http) {


    $scope.save = function (type) {

        var type = {

            UserName: type.UserName,
            oldPassword: type.oldPassword,
            newPassword: type.newPassword,
            reenternewPassword: type.reenternewPassword,

        };

        var req = {
            method: 'POST',
            url: 'http://localhost:52800/api/ValidateCredentials/savepassword',            
            //headers: {
            //    'Content-Type': undefined

            data: type


        }
        $http(req).then(function (response) {

        })
    }
});
