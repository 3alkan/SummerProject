using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Entities.Concrete;

namespace Project.App.Controllers
{
    [Route("films")]
    public class FilmController : Controller
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        // [GET] Get All Films
        [HttpGet()]
        public IActionResult Index()
        {
            var films = _filmService.GetAll();
            return View(films);
        }
        // [GET] Get film by id
        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            var film = _filmService.GetById(id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        // return add view
        [HttpGet("add")]
        public IActionResult Add()
        {
            return View();
        }
        // [POST] Add new film
        [HttpPost("add")]
        public IActionResult Add([FromForm] Film film)
        {
            if (film == null)
            {
                return BadRequest();
            }
            _filmService.Add(film);
            return RedirectToAction(nameof(Index));
        }

        // return edit view
        [HttpGet("edit/{id}")]
        public IActionResult Update(int id)
        {
            var film = _filmService.GetById(id);
            if (film == null)
            {
                return NotFound();
            }
            return View("Edit", film);
        }

        // [PUT] update a film
        [HttpPost("edit/{id}")]
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
            existingFilm.Title=film.Title;
            existingFilm.Description=film.Description;
            existingFilm.Year=film.Year;
            existingFilm.Time=film.Time;
            existingFilm.Rate=film.Rate;
            existingFilm.DirectorId=film.DirectorId;
            existingFilm.DirectorName=film.DirectorName;

            _filmService.Update(existingFilm);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm] int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var existingFilm = _filmService.GetById(id);
            if (existingFilm == null)
            {
                return NotFound();
            }

            _filmService.Delete(existingFilm);

            return RedirectToAction(nameof(Index));
        }

    }
}