var app = angular.module('myApp', ['ngStorage'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $filter) {
   
    $scope.seatstest = [];
    $scope.select_all = false;

    //function to create n-dimensional array

    var makeArray = function createArray(dimensions, value) {
        // Create new array
        var array = new Array(dimensions[0] || 0);
        var i = dimensions[0];

        // If dimensions array's length is bigger than 1
        // we start creating arrays in the array elements with recursions
        // to achieve multidimensional array
        if (dimensions.length > 1) {
            // Remove the first value from the array
            var args = Array.prototype.slice.call(dimensions, 1);
            // For each index in the created array create a new array with recursion
            while (i--) {
                array[dimensions[0] - 1 - i] = createArray(args, value);
            }
            // If there is only one element left in the dimensions array
            // assign value to each of the new array's elements if value is set as param
        } else {
            if (typeof value !== 'undefined') {
                while (i--) {
                    array[dimensions[0] - 1 - i] = value;
                }
            }
        }

        return array;
    }
    $scope.seatstest = makeArray([3, 2]);

    $scope.seats = [{ "Id": 1, "row": 0, "col": 0, "label": "A1" },
    { "Id": 2, "row": 0, "col": 1, "label": "A2" },
    { "Id": 3, "row": 1, "col": 0, "label": "B1" },
    { "Id": 4, "row": 1, "col": 1, "label": "B2" },
    { "Id": 5, "row": 2, "col": 1, "label": "C1" }];
    
    for (i = 0; i <= $scope.seats.length - 1; i++) {
        $scope.seatstest[$scope.seats[i]["row"]][$scope.seats[i]["col"]] = $scope.seats[i]["label"];
    }
    //for (i = 0; i <= $scope.seats.length - 1; i++) {        
    //    for (j = 0; j <= $scope.seats.length - 1; j++) {
    //        if ($scope.seats[j])
    //        $scope.seatstest[i][j] = $scope.seats[j];

    //        //if (i == $scope.seats[j]["row"])
    //        //{
               
    //        //    $scope.seatstest.push({ row: i, col: j,"label": $scope.seats[j]["label"] });
                
    //        //}
    //        //if (i == $scope.seats[j]["row"])
    //        //{
    //        //    if(j == $scope.seats[j]["col"])               
    //        //        $scope.seatstest[i][j] = $scope.seats[j];
    //        //}
            
    //        //$scope.seats.push({ row: i, posn: "B" });
    //        //$scope.seats.push({ row: i, posn: "C" });
    //        //$scope.seats.push({ row: i, posn: "D" });
    //        //$scope.seats.push({ row: i, posn: "E" });
    //        //$scope.seats.push({ row: i, posn: "F" });
    //    }
    //}

    //for (i = 1; i <= 5; i++) {
    //    for (j = 1; j <= 5; j++) {
    //        $scope.seats.push({ row: i, col: j, posn: "A"+i+j });          
    //        //$scope.seats.push({ row: i, posn: "B" });
    //        //$scope.seats.push({ row: i, posn: "C" });
    //        //$scope.seats.push({ row: i, posn: "D" });
    //        //$scope.seats.push({ row: i, posn: "E" });
    //        //$scope.seats.push({ row: i, posn: "F" });
    //    }
    //}

    $scope.columns = function (r) {
        var input = [];
        for (var i = start; i < end; i++) input.push($scope.arr[i]);
        return input;
        //return $filter('filter')($scope.seats, { row: r });
    };

    var stat = 0;
    $scope.selectedSeats = new Array();
    $scope.selectedSeats.pssngr = new Array();
    $scope.selectedSeats.returnpssngr = new Array();

    $scope.selectedIndex = -1;
   
    $scope.testClick = function () {
        $scope.Stops = $localStorage.Stops;
    }
    $scope.GetServices = function () {
        if ($scope.S == null) {
            alert('Please select source.');
            return;
        }

        if ($scope.D == null) {
            alert('Please select destination.');
            return;
        }

        $localStorage.src = $scope.S;
        $localStorage.dest = $scope.D;

        //$rootscope.src = $scope.RS;
        //$rootscope.dest = $scope.RD;
        $localStorage.timing = ($scope.timing == 'Now') ? Date() : $scope.timing;
        $localStorage.triptype = $scope.triptype;
        // $scope.GetAvailableServices();

        $scope.services = [
            { "Id": 1, "Company": "CMP1", "VehicleType": "AC", "AvailableSeats": "10", "WindowSeats": "3", "StartTime": "11:00 AM", "EndTime": "12:30 PM", "Rating": "3", "Price": "10", "luggageCrg": "", "Discount": "" }
            , { "Id": 2, "Company": "CMP2", "VehicleType": "Non-AC", "AvailableSeats": "12", "WindowSeats": "3", "StartTime": "11:10 AM", "EndTime": "12:30 PM", "Rating": "4", "Price": "12", "luggageCrg": "", "Discount": "" }
            , { "Id": 3, "Company": "CMP3", "VehicleType": "AC", "AvailableSeats": "4", "WindowSeats": "4", "StartTime": "12:00 PM", "EndTime": "12:30 PM", "Rating": "3", "Price": "10", "luggageCrg": "", "Discount": "" }
            , { "Id": 4, "Company": "CMP4", "VehicleType": "Non-AC", "AvailableSeats": "5", "WindowSeats": "2", "StartTime": "12:30 PM", "EndTime": "12:30 PM", "Rating": "", "Price": "13", "luggageCrg": "", "Discount": "" }
            , { "Id": 5, "Company": "CMP5", "VehicleType": "AC", "AvailableSeats": "6", "WindowSeats": "2", "StartTime": "12:30 PM", "EndTime": "12:30 PM", "Rating": "", "Price": "11", "luggageCrg": "", "Discount": "" }
            , { "Id": 6, "Company": "CMP6", "VehicleType": "AC", "AvailableSeats": "3", "WindowSeats": "1", "StartTime": "12:30 PM", "EndTime": "12:30 PM", "Rating": "", "Price": "11", "luggageCrg": "", "Discount": "" }
            , { "Id": 7, "Company": "CMP7", "VehicleType": "AC", "AvailableSeats": "23", "WindowSeats": "4", "StartTime": "12:30 PM", "EndTime": "12:30 PM", "Rating": "", "Price": "12", "luggageCrg": "", "Discount": "" }
            , { "Id": 8, "Company": "CMP8", "VehicleType": "AC", "AvailableSeats": "11", "WindowSeats": "2", "StartTime": "12:30 PM", "EndTime": "12:30 PM", "Rating": "", "Price": "11", "luggageCrg": "", "Discount": "" }
            , { "Id": 9, "Company": "CMP9", "VehicleType": "Non-AC", "AvailableSeats": "33", "WindowSeats": "6", "StartTime": "12:30 PM", "EndTime": "12:30 PM", "Rating": "", "Price": "10", "luggageCrg": "", "Discount": "" }
            , { "Id": 10, "Company": "CMP10", "VehicleType": "Non-AC", "AvailableSeats": "2", "WindowSeats": "0", "StartTime": "12:30 PM", "EndTime": "12:30 PM", "Rating": "", "Price": "11", "luggageCrg": "", "Discount": "" }
            , { "Id": 11, "Company": "CMP11", "VehicleType": "AC", "AvailableSeats": "9", "WindowSeats": "2", "StartTime": "12:30 PM", "EndTime": "12:30 PM", "Rating": "", "Price": "13", "luggageCrg": "", "Discount": "" }
            , { "Id": 12, "Company": "CMP12", "VehicleType": "AC", "AvailableSeats": "5", "WindowSeats": "2", "StartTime": "12:30 PM", "EndTime": "12:30 PM", "Rating": "", "Price": "12", "luggageCrg": "", "Discount": "" }
            , { "Id": 13, "Company": "CMP13", "VehicleType": "AC", "AvailableSeats": "8", "WindowSeats": "2", "StartTime": "12:30 PM", "EndTime": "12:30 PM", "Rating": "", "Price": "11", "luggageCrg": "", "Discount": "" }
        ];

    }

    seatMap = [{ "baggage": "0", "carry_ons": "0", "first_name": "", "last_name": "", "meal": "Any", "passport": "", "posn": "A", "row": 1, "selected": false }
        , { "baggage": "0", "carry_ons": "0", "first_name": "", "last_name": "", "meal": "Any", "passport": "", "posn": "B", "row": 1, "selected": false }
        , { "baggage": "0", "carry_ons": "0", "first_name": "", "last_name": "", "meal": "Any", "passport": "", "posn": "C", "row": 1, "selected": false }
        , { "baggage": "0", "carry_ons": "0", "first_name": "", "last_name": "", "meal": "Any", "passport": "", "posn": "D", "row": 1, "selected": false }
        , { "baggage": "0", "carry_ons": "0", "first_name": "", "last_name": "", "meal": "Any", "passport": "", "posn": "E", "row": 1, "selected": false }
        , { "baggage": "0", "carry_ons": "0", "first_name": "", "last_name": "", "meal": "Any", "passport": "", "posn": "F", "row": 1, "selected": false }
        , { "baggage": "0", "carry_ons": "0", "first_name": "", "last_name": "", "meal": "Any", "passport": "", "posn": "A", "row": 2, "selected": false }
        , { "baggage": "0", "carry_ons": "0", "first_name": "", "last_name": "", "meal": "Any", "passport": "", "posn": "B", "row": 2, "selected": false }
        , { "baggage": "0", "carry_ons": "0", "first_name": "", "last_name": "", "meal": "Any", "passport": "", "posn": "C", "row": 2, "selected": false }
        , { "baggage": "0", "carry_ons": "0", "first_name": "", "last_name": "", "meal": "Any", "passport": "", "posn": "D", "row": 2, "selected": false }
        , { "baggage": "0", "carry_ons": "0", "first_name": "", "last_name": "", "meal": "Any", "passport": "", "posn": "E", "row": 2, "selected": false }
        , { "baggage": "0", "carry_ons": "0", "first_name": "", "last_name": "", "meal": "Any", "passport": "", "posn": "F", "row": 2, "selected": false }
        , { "baggage": "0", "carry_ons": "0", "first_name": "", "last_name": "", "meal": "Any", "passport": "", "posn": "A", "row": 3, "selected": false }
        , { "baggage": "0", "carry_ons": "0", "first_name": "", "last_name": "", "meal": "Any", "passport": "", "posn": "B", "row": 3, "selected": false }
        , { "baggage": "0", "carry_ons": "0", "first_name": "", "last_name": "", "meal": "Any", "passport": "", "posn": "C", "row": 3, "selected": false }
        , { "baggage": "0", "carry_ons": "0", "first_name": "", "last_name": "", "meal": "Any", "passport": "", "posn": "D", "row": 3, "selected": false }
        , { "baggage": "0", "carry_ons": "0", "first_name": "", "last_name": "", "meal": "Any", "passport": "", "posn": "E", "row": 3, "selected": false }
        , { "baggage": "0", "carry_ons": "0", "first_name": "", "last_name": "", "meal": "Any", "passport": "", "posn": "F", "row": 3, "selected": false }];

    $scope.test = function (b) {
        if ($scope.selectedIndex != -1)
            document.getElementById('t_' + $scope.selectedIndex).style.display = "none";
        var currstyle = document.getElementById('t_' + b).style.display;
        // var currstyle = document.getElementById('imgTd').style.display;
        if (currstyle == "none") {
            document.getElementById('t_' + b).style.display = "table-cell";
            $scope.selectedIndex = b;
            // $scope.selectedSeats = [];
        }

     //   $scope.basePrice = b.amount;
    }
    $scope.totalseats = 0;
    $scope.count = 0;
    var selectList = [];
   
    //$scope.GetAvailableServices = function () {
    //    $scope.srcId = $localStorage.srcId;
    //    $scope.destId = $localStorage.destId;
    //    $scope.way = $localStorage.waytype;
   
   
    //$scope.totalseats = 0;
    //$scope.count = 0;
    //var selectList = [];
    

    //        $scope.returncount = $scope.selectedSeats.returnpssngr.length;
    //    }
    //        $scope.selectedSeats.returnpssngr.push(returndata);
       
    //        $scope.count = $scope.selectedSeats.returnpssngr.length;
    //}
    //    // $scope.seats = $scope.count;

    //}

    $scope.AddSeats = function (x) {
        document.getElementById('1').src = "/UI/images/busimages/acbus.jpg";

        document.getElementById('1').style.borderColor = "green";
        document.getElementById('1').style.backgroundImage = "/UI/images/busimages/acbus.jpg";

        if (selectList.indexOf(x) != -1)
            return;
        selectList.push(x);
        var item = {
            "SeatId": x
           , "SeatNo": ""
         , "NoOfSeats": $scope.count
           , "Fname": ""
           , "Lname": ""
           , "Age": ""
           , "Sex": ""
           , "Identityproof": ""

        }
            $scope.selectedSeats.pssngr.push(item);

            $scope.count = $scope.selectedSeats.pssngr.length;
            $scope.totalseats = $scope.count;
            $scope.count = 0;
          //  $scope.subtotal = $scope.count * $scope.Booking.Cost;
        }


    $scope.GetAvailableServices = function ()
    {
        $scope.src = $localStorage.src;
        $scope.dest = $localStorage.dest;
        $scope.timing = $localStorage.timing;


        $scope.srcId = $localStorage.src.Id;
        $scope.destId = $localStorage.dest.Id;
        $scope.srcStage = $localStorage.src.name;
        $scope.destStage = $localStorage.dest.name;
        $scope.way = $localStorage.waytype;

       
        $http.get('/api/TicketBooking/GetAvailableServices?srcId=' + $scope.srcId + '&destId=' + $scope.destId).then(function (response, req) {
            $scope.services = response.data;
        });        
    }
    var stat = 0;
    $scope.savedata = function (selectedSeats) {
        if ($localStorage.waytype == 1) {
            $scope.showDiv = true; 
           var book = { "No_Seats": "5", "cost": "1500", "JourneyType": "1", "passengersList": selectedSeats.pssngr, "Seatcost": "900" };
            //for(int i=0; i<selectedSeats.length; i++){}
            // passengersList: [{ "SeatId": "1", SeatNo: selectedSeats.SelectedSeatId, Fname: seat.pssngr.fname, Lname: seat.pssngr.lname, "Age": "30", "Sex": "0", "Identityproof": "adhar" }]

            //Fname2: Booking.psngr2.Fname2,  //Lname2: Booking.psngr2.Lname2, //Fname3: Booking.psngr3.Fname3, //Lname3: Booking.psngr3.Lname3, //"No_Seats": "5", "cost": "1500", "JourneyType": "1",
            //"passengersList": [{ "SeatId": "1","SeatNo": "A1", "Age": "30", "Sex": "0", "Identityproof": "adhar" },
            //                  ]
            //};
            /*
            {
      "Pnr_ID": 0,  "Pnr_No": null,  "No_Seats": 0,  "cost": 0,  "dateandtime": "0001-01-01T00:00:00",  "src": null,  "dest": null,  "vehicle_No": null,  "PassengerId": 0, "Fname": "srujan",
      "Lname": null,  "Age": 0,  "Sex": 0,  "Identityproof": null,  "TransactionId": 0,  "Transaction_Number": null,  "Amount": 0,  "Paymentmode": 0,  "Gateway_transId": null,
      "PSID": 0,  "SeatNo": null,  "passengersList": [    {  "SeatId": null,  "Fname": null, "Lname": null,   "Age": 30,   "Sex": 0,   "Identityproof": null   },
        {
          "SeatId": null,    "Fname": null,     "Lname": null,    "Age": 33,    "Sex": 0,   "Identityproof": null   }  ]
    }*/
            //$localStorage.waytype = selectedSeats;
           var req = {
                method: 'POST'
                , url: '/api/TicketBooking/SaveBookingDetails'
                , data: book
            }
         //  $http(req).then(function (res) { window.location.href = "TicketCartdetails.html"; });

           $http({
               url: '/api/TicketBooking/SaveBookingDetails',
               method: 'POST',
               headers: { 'Content-Type': 'application/json' },
               data: book,

           }).success(function (data, status, headers, config) {
               alert('Saved successfully');
               window.location.href = "TicketCartdetails.html";
           }).error(function (ata, status, headers, config) {
               alert(ata);
           });

        //    window.location.href = "TicketCartdetails.html";

        } else if ($localStorage.waytype == 2 && stat <= 1)
        {
            //var book = { "No_Seats": "5", "cost": "1500", "JourneyType": "1", "passengersList": selectedSeats.returnpssngr, "Seatcost": "900" };
            //$localStorage.book = book;
            //var req = { method: 'POST', url: '/api/TicketBooking/SaveBookingDetails', data: book }
            // $http(req).then(function (res) { window.location.href = "TicketPage.html"; });
         
            stat++;
            if (stat == 1) {
              
                $http.get('/api/TicketBooking/GetAvailableServices?srcId=' + $scope.destId + '&destId=' + $scope.srcId).then(function (response, req) {
                    $scope.services = response.data;
                });                
            }

        } else { window.location.href = "TicketCartdetails.html"; 
        }
    }
    
    });