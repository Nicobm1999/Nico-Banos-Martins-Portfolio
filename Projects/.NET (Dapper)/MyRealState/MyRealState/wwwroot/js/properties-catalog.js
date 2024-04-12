document.addEventListener('DOMContentLoaded', function () {
    let toggleBtn = document.getElementById('toggle-btn');
    let dropMenu = document.getElementById('drop-menu');
    let likeBody = document.getElementById('like-body');
    let as = document.getElementsByTagName('a');

    function invalidateLink(event) {
        event.preventDefault();
    }
    toggleBtn.addEventListener('click', function (event) {
        event.stopPropagation();
        likeBody.style.filter = 'brightness(40%)';
        likeBody.style.opacity = '0.9';
        dropMenu.style.display = 'block';        Array.from(as).forEach(function (a) {
            a.addEventListener('click', invalidateLink);
        });
    });
    likeBody.addEventListener('click', function () {
        if (dropMenu.style.display === 'block') {
            likeBody.style.filter = 'none';
            likeBody.style.opacity = '1';
            dropMenu.style.display = 'none';
        }
        Array.from(as).forEach(function (a) {
            a.removeEventListener('click', invalidateLink);
        });
    });
});


//Falta evitar el overflow y del body cuando esta abierto del dropmenu.