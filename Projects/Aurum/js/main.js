document.addEventListener("DOMContentLoaded", function () {
    let title = document.getElementById('title');
    let minerals = document.querySelector('.minerals');

    title.addEventListener("click", function () {
        console.log("Mouse over title");
        minerals.style.visibility = "visible";
        title.style.visibility = "hidden";
    });
    
});