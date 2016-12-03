var app = angular.module('myApp', ['ngStorage'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {

   

    $scope.GetDetails = function () {

        //get the booking id and get the details from db
        //if obtained from db then take it otherwise retive from session

        //$scope.onwarddetails =  $localStorage.onwarddetails;

        //$scope.source = $localStorage.srcId;
        //$scope.destination = $localStorage.destId;
        //$scope.details = $localStorage.book;
        //$scope.firstName = $scope.details.No_Seats;
        //$scope.NoofSeats = $scope.details.NoofSeats;
        //$scope.JourneyType = $scope.details.JourneyType;



        //$http.get('/api/TicketBooking/GetCities?srcId=' + $scope.source + '&destId=' + $scope.destination).then(function (response, req) {
        //    $scope.services = response.data;
        //    $scope.From = $scope.services.source;
        //    $scope.To = $scope.services.destination;
        //})
    }

    $scope.printDiv = function (div) {
        var docHead = document.head.outerHTML;
        var printContents = document.getElementById(div).outerHTML;
        var winAttr = "location=yes, statusbar=no, menubar=no, titlebar=no, toolbar=no,dependent=no, width=865, height=600, resizable=yes, screenX=200, screenY=200, personalbar=no, scrollbars=yes";

        var newWin = window.open("", "_blank", winAttr);
        var writeDoc = newWin.document;
        writeDoc.open();
        writeDoc.write('<!doctype html><html>' + docHead + '<body onLoad="window.print()">' + printContents + '</body></html>');
        writeDoc.close();
        newWin.focus();
    }

   
});