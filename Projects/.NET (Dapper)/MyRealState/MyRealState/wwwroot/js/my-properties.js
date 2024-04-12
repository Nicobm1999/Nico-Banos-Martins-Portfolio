document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.property').forEach(function (property) {
        let typeElement = property.querySelector(".type"); // Selecciona el elemento .type dentro de la propiedad
        let country = property.querySelector(".country").textContent.trim();

        console.log(typeElement);

        if (typeElement) { // Verifica si se encontró un elemento .type
            let type = typeElement.textContent.trim(); // Obtiene el tipo de propiedad

            let typeIcon; // Variable para almacenar el HTML del ícono

            switch (type) {
                case "Hou":
                    typeIcon = `<span class="material-symbols-outlined ">house</span>`;
                    break;
                case "Apt":
                    typeIcon = `<span class="material-symbols-outlined">apartment</span>`;
                    break;
                default:
                    typeIcon = `<span class="material-symbols-outlined fw-bold">location_on</span>`;
                    break;
            }

            typeElement.innerHTML = typeIcon; // Asigna el HTML del ícono al elemento .type
        }


    });
});


//Buscar la manera de no repetir el diccionario countries mas de una vez 