using System;
using Proyecto_Integracion.Models;
using Proyecto_Integracion.WebApp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Integracion.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Perfil p = new Perfil();
            p.Seleccionar(7);
            var reportes = p.MisReportes();
            Ubicacion ubicacion = new Ubicacion();
            ubicacion.Seleccionar(1);
            var u = Proyecto_Integracion.WebApp.Utils.GeoLocation.direccion(ubicacion);
            //p.Seleccionar("email1@correo.com");
        }
    }
}

