using Proyecto_Integracion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Integracion.WebApp.Utils;

namespace Proyecto_Integracion.WebApp.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Detalles(long Id)
        {
            Reporte r = new Reporte();
            r.Seleccionar(Id);
            return View(r);
        }

        public ActionResult Crear()
        {
            if (Utils.SessionManager.PerfilActivo() != null && Utils.SessionManager.CuentaActiva() != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Crear(Reporte r, Ubicacion u)
        {
            var perfil_Activo = Utils.SessionManager.PerfilActivo();
            if (perfil_Activo != null && Utils.SessionManager.CuentaActiva() != null)
            {
                u.Direccion = Utils.GeoLocation.direccion(u);
                if (u.Crear())
                {
                    
                    r.Perfil = perfil_Activo;
                    r.Ubicacion = u;
                    if (r.Crear())
                        return RedirectToAction("Detalles", "Perfil", new { Id = perfil_Activo.Id });
                    else
                        return RedirectToAction("Index", "Home");

                }

            }
            return RedirectToAction("Index", "Home");
        }

        //GET: modifcicar/Id
        public ActionResult Modificar(long Id)
        {
            Reporte r = new Reporte();
            r.Seleccionar(Id);
            if (Utils.SessionManager.PerfilActivo() != null && Utils.SessionManager.CuentaActiva() != null)
            {
                if (r.Perfil.Id == Utils.SessionManager.PerfilActivo().Id)
                {
                    return View(r);
                }
            }
            else
                return RedirectToAction("Index","Home");
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public ActionResult Modificar(Reporte r, Ubicacion u)
        {
            return RedirectToAction("Index","Home");
        }
    }
}