using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Project.App.Models;
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
            var models = new List<UserIndexViewModel>();
            foreach (var user in users)
            {
                models.Add(new UserIndexViewModel
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Email = user.Email
                });
            }
            return View(models);
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
            var model = new UserDetailsViewModel
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email
            };
            return View(model);
        }

        // return add view
        [HttpGet("add")]
        public IActionResult Add()
        {
            var user = new User();
            return View(user);
        }
        // [POST] Add new user
        [HttpPost("add")]
        public IActionResult Add([FromForm] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (string.IsNullOrEmpty(user.Username) || user.Username.Length < 3)
            {
                ViewBag.Message = "Username can not be empty and must be at least 3 characters";
                return View(user);
            }
            var existingUser = _userService.Get(u => u.Username == user.Username);
            if (existingUser != null)
            {
                ViewBag.Message = "Already exist a user with this username";
                return View(user);
            }
            else
            {
                _userService.Add(user);
            }
            return RedirectToAction(nameof(Index));
        }

        // return edit view
        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            var model = new UserEditViewModel
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                OldPassword = "",
                NewPassword = "",
                Message = ""
            };
            return View(model);
        }

        // [PUT] update a user
        [HttpPost("edit/{id}")]
        public IActionResult Edit(int id, [FromForm] UserEditViewModel model)
        {
            if (model == null || model.UserId != id)
            {
                return BadRequest();
            }
            // check for username
            Expression<Func<User, bool>> filter = u => u.UserId != model.UserId && u.Username == model.Username;
            var usersWithUsername = _userService.GetAll(filter);
            if (usersWithUsername != null && usersWithUsername.Count > 0)
            {
                model.Message = "Already exist a user with this username";
                model.OldPassword = "";
                model.NewPassword = "";
                return View(model);
            }
            // check for password
            var existingUser = _userService.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(model.OldPassword))
            {
                if (existingUser.Password != model.OldPassword)
                {
                    model.Message = "Wrong Old Password!";
                    model.OldPassword = "";
                    model.NewPassword = "";
                    return View(model);
                }
                else{
                    existingUser.Password=model.NewPassword;
                }
            }
            existingUser.Username = model.Username;
            existingUser.Email = model.Email;

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