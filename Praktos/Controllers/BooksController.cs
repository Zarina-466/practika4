using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Praktos.DatabaseContext;
using Praktos.Interfaces;
using Praktos.Model;
using Praktos.Requests;
using Praktos.Services;
using System.ComponentModel.DataAnnotations;
using static System.Reflection.Metadata.BlobBuilder;

namespace Praktos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
       private readonly IBooksService _booksService;
       public BooksController(IBooksService booksService) 
        {
            _booksService = booksService;
        }
        [HttpGet]
        [Route("getAllBooks")]
        public async Task<IActionResult> GetBooks(int page, int pageSize)
        {
            return await _booksService.GetBooks(page,pageSize);
        }

        [HttpPost]
        [Route("CreateNewBooks")]
        public async Task<IActionResult> CreateNewBooks([FromQuery] CreateNewBooks newBooks)
        {
          return await _booksService.CreateNewBooks(newBooks);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            return await _booksService.GetBookById(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromQuery] CreateNewBooks updateBooks)
        {
            return await _booksService.UpdateBook(id, updateBooks);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            return await _booksService.DeleteBook(id);
        }

        [HttpGet("byGenre/{genreId}")]
        public async Task<IActionResult> GetBooksByGenre(int genreId)
        {
            return await _booksService.GetBooksByGenre(genreId);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchBooks(string query)
        {
           return await _booksService.SearchBooks(query);
        }

        [HttpGet("{title}/available-copies")]
        public async Task<IActionResult> GetAvailableCopies([Required][FromRoute] string title)
        {
            return await _booksService.GetAvailableCopies(title);
        }
    }
}
