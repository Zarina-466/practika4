using Microsoft.AspNetCore.Mvc;
using Praktos.Requests;

namespace Praktos.Interfaces
{
    public interface IReadersService
    {
        Task<IActionResult> GetReaders(int page, int pageSize);
        Task<IActionResult> GetReadersF(DateTime? registrationDate);
        Task<IActionResult> CreateNewReaders([FromQuery] CreateNewReaders newReaders);
        Task<IActionResult> UpdateReaders(int id, [FromQuery] CreateNewReaders updateReaders);
        Task<IActionResult> DeleteAutors(int id);
        Task<IActionResult> SearchBooks(string query);
    }
}
