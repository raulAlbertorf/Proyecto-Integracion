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
                Perfil perfil = new Perfil();
                perfil.Seleccionar(c.Email);
                Utils.SessionManager.RegistarPerfil(perfil.Id);
                return RedirectToAction("Index", "Home");
            }
            Utils.UIWarnings.SetError("Su Email o Contraseña es incorrecto");
            return View();
        }

        public ActionResult Salir()
        {
            Utils.SessionManager.Salir();
            return RedirectToAction("Index", "Home");
        }

        //Get : Cuenta
        public ActionResult Crear()
        {
            Cuenta c = Utils.SessionManager.CuentaActiva();
            if (c != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Cuenta c, Perfil p, Ubicacion u)
        {
            if (!Utils.Validator.isNullOrEmptyOrWhiteSpace(new List<String>() { c.Email, c.Contrasena, p.Nombre}) && Utils.Validator.esValido(c.Email))
            {
                if (c.Crear())
                {
                    Utils.SessionManager.Ingresar(c.Email);
                    p.Cuenta = c;
                    p.UrlImagen = "PICON_029.png"; //imagen por default
                    u.Direccion = Utils.GeoLocation.direccion(u);
                    if (u.Crear())
                    {
                        p.Ubicacion = u;
                        p.Crear();
                        Utils.SessionManager.RegistarPerfil(p.Id);

                        //String body = "Hola,<br> Bienvenido a Libromatico,<br> Esperamos que pronto puedas comenzar a compartir o leer nuevos libros<br><br>Saludos";

                        //Utils.Email.SendEmail("Bienvenido a Libromatico", c.Email, body);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    Utils.UIWarnings.SetError("Ya existe una cuenta usando este Email");
                    return RedirectToAction("Ingresar", "Cuenta");
                }
            }
            Utils.UIWarnings.SetError("Campos invalidos");
            return RedirectToAction("Ingresar", "Cuenta");

        }
    }
}