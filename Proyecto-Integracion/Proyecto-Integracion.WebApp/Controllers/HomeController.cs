using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Integracion.Models;
using PagedList;

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


        public ActionResult BusquedaGeneral(FormCollection collection, String buscar, int page = 1, int cantResult = 10, TipoIncidente incidente = 0, int filtro = 5)
        {
            Estanteria e = new Estanteria();
            if (String.IsNullOrEmpty(buscar))
            {
                buscar = "";
            }
            var result = new List<Reporte>();
            switch (filtro)
            {
                case 1: //Dirección
                    result = e.BuscarPorDireccion(buscar, page, cantResult);
                    break;
                case 2: //Fecha
                    if (buscar.Equals(""))
                        buscar = Request.Form["date"];
                    result = e.BuscarPorFecha(buscar, page, cantResult);
                    break;
                case 3: //Palabra Clave
                    result = e.BuscarPorPalabra(buscar, page, cantResult);
                    break;
                case 4: //Ubicacion usamos radio de 40. ALL
                    try
                    {
                        var p = Utils.SessionManager.PerfilActivo();
                        Ubicacion u = p.Ubicacion;
                        var radio = 1;
                        result = e.Buscar(buscar, u, page, cantResult, radio);
                    }
                    catch (Exception ex)
                    { }
                    break;
                case 5: //All
                    result = e.BuscarPorAll(buscar, page, cantResult);
                    break;
                case 6: //Tipo de Incidente
                    result = e.Buscar(incidente, page, cantResult);
                    break;
            }
            this.ViewBag.Page = page;
            this.ViewBag.Results = cantResult;
            if (incidente != 0 && filtro == 6)
                this.ViewBag.Termino = Utils.EnumHelper<TipoIncidente>.GetDisplayValue(incidente);
            else
            this.ViewBag.Termino = buscar;
            this.ViewBag.Filtro = filtro;

            if (result.Count == cantResult)
            {
                this.ViewBag.More = 1;
            }
            else
            {
                this.ViewBag.More = 0;
            }

            return View(result);
        }

        public ActionResult BusquedaAvanzada()
        {
            return View();
        }

        public ActionResult ResultadosAvanzados(String check_miUbicacion, String palabra, String fecha, String nombrePerfil, String direccion, TipoIncidente incidente, String Latitud = "0", String Longitud = "0", int page = 1, int cantResult = 10)
        {
            Estanteria e = new Estanteria();
            var result = new List<Reporte>();

            //var latitud = Convert.ToDouble(Latitud.ToString(System.Globalization.CultureInfo.InvariantCulture));
            //var longitud = Convert.ToDouble(Longitud.ToString(System.Globalization.CultureInfo.InvariantCulture));
            var u = new Ubicacion();
            u.Latitud = float.Parse(Latitud.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            u.Longitud = float.Parse(Longitud.ToString(), System.Globalization.CultureInfo.InvariantCulture);

            if (palabra == "") palabra = null;
            if (fecha == "") fecha = null;
            if (direccion == "") direccion = null;
            if (nombrePerfil == "") nombrePerfil = null;
            if (check_miUbicacion == null) check_miUbicacion = "";
            if (check_miUbicacion.Equals("True"))
            {
                result = e.BusquedaAvanzada(page, cantResult, palabra, fecha, incidente, direccion, nombrePerfil, u, 40);
            }
            else
            {
                result = e.BusquedaAvanzada(page, cantResult, palabra, fecha, incidente, direccion, nombrePerfil);
            }
            this.ViewBag.Page = page;
            this.ViewBag.Results = cantResult;
            this.ViewBag.Palabra = palabra;
            this.ViewBag.Fecha = fecha;
            this.ViewBag.Direccion = direccion;
            this.ViewBag.NombrePerfil = nombrePerfil;
            this.ViewBag.Check_Ubicacion = check_miUbicacion;
            if (incidente != 0)
                this.ViewBag.Incidente = Utils.EnumHelper<TipoIncidente>.GetDisplayValue(incidente);
            else
                this.ViewBag.Incidente = "0";
            if (u != null)
            {
                this.ViewBag.Latitud = u.Latitud;
                this.ViewBag.Longitud = u.Longitud;
            }
            else
            {
                this.ViewBag.Latitud = 0;
                this.ViewBag.Longitud = 0;
            }

            if (result.Count == cantResult)
            {
                this.ViewBag.More = 1;
            }
            else
            {
                this.ViewBag.More = 0;
            }
            return View(result);
        }

        public ActionResult Faq()
        {
            return View();
        }
    }
}

