using ASp_MVC.Models;
using ASp_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Globalization;
using ASp_MVC.Filters;

namespace ASp_MVC.Controllers
{
    [LogActionFilter]
     public class HomeController : Controller
    {
        static int _userId = 1;
        static int  _consultId = 1;
        private static readonly List<User> _users = new();

        private static readonly List<Consult> _consults = new();
        private static readonly List<string> _subjects = new List<string> { "JavaScript", "C#", "Java", "Python", "Основи" };

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Subjects = new SelectList(_subjects);
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [UniqUserFilter]
        [HttpPost]
        public ActionResult SignUp(User user)
        {
            Console.WriteLine(user.Login);
            if (ModelState.IsValid)
            {
                user.Id = _userId;
                Console.WriteLine($"user.Id ---- {user.Id}");
                _users.Add(user);
                Response.Cookies.Append("userId", _userId.ToString());
                _userId++;

                return View("SignUp");
            }
            else
            {
                foreach (var key in ModelState.Keys)
                {
                    for (int i = 0; i < ModelState[key].Errors.Count; i++)
                    {
                        var error = ModelState[key].Errors[i];
                        ModelState.AddModelError(key, error.ErrorMessage);
                    }
                }

                ViewBag.Subjects = new SelectList(_subjects);
                return View("SignUp", user);
            }
        }


        [HttpPost]
        public IActionResult Register(Consult consult)
        {
            if (ModelState.IsValid)
            {
                if (consult.Subject == "Основи" && consult.Date.DayOfWeek == DayOfWeek.Monday)
                {
                    ModelState.AddModelError("DateOfConsultation", "Консультація щодо 'Основи' не може проходити по понеділках.");
                    ViewBag.Subjects = new SelectList(_subjects);
                    return View("Index", consult);
                }

                consult.Id = _consultId;
                _consults.Add(consult);
                _consultId++;

                ModelState.Clear();

                return RedirectToAction("Index");
            }
            else
            {
                foreach (var key in ModelState.Keys)
                {
                    for (int i = 0; i < ModelState[key].Errors.Count; i++)
                    {
                        var error = ModelState[key].Errors[i];
                        ModelState.AddModelError(key, error.ErrorMessage);
                    }
                }

                ViewBag.Subjects = new SelectList(_subjects);
                return View("Index", consult);
            }
        }

        public IActionResult ShowConsults()
        {
            ShowConsultsViewModel showConsultsViewModel = new(_consults);
            return View(showConsultsViewModel);
        }

    }
}