﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Integracion.Models;
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

        //public ActionResult Busqueda(string buscar, int page = 1, int cantResult = 10, int filtro = 1)
        //{
        //    Estanteria e = new Estanteria();
        //    if (String.IsNullOrEmpty(buscar))
        //    {
        //        buscar = "";
        //    }
        //    var result = new List<Reporte>();
        //    switch (filtro)
        //    {
        //        case 1: //titulo
        //            result = e.Buscar(buscar, page, cantResult);
        //            break;
        //        case 2: //Autor
        //            result = e.BuscarPorAutor(buscar, page, cantResult);
        //            break;
        //        case 3: //Propiedad
        //            result = e.BuscarPorPropiedad(buscar, page, cantResult);
        //            break;
        //        case 4: //Ubicacion    usamos radio de 40.
        //            try
        //            {
        //                var p = Utils.SessionManager.PerfilActivo();
        //                Ubicacion u = p.Ubicacion;
        //                var radio = 40;
        //                result = e.Buscar(buscar, u, page, cantResult, radio);
        //            }
        //            catch (Exception ex)
        //            { }
        //            break;
        //        case 5: //All
        //            result = e.BuscarPorAll(buscar, page, cantResult);
        //            break;
        //        default:
        //            result = e.Buscar(buscar, page, cantResult);
        //            break;
        //    }
        //}
    }
}