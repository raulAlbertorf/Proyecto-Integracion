using Proyecto_Integracion.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

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
        public ActionResult Modificar(long Id)
        {
           
            if(Utils.SessionManager.CuentaActiva() !=null && Utils.SessionManager.PerfilActivo() != null && Utils.SessionManager.PerfilActivo().Id == Id)
            {
                Perfil p = new Perfil();
                p.Seleccionar(Id);
                return View(p);
            }
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public ActionResult Modificar(Perfil p, Ubicacion u)
        {
            if (!Utils.Validator.isNullOrEmptyOrWhiteSpace(new List<String>() { p.Nombre, Convert.ToString(u.Latitud), Convert.ToString(u.Longitud) }))
            {
                p.Seleccionar(p.Id);
                p.Ubicacion.Latitud = u.Latitud;
                p.Ubicacion.Longitud = u.Longitud;
                p.Ubicacion.Direccion = Utils.GeoLocation.direccion(p.Ubicacion);
                if (p.Modificar() && p.Ubicacion.Modificar())
                {
                    Utils.UIWarnings.SetInfo("Módificacion dde perfil exitosa");
                    return RedirectToAction("Detalles", "Perfil", new { Id = p.Id });
                }
            }
            else
            {
                Utils.UIWarnings.SetError("No tiene los permisos para realizar modificaciones a este perfil");
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult MisReportes(int? page, long Id)
        {
            Cuenta cuenta = Utils.SessionManager.CuentaActiva();
            Perfil perfilActivo = Utils.SessionManager.PerfilActivo();
            Perfil p = new Perfil();

            if (cuenta != null && perfilActivo != null && p.Seleccionar(Id))
            {
               List<Proyecto_Integracion.Models.Reporte> items = p.MisReportes();
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(items.ToPagedList(pageNumber, pageSize));
            }
            return RedirectToAction("Ingresar", "Cuenta");
        }
    }
}