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
};

loadMap('map');
