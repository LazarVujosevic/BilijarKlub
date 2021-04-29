$(function () {
    var hub = $.connection.rezervacijaHub;
    hub.client.dodajRezervaciju = function (stoId, pocetak, kraj) {
        document.getElementById('rezervacijeTable').innerHTML += '<tr> <td>' + stoId + '</td> <td>' + pocetak + '</td> <td>' + kraj + '</td>' + '</tr>';
    }

    $.connection.hub.start().done(function () {
        $('#callSignalButton').click(function () {
            var sel = document.getElementById("stoSelect");
            var stoNaziv = sel.options[sel.selectedIndex].text;
            
            hub.server.send(stoNaziv, $('#datetimepicker').val(), $('#krajTerminaInput').val());
            $('#message').val('').focus();
        });
    });
});