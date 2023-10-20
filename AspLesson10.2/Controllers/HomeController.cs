using AspLesson10._2.Models;
using AspLesson10._2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace AspLesson10._2.Controllers
{
    public class HomeController : Controller
    {
        SmtpMailSender SmtpMailSender { get;}
        IConfiguration Configuration { get; }
        public HomeController(IConfiguration configuration, SmtpMailSender smtpMailSender)
        {
            Configuration = configuration;
            SmtpMailSender = smtpMailSender;
        }
        public IActionResult Index()
        {
            return View();
        }

        public string ExternalEx()
        {
            string res = Configuration["Message"];
            return res;
        }

        public IActionResult Ex2()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Ex2(Email email)
        {
            SmtpMailSender.SendEmail(email);
            return RedirectToAction();
        }
    }
}
