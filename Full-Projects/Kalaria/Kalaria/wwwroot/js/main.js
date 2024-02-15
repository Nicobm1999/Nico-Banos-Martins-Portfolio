const animationToLeft = document.querySelectorAll('.animation-to-left');
const animationToRight = document.querySelectorAll('.animation-to-right');

const observerOptions = {
    root: null,
    threshold: 0.2,
};

const observer = new IntersectionObserver(entries => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.style.animation = 'ToLeft 1s ease-out';
            entry.target.style.opacity = '1';
        }
    });
}, observerOptions);

animationToLeft.forEach(element => {
    observer.observe(element);
});

const observer2 = new IntersectionObserver(entries => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.style.animation = 'ToRight 1s ease-out';
            entry.target.style.opacity = '1';
        }
    });
}, observerOptions);

animationToRight.forEach(element => {
    observer2.observe(element);
});