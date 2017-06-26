var loadMap = function (id) {

    var HELSINKI = [60.1708, 24.9375];
    var map = L.map(id);
    var marker;
    var circle;
    var tile_url = 'http://{s}.tile.osm.org/{z}/{x}/{y}.png';
    var layer = L.tileLayer(tile_url, {
        attribution: 'OSM'
    });
    //var drawnItems = new L.FeatureGroup();
    //map.addLayer(drawnItems);
    //var drawControl = new L.Control.Draw({
    //    edit: {
    //        featureGroup: drawnItems
    //    }
    //});
    //map.addControl(drawControl);
    map.addLayer(layer);
    map.setView(HELSINKI, 50);
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
                var marker = L.marker([latitude, longitude], { icon: L.AwesomeMarkers.icon({icon: 'exclamation-triangle', prefix: 'fa', markerColor: 'red', iconColor: 'white' }) }).addTo(map);
                marker.bindTooltip("Homicidio", { permanent: true, className: "homicidio", offset: [0, 0] });
                marker.addTo(map);
                break;
            case "Suicidio":
                var marker = L.marker([latitude, longitude], { icon: L.AwesomeMarkers.icon({ icon: 'exclamation-triangle', prefix: 'fa', markerColor: 'darkred', iconColor: 'white' }) });
                //L.Marker.Text([latitude, longitude], 'Suicidio').addTo(map);
                marker.bindTooltip("Suicidio", { permanent: true, className: "suicidio", offset: [0, 0] });
                marker.addTo(map);
                break;
            case "RoboAsalto":
                var marker = L.marker([latitude, longitude], { icon: L.AwesomeMarkers.icon({ icon: 'exclamation-triangle', prefix: 'fa', markerColor: 'lightred', iconColor: 'white' }) });
                //L.Marker.Text([latitude, longitude], 'Robo o Asalto').addTo(map);
                marker.bindTooltip("Robo o Asalto", { permanent: true, className: "roboasalto", offset: [0, 0] });
                marker.addTo(map);
                break;
            case "Violacion":
                var marker = L.marker([latitude, longitude], { icon: L.AwesomeMarkers.icon({ icon: 'exclamation-triangle', prefix: 'fa', markerColor: 'orange', iconColor: 'white' }) });
                //L.Marker.Text([latitude, longitude], 'Violación').addTo(map);
                marker.bindTooltip("Violación", { permanent: true, className: "violacion", offset: [0, 0] });
                marker.addTo(map);
                break;
            case "ExplotacionSexual":
                var marker = L.marker([latitude, longitude], { icon: L.AwesomeMarkers.icon({ icon: 'exclamation-triangle', prefix: 'fa', markerColor: 'black', iconColor: 'white' }) });
                //L.Marker.Text([latitude, longitude], 'Violación').addTo(map);
                marker.bindTooltip("Explotación Sexual", { permanent: true, className: "explotacionsexual", offset: [0, 0] });
                marker.addTo(map);
        }

        console.log(latitude + " " + longitude + " " + incidente);
    }
};

loadMap('map');




//var marker = new L.Marker.Text([latitude, longitude], 'Sweet!');

//map.addLayer(new L.Marker([latitude, longitude], { opacity: 0.5 }));

//map.addLayer(marker);

//var marker = new L.marker([latitude, longitude], { icon: L.AwesomeMarkers.icon({ icon: 'exclamation-triangle', prefix: 'fa', markerColor: 'red', iconColor: 'white', fillOpacity:0.1 }) }); //opacity may be set to zero
