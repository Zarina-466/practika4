using Microsoft.AspNetCore.Mvc;
using Praktos.Model;
using Praktos.Requests;
using System.ComponentModel.DataAnnotations;

namespace Praktos.Interfaces
{
    public interface IBooksService
    {
        Task<IActionResult> GetBooks(int page, int pageSize);
        Task<IActionResult> CreateNewBooks([FromQuery] CreateNewBooks newBooks);
        Task<IActionResult> GetBookById(int id);
        Task<IActionResult> UpdateBook(int id, [FromQuery] CreateNewBooks updateBooks);
        Task<IActionResult> DeleteBook(int id);
        Task<IActionResult> GetBooksByGenre(int genreId);
        Task<IActionResult> SearchBooks(string query);
        Task<IActionResult> GetAvailableCopies([Required][FromRoute] string title);
    }
}
