using Proyecto_Integracion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Integracion.WebApp.Controllers
{
    public class CuentaController : Controller
    {
        // GET: Cuenta
        public ActionResult Ingresar()
        {
            Cuenta c = Utils.SessionManager.CuentaActiva();
            if (c != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();

        }

        [HttpPost]
        public ActionResult Ingresar(Cuenta c)
        {
            if (!Utils.Validator.isNullOrEmptyOrWhiteSpace(new List<String>() { c.Email, c.Contrasena }) && c.IniciarSesion())
            {
                Utils.SessionManager.Ingresar(c.Email);
                Utils.SessionManager.RegistarPerfil(c.Perfiles().First().Id);
                return RedirectToAction("Perfiles", "Cuenta");
            }
            Utils.UIWarnings.SetError("Su Email o Contraseña es incorrecto");
            return View();
        }

    }
}