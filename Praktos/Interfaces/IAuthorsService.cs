using Microsoft.AspNetCore.Mvc;
using Praktos.Requests;

namespace Praktos.Interfaces
{
    public interface IAuthorsService
    {
        Task<IActionResult> GetAutors();
        Task<IActionResult> CreateNewAutors([FromQuery] CreateNewAutors newAutors);

        Task<IActionResult> UpdateAutor(int id, [FromQuery] CreateNewAutors updateAutors);
        Task<IActionResult> DeleteAutor(int id);
    }
}
