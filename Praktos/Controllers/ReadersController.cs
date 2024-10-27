using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Praktos.DatabaseContext;
using Praktos.Interfaces;
using Praktos.Model;
using Praktos.Requests;
using Praktos.Services;

namespace Praktos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ReadersController : Controller
    {
        private readonly IReadersService _readersService;
        public ReadersController(IReadersService readersService)
        {
            _readersService = readersService;
        }
        [HttpGet]
        [Route("getAllReaders")]
        public async Task<IActionResult> GetReaders(int page, int pageSize)
        {
            return await _readersService.GetReaders(page, pageSize);
        }
        [HttpGet]
        [Route("getAllReadersWithFilter")]
        public async Task<IActionResult> GetReadersF([FromQuery] DateTime? registrationDate = null)
        {
            return await _readersService.GetReadersF((DateTime)registrationDate);
        }

        [HttpPost]
        [Route("CreateNewReaders")]
        public async Task<IActionResult> CreateNewReaders([FromQuery] CreateNewReaders newReaders)
        {
            return await _readersService.CreateNewReaders(newReaders);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReaders(int id, [FromQuery] CreateNewReaders updateReaders)
        {
            return await _readersService.UpdateReaders(id, updateReaders);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutors(int id)
        {
           return await _readersService.DeleteAutors(id);
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchBooks(string query)
        {
            return await _readersService.SearchBooks(query);
        }
    }
}
