using Microsoft.AspNetCore.Mvc;
using Praktos.Requests;

namespace Praktos.Interfaces
{
    public interface IGenresService
    {
        Task<IActionResult> GetGenres();
        Task<IActionResult> CreateNewGenres([FromQuery] CreateNewGenres newGenres);
        Task<IActionResult> UpdateGenres(int id, [FromQuery] CreateNewGenres updateGenre);
        Task<IActionResult> DeleteGenres(int id);

    }
}
