//var map = L.map('map').setView([51.505, -0.09], 13);

//L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
//    attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
//}).addTo(map);

//L.marker([51.5, -0.09]).addTo(map)
//    .bindPopup('A pretty CSS3 popup.<br> Easily customizable.')
//    .openPopup();

//this.map.locate({ setView: true});
var lon;
var lat;
var loadMap = function (id) {
    
    var HELSINKI = [60.1708, 24.9375];
    var map = L.map(id);
    var tile_url = 'http://{s}.tile.osm.org/{z}/{x}/{y}.png';
    var layer = L.tileLayer(tile_url, {
        attribution: 'OSM'
    });
    map.addLayer(layer);
    map.setView(HELSINKI, 19);

    map.locate({ setView: true, watch: true }) /* This will return map so you can do chaining */
        .on('locationfound', function (e) {
            var marker = L.marker([e.latitude, e.longitude]).bindPopup('Your are here :)');
            console.log(e.latitude);
            console.log(e.longitude);
            lon = e.longitude;
            lat = e.latitude;
            //document.getElementById("#inLongitud").innerText = lon;
            var circle = L.circle([e.latitude, e.longitude], e.accuracy / 2, {
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