document.addEventListener('DOMContentLoaded', function () {
    let subjectsString = document.getElementById('subject-string');
    let subjects = document.getElementsByClassName('check-subject');
    let subjectsChecked = [];
    for (let i = 0; i < subjects.length; i++) {
        subjects[i].addEventListener('click', function () {
            subjectsString.textContent = "";
            if (subjects[i].checked) {
                subjectsChecked.push(subjects[i].value);
            } else {
                let index = subjectsChecked.indexOf(subjects[i].value);
                if (index !== -1) {
                    subjectsChecked.splice(index, 1);
                }
            }
            subjectsString.textContent = subjectsChecked.toString();
        });
    }

  let courseString = document.getElementById('course-string');
    let select = document.querySelector('select');

    select.addEventListener('change', function () {
        let selectedValue = select.value;
        
        // Limpiar el contenido actual antes de agregar el nuevo curso
        courseString.textContent = "";

        // Mostrar el valor seleccionado
        courseString.textContent = selectedValue;
    });
});

