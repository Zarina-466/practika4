using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Praktos.DatabaseContext;
using Praktos.Interfaces;
using Praktos.Model;
using Praktos.Requests;

namespace Praktos.Services
{
    public class ReadersService : IReadersService
    {
        readonly TestApiDB _context;
        public ReadersService(TestApiDB context)
        {
            _context = context;
        }
        public async Task<IActionResult> CreateNewReaders([FromQuery] CreateNewReaders newReaders)
        {
            try
            {
                var readers = new Readers()
                {
                    FName = newReaders.FName,
                    LName = newReaders.FName,
                    DateOfBirth = newReaders.DateOfBirth,
                    ContactDetails = newReaders.ContactDetails,
                    RegistrationDate = DateTime.Now.Date
                };
                await _context.Readers.AddAsync(readers);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Внутренняя ошибка сервера: {ex.Message}") { StatusCode = 500 };
            }
        }

        public async Task<IActionResult> DeleteAutors(int id)
        {
            if (id <= 0)
            {
                return new BadRequestObjectResult("Некорректный идентификатор читателя.");
            }

            try
            {
                var readers = await _context.Readers.FindAsync(id);
                if (readers == null)
                {
                    return new NotFoundObjectResult("Читатель с указанным идентификатором не найдена.");
                }

                _context.Readers.Remove(readers);
                await _context.SaveChangesAsync();

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Внутренняя ошибка сервера: {ex.Message}") { StatusCode = 500 };
            }
        }

        public async Task<IActionResult> GetReaders(int page, int pageSize)
        {
            if (page <= 0 || pageSize <= 0)
            {
                return new BadRequestObjectResult("Параметры страницы и размера страницы должны быть положительными.");
            }

            try
            {
                var totalReaders = await _context.Readers.CountAsync();
                var totalPages = (int)Math.Ceiling(totalReaders / (double)pageSize);

                var readers = await _context.Readers
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var readersDto = readers.Select(r => new GetAllReaders
                {
                    Id_Readers = r.Id_Readers,
                    FName = r.FName,
                    LName = r.LName,
                    DateOfBirth = r.DateOfBirth,
                    ContactDetails = r.ContactDetails
                });

                var result = new
                {
                    CurrentPage = page,
                    TotalPages = totalPages,
                    TotalReaders = totalReaders,
                    Readers = readersDto
                };

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Внутренняя ошибка сервера: {ex.Message}") { StatusCode = 500 };
            }
        }

        public async Task<IActionResult> SearchBooks(string query)
        {
            if (query == null)
            {
                return new BadRequestObjectResult("Строка обязательна для поиска.");
            }

            try
            {
                var readers = await _context.Readers
                   .Where(b => b.FName.Contains(query) || b.LName.Contains(query))
                   .ToListAsync();

                if (readers == null)
                {
                    return new NotFoundObjectResult("Читатель с указанным идентификатором не найден.");
                }

                var readersDto = readers.Select(b => new GetAllReaders
                {
                    Id_Readers = b.Id_Readers,
                    FName = b.FName,
                    LName = b.LName,
                    DateOfBirth = b.DateOfBirth,
                    ContactDetails = b.ContactDetails
                });

                return new OkObjectResult(readersDto);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Внутренняя ошибка сервера: {ex.Message}") { StatusCode = 500 };
            }
        }

        public async Task<IActionResult> UpdateReaders(int id, [FromQuery] CreateNewReaders updateReaders)
        {
            if (id <= 0 || updateReaders == null)
            {
                return new BadRequestObjectResult("Некорректные данные для обновления читателя.");
            }
            try
            {
                var readers = await _context.Readers.FindAsync(id);
                if (readers == null)
                {
                    return new NotFoundObjectResult("Читатель с указанным идентификатором не найден.");
                }
                readers.FName = updateReaders.FName;
                readers.LName = updateReaders.LName;
                readers.DateOfBirth = updateReaders.DateOfBirth;
                readers.ContactDetails = updateReaders.ContactDetails;

                _context.Readers.Update(readers);
                await _context.SaveChangesAsync();

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Внутренняя ошибка сервера: {ex.Message}") { StatusCode = 500 };
            }
        }
        public async Task<IActionResult> GetReadersF([FromQuery] DateTime? registrationDate = null)
        {
            try
            {
                var query = _context.Readers.AsQueryable();

                if (registrationDate.HasValue)
                {
                    query = query.Where(r => r.RegistrationDate == registrationDate.Value.Date);
                }

                var readers = await query.ToListAsync();

                var readersDto = readers.Select(b => new GetAllReaders
                {
                    Id_Readers = b.Id_Readers,
                    FName = b.FName,
                    LName = b.LName,
                    DateOfBirth = b.DateOfBirth,
                    ContactDetails = b.ContactDetails
                });

                return new OkObjectResult(readersDto);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Внутренняя ошибка сервера: {ex.Message}") { StatusCode = 500 };
            }
        }
    }
}
