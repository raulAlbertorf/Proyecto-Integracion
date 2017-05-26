using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Integracion.Models
{
    public class Estanteria
    {
        //Buscar por termino y ubicacion
        public List<Reporte> buscar(string termino, int pagina, int cantResult, Ubicacion ubicacion)
        {
            throw new System.NotImplementedException();
        }

        //Buscar por tipo de incidente y ubicacion
        public List<Reporte> buscar(TipoIncidente incidenete, int pagina, int cantResult, Ubicacion ubicacion)
        {
            throw new System.NotImplementedException();
        }

        //Buscar por fecha y Ubicacion
        public List<Reporte> buscar(DateTime fecha, int pagina, int cantResult, Ubicacion ubicacion)
        {
            throw new System.NotImplementedException();
        }

        //Buscar por ubicacion
        public List<Reporte> buscar(Ubicacion ubicacion, int pagina, int cantResult)
        {
            throw new System.NotImplementedException();
        }


        //Traer las utlimas publicaciones
        public List<Reporte> UltimosPublicados(int cantidad)
        {
            throw new System.NotImplementedException();
        }
    }
}
