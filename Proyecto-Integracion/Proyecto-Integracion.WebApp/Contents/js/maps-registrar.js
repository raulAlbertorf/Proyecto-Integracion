﻿var loadMap = function (id) {

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

    map.locate({ setView: true, watch: false}) /* This will return map so you can do chaining */
        .on('locationfound', function (e) {
            marker = L.marker([e.latitude, e.longitude]).bindPopup('Ubicacion actual');
            console.log(e.latitude);
            console.log(e.longitude);
            var long = document.getElementById('Longitud');
            long.value = e.longitude
            
            var lati = document.getElementById('Latitud');
            lati.value = e.latitude;
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
    
    
    map.on('click', function (e) {
        var popLocation = e.latlng;
        var long = document.getElementById('Longitud');
        long.value = popLocation.lng;

        var lati = document.getElementById('Latitud');
        lati.value = popLocation.lat;
        console.log(marker);
        if (marker && circle) {
            marker.setLatLng([popLocation.lat, popLocation.lng]);
            circle.setLatLng([popLocation.lat, popLocation.lng]);
        } else {
            marker = L.marker([popLocation.lat, popLocation.lng]).addTo(map);
            circle = L.circle([popLocation.lat, popLocation.lng], e.accuracy / 2, {
                weight: 1,
                color: 'blue',
                fillColor: '#cacaca',
                fillOpacity: 0.2
            }).addTo(map);
        }
        var popup = L.popup()
        .setLatLng(popLocation)
        .setContent('<p>Ubicación nueva</p>')
        .openOn(map);
    });
};

loadMap('map');
