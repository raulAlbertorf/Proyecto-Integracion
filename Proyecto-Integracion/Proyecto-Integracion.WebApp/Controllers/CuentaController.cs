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
            Utils.UIWarnings.SetInfo("Sesión cerrada");
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
                    p.UrlImagen = "PICON_023.png"; //imagen por default
                    u.Direccion = Utils.GeoLocation.direccion(u);
                    if (u.Crear())
                    {
                        p.Ubicacion = u;
                        p.Crear();
                        Utils.SessionManager.RegistarPerfil(p.Id);

                        String body = "Hola,<br> Bienvenido a ReportIt,<br> Esperamos que nuestra aplicación te sea de ayuda<br><br>Saludos";

                        Utils.Email.SendEmail("Bienvenido a ReportIt", c.Email, body);
                        Utils.UIWarnings.SetInfo("Cuenta creada exitosamente");
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
        [HttpPost]
        public ActionResult OlvidePassword(Cuenta p)
        {
            string nuevopassword = p.CreatePassword(8);
            if (p.CambiarContrasena(nuevopassword))
            {
                string subject = "Nueva contraseña ReportIt";
                string mensaje = string.Format("Hola, <br><br> Tu nueva contraseña es: {0}. <br><br>Saludos<br><br>ReportIt", nuevopassword);

                Utils.Email.SendEmail(subject, p.Email, mensaje);
                Utils.UIWarnings.SetInfo("Su nueva contraseña ha sido enviada al correo: " + p.Email);
                return RedirectToAction("Ingresar", "Cuenta");
            }
            Utils.UIWarnings.SetError("Lo sientimos, No se pudo recuperar la contraseña.");
            return RedirectToAction("Ingresar", "Cuenta");
        }

        [HttpPost]
        public ActionResult CambiarContrasena(Cuenta p, string confirm_password)
        {
            if (p != null)
            {
                if (p.Contrasena == confirm_password)
                {
                    if (p.CambiarContrasena(p.Contrasena))
                    {
                        Utils.UIWarnings.SetInfo("Se ha cambiado su contraseña Exitosamente");
                        return RedirectToAction("Index", "Home");
                    }
                }
                Utils.UIWarnings.SetError("Lo sientimos, No se pudo cambiar la contraseña.");
                return RedirectToAction("Index", "Home");
            }
            Utils.UIWarnings.SetError("Usted no tiene los permisos para cambiar una contraseña.");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult CambiarPassword()
        {
            Cuenta c = Utils.SessionManager.CuentaActiva();
            if (c != null)
            {
                return View(c);
            }
            Utils.UIWarnings.SetError("Debe estar autenticado para cambiar su contraseña.");
            return RedirectToAction("Ingresar", "Cuenta");
        }

        public ActionResult Eliminar(Cuenta c)
        {
            if(Utils.SessionManager.CuentaActiva() != null && Utils
                .SessionManager.PerfilActivo() != null)
            {
                if (c.Eliminar())
                {
                    Utils.UIWarnings.SetInfo("Su cuenta de ReportIt ha sido eliminada exitosamente");
                    Utils.SessionManager.Salir();
                }
            }
            return RedirectToAction("Index","Home");

        }
    }
}