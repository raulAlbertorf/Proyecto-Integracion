var loadMap = function (id) {

    var HELSINKI = [60.1708, 24.9375];
    var map = L.map(id);
    var marker;
    var circle;
    var tile_url = 'http://{s}.tile.osm.org/{z}/{x}/{y}.png';
    var layer = L.tileLayer(tile_url, {
        attribution: 'OSM'
    });
    map.addLayer(layer);
    map.setView(HELSINKI, 19);
    console.log(id);
    map.locate({ setView: true, watch: false }) /* This will return map so you can do chaining */
        .on('locationfound', function (e) {
            marker = L.marker([e.latitude, e.longitude]).bindPopup('Mi ubicacion actual');
            console.log(e.latitude);
            console.log(e.longitude);
            circle = L.circle([e.latitude, e.longitude], e.accuracy / 2, {
                weight: 1,
                color: 'blue',
                fillColor: '#cacaca',
                fillOpacity: 0.2
            });
            map.addLayer(marker);
            map.addLayer(circle);
        })
       .on('locationerror', function (e) {
           console.log(e);
           alert("Location access denied.");
       });






    var cont = document.getElementById("report_count").value;
    console.log(cont);
    for (i = 0; i < cont; i++) {
        var latitude = document.getElementById('Latitud+' + i).value;
        var longitude = document.getElementById("Longitud+" + i).value;
        var incidente = document.getElementById("incidente+" + i).value;
        switch (incidente) {
            case 'Homicidio':
                //var marker = L.marker([latitude, longitude], { icon: L.AwesomeMarkers.icon({ icon: 'exclamation-triangle', prefix: 'fa', markerColor: 'red', iconColor: 'white' }) }).addTo(map);
                
                var marker = new L.Marker.Text([latitude, longitude], 'Sweet!');

                map.addLayer(new L.Marker([latitude, longitude], { opacity: 0.5 }));

                map.addLayer(marker);

                //var marker = new L.marker([latitude, longitude], { opacity: 0.01 }); //opacity may be set to zero

                //marker.bindTooltip("Homicidio", { permanent: true, className: "homicidio", offset: [0, 0] });
                //marker.addTo(map);
                break;
            case "Suicidio":
                //var marker = L.marker([latitude, longitude], { icon: L.AwesomeMarkers.icon({ icon: 'exclamation-triangle', prefix: 'fa', markerColor: 'darkred', iconColor: 'white' }) }).addTo(map);
                //L.Marker.Text([latitude, longitude], 'Suicidio').addTo(map);
                //marker.bindTooltip("Suicidio", { permanent: true, className: "suicidio", offset: [0, 0] });
                //marker.addTo(map);
                break;
            case "RoboAsalto":
                //var marker = L.marker([latitude, longitude], { icon: L.AwesomeMarkers.icon({ icon: 'exclamation-triangle', prefix: 'fa', markerColor: 'lightred', iconColor: 'white' }) }).addTo(map);
                //L.Marker.Text([latitude, longitude], 'Robo o Asalto').addTo(map);
                //marker.bindTooltip("Robo o Asalto", { permanent: true, className: "roboasalto", offset: [0, 0] });
                //marker.addTo(map);
                break;
            case "Violacion":
                //var marker = L.marker([latitude, longitude], { icon: L.AwesomeMarkers.icon({ icon: 'exclamation-triangle', prefix: 'fa', markerColor: 'orange', iconColor: 'white' }) }).addTo(map);
                //L.Marker.Text([latitude, longitude], 'Violación').addTo(map);
                //marker.bindTooltip("Violación", { permanent: true, className: "violacion", offset: [0, 0] });
                //marker.addTo(map);
                break;
            case "ExplotacionSexual":
                //var marker = L.marker([latitude, longitude], { icon: L.AwesomeMarkers.icon({ icon: 'exclamation-triangle', prefix: 'fa', markerColor: 'beige', iconColor: 'white' }) }).addTo(map);
                //L.Marker.Text([latitude, longitude], 'Explotación Sexual').addTo(map);
                //marker.bindtooltip("explotación sexual", { permanent: true, classname: "explotacionsexual", offset: [0, 0] });
                //marker.addto(map);
                break;
                //case "Robo_Negocio_Con_Violencia":
                //    L.marker([latitude, longitude], { icon: L.AwesomeMarkers.icon({ icon: 'exclamation-triangle', prefix: 'fa', markerColor: 'green', iconColor: 'white' }) }).addTo(map);
                //    break;
                //case "Robo_CasaHabitacion_Sin_Violencia":
                //    L.marker([latitude, longitude], { icon: L.AwesomeMarkers.icon({ icon: 'exclamation-triangle', prefix: 'fa', markerColor: 'lightgreen', iconColor: 'white' }) }).addTo(map);
                //    break;
                //case "Robo_CasaHabitacion_Con_Violencia":
                //    L.marker([latitude, longitude], { icon: L.AwesomeMarkers.icon({ icon: 'exclamation-triangle', prefix: 'fa', markerColor: 'blue', iconColor: 'white' }) }).addTo(map);
                //    break;
                //case "HomicidioDoloso":
                //    L.marker([latitude, longitude], { icon: L.AwesomeMarkers.icon({ icon: 'exclamation-triangle', prefix: 'fa', markerColor: 'darkblue', iconColor: 'white' }) }).addTo(map);
                //    break;
                //case "Robo_Transeunte_Sin_Violencia":
                //    L.marker([latitude, longitude], { icon: L.AwesomeMarkers.icon({ icon: 'exclamation-triangle', prefix: 'fa', markerColor: 'purple', iconColor: 'white' }) }).addTo(map);
                //    break;
                //case "Robo_Transeunte_Con_Violencia":
                //    L.marker([latitude, longitude], { icon: L.AwesomeMarkers.icon({ icon: 'exclamation-triangle', prefix: 'fa', markerColor: 'cadetblue', iconColor: 'white' }) }).addTo(map);
                //    break;
                //case "Voilacion":
                //    L.marker([latitude, longitude], { icon: L.AwesomeMarkers.icon({ icon: 'exclamation-triangle', prefix: 'fa', markerColor: 'gray', iconColor: 'white' }) }).addTo(map);
                //    break;
                //case "Lesiones_Arma_Fuego":
                //    L.marker([latitude, longitude], { icon: L.AwesomeMarkers.icon({ icon: 'exclamation-triangle', prefix: 'fa', markerColor: 'black', iconColor: 'white' }) }).addTo(map);
                //    break;
        }

        console.log(latitude + " " + longitude + " " + incidente);
    }
};

loadMap('map');
