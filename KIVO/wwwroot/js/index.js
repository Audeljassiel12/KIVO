const sections = document.querySelectorAll('.section');
let currentSection = 0;
const totalSections = sections.length;

// Función para cambiar entre secciones
function showNextSection() {
    // Ocultar la sección actual
    sections[currentSection].classList.remove('active');

    // Incrementar la sección actual
    currentSection++;

    if (currentSection < totalSections) {
        // Mostrar la siguiente sección si no ha llegado al final
        sections[currentSection].classList.add('active');
    } else {
        // Redirigir al login una vez pasadas las secciones
        window.location.href = '/Account/Login'; // Enlace directo al login
    }
}

// Cambiar la sección automáticamente cada 3 segundos
const sectionInterval = setInterval(() => {
    if (currentSection < totalSections) {
        showNextSection();
    } else {
        clearInterval(sectionInterval); // Detener el ciclo
    }
}, 3000);
