using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Praktos.DatabaseContext;
using Praktos.Interfaces;
using Praktos.Model;
using Praktos.Requests;

namespace Praktos.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : Controller
    {
        private readonly IGenresService _genresService;
        public GenresController(IGenresService genresService)
        {
            _genresService = genresService;
        }
        [HttpGet]
        [Route("getAllGenres")]
        public async Task<IActionResult> GetGenres()
        {
            return await _genresService.GetGenres();
        }

        [HttpPost]
        [Route("CreateNewGenres")]
        public async Task<IActionResult> CreateNewGenres([FromQuery] CreateNewGenres newGenres)
        {
            return await _genresService.CreateNewGenres(newGenres);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenres(int id, [FromQuery] CreateNewGenres updateGenre)
        {
            return await _genresService.UpdateGenres(id, updateGenre);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenres(int id)
        {
            return await _genresService.DeleteGenres(id);
        }
    }
}
