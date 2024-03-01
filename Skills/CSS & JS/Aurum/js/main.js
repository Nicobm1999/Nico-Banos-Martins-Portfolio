document.addEventListener("DOMContentLoaded", function () {
    let inversionInput = document.getElementById('inversion');
    let rentabilidadInput = document.getElementById('rentabilidad');
    let duracionInput = document.getElementById('duracion');
    let submit = document.getElementById('submit');

    submit.addEventListener("click", function (event) {
        event.preventDefault(); // Evita que el formulario se envíe y recargue la página

        let inversion = parseFloat(inversionInput.value);
        let rentabilidad = parseFloat(rentabilidadInput.value);
        let duracion = parseInt(duracionInput.value);
        let acumuladoTotal = 0;

        for (let i = 1; i <= duracion; i++) {
            let beneficioAnual = inversion * (rentabilidad / 100);
            inversion += beneficioAnual;
        }

        alert("Beneficio mensual: " + ((inversion * rentabilidad / 100) / 12));
        alert("Valor total acumulado: " + inversion);
    });
});