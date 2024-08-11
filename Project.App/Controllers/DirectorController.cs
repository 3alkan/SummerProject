using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Project.Business.Abstract;
using Project.Entities.Concrete;
using Project.App.Models;



namespace Project.App.Controllers
{
    [Route("directors")]
    public class DirectorController : Controller
    {
        private readonly IDirectorService _directorService;

        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        [HttpGet()]
        public IActionResult Index()
        {
            var directors = _directorService.GetAll();
            return View(directors);
        }

        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            Expression<Func<Director, bool>> filter = d => d.DirectorId == id;
            var includes = new List<Expression<Func<Director, object>>> { d => d.Films };

            var director = _directorService.Get(filter, includes);
            if (director == null)
            {
                return NotFound();
            }
            return View(director);

        }

        [HttpGet("add")]
        public IActionResult Add()
        {
            var director = new Director();
            return View(director);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] Director director)
        {
            if (director == null)
            {
                return BadRequest();
            }
            if (string.IsNullOrWhiteSpace(director.Name) || director.Name.Length < 3)
            {
                ViewBag.Message = "Director name can not be empty and must be at least 3 characters";
                return View(director);
            }
            var existingDirector = _directorService.Get(d => d.Name == director.Name);
            if (existingDirector != null)
            {
                ViewBag.Message = "Already exist a director with this name";
                return View(director);
            }
            else
            {
                _directorService.Add(director);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var director = _directorService.GetById(id);
            if (director == null)
            {
                return NotFound();
            }
            return View(director);
        }

        [HttpPost("edit/{id}")]
        public IActionResult Edit(int id, [FromForm] Director director)
        {
            if (director == null || director.DirectorId != id)
            {
                return NotFound();
            }
            if (string.IsNullOrWhiteSpace(director.Name) || director.Name.Length < 3)
            {
                ViewBag.Message = "Director name can not be empty or shorter than 3 characters";
                return View(director);
            }
            var existingDirector = _directorService.GetById(id);
            if (existingDirector == null)
            {
                return NotFound();
            }
            existingDirector.Name = director.Name;
            _directorService.Update(existingDirector);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm] int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            Expression<Func<Director, bool>> filter = d => d.DirectorId == id;
            var includes = new List<Expression<Func<Director, object>>> { d => d.Films };
            var existingDirector = _directorService.Get(filter, includes);
            if (existingDirector == null)
            {
                return NotFound();
            }
            if (existingDirector.Films != null && existingDirector.Films.Count > 0)
            {
                TempData["Message"] = "You cannot delete a director if there is any film associated with this director.";
                return RedirectToAction(nameof(Details), new { id });
            }

            _directorService.Delete(existingDirector);

            return RedirectToAction(nameof(Index));
        }
    }
}