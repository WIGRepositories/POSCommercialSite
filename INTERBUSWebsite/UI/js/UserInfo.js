var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {

    $scope.registeredUseId = 0;

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

        var agreement = document.getElementById('agreement');
        if (agreement.checked == false)
        {
            alert('Please accept the terms and conditions.');
            return;
        }

        var userinfo = {
            FirstName: type.FirstName,
            LastName: type.LastName,
            UserName: type.UserName,
            Password: type.Password,
            EmailAddress: type.EmailAddress,
            Mobile: type.Mobile,    
            Gender:type.Gender,    
            UserTypeId:1,
            UserId:null,
            Active: 1,
            IsEmailVerified:0,
            InsUpdDelFlag:'I'
        };

        var req = {
            method: 'POST',
            url: '/api/UserInfo/saveUserInfo',
            //headers: {
            //    'Content-Type': undefined

            data: userinfo
        }
        //if (data != null) {
        //    alert('Saved successfully!!.');
        //    return;
        //}
        $http(req).then(function (response) {

            if (response.data.length == 0) {
                $scope.registeredUseId = 0;
                alert('User name or email address or mobile already exists or could not be registered. Please contact INTERBUS administrator.')
            }
        else {
            //if the user has role, then get the details and save in session
                $localStorage.uname = response.data[0].name;
                $localStorage.userdetails = response.data;

                $scope.registeredUseId = 1;
                
            alert("Saved successfully!!. Please enter the Email verification code sent to email address to complete registration.");
            $scope.type = null;
        }

            //$scope.registeredUseId = response.data;

            //if ($scope.registeredUseId > 0) {
            //    // $scope.showDialog("Saved successfully!!<br/>. Please enter the Email verification code sent to email address to complete registration.");
            //    alert("Saved successfully!!. Please enter the Email verification code sent to email address to complete registration.");
            //    $scope.type = null;
            //    // $scope.GetWebsiteUserInfo();
            //}
            //else {
               
            //}

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            $scope.registeredUseId = 0;
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);            
        });

    }

    $scope.VerifyEmailAddress = function (code) {

        if (code == '1111') {
            $scope.codeVerified = 1;
            //redirect to user profile page

            window.location.href = "UserProfile.html";
        }
        else {
            // alert('invalid email code');
            $scope.codeVerified = 0;
        }
    }

    $scope.showDialog = function (message) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            backdrop: false,
            templateUrl: 'statusPopup.html',
              controller: 'ModalInstanceCtrl',            
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
