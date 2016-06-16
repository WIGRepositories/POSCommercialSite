// JavaScript source code
var app = angular.module('myApp', [])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localstorage) {
    $scope.values = $localstorage.val;
    $scope.LicenseType1 = $scope.values.LicenseType;
    $scope.Id1 = $scope.values.Id;
    $scope.Unitprice1 = $scope.values.Unitprice;
    $scope.FeatureName1 = $scope.values.FeatureName;
    $scope.FeatureValue1 = $scope.values.FeatureValue;
    $scope.LicenseType1 = $scope.values.LicenseType;






});