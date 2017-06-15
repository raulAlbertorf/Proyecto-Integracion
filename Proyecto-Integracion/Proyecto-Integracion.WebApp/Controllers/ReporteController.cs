using Proyecto_Integracion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Integracion.WebApp.Utils;
using System.Globalization;

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
        public ActionResult Crear(Reporte r, Ubicacion u, FormCollection collection)
        {

            string date = Request.Form["date"];
            var perfil_Activo = Utils.SessionManager.PerfilActivo();
            if (perfil_Activo != null && Utils.SessionManager.CuentaActiva() != null)
            {
                u.Direccion = Utils.GeoLocation.direccion(u);
                if (u.Crear())
                {
                    
                    r.Perfil = perfil_Activo;
                    DateTime fecha;
                    DateTime.TryParse(date, out fecha);
                    r.FechaExpedicion = fecha;
                    r.Ubicacion = u;
                    if (r.Crear())
                    {
                        Utils.UIWarnings.SetError("Reporte creado exitosamente");
                        return RedirectToAction("Detalles", "Perfil", new { Id = perfil_Activo.Id });
                    }
                    else
                    {
                        Utils.UIWarnings.SetError("El reporte no pudo ser creado");
                        return RedirectToAction("Index", "Home");
                    }

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
            {
                Utils.UIWarnings.SetError("No tiene permisos para modificar este reporte");
                return RedirectToAction("Index", "Home");
            }
                
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public ActionResult Modificar(Reporte r, Ubicacion u, FormCollection collection)
        {
            u.Direccion = Utils.GeoLocation.direccion(u);
            u.Modificar();
            r.Ubicacion = u;
            string date = Request.Form["date"];
            DateTime fecha;
            DateTime.TryParse(date, out fecha);
            r.FechaExpedicion = fecha;
            if (r.Modificar())
            {
                Utils.UIWarnings.SetInfo("Modificación de reporte exitosa");
                return RedirectToAction("Detalles", "Reporte", new { Id = r.Id});
            }
            Utils.UIWarnings.SetError("No se pudo realizar las modificaciones del reporte");
            return RedirectToAction("Index","Home");
        }

        public ActionResult Eliminar(long Id)
        {
            var Perfil_activo = Utils.SessionManager.PerfilActivo();
            Reporte r = new Reporte();
            r.Seleccionar(Id);
            if(Perfil_activo != null && Utils.SessionManager.CuentaActiva() !=  null && Perfil_activo.Id == r.Perfil.Id)
            {
                r.Eliminar();
                Utils.UIWarnings.SetInfo("Eliminacion exitosa del reporte");
                return RedirectToAction("Detalles", "Perfil", new { Id = Perfil_activo.Id });
            }
            else
            {
                Utils.UIWarnings.SetError("No tiene los permisos necesarios");
                return RedirectToAction("Index", "Home");
            }
        }


    }
}