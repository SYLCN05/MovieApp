using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Server.Models;

namespace MovieApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MovieController : Controller
    {
        private ApplicationDBContext _context;
        public MovieController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet("GetMovies")]
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }
    }
}
