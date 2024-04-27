document.addEventListener('DOMContentLoaded', function () {
    console.log("DOM LOADED details.js")
    let booleans = [
        document.getElementById('swimming-pool').getAttribute('data-value') === 'true',
        document.getElementById('garden').getAttribute('data-value') === 'true',
        document.getElementById('garage').getAttribute('data-value') === 'true',
        document.getElementById('security-system').getAttribute('data-value') === 'true',
        document.getElementById('heating').getAttribute('data-value') === 'true',
        document.getElementById('pets').getAttribute('data-value') === 'true',
        document.getElementById('appliances').getAttribute('data-value') === 'true',
        document.getElementById('air-conditioning').getAttribute('data-value') === 'true',
        document.getElementById('elevator').getAttribute('data-value') === 'true',
        document.getElementById('security-door').getAttribute('data-value') === 'true',
        document.getElementById('gated-community').getAttribute('data-value') === 'true',
        document.getElementById('balcony').getAttribute('data-value') === 'true'
    ];
    let cols = [
        document.getElementById('swimming-pool-sym'),
        document.getElementById('garden-sym'),
        document.getElementById('garage-sym'),
        document.getElementById('security-system-sym'),
        document.getElementById('heating-sym'),
        document.getElementById('pets-sym'),
        document.getElementById('appliances-sym'),
        document.getElementById('air-conditioning-sym'),
        document.getElementById('elevator-sym'),
        document.getElementById('security-door-sym'),
        document.getElementById('gated-community-sym'),
        document.getElementById('balcony-sym')
    ];
    for (let i = 0; i < booleans.length; i++) {
        if (!booleans[i]) {
            cols[i].style.display = "none";
        }
    }
    if (!booleans.includes(true)) {
        document.getElementById('offer').style.display = "none";
    }
    let placeDescription = document.getElementById('place-description');
    if (placeDescription == null || placeDescription == "") {
        placeDescription.style.display = "none";
    }

});
