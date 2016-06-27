var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {

    $scope.srcStage = $localStorage.src.name;
    $scope.destStage = $localStorage.dest.name;

    $scope.processPymt = function () {
        alert('Payment gateway integration will done here and on successful payment user will be redirect to ticket printing page.')
        window.location.href = "http://localhost:52800/UI/TicketPage.html";
    }

});