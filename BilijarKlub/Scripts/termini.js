////setupConnection = (hubProxy) => {
////    hubProxy.client.receiveOrderUpdate = (updateObject) => {
////        const label = document.getElementById("testLabel");
////        label.innerText = "Test";
////    }
////}

////$(document).ready(() => {
////    console.log("connection started!");
////    var hubProxy = $.connection.rezervacijaHub;
////    setupConnection(hubProxy);
////    $.connection.hub.start();

////    document.getElementById("submit").addEventListener("click",
////        e => {
////            e.preventDefault();
////            fetch("api/Index",
////                {
////                    method: "POST",
////                    body: JSON.stringify({})
////                }
////            )
////        })
////});

//$(function () {
//    var hub = $.connection.echo;
//    $.connection.hub
//        .start()
//        .done(function () {
//            hub.server.say('Hello SignalR!');
//        });
//});


$(function () {
    var hub = $.connection.rezervacijaHub;
    //$.connection.hub.start();
    hub.client.dodajRezervaciju = function (stoId, pocetak, kraj) {
        document.getElementById('rezervacijeTable').innerHTML += '<tr> <td>' + stoId + '</td> <td>' + pocetak + '</td> <td>' + kraj + '</td>' + '</tr>';
    }

    $.connection.hub.start().done(function () {
        $('#callSignalButton').click(function () {
            var sel = document.getElementById("stoSelect");
            var stoNaziv = sel.options[sel.selectedIndex].text;
            
            hub.server.send(stoNaziv, $('#datetimepicker').val(), $('#krajTerminaInput').val());
            // Clear text box and reset focus for next comment.
            $('#message').val('').focus();
        });
    });
});