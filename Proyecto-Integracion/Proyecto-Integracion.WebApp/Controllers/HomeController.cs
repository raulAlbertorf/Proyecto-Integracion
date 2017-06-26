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
            List<Proyecto_Integracion.Models.Reporte> reportes = e.Buscar(incidente);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(reportes.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult BusquedaGeneral(FormCollection collection, int? page, String termino, int filtro = 5)
        {
            Estanteria e = new Estanteria();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            if (String.IsNullOrEmpty(termino))
            {
                termino = "";
            }
            var result = new List<Reporte>();
            switch (filtro)
            {
                case 1: //Dirección
                    result = e.BuscarPorDireccion(termino);
                    break;
                case 2: //Fecha
                    termino = Request.Form["date"];
                    result = e.BuscarPorFecha(termino);
                    break;
                case 3: //Palabra Clave
                    result = e.BuscarPorPalabra(termino);
                    break;
                case 4: //Ubicacion usamos radio de 40. ALL
                    try
                    {
                        var p = Utils.SessionManager.PerfilActivo();
                        Ubicacion u = p.Ubicacion;
                        var radio = 40;
                        result = e.Buscar(termino, u, radio);
                    }
                    catch (Exception ex)
                    { }
                    break;
                case 5: //All
                    result = e.BuscarPorAll(termino);
                    break;
            }
            this.ViewBag.Termino = termino;
            return View(result.ToPagedList(pageNumber, pageSize));
        }
    }
}

