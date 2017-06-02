using Proyecto_Integracion.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Integracion.WebApp.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        public ActionResult Detalles(long Id)
        {
            Cuenta cuenta = Utils.SessionManager.CuentaActiva();
            Perfil perfilActivo = Utils.SessionManager.PerfilActivo();
            Perfil perfil = new Perfil();
            perfil.Seleccionar(Id);
            if (cuenta != null && perfilActivo != null)
            {
                return View(perfil);
            }
            else
            {
                return RedirectToAction("Ingresar", "Cuenta");
            }
        }

        [HttpPost]
        public ActionResult CargarImagen(Int64 Id)
        {
            string directory = System.AppDomain.CurrentDomain.BaseDirectory + @"Contents\img\perfiles";
            HttpPostedFileBase photo = Request.Files["photo"];
            var perfil = new Perfil();
            perfil.Seleccionar(Id);
            try
            {
                if (photo != null && photo.ContentLength > 0 && Utils.Validator.verificarExtension(Path.GetExtension(photo.FileName)))
                {
                    if (photo.FileName.Length > 30)
                    {
                        Utils.UIWarnings.SetError("Nombre de la imagen demasiado largo");
                        return RedirectToAction("Detalles", "Perfil", new { Id = Id });
                    }
                    var fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);

                    photo.SaveAs(Path.Combine(directory, fileName));
                    perfil.UrlImagen = fileName;
                    if (!perfil.ModificarImagen())
                    {
                        Utils.UIWarnings.SetError("No se pudo agregar la imagen");
                        return RedirectToAction("Detalles", "Perfil", new { Id = Id });
                    }
                    else
                    {
                        Utils.UIWarnings.SetInfo("Modificación realizada");
                        return RedirectToAction("Detalles", "perfil", new { Id = Id });
                    }
                }
                else
                {
                    Utils.UIWarnings.SetError("El archivo no corresponde a una imagen");
                    return RedirectToAction("Detalles", "perfil", new { Id = Id });
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //GET:Modificar
        public ActionResult Modificar()
        {
            if(Utils.SessionManager.CuentaActiva() !=null && Utils.SessionManager.PerfilActivo() != null)
            {
                return View();
            }
            return RedirectToAction("Index","Home");
        }
    }
}