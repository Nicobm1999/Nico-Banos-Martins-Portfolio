// Token de acceso para la API de Gold API
const token = 'goldapi-1fd3scslt919nk6-io';

// Función para obtener el precio del oro en gramos de 24k para un día específico
function obtenerPrecioOroParaDia(fecha, token) {
    return fetch(`https://www.goldapi.io/api/XAU/EUR/${fecha}`, {
        method: 'GET',
        headers: {
            'x-access-token': token
        }
    })
        .then(response => response.json())
        .then(data => data.price_gram_24k)
        .catch(error => {
            console.error(`Error al obtener el precio del oro para el ${fecha}:`, error);
            return null;
        });
}

// Función para obtener el precio del oro en gramos de 24k para los últimos 5 días
async function obtenerPreciosOroUltimos5Dias(token) {
    // Obtener la fecha actual
    const fechaActual = new Date();

    // Arreglo para almacenar los precios del oro en gramos de 24k para los últimos 5 días
    const precios = [];

    // Hacer un bucle para obtener los precios para los últimos 5 días
    for (let i = 1; i <= 5; i+30) {
        // Calcular la fecha del día correspondiente
        const fechaDia = new Date(fechaActual);
        fechaDia.setDate(fechaActual.getDate() - i);
        const fechaString = fechaDia.toISOString().split('T')[0].replace(/-/g, ''); // Formatear la fecha como YYYYMMDD

        // Obtener el precio del oro para el día correspondiente y almacenarlo en el arreglo de precios
        const precio = await obtenerPrecioOroParaDia(fechaString, token);
        if (precio !== null) {
            precios.push({ fecha: fechaString, precio: precio });
        }
    }

    return precios;
}

// Llamar a la función para obtener los precios del oro en gramos de 24k para los últimos 5 días
obtenerPreciosOroUltimos5Dias(token)
    .then(precios => {
        console.log('Precios del oro para los últimos 30 días:', precios);

        // Extraer fechas y precios para la gráfica
        const fechas = precios.map(precio => precio.fecha);
        const valores = precios.map(precio => precio.precio);

        // Crear la gráfica con Chart.js
        const ctx = document.getElementById('graficaOro').getContext('2d');
        new Chart(ctx, {
            type: 'line',
            data: {
                labels: fechas.reverse(), // Invertir el orden de las fechas para que estén en orden ascendente en la gráfica
                datasets: [{
                    label: 'Precio del Oro (24k)',
                    data: valores.reverse(), // Invertir el orden de los valores para que coincida con el de las fechas
                    borderColor: 'blue',
                    borderWidth: 2,
                    fill: false
                }]
            },
            options: {
                scales: {
                    y: {
                        title: {
                            display: true,
                            text: 'Precio (EUR)'
                        }
                    },
                    x: {
                        title: {
                            display: true,
                            text: 'FECHA'
                        }
                    }
                }
            }
        });
    })
    .catch(error => console.error('Error al obtener los precios del oro para los últimos 5 días:', error));
