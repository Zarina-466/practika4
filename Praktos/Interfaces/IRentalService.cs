using Microsoft.AspNetCore.Mvc;
using Praktos.Requests;

namespace Praktos.Interfaces
{
    public interface IRentalService
    {
        Task<IActionResult> RentBook([FromQuery] CreateNewRental request);
        Task<IActionResult> ReturnBook([FromQuery] CreateNewReturn request);
        Task<IActionResult> GetRentalHistoryByUser(int id_readers);
        Task<IActionResult> GetCurrentRentals();
        Task<IActionResult> GetRentalHistoryByBook(int id_book);
    }
}
