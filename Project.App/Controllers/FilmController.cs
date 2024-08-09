using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Entities.Concrete;
using Project.App.Models;
using System.Linq.Expressions;

namespace Project.App.Controllers
{
    [Route("films")]
    public class FilmController : Controller
    {
        private readonly IFilmService _filmService;
        private readonly IDirectorService _directorService;

        public FilmController(IFilmService filmService, IDirectorService directorService)
        {
            _filmService = filmService;
            _directorService = directorService;
        }

        [HttpGet()]
        public IActionResult Index()
        {
            var includes = new List<Expression<Func<Film, object>>>
            {
                f=>f.Director
            };

            var films = _filmService.GetAll(includes:includes);
            List<FilmIndexViewModel> filmModels=new List<FilmIndexViewModel>();
            foreach(var film in films){
                filmModels.Add(new FilmIndexViewModel
                {
                    FilmId=film.FilmId,
                    Title=film.Title,
                    Description=film.Description,
                    Year=film.Year,
                    DirectorName=film.Director.Name
                });
            }
            return View(filmModels);
        }

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

        [HttpGet("add")]
        public IActionResult Add()
        {
            var model = new FilmAddViewModel();
            return View(model);
        }

        // [POST] Add new film
        [HttpPost("add")]
        public IActionResult Add([FromForm] FilmAddViewModel model)
        {
            if (Request.Form["search"] == "true")
            {
                // Perform director search
                model.Directors = _directorService.GetAll(d => d.Name == model.DirectorName);
                return View(model); // Re-render the form with the updated director list
            }

            // Handle director selection or creation
            if (model.Film.DirectorId == 0)
            {
                if (model.DirectorName == "")
                {
                    return BadRequest();
                }
                var selectedDirector = _directorService.Get(d => d.Name == model.DirectorName);
                // Create new director if not found
                if (selectedDirector == null)
                {
                    var newDirector = new Director { Name = model.DirectorName };
                    _directorService.Add(newDirector);
                    model.Film.DirectorId = newDirector.DirectorId; // Assign new director ID to film
                }
                else
                {
                    model.Film.DirectorId = selectedDirector.DirectorId;
                }
            }

            _filmService.Add(model.Film);
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
            /* existingFilm.Title=film.Title;
            existingFilm.Description=film.Description;
            existingFilm.Year=film.Year;
            existingFilm.Time=film.Time;
            existingFilm.Rate=film.Rate;
            existingFilm.DirectorId=film.DirectorId;
            existingFilm.DirectorName=film.DirectorName; */

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