using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Integracion.Models;
namespace Proyecto_Integracion.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Estanteria e = new Estanteria();
            return View(e);
        }

        // GET: Home
        public ActionResult About()
        {
            return View();
        }
    }
}