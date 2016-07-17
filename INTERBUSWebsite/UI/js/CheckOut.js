var app = angular.module('myApp', ['ngStorage'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {

    $scope.GetDetails = function (TicketDetails)
    {
        $scope.details = $localStorage.book;
        $scope.FirstName = $scope.details.No_Seats;
    }

    $scope.processPymt = function () {

        if ($scope.qty <= 0) {
            alert('Please select the number of units.');
            return;
        }

        var processPymt1 =
         [

             {
                 LicenseType: 'BTPOS1',
                 Frequency: '2333',
                 UnitPrice: '12.2',
                 FleetOwner: '002',
                 NoOfMonths: '4Months',
                 TotalAmount: '2345',
                 CreateDate: '01/01/2016',
                 TransId: 'we34'
             }
         ];

        var req = {
            method: 'POST',
            url: 'http://localhost:52800/api/CartPaymentDetails/SaveType',
            //headers: {
            //    'Content-Type': undefined
            data: processPymt1[0]
        }

        $http(req).then(function (res) {
            if (res.data.length == 0) {
                alert('invalid credentials');
            }
            else {
                //if the user has role, then get the details and save in session
                $localStorage.uname = res.data[0].name;
                $localStorage.userdetails = res.data;
                window.location.href = "LicenseConfirmation.html";
            }
        });

    }

    //for (var v = 0; v < details.length; v++)
    //{

    //}
    
    
});