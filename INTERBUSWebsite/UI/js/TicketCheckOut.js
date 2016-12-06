var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {

    $scope.book1 = $scope.$localStorage;

    $scope.onwarddetails = $localStorage.onwarddetails;
    $scope.BookingId = $localStorage.BookingId;

    //retrive the emailid and mobile no and try to get the user details from db
    //if not exists then show empty
    $scope.getcheckoutdetails = function () {
        
        var emailid = $scope.onwarddetails.EmailId;
        $http.get('/api/websiteuserinfo/GetWebsiteUserInfo?logininfo=' + emailid).then(function (response, data) {
            $scope.userdetails = response.data[0];
        });
    }


    $scope.ProceedToPayment = function () {

        alert('Payment gateway integration will done here and on successful payment user will be redirect to ticket printing page.')
        window.location.href = "TicketPage.html";
    }

});