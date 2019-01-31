using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEbFirebaseAuth.Models;
using Microsoft.AspNetCore.Http;

namespace WEbFirebaseAuth.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index([FromQuery] string UKey,[FromQuery] string Type)
        {

            if (UKey != null && Type != null)
            {
                TempData["UKey"] = UKey;
                ViewBag.Type = Type;
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult register(string email)
        {
            ClassDM cd = new ClassDM();
            var UKey = TempData["UKey"].ToString();
            int a=cd.SaveData(email, UKey);
            if (a == 1)
                return Json("Success");
            else
                return Json("Exist");
        }
    }
}
