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
        if (type.FirstName == null || type.FirstName == "") {
            alert('Please enter FirstName.');
            return;
        }

        if (type.LastName == null || type.LastName == "") {
            alert('Please enter LastName.');
            return;
        }

        if (type.UserName == null || type.UserName == "") {
            alert('Please enter UserName.');
            return;
        }

        if (type.Password == null || type.Password == "") {
            alert('Please enter Password.');
            return;
        }

        if (type.EmailAddress == null || type.EmailAddress == "") {
            alert('Please enter EmailAddress.');
            return;
        }

        if (type.Mobile == null || type.Mobile == "") {
            alert('Please enter Mobile.');
            return;
        }



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
        //if (data != null) {
        //    alert('Saved successfully!!.');
        //    return;
        //}
        $http(req).then(function (response) {
            $scope.showDialog("Saved successfully!!");

            $scope.type = null;
            $scope.GetWebsiteUserInfo();

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });

    }

   
});