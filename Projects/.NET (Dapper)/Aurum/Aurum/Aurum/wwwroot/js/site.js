// Función para obtener y mostrar los datos de la API
function mostrarDatos(idDiv, metal) {
    fetch(`https://api.gold-api.com/price/${metal}`)
        .then(response => response.json())
        .then(data => {
            const div = document.getElementById(idDiv);
            const pNombre = document.createElement('p');
            pNombre.textContent = 'Nombre del metal: ' + data.name;
            const pPrecio = document.createElement('p');
            pPrecio.textContent = 'Precio: ' + (data.price / 28.3495)*0.92;
            const pActualizacion = document.createElement('p');
            pActualizacion.textContent = 'Última actualización: ' + data.updatedAtReadable;
            div.appendChild(pNombre);
            div.appendChild(pPrecio);
            div.appendChild(pActualizacion);
        })
        .catch(error => {
            console.error('Error al obtener los datos:', error);
        });
}

// Llamar a la función para cada div con su respectivo id
mostrarDatos('gold', 'XAU');
mostrarDatos('silver', 'XAG');
