using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Form_Submission.Models;

namespace Form_Submission
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {

            ViewBag.errors = TempData["errors"];
            return View();
        }

        [HttpPost]
        [Route("submit_form")]
        public IActionResult SubmitForm(string first_name, string last_name, int Age, string Email, string Password)
        {
            MyUser NewUser = new MyUser
            {
                FirstName = first_name,
                LastName = last_name,
                Age = Age,
                Email = Email,
                Password = Password
            };

            TryValidateModel(NewUser);
            if(ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            else
            {
                ViewBag.errors = ModelState.Values;
                return View();
            }
        }

        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            return View();
        }
    }
}
