using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using KIVO.Services.IServerces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class CloudinaryService : ICloudinaryService
{
    private readonly Cloudinary _cloudinary;

    public CloudinaryService(Cloudinary cloudinary)
    {
        _cloudinary = cloudinary;
    }
    public async Task<string> SubirImagenAsync(IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, stream)
                };

                try
                {
                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                    // Verifica si la URL segura está presente
                    if (uploadResult?.SecureUrl != null)
                    {
                        return uploadResult.SecureUrl.ToString();
                    }
                    else
                    {
                        throw new Exception("La carga de la imagen falló. La URL segura es nula.");
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones (puedes registrar el error o devolver un mensaje)
                    Console.WriteLine($"Error al subir la imagen: {ex.Message}");
                    throw; // Lanza la excepción nuevamente o maneja el error según sea necesario
                }
            }
        }

        return null;
    }


}
