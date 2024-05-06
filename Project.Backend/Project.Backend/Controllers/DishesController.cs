using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Backend.Entities;

namespace Project.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishsController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        private readonly IMapper _mapper;
        private readonly ImageController _imageController;

        public DishsController(ProjectDBContext context,
            IMapper mapper,
            ImageController imageController)
        {
            _context = context;
            _mapper = mapper;
            _imageController = imageController;
        }

        // GET: api/Dishs
        //[HttpGet("GetByResturantId/{ResturantId}")]
        //public async Task<ActionResult<List<GetDishDto>>> GetDishsBy(Guid ResturantId)
        //{
        //    var listOfDishsDto = new List<GetDishDto>();
        //    var listOfDishs = await _context.Dishes.Include(a => a.DishSizes).Where(x => x.IsDeleted == false && x.ResturantId == ResturantId).ToListAsync();
        //    if (listOfDishs.Any())
        //    {
        //        foreach (var item in listOfDishs)
        //        {
        //            var dto = _mapper.Map<GetDishDto>(item);
        //            listOfDishsDto.Add(dto);
        //        }
        //    }
        //    return listOfDishsDto;
        //}
        //[HttpGet("GetByDishId/{DishId}")]
        //public async Task<ActionResult<List<GetDishSizeDto>>> GetDishSizesByDishId(Guid DishId)
        //{
        //    var listOfDishSizesDto = new List<GetDishSizeDto>();
        //    var listOfDishSizes = await _context.DishSizes.Where(x => x.IsDeleted == false && x.DishId == DishId).ToListAsync();
        //    if (listOfDishSizes.Any())
        //    {
        //        foreach (var item in listOfDishSizes)
        //        {
        //            var dto = _mapper.Map<GetDishSizeDto>(item);
        //            listOfDishSizesDto.Add(dto);
        //        }
        //    }
        //    return listOfDishSizesDto;
        //}

        //// GET: api/Dishs/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<GetDishDto>> GetDish(Guid id)
        //{
        //    var Dish = await _context.Dishes.Include(x => x.DishSizes).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

        //    if (Dish == null)
        //    {
        //        return NotFound();
        //    }
        //    var DishResult = _mapper.Map<GetDishDto>(Dish);
        //    return DishResult;
        //}
        //[HttpGet("DishSizes/{id}")]
        //public async Task<ActionResult<GetDishSizeDto>> GetDishSize(Guid id)
        //{
        //    var DishSize = await _context.DishSizes.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

        //    if (DishSize == null)
        //    {
        //        return NotFound();
        //    }
        //    var DishSizeResult = _mapper.Map<GetDishSizeDto>(DishSize);
        //    return DishSizeResult;
        //}

        //// PUT: api/Dishs/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<ActionResult<GetDishDto>> PutDish(Guid id, UpdateDishDto DishDto)
        //{
        //    if (id != DishDto.Id)
        //    {
        //        return BadRequest();
        //    }
        //    var Dish = _mapper.Map<Dish>(DishDto);
        //    _context.Entry(Dish).State = EntityState.Modified;
        //    try
        //    {
        //        await _context.SaveChangesAsync();

        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DishExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return _mapper.Map<GetDishDto>(Dish);
        //}
        //[HttpPut("{DishId}/DishSizes/{id}")]
        //public async Task<ActionResult<GetDishSizeDto>> PutDishSizeSize(Guid id, Guid DishId, UpdateDishSizeDto DishSizeDto)
        //{
        //    if (id != DishSizeDto.Id)
        //    {
        //        return BadRequest();
        //    }
        //    var DishSize = _mapper.Map<DishSize>(DishSizeDto);
        //    DishSize.DishId = DishId;
        //    _context.Entry(DishSize).State = EntityState.Modified;
        //    try
        //    {
        //        await _context.SaveChangesAsync();

        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DishSizeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return _mapper.Map<GetDishSizeDto>(DishSize);
        //}

        //// POST: api/Dishs
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<GetDishDto>> PostDish(CreateDishDto DishDto)
        //{
        //    var Dish = _mapper.Map<Dish>(DishDto);
        //    Dish.Id = Guid.NewGuid();
        //    if (DishDto.DishSizes != null)
        //    {
        //        if (DishDto.DishSizes.Any())
        //        {
        //            Dish.DishSizes = new List<DishSize>();
        //            foreach (var dishSize in Dish.DishSizes)
        //            {
        //                dishSize.DishId = Dish.Id;
        //                Dish.DishSizes.Add(dishSize);
        //            }
        //        }
        //    }
        //    _context.Dishes.Add(Dish);
        //    await _context.SaveChangesAsync();
        //    var DishToReturn = _mapper.Map<GetDishDto>(Dish);

        //    return CreatedAtAction("GetDish", new { id = Dish.Id }, DishToReturn);
        //}
        //[HttpPost("{DishId}/DishSize")]
        //public async Task<ActionResult<GetDishSizeDto>> AddDishSizeSize(CreateDishSizeDto DishSizeDto, Guid DishId)
        //{
        //    var DishSize = _mapper.Map<DishSize>(DishSizeDto);
        //    DishSize.DishId = DishId;
        //    _context.DishSizes.Add(DishSize);
        //    await _context.SaveChangesAsync();
        //    var DishSizeToReturn = _mapper.Map<GetDishSizeDto>(DishSize);

        //    return CreatedAtAction("GetDishSize", new { id = DishSize.Id }, DishSizeToReturn);
        //}

        //// DELETE: api/Dishs/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDish(Guid id)
        //{
        //    var Dish = await _context.Dishes.FindAsync(id);
        //    if (Dish == null)
        //    {
        //        return NotFound();
        //    }
        //    Dish.IsDeleted = true;
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
        //[HttpDelete("DishSize/{id}")]
        //public async Task<IActionResult> DeleteDishSize(Guid id)
        //{
        //    var DishSize = await _context.DishSizes.FindAsync(id);
        //    if (DishSize == null)
        //    {
        //        return NotFound();
        //    }
        //    DishSize.IsDeleted = true;
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
        //[HttpPost("addImage/{Id}")]
        //public async Task<IActionResult> UploadImage([FromForm] IFormFile ImageFile, Guid Id)
        //{
        //    var Dish = await _context.Dishes.FirstOrDefaultAsync(x => x.Id == Id);
        //    if (Dish == null)
        //        return NotFound();
        //    string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
        //    if (ImageFile == null || ImageFile.Length == 0)
        //    {
        //        return BadRequest("No image file uploaded.");
        //    }
        //    var result = await _imageController.UploadImage(ImageFile, Id, baseUrl, "Dish");

        //    if (result is ObjectResult objectResult && objectResult.Value is string imagePath)
        //    {
        //        Dish.CoverUrl = imagePath;
        //        Dish.UpdatedAt = DateTime.Now;
        //        _context.Entry(Dish).State = EntityState.Modified;
        //        await _context.SaveChangesAsync();
        //        var DishtoReurn = _mapper.Map<GetDishDto>(Dish);
        //        return Ok(DishtoReurn);
        //    }
        //    else
        //    {
        //        // Handle unexpected result
        //        return BadRequest("Error processing Image.");
        //    }
        //}

        //private bool DishExists(Guid id)
        //{
        //    return _context.Dishes.Any(e => e.Id == id && e.IsDeleted == false);
        //}
        //private bool DishSizeExists(Guid id)
        //{
        //    return _context.DishSizes.Any(e => e.Id == id && e.IsDeleted == false);
        //}

    }
}
