document.addEventListener('DOMContentLoaded', function () {

    let map = L.map('map');

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors'
    }).addTo(map);
    map.setMaxZoom(18);
    map.setMinZoom(4);

    let markers = [];

    let ids = document.getElementsByClassName('id');
    let coordinates = document.getElementsByClassName('coordinates');
    let cities = document.getElementsByClassName('city');
    let countries = document.getElementsByClassName('country');
    let adresses = document.getElementsByClassName('adress');

    for (let i = 0; i < ids.length; i++) {
        let adress = adresses[i].textContent;
        let city = cities[i].textContent;
        let country = countries[i].textContent;
        let coordinateString = coordinates[i].textContent;
        let coordinatesArray = coordinateString.split(',').map(coord => parseFloat(coord));
;

        popupContent = `<div class="text-center">
            <p>
                ${country}, ${city}, ${adress} <br>
            </p>
            <button class="verDetalles btn btn-outline-dark">Ver Detalles</button>
            </div>`;       

        let propertyIcon = L.icon({
            iconUrl: '/images/icons/location.png',
            iconSize: [18, 18],
            iconAnchor: [9, 9] 
        });


        let marker = L.marker(coordinatesArray, { icon: propertyIcon }).bindPopup(popupContent);
        markers.push(marker);
        marker.addTo(map);
        function redirectToDetails() {
            window.location.href = 'details/' + ids[i].textContent;
        }
        marker.on('popupopen', function () {
            document.querySelector('.verDetalles').addEventListener('click', redirectToDetails);
        });
    }

    let bounds = L.latLngBounds(markers.map(marker => marker.getLatLng()));
    map.fitBounds(bounds);
});