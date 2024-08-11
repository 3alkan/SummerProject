using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Business.Abstract;
using Project.Entities.Concrete;
using Project.App.Models;
using System.Linq.Expressions;
using System;

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

            var films = _filmService.GetAll(includes: includes);
            List<FilmIndexViewModel> filmModels = new List<FilmIndexViewModel>();
            foreach (var film in films)
            {
                filmModels.Add(new FilmIndexViewModel
                {
                    FilmId = film.FilmId,
                    Title = film.Title,
                    Description = film.Description,
                    Year = film.Year,
                    DirectorName = film.Director.Name
                });
            }
            return View(filmModels);
        }

        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            Expression<Func<Film, bool>> filter = f => f.FilmId == id;
            var includes = new List<Expression<Func<Film, object>>> { f => f.Director, f => f.Reviews };

            var film = _filmService.Get(filter, includes);
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
            if (string.IsNullOrWhiteSpace(model.DirectorName) || model.DirectorName.Length < 3)
            {
                model.Message = "Director name can not be empty or shorter than 3 characters";
                return View(model);
            }

            if (Request.Form["SearchDirector"] == "SearchDirector")
            {
                // searching
                model.Directors = _directorService.GetAll(d => EF.Functions.Like(d.Name, $"%{model.DirectorName}%"));
                if (model.Directors == null || model.Directors.Count == 0)
                {
                    model.Message = "No match found with " + model.DirectorName;
                }
                return View(model);
            }
            if (Request.Form["Add"] == "Add")
            {
                var existingFilms = _filmService.GetAll(f => f.Title == model.Title);
                if (model.DirectorId == 0)
                {
                    var selectedDirector = _directorService.Get(d => d.Name == model.DirectorName);
                    // Create new director if not found
                    if (selectedDirector == null)
                    {
                        var newDirector = new Director { Name = model.DirectorName };
                        _directorService.Add(newDirector);
                        model.DirectorId = newDirector.DirectorId;
                    }
                    else
                    {
                        // with same film and director name there exist a film
                        if (existingFilms != null)
                        {
                            foreach (var film in existingFilms)
                            {
                                if (film.DirectorId == selectedDirector.DirectorId)
                                {
                                    model.Message = "Already exist a film with this name and director";
                                    return View(model);
                                }
                            }
                        }
                        model.DirectorId = selectedDirector.DirectorId;
                    }
                }
                else
                {
                    // with same film and director name there exist a film
                    if (existingFilms != null)
                    {
                        foreach (var film in existingFilms)
                        {
                            if (film.DirectorId == model.DirectorId)
                            {
                                model.Message = "Already exist a film with this name and director";
                                return View(model);
                            }
                        }
                    }
                }

                var newFilm = new Film
                {
                    Title = model.Title,
                    Description = model.Description,
                    Year = model.Year,
                    Time = model.Time,
                    DirectorId = model.DirectorId
                };
                _filmService.Add(newFilm);
            }
            return RedirectToAction(nameof(Index));
        }


        // return edit view
        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            Expression<Func<Film, bool>> filter = f => f.FilmId == id;
            var includes = new List<Expression<Func<Film, object>>> { f => f.Director };
            var film = _filmService.Get(filter, includes);
            if (film == null)
            {
                return NotFound();
            }
            var editModel = new FilmEditViewModel
            {
                FilmId = film.FilmId,
                Title = film.Title,
                Description = film.Description,
                Year = film.Year,
                Time = film.Time,
                OriginalDirectorId = film.DirectorId,
                OriginalDirectorName = film.Director.Name,
                NewDirectorName = "",
                NewDirectorId = 0,
                ShowSearchDirector = false,
                Message = ""
            };
            return View(editModel);
        }

        // [PUT] update a film
        [HttpPost("edit/{id}")]
        public IActionResult Edit(int id, [FromForm] FilmEditViewModel model)
        {
            if (model == null || model.FilmId != id)
            {
                return NotFound();
            }
            if (Request.Form[nameof(model.ShowSearchDirector)] == "true")
            {
                model.ShowSearchDirector = true;
            }
            else
            {
                model.ShowSearchDirector = false;
            }

            if (Request.Form["ChangeDirector"] == "ChangeDirector")
            {
                model.ShowSearchDirector = true;
                return View(model);
            }

            if (Request.Form["SearchDirector"] == "SearchDirector")
            {
                //model.ChangeDirector = "true";
                if (string.IsNullOrWhiteSpace(model.NewDirectorName) || model.NewDirectorName.Length < 3)
                {
                    model.Message = "Director name can not be empty or shorter than 3 characters";
                    return View(model);
                }
                // searching
                model.Directors = _directorService.GetAll(d => EF.Functions.Like(d.Name, $"%{model.NewDirectorName}%"));
                if (model.Directors == null || model.Directors.Count == 0)
                {
                    model.Message = "No match found with " + model.NewDirectorName;
                }
                return View(model);
            }
            if (Request.Form["Save"] == "Save")
            {
                if (model.ShowSearchDirector == true)
                {
                    if (model.NewDirectorId == 0)
                    {
                        if (string.IsNullOrWhiteSpace(model.NewDirectorName) || model.NewDirectorName.Length < 3)
                        {
                            model.Message = "Director name can not be empty or shorter than 3 characters";
                            return View(model);
                        }
                        if (model.NewDirectorName == model.OriginalDirectorName)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                        var includes = new List<Expression<Func<Director, object>>> { d => d.Films };
                        Expression<Func<Director, bool>> filter = d => d.Name == model.NewDirectorName;
                        var selectedDirector = _directorService.Get(filter, includes);
                        // Create new director if not found
                        if (selectedDirector == null)
                        {
                            var newDirector = new Director { Name = model.NewDirectorName };
                            _directorService.Add(newDirector);
                            model.NewDirectorId = newDirector.DirectorId;
                        }
                        else
                        {
                            if (selectedDirector.Films != null && selectedDirector.Films.Any(f => f.Title == model.Title))
                            {
                                model.Message = "Already exist a film with this name and director";
                                return View(model);
                            }
                            model.NewDirectorId = selectedDirector.DirectorId;
                        }
                    }
                    else
                    {
                        if (model.NewDirectorId == model.OriginalDirectorId)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                        var includes = new List<Expression<Func<Director, object>>> { d => d.Films };
                        var selectedDirector = _directorService.Get(d => d.DirectorId == model.NewDirectorId, includes);
                        if (selectedDirector.Films != null && selectedDirector.Films.Any(f => f.Title == model.Title))
                        {
                            model.Message = "Already exist a film with this name and director";
                            return View(model);
                        }

                    }

                }

                var existingFilm = _filmService.GetById(id);
                if (existingFilm == null)
                {
                    return NotFound();
                }
                existingFilm.Title = model.Title;
                existingFilm.Description = model.Description;
                existingFilm.Year = model.Year;
                existingFilm.Time = model.Time;
                if (model.ShowSearchDirector == true)
                {
                    existingFilm.DirectorId = model.NewDirectorId;

                }

                _filmService.Update(existingFilm);
            }
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