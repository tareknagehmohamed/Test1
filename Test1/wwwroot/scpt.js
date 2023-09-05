window.Alert = function (message) {
    alert(message);
}

var map;

function initialize() {
    var Latlng = new google.maps.Latlng(40.716948, -74.003563);
    var options = {
        zoom: 14, center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById("map"), options);

}