function mostrarDatos(idDiv, metal) {
    fetch(`https://api.gold-api.com/price/${metal}`)
        .then(response => response.json())
        .then(data => {
            const div = document.getElementById(idDiv);
            const pNombre = document.createElement('p');
            const pPrecio = document.createElement('p');
            pPrecio.textContent = ((data.price / 28.3495) * 0.92).toFixed(3) + " $/g";
            const pActualizacion = document.createElement('p');
            div.appendChild(pNombre);
            div.appendChild(pPrecio);
        })
        .catch(error => {
            console.error('Error al obtener los datos:', error);
        });
}
mostrarDatos('gold', 'XAU');
mostrarDatos('silver', 'XAG');


document.addEventListener('DOMContentLoaded', function () {
    function calculateChest(idDiv, metal) {
        const metalWeight = parseFloat(document.getElementById(idDiv).textContent);
        fetch(`https://api.gold-api.com/price/${metal}`)
            .then(response => response.json())
            .then(data => {
                const metalChestValue = ((data.price / 28.3495) * metalWeight).toFixed(2) + " $";
                const metalWeightDiv = document.getElementById(idDiv);
                const pMetalChestValue = document.createElement('p');
                pMetalChestValue.textContent = metalChestValue;
                metalWeightDiv.appendChild(pMetalChestValue);
            })
            .catch(error => {
                console.error('Error al obtener los datos:', error);
            });
    }

    calculateChest('gold-weight', 'XAU');
    calculateChest('silver-weight', 'XAG');
});





