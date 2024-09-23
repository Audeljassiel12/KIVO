function showMessage(message, type) {
    const messageContainer = document.getElementById('message-container');
    const messageDiv = document.createElement('div');

    messageDiv.className = `custom-message ${type}`; // clase personalizada para estilos
    messageDiv.textContent = message;

    // Añadir un botón para cerrar el mensaje
    const closeButton = document.createElement('span');
    closeButton.textContent = '×'; // carácter de cierre
    closeButton.className = 'close-alert';
    closeButton.onclick = function () {
        messageDiv.style.display = 'none';
    };

    messageDiv.appendChild(closeButton);
    messageContainer.appendChild(messageDiv);

    // Cerrar automáticamente después de 4 segundos
    setTimeout(() => {
        messageDiv.style.display = 'none';
    }, 4000);
}

// Función para reenviar el código
function resendCode() {
    var phoneNumber = document.querySelector('input[name="PhoneNumber"]').value;

    // Validar que el número de teléfono no esté vacío
    if (!phoneNumber) {
        showMessage("Por favor, ingrese un número de teléfono.", 'danger');
        return;
    }

    // Obtener el token anti-CSRF
    var token = document.querySelector('input[name="__RequestVerificationToken"]').value;

    // Enviar la solicitud AJAX al servidor
    fetch('/Account/ResendVerificationCode', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': token
        },
        body: JSON.stringify({ phoneNumber: phoneNumber })
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                showMessage(data.message, 'success');
            } else {
                showMessage("Error al reenviar el código: " + data.message, 'danger');
            }
        })
        .catch(error => {
            console.error('Error:', error);
            showMessage("Error al reenviar el código.", 'danger');
        });
}
