using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Praktos.DatabaseContext;
using Praktos.Interfaces;
using Praktos.Model;
using Praktos.Requests;

namespace Praktos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookRentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        public BookRentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost("rent")]
        public async Task<IActionResult> RentBook([FromQuery] CreateNewRental request)
        {
            return await _rentalService.RentBook(request);
        }

        [HttpPost("return")]
        public async Task<IActionResult> ReturnBook([FromQuery] CreateNewReturn request)
        {
            return await _rentalService.ReturnBook(request);
        }

        [HttpGet("user/{id_readers}/history")]
        public async Task<IActionResult> GetRentalHistoryByUser(int id_readers)
        {
            return await _rentalService.GetRentalHistoryByUser(id_readers);
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentRentals()
        {
            return await _rentalService.GetCurrentRentals();
        }

        [HttpGet("book/{id_book}/history")]
        public async Task<IActionResult> GetRentalHistoryByBook(int id_book)
        {
            return await _rentalService.GetRentalHistoryByBook(id_book);
        }
    }
}