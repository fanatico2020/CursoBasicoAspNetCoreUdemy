using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Site01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //return new ContentResult() { Content = "Ola mundo hehehehe",ContentType = "text/plain"};
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login([FromForm] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (usuario.Email == "italo.ramon2020@gmail.com" && usuario.Senha == "123456")
                {

                    //Add session
                    HttpContext.Session.SetString("Login", "true");

                    //Ler session
                    string login = HttpContext.Session.GetString("Login");

                    return RedirectToAction("Index","Palavra");
                }
                else
                {
                    ViewBag.Mesangem = "Os dados informados são inválidos!";
                    return View();
                }
            }
            else
            {
                return View();
            }
            
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
    }
}
