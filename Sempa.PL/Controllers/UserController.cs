using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Restaurant.DAL.Entitiy;
using Resturant.BLL.ModelVM.User;
using Resturant.BLL.Services.Abstraction;
using Resturant.BLL.Services.Implementation;

namespace Restaurant.PL.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        public UserController()
        {
            userService = new UserService();
        }
        public IActionResult GetAll()
        {
            var result = userService.GetAll();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult SaveUser(CreateUser user)
        {
            if (ModelState.IsValid)
            {
                var result = userService.Create(user);
                if (result.Item1 == false)
                    return RedirectToAction("GetAll", "User");
                ViewBag.Message = result.Item2;
                return View(user);
            }
            
            return View("Create",user);
        }
    }
}
