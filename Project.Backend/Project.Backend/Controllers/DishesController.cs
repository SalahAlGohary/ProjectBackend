using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Backend.Entities;

namespace Project.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        private readonly IMapper _mapper;
        private readonly ImageController _imageController;

        public RecipesController(ProjectDBContext context,
            IMapper mapper,
            ImageController imageController)
        {
            _context = context;
            _mapper = mapper;
            _imageController = imageController;
        }

        // GET: api/Recipes
        //[HttpGet("GetByResturantId/{ResturantId}")]
        //public async Task<ActionResult<List<GetRecipeDto>>> GetRecipesBy(Guid ResturantId)
        //{
        //    var listOfRecipesDto = new List<GetRecipeDto>();
        //    var listOfRecipes = await _context.Recipees.Include(a => a.RecipeSizes).Where(x => x.IsDeleted == false && x.ResturantId == ResturantId).ToListAsync();
        //    if (listOfRecipes.Any())
        //    {
        //        foreach (var item in listOfRecipes)
        //        {
        //            var dto = _mapper.Map<GetRecipeDto>(item);
        //            listOfRecipesDto.Add(dto);
        //        }
        //    }
        //    return listOfRecipesDto;
        //}
        //[HttpGet("GetByRecipeId/{RecipeId}")]
        //public async Task<ActionResult<List<GetRecipeSizeDto>>> GetRecipeSizesByRecipeId(Guid RecipeId)
        //{
        //    var listOfRecipeSizesDto = new List<GetRecipeSizeDto>();
        //    var listOfRecipeSizes = await _context.RecipeSizes.Where(x => x.IsDeleted == false && x.RecipeId == RecipeId).ToListAsync();
        //    if (listOfRecipeSizes.Any())
        //    {
        //        foreach (var item in listOfRecipeSizes)
        //        {
        //            var dto = _mapper.Map<GetRecipeSizeDto>(item);
        //            listOfRecipeSizesDto.Add(dto);
        //        }
        //    }
        //    return listOfRecipeSizesDto;
        //}

        //// GET: api/Recipes/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<GetRecipeDto>> GetRecipe(Guid id)
        //{
        //    var Recipe = await _context.Recipees.Include(x => x.RecipeSizes).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

        //    if (Recipe == null)
        //    {
        //        return NotFound();
        //    }
        //    var RecipeResult = _mapper.Map<GetRecipeDto>(Recipe);
        //    return RecipeResult;
        //}
        //[HttpGet("RecipeSizes/{id}")]
        //public async Task<ActionResult<GetRecipeSizeDto>> GetRecipeSize(Guid id)
        //{
        //    var RecipeSize = await _context.RecipeSizes.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

        //    if (RecipeSize == null)
        //    {
        //        return NotFound();
        //    }
        //    var RecipeSizeResult = _mapper.Map<GetRecipeSizeDto>(RecipeSize);
        //    return RecipeSizeResult;
        //}

        //// PUT: api/Recipes/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<ActionResult<GetRecipeDto>> PutRecipe(Guid id, UpdateRecipeDto RecipeDto)
        //{
        //    if (id != RecipeDto.Id)
        //    {
        //        return BadRequest();
        //    }
        //    var Recipe = _mapper.Map<Recipe>(RecipeDto);
        //    _context.Entry(Recipe).State = EntityState.Modified;
        //    try
        //    {
        //        await _context.SaveChangesAsync();

        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RecipeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return _mapper.Map<GetRecipeDto>(Recipe);
        //}
        //[HttpPut("{RecipeId}/RecipeSizes/{id}")]
        //public async Task<ActionResult<GetRecipeSizeDto>> PutRecipeSizeSize(Guid id, Guid RecipeId, UpdateRecipeSizeDto RecipeSizeDto)
        //{
        //    if (id != RecipeSizeDto.Id)
        //    {
        //        return BadRequest();
        //    }
        //    var RecipeSize = _mapper.Map<RecipeSize>(RecipeSizeDto);
        //    RecipeSize.RecipeId = RecipeId;
        //    _context.Entry(RecipeSize).State = EntityState.Modified;
        //    try
        //    {
        //        await _context.SaveChangesAsync();

        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RecipeSizeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return _mapper.Map<GetRecipeSizeDto>(RecipeSize);
        //}

        //// POST: api/Recipes
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<GetRecipeDto>> PostRecipe(CreateRecipeDto RecipeDto)
        //{
        //    var Recipe = _mapper.Map<Recipe>(RecipeDto);
        //    Recipe.Id = Guid.NewGuid();
        //    if (RecipeDto.RecipeSizes != null)
        //    {
        //        if (RecipeDto.RecipeSizes.Any())
        //        {
        //            Recipe.RecipeSizes = new List<RecipeSize>();
        //            foreach (var RecipeSize in Recipe.RecipeSizes)
        //            {
        //                RecipeSize.RecipeId = Recipe.Id;
        //                Recipe.RecipeSizes.Add(RecipeSize);
        //            }
        //        }
        //    }
        //    _context.Recipees.Add(Recipe);
        //    await _context.SaveChangesAsync();
        //    var RecipeToReturn = _mapper.Map<GetRecipeDto>(Recipe);

        //    return CreatedAtAction("GetRecipe", new { id = Recipe.Id }, RecipeToReturn);
        //}
        //[HttpPost("{RecipeId}/RecipeSize")]
        //public async Task<ActionResult<GetRecipeSizeDto>> AddRecipeSizeSize(CreateRecipeSizeDto RecipeSizeDto, Guid RecipeId)
        //{
        //    var RecipeSize = _mapper.Map<RecipeSize>(RecipeSizeDto);
        //    RecipeSize.RecipeId = RecipeId;
        //    _context.RecipeSizes.Add(RecipeSize);
        //    await _context.SaveChangesAsync();
        //    var RecipeSizeToReturn = _mapper.Map<GetRecipeSizeDto>(RecipeSize);

        //    return CreatedAtAction("GetRecipeSize", new { id = RecipeSize.Id }, RecipeSizeToReturn);
        //}

        //// DELETE: api/Recipes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteRecipe(Guid id)
        //{
        //    var Recipe = await _context.Recipees.FindAsync(id);
        //    if (Recipe == null)
        //    {
        //        return NotFound();
        //    }
        //    Recipe.IsDeleted = true;
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
        //[HttpDelete("RecipeSize/{id}")]
        //public async Task<IActionResult> DeleteRecipeSize(Guid id)
        //{
        //    var RecipeSize = await _context.RecipeSizes.FindAsync(id);
        //    if (RecipeSize == null)
        //    {
        //        return NotFound();
        //    }
        //    RecipeSize.IsDeleted = true;
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
        //[HttpPost("addImage/{Id}")]
        //public async Task<IActionResult> UploadImage([FromForm] IFormFile ImageFile, Guid Id)
        //{
        //    var Recipe = await _context.Recipees.FirstOrDefaultAsync(x => x.Id == Id);
        //    if (Recipe == null)
        //        return NotFound();
        //    string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
        //    if (ImageFile == null || ImageFile.Length == 0)
        //    {
        //        return BadRequest("No image file uploaded.");
        //    }
        //    var result = await _imageController.UploadImage(ImageFile, Id, baseUrl, "Recipe");

        //    if (result is ObjectResult objectResult && objectResult.Value is string imagePath)
        //    {
        //        Recipe.CoverUrl = imagePath;
        //        Recipe.UpdatedAt = DateTime.Now;
        //        _context.Entry(Recipe).State = EntityState.Modified;
        //        await _context.SaveChangesAsync();
        //        var RecipetoReurn = _mapper.Map<GetRecipeDto>(Recipe);
        //        return Ok(RecipetoReurn);
        //    }
        //    else
        //    {
        //        // Handle unexpected result
        //        return BadRequest("Error processing Image.");
        //    }
        //}

        //private bool RecipeExists(Guid id)
        //{
        //    return _context.Recipees.Any(e => e.Id == id && e.IsDeleted == false);
        //}
        //private bool RecipeSizeExists(Guid id)
        //{
        //    return _context.RecipeSizes.Any(e => e.Id == id && e.IsDeleted == false);
        //}

    }
}
