using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Praktos.DatabaseContext;
using Praktos.Interfaces;
using Praktos.Model;
using Praktos.Requests;
using static System.Reflection.Metadata.BlobBuilder;

namespace Praktos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorsController : Controller
    {
        private readonly IAuthorsService _authorsService;
        public AutorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpGet]
        [Route("getAllAutors")]
        public async Task<IActionResult> GetAutors()
        {
            return await _authorsService.GetAutors();
        }

        [HttpPost]
        [Route("CreateNewAutors")]
        public async Task<IActionResult> CreateNewAutors([FromQuery] CreateNewAutors newAutors)
        {
            return await _authorsService.CreateNewAutors(newAutors);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAutors(int id, [FromQuery] CreateNewAutors updateAutors)
        {
            return await _authorsService.UpdateAutor(id, updateAutors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutors(int id)
        {
            return await _authorsService.DeleteAutor(id);
        }
    }
}
