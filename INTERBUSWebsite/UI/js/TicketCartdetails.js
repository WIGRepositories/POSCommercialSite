var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {

    $scope.book1 = $scope.$localStorage;

    $scope.processPymt = function () {
        alert('Payment gateway integration will done here and on successful payment user will be redirect to ticket printing page.')
        window.location.href = "/UI/TicketPage.html";
    }

});