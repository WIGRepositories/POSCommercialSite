// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('Mycntrlr', function ($scope, $http) {

    $http.get('http://localhost:1476/api/Stops/GetStops').then(function (res, data) {
        $scope.Stops = res.data;
    }
    });
//    $scope.save = function (Stops) {

//        var Stops = {
//            Id: Stops.Id,
//           Name: Stops.Name,
//           Description: Stops.Description,
//            Code: Stops.Code,
           
//            Active: (Stops.Active == true) ? 1 : 0,
          
//            insupdflag: "I"
//        }

//        var req = {
//            method: 'POST',
//            url: 'http://localhost:1476/api/Stops/saveStops',
//            data: User
//        }
//        $http(req).then(function (response) { });


//        $scope.Stops1 = null;
//    };

//    $scope.setStops = function (usr) {
//        $scope.Stops1 = usr;
//    };

//    $scope.clearStops = function () {
//        $scope.Stops1 = null;
//    }
//});


