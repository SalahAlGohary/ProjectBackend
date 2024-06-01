using Project.Backend.Contracts.Infrastructure;

namespace Project.Backend.Services.ImageService
{
    public class FormFileImagesService : IFormFileImagesService
    {
        public string saveImage(IFormFile image, string WebRootPath, string ContentRootPath, string Domain)
        {
            try
            {

                string fileName = Guid.NewGuid().ToString() + ".jpg";
                string baseUrl = WebRootPath + "\\Images\\";
                string filePath = baseUrl + fileName;
                //create folder Images in wwwroot if not exist
                if (!Directory.Exists(baseUrl))
                {
                    Directory.CreateDirectory(Path.Combine(ContentRootPath, @"~/\Images\\"));
                }
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }

                return Domain + "/Images/" + fileName;


            }
            catch (Exception e)
            { return null; }

        }
        public string saveImage(IFormFile image, string WebRootPath, string ContentRootPath, string Domain, string folder)
        {
            try
            {
                string fileName = Guid.NewGuid().ToString() + ".jpg";
                string baseUrl = WebRootPath + $"\\Images\\{folder}\\";
                string filePath = baseUrl + fileName;
                //create folder Images in wwwroot if not exist
                if (!Directory.Exists(baseUrl))
                {
                    Directory.CreateDirectory(Path.Combine(ContentRootPath, $@"~/\Images\\{folder}\\"));
                }
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }

                return Domain + $"/Images/{folder}/" + fileName;


            }
            catch (Exception e)
            { return null; }

        }
        public string saveImage(IFormFile image, string WebRootPath)
        {
            try
            {

                string fileName = Guid.NewGuid().ToString() + ".jpg";
                string baseUrl = WebRootPath + "\\Images\\";
                string filePath = baseUrl + fileName;
                //create folder Images in wwwroot if not exist
                if (!Directory.Exists(baseUrl))
                {
                    Directory.CreateDirectory(baseUrl);
                }
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }

                return WebRootPath + "/Images/" + fileName;


            }
            catch (Exception e)
            { return null; }

        }
    }
}
