var app = angular.module('myApp', ['ngStorage','angularFileUpload'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, fileReader) {

   

    $scope.GetDetails = function () {

        //get the booking id and get the details from db
        //if obtained from db then take it otherwise retive from session

        $scope.onwarddetails =  $localStorage.onwarddetails;

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

        var pdf = new jsPDF('p', 'pt', 'letter');

        var html1 = '<!doctype html><html>' + docHead + '<body onLoad="window.print()">' + printContents + '</body></html>';

        var html = '<html>' + docHead + '<body>' + printContents + '</body></html>';

        html2pdf(html, pdf, function (pdf) {
            var content = pdf.output('blob');
            //pdf.output('dataurlnewwindow');
            //pdf.save('ticket.pdf')

            fileReader.readAsDataUrl(content, $scope, 4).then(function (result) {

                var docContent = result;
                openPDF(docContent, "test.pdf");
            });
        });
        
        //var winAttr = "location=yes, statusbar=no, menubar=no, titlebar=no, toolbar=no,dependent=no, width=865, height=600, resizable=yes, screenX=200, screenY=200, personalbar=no, scrollbars=yes";

        //var newWin = window.open("", "_blank", winAttr);
        //var writeDoc = newWin.document;
        //writeDoc.open();
        //writeDoc.write(html1);
        //writeDoc.close();
        //newWin.focus();
    }

    function openPDF(resData, fileName) {
        var ieEDGE = navigator.userAgent.match(/Edge/g);
        var ie = navigator.userAgent.match(/.NET/g); // IE 11+
        var oldIE = navigator.userAgent.match(/MSIE/g);

        if (ie || oldIE || ieEDGE) {
            var blob = b64toBlob(resData, 'application/pdf')
            // window.open(blob, '_blank');
            window.navigator.msSaveBlob(blob, fileName);
            //window.open(resData, '_blank');
            //  var a = document.createElement("a");
            //  document.body.appendChild(a);
            //  a.style = "display: none";
            //  a.href = resData;
            //  a.download = fileName;
            ////  a.onclick = "window.open(" + fileURL + ", 'mywin','left=200,top=20,width=1000,height=800,toolbar=1,resizable=0')";
            //  a.click(); 

        }
        else {
            window.open(resData, 'mywin', 'left=200,top=20,width=1000,height=700,toolbar=1,resizable=0');
        }
    }

    function b64toBlob(b64Data, contentType) {
        contentType = contentType || '';
        var sliceSize = 512;
        b64Data = b64Data.replace(/^[^,]+,/, '');
        b64Data = b64Data.replace(/\s/g, '');
        var byteCharacters = window.atob(b64Data);
        var byteArrays = [];

        for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
            var slice = byteCharacters.slice(offset, offset + sliceSize);

            var byteNumbers = new Array(slice.length);
            for (var i = 0; i < slice.length; i++) {
                byteNumbers[i] = slice.charCodeAt(i);
            }

            var byteArray = new Uint8Array(byteNumbers);

            byteArrays.push(byteArray);
        }

        var blob = new Blob(byteArrays, { type: contentType });
        return blob;
    }


   
});