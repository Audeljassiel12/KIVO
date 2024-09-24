const sections = document.querySelectorAll('.section');
let currentSection = 0;

// Función para cambiar entre secciones
function showNextSection() {
    // Ocultar la sección actual
    sections[currentSection].classList.remove('active');

    // Calcular la siguiente sección
    currentSection = (currentSection + 1) % sections.length;

    // Mostrar la siguiente sección
    sections[currentSection].classList.add('active');
}

// Cambiar la sección automáticamente cada 3 segundos
setInterval(showNextSection, 3000);
