function resendCode() {
    var phoneNumber = document.querySelector('input[name="PhoneNumber"]').value;

    // Validar que el número de teléfono no esté vacío
    if (!phoneNumber) {
        alert("Por favor, ingrese un número de teléfono.");
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
                alert(data.message);
            } else {
                alert("Error al reenviar el código: " + data.message);
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert("Error al reenviar el código.");
        });
}
