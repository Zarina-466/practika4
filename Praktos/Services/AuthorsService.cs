using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Praktos.DatabaseContext;
using Praktos.Interfaces;
using Praktos.Model;
using Praktos.Requests;

namespace Praktos.Services
{
    public class AuthorsService : IAuthorsService
    {
        readonly TestApiDB _context;
        public AuthorsService(TestApiDB context)
        {
            _context = context;
        }
        public async Task<IActionResult> CreateNewAutors([FromQuery] CreateNewAutors newAutors)
        {
            try
            {
                var autors = new Autors()
                {
                    FName = newAutors.FirstName,
                    LName = newAutors.LastName,
                };
                await _context.Autors.AddAsync(autors);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        public async Task<IActionResult> DeleteAutor(int id)
        {
            if (id <= 0)
            {
                return new BadRequestObjectResult("Некорректный идентификатор автора.");
            }
            try
            {
                var autors = await _context.Autors.FindAsync(id);
                if (autors == null)
                {
                    return new NotFoundObjectResult("Автор с указанным идентификатором не найден.");
                }

                _context.Autors.Remove(autors);
                await _context.SaveChangesAsync();

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Внутренняя ошибка сервера: {ex.Message}") { StatusCode = 500 };
            }
        }

        public async Task<IActionResult> GetAutors()
        {
            try
            {
                var autors = await _context.Autors.ToListAsync();
                var autorsDto = autors.Select(b => new GetAllAutors
                {
                    Id_Autors = b.Id_Autors,
                    FName = b.FName,
                    LName = b.LName
                });
                return new OkObjectResult(autorsDto);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Внутренняя ошибка сервера: {ex.Message}") { StatusCode = 500 };
            }
        }

        public async Task<IActionResult> UpdateAutor(int id, [FromQuery] CreateNewAutors updateAutors)
        {
            if (id <= 0 || updateAutors == null)
            {
                return new BadRequestObjectResult("Некорректные данные для обновления автора.");
            }
            try
            {
                var autors = await _context.Autors.FindAsync(id);
                if (autors == null)
                {
                    return new NotFoundObjectResult("Автор с указанным идентификатором не найден.");
                }

                autors.FName = updateAutors.FirstName;
                autors.LName = updateAutors.LastName;

                _context.Autors.Update(autors);
                await _context.SaveChangesAsync();

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Внутренняя ошибка сервера: {ex.Message}") { StatusCode = 500 };
            }
        }
    }
}
