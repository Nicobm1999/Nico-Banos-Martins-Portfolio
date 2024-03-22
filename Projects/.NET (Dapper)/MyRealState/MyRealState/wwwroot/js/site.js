document.addEventListener('DOMContentLoaded', function () {

    let map = L.map('map').setView([40.416775, -3.703790], 5);
    let markers = [];

    // Crear iconos para los tipos de propiedad
    let houseIcon = L.icon({
        iconUrl: '../images/icons/house.png',
        iconSize: [30, 30],
        iconAnchor: [15, 15], // Punto de anclaje del icono
        popupAnchor: [0, -15] // Punto de anclaje del popup
    });

    let apartmentIcon = L.icon({
        iconUrl: '../images/icons/apartment.png',
        iconSize: [30, 30],
        iconAnchor: [15, 15], // Punto de anclaje del icono
        popupAnchor: [0, -15] // Punto de anclaje del popup
    });

    // Obtener la información de las propiedades y crear marcadores
    let areas = document.getElementsByClassName('area');
    let types = document.getElementsByClassName('type');
    let statuss = document.getElementsByClassName('status');
    let coordinates = document.getElementsByClassName('coordinates');

    for (let i = 0; i < areas.length; i++) {
        let area = areas[i].textContent;
        let type = types[i].textContent.trim().toLowerCase(); // Convertir a minúsculas y eliminar espacios en blanco
        let status = statuss[i].textContent;
        let coordinateString = coordinates[i].textContent;
        let coordinatesArray = coordinateString.split(',').map(coord => parseFloat(coord));
        console.log("Tipo de propiedad:", type); // Agregamos esta línea para verificar el tipo de propiedad obtenido
        console.log("Tipo de propiedad (desde HTML):", types[i].textContent.trim());

        console.log("Tipo de propiedad (antes de la comparación):", type);
        if (type.toLowerCase() === "hou") {
            icon = houseIcon;
            type.textContent = "hola";
        } else {
            icon = apartmentIcon;
        }


        console.log("Tipo de propiedad:", type); // Imprimir el tipo obtenido
        console.log("Comparación con 'apt':", type === "Apt"); // Verificar si la comparación es verdadera
        console.log("Icono seleccionado:", icon); // Imprimir el icono seleccionado


        // Crear el contenido del popup
        let popupContent = `
        <strong>Área:</strong> ${area}<br>
        <strong>Tipo:</strong> ${type}<br>
        <strong>Estado:</strong> ${status}<br>
        <strong>Coordenadas:</strong> ${coordinateString}<br>
    `;

        // Crear el marcador y asociarlo con el pop-up dinámico
        let marker = L.marker(coordinatesArray, { icon: icon }).bindPopup(popupContent);
        markers.push(marker);
    }


    // Añadir todos los marcadores al mapa
    markers.forEach(function (marker) {
        marker.addTo(map);
    });

    // Añadir capa de tiles al mapa
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

});