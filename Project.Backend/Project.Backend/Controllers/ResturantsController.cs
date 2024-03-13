using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Backend.Entities;
using Project.Backend.Models.Dtos.Resturant;

namespace Project.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantsController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        private readonly IMapper _mapper;
        private readonly ImageController _imageController;

        public ResturantsController(ProjectDBContext context,
            IMapper mapper,
            ImageController imageController)
        {
            _context = context;
            _mapper = mapper;
            _imageController = imageController;
        }

        // GET: api/Resturants
        [HttpGet]
        public async Task<ActionResult<List<GetResturantDto>>> GetRestuarants()
        {
            var listOfResturantsDto = new List<GetResturantDto>();
            var listOfResturants = await _context.Restuarants.Include(a => a.Address).Where(x => x.IsDeleted == false).ToListAsync();
            if (listOfResturants.Any())
            {
                foreach (var item in listOfResturants)
                {
                    var dto = _mapper.Map<GetResturantDto>(item);
                    listOfResturantsDto.Add(dto);
                }
            }
            return listOfResturantsDto;
        }

        // GET: api/Resturants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetResturantDto>> GetResturant(Guid id)
        {
            var resturant = await _context.Restuarants.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

            if (resturant == null)
            {
                return NotFound();
            }
            var resturantResult = _mapper.Map<GetResturantDto>(resturant);
            return resturantResult;
        }

        // PUT: api/Resturants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<GetResturantDto>> PutResturant(Guid id, UpdateResturantDto resturantDto)
        {
            if (id != resturantDto.Id)
            {
                return BadRequest();
            }
            var resturant = _mapper.Map<Resturant>(resturantDto);
            _context.Entry(resturant).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResturantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return _mapper.Map<GetResturantDto>(resturant);
        }

        // POST: api/Resturants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetResturantDto>> PostResturant(CreateResturantDto resturantDto)
        {
            var resturant = _mapper.Map<Resturant>(resturantDto);
            _context.Restuarants.Add(resturant);
            await _context.SaveChangesAsync();
            var resturantToReturn = _mapper.Map<GetResturantDto>(resturant);

            return CreatedAtAction("GetResturant", new { id = resturant.Id }, resturantToReturn);
        }

        // DELETE: api/Resturants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResturant(Guid id)
        {
            var resturant = await _context.Restuarants.FindAsync(id);
            if (resturant == null)
            {
                return NotFound();
            }

            _context.Restuarants.Remove(resturant);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost("addImage/{Id}")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile ImageFile, Guid Id)
        {
            var resturant = await _context.Restuarants.FirstOrDefaultAsync(x => x.Id == Id);
            if (resturant == null)
                return NotFound();
            string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            if (ImageFile == null || ImageFile.Length == 0)
            {
                return BadRequest("No image file uploaded.");
            }
            var result = await _imageController.UploadImage(ImageFile, Id, baseUrl, "Resturant");

            if (result is ObjectResult objectResult && objectResult.Value is string imagePath)
            {
                resturant.CoverUrl = imagePath;
                resturant.UpdatedAt = DateTime.Now;
                _context.Entry(resturant).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                var resturanttoReurn = _mapper.Map<GetResturantDto>(resturant);
                return Ok(resturanttoReurn);
            }
            else
            {
                // Handle unexpected result
                return BadRequest("Error processing Image.");
            }
        }

        private bool ResturantExists(Guid id)
        {
            return _context.Restuarants.Any(e => e.Id == id && e.IsDeleted == false);
        }

    }
}
