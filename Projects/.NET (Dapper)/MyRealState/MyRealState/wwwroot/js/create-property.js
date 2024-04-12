document.addEventListener('DOMContentLoaded', function () {

    document.getElementById('HasMortgage').addEventListener('change', function () {
        var mortgageField = document.getElementById('MortgageField');
        if (this.value === 'true') {
            mortgageField.style.display = 'block';
            document.getElementById('Mortgage').required = true; // Marcar como requerido
        } else {
            mortgageField.style.display = 'none';
            document.getElementById('Mortgage').required = false; // No requerido
        }
    });
    function getCurrentDateTime() {
        var now = new Date();
        var year = now.getFullYear();
        var month = String(now.getMonth() + 1).padStart(2, '0');
        var day = String(now.getDate()).padStart(2, '0');
        var hours = String(now.getHours()).padStart(2, '0');
        var minutes = String(now.getMinutes()).padStart(2, '0');

        return `${year}-${month}-${day} ${hours}:${minutes}`;
    }


    // Asignar la fecha actual a los campos ocultos
    document.addEventListener('DOMContentLoaded', function () {
        var dateListedInput = document.getElementById('DateListed');
        var lastUpdatedInput = document.getElementById('LastUpdated');

        dateListedInput.value = getCurrentDate();
        lastUpdatedInput.value = getCurrentDate();




    });
    document.getElementById('HasGarage').addEventListener('change', function () {
        var garageFields = document.getElementById('garageFields');
        if (this.value === 'true') {
            garageFields.style.display = 'block';
            document.getElementById('GarageCapacity').required = true; // Marcar como requerido
            document.getElementById('NumberOfParkingSpaces').required = true; // Marcar como requerido
        } else {
            garageFields.style.display = 'none';
            document.getElementById('GarageCapacity').required = false; // No requerido
            document.getElementById('NumberOfParkingSpaces').required = false; // No requerido
        }
    });
    document.getElementById('HasGarden').addEventListener('change', function () {
        var gardenField = document.getElementById('gardenField');
        if (this.value === 'true') {
            gardenField.style.display = 'block';
            document.getElementById('LandArea').required = true; // Marcar como requerido
        } else {
            gardenField.style.display = 'none';
            document.getElementById('LandArea').required = false; // No requerido
        }
    });

    document.querySelector('form').addEventListener('submit', function (event) {
        event.preventDefault(); 
        let appraisal = 0;
        function obtenerValoresDelFormulario() {
            var valores = {};

            valores.area = parseFloat(document.getElementById('Area').value);
            valores.type = document.getElementById('Type').value;
            valores.address = document.getElementById('Address').value;
            valores.bedrooms = parseInt(document.getElementById('Bedrooms').value);
            valores.bathrooms = parseInt(document.getElementById('Bathrooms').value);
            valores.mortgage = parseFloat(document.getElementById('Mortgage').value);
            valores.rentPrice = parseFloat(document.getElementById('RentPrice').value);
            valores.status = document.getElementById('Status').value;
            valores.country = document.getElementById('Country').value;
            valores.city = document.getElementById('City').value;
            valores.coordenates = document.getElementById('Coordenates').value;
            valores.dateListed = new Date(document.getElementById('DateListed').value);
            valores.lastUpdated = new Date(document.getElementById('LastUpdated').value);
            valores.description = document.getElementById('Description').value;
            valores.ownerID = parseInt(document.getElementById('OwnerID').value);
            valores.yearBuilt = parseInt(document.getElementById('YearBuilt').value);
            valores.constructionMaterial = document.getElementById('ConstructionMaterial').value;
            valores.hasSwimmingPool = document.getElementById('HasSwimmingPool').checked;
            valores.hasGarden = document.getElementById('HasGarden').checked;
            valores.garageCapacity = parseInt(document.getElementById('GarageCapacity').value);
            valores.landArea = parseFloat(document.getElementById('LandArea').value);
            valores.appraisal = parseFloat(document.getElementById('Appraisal').value);
            valores.propertyViews = document.getElementById('PropertyViews').value;
            valores.hasFireplace = document.getElementById('HasFireplace').checked;
            valores.hasSecuritySystem = document.getElementById('HasSecuritySystem').checked;
            valores.isNewConstruction = document.getElementById('IsNewConstruction').checked;
            valores.energyEfficiencyRating = document.getElementById('EnergyEfficiencyRating').value;
            valores.distanceToAmenities = parseFloat(document.getElementById('DistanceToAmenities').value);
            valores.numberOfFloors = parseInt(document.getElementById('NumberOfFloors').value);
            valores.isWaterfront = document.getElementById('IsWaterfront').checked;
            valores.condition = document.getElementById('Condition').value;
            valores.hasBasement = document.getElementById('HasBasement').checked;
            valores.heatingType = document.getElementById('HeatingType').value;
            valores.hasAirConditioning = document.getElementById('HasAirConditioning').checked;
            valores.hasElevator = document.getElementById('HasElevator').checked;
            valores.hasGarage = document.getElementById('HasGarage').checked;
            valores.hasSecurityDoor = document.getElementById('HasSecurityDoor').checked;
            valores.isInGatedCommunity = document.getElementById('IsInGatedCommunity').checked;
            valores.neighborhoodSafety = document.getElementById('NeighborhoodSafety').value;
            valores.numberOfParkingSpaces = parseInt(document.getElementById('NumberOfParkingSpaces').value);
            valores.isSmartHome = document.getElementById('IsSmartHome').checked;
            valores.hasTerrace = document.getElementById('HasTerrace').checked;
            valores.surroundings = document.getElementById('Surroundings').value;

            return valores;
        }

        function calcularTasacion(valores) {
            // Factor base para la tasaci�n
            var factorBase = 1000;

            // Factores adicionales basados en las caracter�sticas de la propiedad
            var factorArea = 10; // $10 por cada metro cuadrado
            var factorBedrooms = 5000; // $5000 por cada habitaci�n
            var factorBathrooms = 3000; // $3000 por cada ba�o
            var factorGarageCapacity = 2.5; // $2000 por cada espacio de estacionamiento en garaje

            // Factores adicionales para caracter�sticas booleanas
            var factorSwimmingPool = 10000; // $10000 si tiene piscina
            var factorGarden = 5000; // $5000 si tiene jard�n
            var factorFireplace = 3000; // $3000 si tiene chimenea
            var factorAirConditioning = 4000; // $4000 si tiene aire acondicionado
            var factorElevator = 7000; // $7000 si tiene ascensor
            var factorSecurityDoor = 6000; // $6000 si tiene puerta de seguridad
            var factorInGatedCommunity = 8000; // $8000 si est� en una comunidad cerrada
            var factorSmartHome = 6000; // $6000 si es una casa inteligente
            var factorHasTerrace = 4000; // $4000 si tiene terraza
            var factorIsWaterfront = 12000; // $12000 si es frente al agua
            var factorHasBasement = 3000; // $3000 si tiene s�tano
            var factorIsNewConstruction = 9000; // $9000 si es construcci�n nueva
            var factorHasSecuritySystem = 5000; // $5000 si tiene sistema de seguridad

            // Factores adicionales para otras caracter�sticas
            var factorYearBuilt = 50; // $50 por cada a�o de antig�edad
            var factorLandArea = 5; // $5 por cada metro cuadrado de �rea de terreno
            var factorPropertyViews = 3000; // $3000 por cantidad de vistas a la propiedad
            var factorEnergyEfficiencyRating = 2000; // $2000 por calificaci�n de eficiencia energ�tica
            var factorDistanceToAmenities = -20; // -$20 por cada metro de distancia a servicios
            var factorNumberOfFloors = 2000; // $2000 por n�mero de pisos
            var factorHeatingType = 3000; // $3000 por tipo de calefacci�n
            var factorNeighborhoodSafety = 5000; // $5000 por seguridad del vecindario
            var factorNumberOfParkingSpaces = 1000; // $1000 por n�mero de espacios de estacionamiento

            // Calcular la tasaci�n base
            var tasacion = factorBase;
            console.log("Tasaci�n 1:", tasacion);

            // Considerar caracter�sticas espec�ficas de la propiedad
            tasacion += parseFloat(valores.area) * factorArea;
            console.log("Tasaci�n 1.1:", tasacion);
            tasacion += valores.bedrooms * factorBedrooms;
            console.log("Tasaci�n 1.2:", tasacion);
            tasacion += valores.bathrooms * factorBathrooms;
            console.log("Tasaci�n 1.3:", tasacion);

            tasacion += (new Date().getFullYear() - valores.yearBuilt) * factorYearBuilt;
            console.log("Tasaci�n 2:", tasacion);
            tasacion += parseFloat(valores.landArea) * factorLandArea;      
            console.log("Tasaci�n 3:", tasacion);
            tasacion += valores.numberOfFloors * factorNumberOfFloors;
            console.log("Tasaci�n 4:", tasacion);




            // Considerar caracter�sticas booleanas
            if (valores.hasSwimmingPool) {
                tasacion += factorSwimmingPool;
            }
            if (valores.hasGarden) {
                tasacion += factorGarden;
            }
            if (valores.hasGarage) {
                tasacion += hasGarage;
                tasacion += valores.garageCapacity * factorGarageCapacity;
                tasacion += valores.numberOfParkingSpaces * factorNumberOfParkingSpaces;

            }
            if (valores.hasFireplace) {
                tasacion += factorFireplace;
            }
            if (valores.hasAirConditioning) {
                tasacion += factorAirConditioning;
            }
            if (valores.hasElevator) {
                tasacion += factorElevator;
            }
            if (valores.hasSecurityDoor) {
                tasacion += factorSecurityDoor;
            }
            if (valores.isInGatedCommunity) {
                tasacion += factorInGatedCommunity;
            }
            if (valores.isSmartHome) {
                tasacion += factorSmartHome;
            }
            if (valores.hasTerrace) {
                tasacion += factorHasTerrace;
            }
            if (valores.isWaterfront) {
                tasacion += factorIsWaterfront;
            }
            if (valores.hasBasement) {
                tasacion += factorHasBasement;
            }
            if (valores.isNewConstruction) {
                tasacion += factorIsNewConstruction;
            }
            if (valores.hasSecuritySystem) {
                tasacion += factorHasSecuritySystem;
            }

            console.log("Tasaci�n 3:", tasacion);

            /*
            // Considerar otras caracter�sticas
            tasacion += (new Date().getFullYear() - valores.yearBuilt) * factorYearBuilt;
            tasacion += valores.landArea * factorLandArea;
            tasacion += valores.propertyViews * factorPropertyViews;
            tasacion += valores.energyEfficiencyRating * factorEnergyEfficiencyRating;
            tasacion += valores.distanceToAmenities * factorDistanceToAmenities;
            tasacion += valores.numberOfFloors * factorNumberOfFloors;
            tasacion += valores.heatingType.length * factorHeatingType; // Se asume que la longitud del tipo de calefacci�n afecta al valor
            tasacion += valores.neighborhoodSafety * factorNeighborhoodSafety;
            tasacion += valores.numberOfParkingSpaces * factorNumberOfParkingSpaces;

            // Otros ajustes o factores podr�an ser agregados aqu� seg�n tus necesidades
            */
            return tasacion;

        }

        // Obtener los valores del formulario
        var valoresDelFormulario = obtenerValoresDelFormulario();

        // Calcular la tasaci�n utilizando los valores del formulario
        var tasacionPropiedad = calcularTasacion(valoresDelFormulario);

        console.log("Tasaci�n de la propiedad:", tasacionPropiedad);


        

      


        document.getElementById('Appraisal').value = tasacionPropiedad.toFixed(2);
    });
});

//En espera de modificar la clase Propiedades.cs