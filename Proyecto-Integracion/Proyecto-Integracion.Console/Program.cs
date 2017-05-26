using System;
using Proyecto_Integracion.Models;
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
            p.Seleccionar(1);
            //p.Seleccionar("email1@correo.com");
        }
    }
}
