var app = angular.module('myApp', ['ui.bootstrap'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $uibModal) {
    $scope.EmailAddress = null;

    $scope.RecoverPassword = function () {
        if ($scope.EmailAddress == null)
        {
            $scope.showDialog("Please enter email address or user name.");
            return;
        }
       
        $http.get('/api/ValidateCredentials/RetrivePassword?emailId=' + $scope.EmailAddress).then(function (res, data) {
            $scope.isRetrived = res.data;
            if ($scope.isRetrived == "1") {
                // $scope.showDialog("The password has been sent to the registered email address. Please login and reset the password.");
               alert("The password has been sent to the registered email address. Please login and reset the password.");
                window.location.href = "../index.html";
            }
            else {
                $scope.showDialog("Credentials could not be verified. Please contact INTERBUS administrator.");
                return;
            }
            //alerts("hi");
        });
    }


    $scope.showDialog = function (message) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
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

app.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});

