namespace KIVO.Services.IServerces
{
    public interface ICloudinaryService
    {
        Task<string> SubirImagenAsync(IFormFile file);
    }

}
