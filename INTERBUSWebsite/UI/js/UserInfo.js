var myapp1 = angular.module('myApp',[])
var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http) {


    $scope.saveUser = function (type) {
        if (type == null) {
            alert('Please enter FirstName.');
            return;
        }

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
        if (type.RePassword == null || type.RePassword == "") {
            alert('Please re-enter Password.');
            return;
        }
        if (type.Password != type.RePassword)
        {
            alert('Passwords do not match');
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
        if (type.Gender == null) {
            alert('Please select Gender.');
            return;
        }



        var userinfo = {
            FirstName: type.FirstName,
            LastName: type.LastName,
            UserName: type.UserName,
            Password: type.Password,
            EmailAddress: type.EmailAddress,
            Mobile: type.Mobile

        };

        var req = {
            method: 'POST',
            url: '/api/UserInfo/saveUserInfodfds',
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

    $scope.showDialog = function (message) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            backdrop: false,
            templateUrl: 'statusPopup.html',
            //  controller: 'ModalInstanceCtrl',            
            resolve: {
                mssg: function () {
                    return message;
                }
            }
        });
    }
});


myapp1.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});
