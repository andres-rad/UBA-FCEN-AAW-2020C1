var fromProjection = new OpenLayers.Projection("EPSG:4326");   // Transform from WGS 1984
var toProjection = new OpenLayers.Projection("EPSG:900913"); // to Spherical Mercator Projection

var zoom = 15;
var lat = Model.latitud;
var lon = Model.longitud;
var posTurnero = new OpenLayers.LonLat(lon, lat).transform(fromProjection, toProjection);

var map = new OpenLayers.Map("mapaTurnero");
var mapnik = new OpenLayers.Layer.OSM();

var markers = new OpenLayers.Layer.Markers("Markers");
var marker = new OpenLayers.Marker(posTurnero);
marker.id = Model.idTurnero;
marker.icon.imageDiv.title = "@Model.Concepto";
markers.addMarker(marker);

map.addLayer(mapnik);
map.addLayer(markers);
map.setCenter(posTurnero, zoom);