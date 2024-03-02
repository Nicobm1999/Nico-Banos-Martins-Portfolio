// Realiza una solicitud GET a la API de Gold API para obtener los datos del precio del oro de los últimos 5 días
fetch('https://www.goldapi.io/api/XAU/USD/last_5_days', {
    method: 'GET',
    headers: {
        'x-access-token': 'goldapi-21aslt8xh7lz-io'
    }
})
    .then(response => response.json())
    .then(data => {
        // Extrae las fechas y los precios del objeto de datos
        const fechas = data.map(dato => dato.timestamp);
        const precios = data.map(dato => dato.price);

        // Crea un nuevo gráfico utilizando Chart.js
        var ctx = document.getElementById('grafico-oro').getContext('2d');
        var graficoOro = new Chart(ctx, {
            type: 'line',
            data: {
                labels: fechas,
                datasets: [{
                    label: 'Precio del Oro (USD)',
                    data: precios,
                    borderColor: 'rgba(255, 159, 64, 1)',
                    backgroundColor: 'rgba(255, 159, 64, 0.2)',
                    borderWidth: 1
                }]
            },
            options: {
                scales: {
                    xAxes: [{
                        type: 'time',
                        time: {
                            unit: 'day',
                            displayFormats: {
                                day: 'MMM D'
                            }
                        },
                        scaleLabel: {
                            display: true,
                            labelString: 'Fecha'
                        }
                    }],
                    yAxes: [{
                        scaleLabel: {
                            display: true,
                            labelString: 'Precio (USD)'
                        }
                    }]
                }
            }
        });
    })
    .catch(error => {
        console.error('Error al obtener los datos del precio del oro:', error);
    });
