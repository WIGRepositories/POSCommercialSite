var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {

    
    $scope.FillDetails = function () {
        
            $scope.licenseCatId = $localStorage.LicenseTypeId;
            $scope.focode = $localStorage.FleetOwnerCode;

            //displaying the current fleet owner code
            var fodetails = $localStorage.FleetOwnerCode;
            $scope.selFleetOwnerCode = "";
         
            var ldetails = $localStorage.License;
            $scope.selLicense = "";
            $scope.selLicensePrice = "";
             

            //identify the selected license and display the properties
            for (ltCnt = 0; ltCnt < ldetails.Table.length; ltCnt++) {
                if (ldetails.Table[ltCnt].Id == $scope.licenseCatId) {
                    $scope.selLicense = ldetails.Table[ltCnt];
                    break;
                }
            }

            for (ltCnt = 0 ; ltCnt < ldetails.Table2.length; ltCnt++) {
                if (ldetails.Table2[ltCnt].LicenseId == $scope.selLicense.Id) {
                    $scope.selLicensePrice = ldetails.Table2[ltCnt]
                }
            }


        //if (FleetOwnerCode != null) {
        //    $scope.selFleetOwnerCode = fodetails.FleetOwnerCode;
        //    document.getElementById("Id").innerHTML = localStorage.getItem("FleetOwnerCode");
        //}

    }

    $scope.CheckOut = function () {

        //insert the details into user license tables and return the fleet owner details 
        //then redirect to checkout page

        //public List<ULLicense> ULP{ get; set; }
        //public int Id { set; get; }
        //public int UserId { set; get; }
        //public int FOId { set; get; }
        //public int LicenseTypeId { set; get; }
        //public DateTime StartDate { set; get; }
        //public DateTime ExpiryOn { set; get; }
        //public int GracePeriod { set; get; }
        //public DateTime ActualExpiry { set; get; }
        //public DateTime LastUpdatedOn { set; get; }
        //public int Active { set; get; }
        //public int StatusId { set; get; }

        for (var cnt = 0; cnt < configFareList.length; cnt++) {
            var arrTime = configFareList[cnt].arrivaltime; //12:00 AM

            var atimeAtt = arrTime.split(' ')
            var atArr = atimeAtt[0].split(':');

            var depTime = configFareList[cnt].departuretime; //12:00 AM

            var dtimeAtt = depTime.split(' ')
            var dtArr = dtimeAtt[0].split(':');


            var FVS = {

                StopId: configFareList[cnt].stopid,
                ArrivalHr: atArr[0],
                DepartureHr: dtArr[0],

                ArrivalMin: atArr[1],
                DepartureMin: dtArr[1],
                ArrivalAMPM: atimeAtt[1],
                DepartureAmPm: dtimeAtt[1],
                Duration: stop.Duration,

                arrivaltime: arrTime,
                departuretime: depTime,

                insupddelflag: 'U'
            }
            FleetOwnerVS.push(FVS);
        }
        foSchedule.VSchedule = FleetOwnerVS;
        $http({
            url: 'http://localhost:1476/api/FleetOwnerVehicleSchedule/saveFORSchedule',
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            data: foSchedule,

        }).success(function (data, status, headers, config) {
            alert('Fleet owner Vehicle Schedule Saved successfully');
            $scope.GetFORoutes();
        }).error(function (ata, status, headers, config) {
            alert(ata);
        });

        window.location.href = "http://localhost:52800/UI/CheckOut.html";
    }
       
        //window.location.href = "http://localhost:52800/UI/LicenseConfirmation.html";

});


            //save the details into db for user license
            //if ($scope.qty <= 0)
            //{
            //    alert("please select the month(s)");
            //}
            //else {

            //    alert('Payment gateway integration will done here and on successful payment fleet owner will be sent a confirmation email with dashboard login details.')
            //    window.location.href = "http://localhost:52800/UI/LicenseConfirmation.html";

            //    $scope.Licensepayments = function () {

            //        var pmnt = {
            //            LicenseTypeId: LicenseTypeId,
            //            fleetownercode:code 
            //        };
            //        $localstorage.value = pmnt;
            //        var req = {
            //            method: 'POST',
            //            url: 'http://localhost:52800/api/LicensePage/SaveLicence',
            //            data: pmnt
            //        }
            //        $http(req).then(function (response) {
            //            alert(response.data);
            //            window.location.href = "http://localhost:52800/UI/LicenseConfirmation.html";
            //        })
            ////create a user login for the fleet owner
            ////communicate the same to user


            //            }
            //create a user login for the fleet owner
            //communicate the same to user

           // window.location.href = "http://localhost:52800/UI/LicenseConfirmation.html";
