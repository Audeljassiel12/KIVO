using System;
using System.ComponentModel.DataAnnotations;
using PhoneNumbers;  // Aquí estamos usando la librería libphonenumber-csharp para trabajar con números de teléfono

/// <summary>
/// Esta es una clase de validación personalizada para números de teléfono.
/// </summary>
public class PhoneNumberAttribute : ValidationAttribute
{
    // Este campo guardará el código de región que vamos a usar por defecto
    private readonly string _regionCode;

    /// <summary>
    /// Este es el constructor. Aquí podemos especificar el código de región que queremos usar.
    /// Por defecto, está configurado para "US", que es Estados Unidos.
    /// </summary>
    /// <param name="regionCode">El código de la región para validar el número de teléfono.</param>
    public PhoneNumberAttribute(string regionCode = "US")
    {
        _regionCode = regionCode; // Asignamos el código de región
        ErrorMessage = "El número de teléfono no es válido."; // Este es el mensaje de error que mostraremos si la validación falla
    }

    /// <summary>
    /// Este método es donde realmente validamos el número de teléfono.
    /// </summary>
    /// <param name="value">El valor que queremos validar, que en este caso es el número de teléfono.</param>
    /// <param name="validationContext">Nos da contexto sobre la validación que se está realizando.</param>
    /// <returns>El resultado de la validación, que puede ser exitoso o un error.</returns>
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // Primero, chequeamos si el valor es nulo
        if (value == null)
        {
            return ValidationResult.Success!; // Si es nulo, decimos que está bien (puedes cambiar esto si quieres que sea obligatorio)
        }

        // Convertimos el valor a una cadena de texto
        var phoneNumberString = value as string;

        // Si la cadena está vacía o solo tiene espacios en blanco, también decimos que está bien
        if (string.IsNullOrWhiteSpace(phoneNumberString))
        {
            return ValidationResult.Success!; // No hacemos nada si está vacío
        }

        try
        {
            // Aquí obtenemos una instancia de PhoneNumberUtil, que nos ayudará a validar el número
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();

            // Intentamos analizar el número de teléfono usando el código de región que especificamos
            var phoneNumber = phoneNumberUtil.Parse(phoneNumberString, _regionCode);

            // Ahora verificamos si el número es válido
            if (phoneNumberUtil.IsValidNumber(phoneNumber))
            {
                return ValidationResult.Success; // Si es válido, todo bien
            }
            else
            {
                return new ValidationResult(ErrorMessage); // Si no es válido, regresamos nuestro mensaje de error
            }
        }
        catch (NumberParseException)
        {
            // Si algo sale mal al intentar analizar el número, capturamos la excepción
            return new ValidationResult(ErrorMessage); // Y regresamos el mensaje de error
        }
        catch (Exception ex) // Agregar esta línea para manejar otras excepciones
        {
            // Regresar un error genérico para otras excepciones inesperadas
            return new ValidationResult($"Error al validar el número: {ex.Message}");
        }
    }

}
