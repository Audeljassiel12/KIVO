using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KIVO.Validaciones
{
    public class ValidarNumeroAttribute : ValidationAttribute
    {
        public string CodigoPais { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var telefono = value as string;
            if (string.IsNullOrEmpty(telefono))
            {
                return new ValidationResult("El número de teléfono es requerido.");
            }

            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            try
            {
                var numero = phoneUtil.Parse(telefono, CodigoPais);
                bool esValido = phoneUtil.IsValidNumber(numero);

                if (!esValido)
                {
                    return new ValidationResult("El número de teléfono no es válido.");
                }
            }
            catch (NumberParseException)
            {
                return new ValidationResult("El formato del número es incorrecto.");
            }

            return ValidationResult.Success;
        }
    }
}

