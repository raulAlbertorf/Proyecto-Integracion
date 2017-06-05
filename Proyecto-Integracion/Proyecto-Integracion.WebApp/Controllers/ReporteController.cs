using Proyecto_Integracion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Integracion.WebApp.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Detalles(long Id)
        {
            Reporte r = new Reporte();
            return View(r);
        }

        public ActionResult Crear()
        {
            if(Utils.SessionManager.PerfilActivo() !=null && Utils.SessionManager.CuentaActiva()!=null)
            {
                return View();
            }
            return RedirectToAction("Index","Home");
        }   
    }
}