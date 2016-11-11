using GameStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;


namespace GameStore.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            StartPage startPage = new StartPage();
            startPage.LatestGames = Helpers.GameHelper.GetLatestGames(4);
            return View(startPage);
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(string Name, string Email, string Message)
        {
            ViewBag.Name = Name;
            ViewBag.Email = Email;
            ViewBag.Message = Message;

            MailMessage mailObj = new MailMessage(
                              Email,
                              "info@gamestore.com",
                              "you got a message from your website from" + Name,
                              Message);
            SmtpClient SMTPServer = new SmtpClient("127.0.0.1");
            SMTPServer.Send(mailObj);


            return View();
        }

        public ActionResult FindUs()
        {
            return View();
        }

    }
}