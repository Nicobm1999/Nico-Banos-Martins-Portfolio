document.addEventListener('DOMContentLoaded', function () {
    let subjectsString = document.getElementById('subject-string');
    let moreInfo = document.getElementById('more-info');
    let subjects = document.getElementsByClassName('check-subject');
    moreInfo.addEventListener('click', function () {
        for (let i = 0; i < subjects.length; i++) {
            if (subjects[i].checked) {
                subjectsString.textContent += "[" + subjects[i].nextElementSibling.textContent + "]";
            }
        }
    });
});
