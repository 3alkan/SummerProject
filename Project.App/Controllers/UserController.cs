using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Entities.Concrete;

namespace Project.App.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // [GET] Get All Users
        [HttpGet()]
        public IActionResult Index()
        {
            var users = _userService.GetAll();
            return View(users);
        }
        // [GET] Get user by id
        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // return add view
        [HttpGet("add")]
        public IActionResult Add()
        {
            return View();
        }
        // [POST] Add new user
        [HttpPost("add")]
        public IActionResult Add([FromForm] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            _userService.Add(user);
            return RedirectToAction(nameof(Index));
        }

        // return edit view
        [HttpGet("edit/{id}")]
        public IActionResult Update(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View("Edit", user);
        }

        // [PUT] update a user
        [HttpPost("edit/{id}")]
        public IActionResult Update(int id, [FromForm] User user)
        {
            if (user == null || user.UserId != id)
            {
                return BadRequest();
            }
            var existingUser = _userService.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            existingUser.Username=user.Username;
            existingUser.Email=user.Email;
            existingUser.Password=user.Password;

            _userService.Update(existingUser);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm] int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var existingUser = _userService.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            _userService.Delete(existingUser);

            return RedirectToAction(nameof(Index));
        }

    }
}