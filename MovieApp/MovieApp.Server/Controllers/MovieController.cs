using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task<IEnumerable<Movie>> GetMovies(int pageIndex=0, int pageSize=10)
        {
            if(pageIndex >=0 && pageIndex <= 99)
            {
                return await _context.Movies.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
            }
            else
            {
                return new List<Movie>();
            }
            
        }
        [HttpGet("GetMovie")]
        public async Task<IActionResult> GetMovie(int movieId)
        {
            if (movieId >=1 && movieId <= 1000 )
            {
                var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

                return Ok(movie);
            }
            else
            {
                return BadRequest("Invalid ID");
            }
           
        }
    }
}
