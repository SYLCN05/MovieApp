using Microsoft.AspNetCore.Mvc;
using MovieApp.Server.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
namespace MovieApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SeedController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _environment;

        public SeedController(ApplicationDBContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        [HttpPut("AddMovieData")]
        public async Task<IActionResult> MovieData()
        {
            var config = new CsvConfiguration(CultureInfo.GetCultureInfo("pt-BR"))
            {
                HasHeaderRecord = true,
                Delimiter = ";",
            };

            using var reader = new StreamReader(System.IO.Path.Combine(_environment.ContentRootPath, "Data/imdb_top_1000.csv"));

            using var csv = new CsvReader(reader, config);

            var existingMovies = await _context.Movies.ToDictionaryAsync(m => m.Series_Title);

            var records = csv.GetRecords<Movie>();
            var skippedRows = 0;

            return View();
        }
    }
}
