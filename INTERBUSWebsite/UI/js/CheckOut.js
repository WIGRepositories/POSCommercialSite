var app = angular.module('myApp', ['ngStorage'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {

    $scope.GetDetails = function (TicketDetails)
    {
        $scope.details = $localStorage.book;
        $scope.FirstName = $scope.details.No_Seats;
    }

    //for (var v = 0; v < details.length; v++)
    //{

    //}
    
    
});