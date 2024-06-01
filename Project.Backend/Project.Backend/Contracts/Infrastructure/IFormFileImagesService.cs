namespace Project.Backend.Contracts.Infrastructure
{
    public interface IFormFileImagesService
    {
        string saveImage(IFormFile image, string WebRootPath, string ContentRootPath, string Domain, string folder);
        string saveImage(IFormFile image, string WebRootPath, string ContentRootPath, string Domain);
        string saveImage(IFormFile image, string WebRootPath);
    }
}
