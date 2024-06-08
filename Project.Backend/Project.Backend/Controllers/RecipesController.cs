using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Backend.Contracts.Identity;
using Project.Backend.Contracts.Services;
using Project.Backend.Models.Dtos;

namespace Project.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {

        private readonly IRecipeService _recipeService;
        private readonly IFavoriteService _favoriteService;
        private readonly IUserService _userService;


        public RecipesController(IRecipeService recipeService,
            IFavoriteService favoriteService,
            IUserService userService)
        {
            _recipeService = recipeService;
            _favoriteService = favoriteService;
            _userService = userService;

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<RecipeDTO>> Get(int Id)
        {
            var result = await _recipeService.GetByIdAsync(Id);
            if (result != null)
            {
                return Ok(result);
            }
            else
                return NotFound();
        }
        [HttpGet()]
        public async Task<ActionResult<List<RecipeDTO>>> GetAll(int page = 1, int size = 10)
        {
            var result = await _recipeService.GetAllAsync();
            if (result != null)
            {
                return Ok(result);
            }
            else
                return NotFound();
        }
        [HttpGet("getbykeyword/{keywordId}")]
        public async Task<ActionResult<List<RecipeDTO>>> GetAllByKeyword(int keywordId, int page = 1, int size = 10)
        {
            var result = await _recipeService.GetAllByKeywordAsync(keywordId);
            if (result != null)
            {
                return Ok(result);
            }
            else
                return NotFound();
        }
        [HttpGet("getbycuisine/{cuisineId}")]
        public async Task<ActionResult<List<RecipeDTO>>> GetAllByCuisine(int cuisineId, int page = 1, int size = 10)
        {
            var result = await _recipeService.GetAllByCuisineAsync(cuisineId);
            if (result != null)
            {
                return Ok(result);
            }
            else
                return NotFound();
        }
        [HttpGet("getbydiettype/{diettypeId}")]
        public async Task<ActionResult<List<RecipeDTO>>> GetAllByDietType(int diettypeId, int page = 1, int size = 10)
        {
            var result = await _recipeService.GetAllByDietTypeAsync(diettypeId);
            if (result != null)
            {
                return Ok(result);
            }
            else
                return NotFound();
        }
        [HttpGet("getbycollection/{collectionId}")]
        public async Task<ActionResult<List<RecipeDTO>>> GetAllByCollection(int collectionId, int page = 1, int size = 10)
        {
            var result = await _recipeService.GetAllByCollectionAsync(collectionId);
            if (result != null)
            {
                return Ok(result);
            }
            else
                return NotFound();
        }
        [HttpGet("getbycourse/{courseId}")]
        public async Task<ActionResult<List<RecipeDTO>>> GetAllByCourseAsync(int courseId, int page = 1, int size = 10)
        {
            var result = await _recipeService.GetAllByCourseAsync(courseId);
            if (result != null)
            {
                return Ok(result);
            }
            else
                return NotFound();
        }
        [HttpPost("AddToFavorite/{recipeId}")]
        [Authorize]
        public async Task<ActionResult> AddToFavorite(int recipeId)
        {
            var userIdString = _userService.UserId;
            var userId = new Guid(userIdString);
            var result = await _favoriteService.AddToFavorite(recipeId, userId);
            if (result != 0)
                return Ok(result);
            return BadRequest();

        }
        [HttpPost("RemoveFromFavorite/{recipeId}")]
        [Authorize]
        public async Task<ActionResult> RemoveFromFavorite(int recipeId)
        {
            var userIdString = _userService.UserId;
            var userId = new Guid(userIdString);
            var result = await _favoriteService.RemoveFromFavorite(recipeId, userId);
            if (result)
                return Ok(result);
            return BadRequest();

        }
        [HttpGet("GetAllFavorites")]
        [Authorize]
        public async Task<ActionResult> GetAllFavorites()
        {
            var userIdString = _userService.UserId;
            var userId = new Guid(userIdString);
            var result = await _favoriteService.GetAllFavorites(userId);
            if (result != null)
                return Ok(result);
            return BadRequest();

        }

    }
}
