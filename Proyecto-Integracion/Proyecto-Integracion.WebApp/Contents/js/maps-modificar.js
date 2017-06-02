var loadMap = function (id) {

    var lati = document.getElementById('Latitud').value;
    var long = document.getElementById('Longitud').value;
    console.log(parseFloat(lati) + " " + parseFloat(long));
    var HELSINKI = [parseFloat(lati), parseFloat(long)];
    var map = L.map(id);
    var marker = L.marker([parseFloat(lati), parseFloat(long)]).bindPopup('Estoy Aquí');
    var circle = L.circle([parseFloat(lati), parseFloat(long)], {
        weight: 1,
        color: 'blue',
        fillColor: '#cacaca',
        fillOpacity: 0.2
    });
    map.addLayer(marker);
    map.addLayer(circle);
    var tile_url = 'http://{s}.tile.osm.org/{z}/{x}/{y}.png';
    var layer = L.tileLayer(tile_url, {
        attribution: 'OSM'
    });
    map.addLayer(layer);
    map.setView(HELSINKI, 19);

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
        .setContent('<p>Tu estas aquí</p>')
        .openOn(map);
    });
};

loadMap('map');
