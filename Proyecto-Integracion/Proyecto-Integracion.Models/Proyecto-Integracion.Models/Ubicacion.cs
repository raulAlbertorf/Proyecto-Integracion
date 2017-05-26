using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Integracion.Models
{
    public class Ubicacion
    {
        public Int64 Id { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
        public string Delegacion { get; set; }
        public Int32 codigoPostal { get; set; }

        //CRUD
        public bool Crear()
        {
            throw new System.NotImplementedException();
        }
        public bool Seleccionar(Int64 ID)
        {
            throw new System.NotImplementedException();
        }
        public bool Modificar()
        {
            throw new System.NotImplementedException();
        }
        public bool Eliminar()
        {
            throw new System.NotImplementedException();
        }
    }
}
