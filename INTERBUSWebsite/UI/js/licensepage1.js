
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http) {
    $scope.GetLicense = function () {

        $http.get('/api/LicensePage/GetLicense?catId=8').then(function (response, req) {
            $scope.License = response.data;
        })

    }
    $scope.GoToConfirmation = function (code) {

        if (code == null) {
            alert('please enter valid fleet owner code or contact administrator.');
            return false;
        }
        else {
            $http.get('/api/fleetownerlicense/validatefleetowner?fleetownercode=' + code).then(function (response, req) {
                $scope.result = response.data;

                if ($scope.result > 0)
                    window.location.href = "/UI/LicenseConfirmation.html";
                else
                    alert('invalid fleet owner code');

            });
        }
        $scope.gridOptions = {
            data: 'sampledata',
            columnDefs: [
            { field: 'LicenseType' },
            { field: 'PricePerMonth' },
            { field: 'BTPOSNos' },
             { field: 'TroubleTickets' },
            { field: 'click', cellTemplate: '<button class="btn primary" ng-click="grid.appScope.sampledetails()">Click Me</button>' }
            ]
        };

    };
});