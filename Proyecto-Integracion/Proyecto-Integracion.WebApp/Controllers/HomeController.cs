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

        public ActionResult Busqueda(int? page, TipoIncidente incidente)
        {
            Estanteria e = new Estanteria();
            List<Proyecto_Integracion.Models.Reporte> reportes = e.Buscar(incidente, 0, int.MaxValue);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(reportes.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult BusquedaGeneral(FormCollection collection, String buscar, int page = 1, int cantResult = 10, int filtro = 5)
            {
            Estanteria e = new Estanteria();
            var incidente = new TipoIncidente();
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
                    if(buscar.Equals(""))
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
                case 6:
                    switch (buscar)
                    {
                        case "#1":
                            incidente = TipoIncidente.Homicidio;
                            break;
                        case "#2":
                            incidente = TipoIncidente.Suicidio;
                            break;
                        case "#3":
                            incidente = TipoIncidente.RoboAsalto;
                            break;
                        case "#4":
                            incidente = TipoIncidente.Violacion;
                            break;
                        case "#5":
                            incidente = TipoIncidente.ExplotacionSexual;
                            break;
                    }
                    result = e.Buscar(incidente, page, cantResult);
                    break;
            }
            this.ViewBag.Page = page;
            this.ViewBag.Results = cantResult;
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

        [HttpGet]
        public ActionResult BusquedaAvanzada()
        {
            return View();
        }

        public ActionResult BusquedaAvanzada(FormCollection collection, String palabra, String descripcion, TipoIncidente incidente, int page = 1, int cantResult = 10)
        {
            Estanteria e = new Estanteria();
            return View();
        }

        public ActionResult Faq()
        {
            return View();
        }
    }
}

