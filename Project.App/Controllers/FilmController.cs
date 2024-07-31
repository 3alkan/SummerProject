using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Entities.Concrete;

namespace Project.App.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class FilmController : Controller
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var films = _filmService.GetAll();
            return View(films);
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var film = _filmService.GetById(id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        [HttpPost]
        public IActionResult Create([FromForm] Film film)
        {
            if (film == null)
            {
                return BadRequest();
            }
            _filmService.Add(film);
            return RedirectToAction(nameof(Index));
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromForm] Film film)
        {
            if (film == null || film.FilmId != id)
            {
                return BadRequest();
            }
            var existingFilm = _filmService.GetById(id);
            if (existingFilm == null)
            {
                return NotFound();
            }
            _filmService.Update(film);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var film = _filmService.GetById(id);
            if (film == null)
            {
                return NotFound();
            }
            _filmService.Delete(film);
            return RedirectToAction(nameof(Index));
        }

    }
}