using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ImageController : ControllerBase
{
    [HttpPost("upload/{Id}")]
    public async Task<IActionResult> UploadImage([FromForm] IFormFile imageFile, Guid id, string baseUrl, string folder)
    {
        if (imageFile == null || imageFile.Length == 0)
        {
            return BadRequest("No image file uploaded.");
        }
        try
        {
            string uploadsFolder = Path.Combine("wwwroot", "uploads", folder);
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            var extention = Path.GetExtension(imageFile.FileName);
            string uniqueFileName = id.ToString();
            // Check if the file already exists
            string existingFilePath = Path.Combine(uploadsFolder, uniqueFileName + extention);
            if (System.IO.File.Exists(existingFilePath))
            {
                System.IO.File.Delete(existingFilePath); // Delete the existing file
            }
            string filePath = Path.Combine(uploadsFolder, uniqueFileName + extention);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
            string fullPath = $"{baseUrl}/wwwroot/uploads/{uniqueFileName + extention}";
            return Ok(fullPath);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading image: " + ex.Message);
        }
    }
}
