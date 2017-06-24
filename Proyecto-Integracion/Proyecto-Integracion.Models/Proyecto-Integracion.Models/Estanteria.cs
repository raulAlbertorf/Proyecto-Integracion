using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Integracion.Models
{
    public class Estanteria
    {
        public List<Reporte> Buscar(string termino, Ubicacion ubicacion, int pagina, int cantidadResultados, int radio)
        {

            var reportes = new List<Reporte>();
            int index = pagina;
            if (pagina > 0)
                index = cantidadResultados * (pagina - 1);
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_Item_Seleccionar_Items_Termino_Ubicacion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inTermino", Direction = System.Data.ParameterDirection.Input, Value = termino });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inUbicacion_Latitude", Direction = System.Data.ParameterDirection.Input, Value = ubicacion.Latitud });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inUbicacion_Longitude", Direction = System.Data.ParameterDirection.Input, Value = ubicacion.Longitud });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inRadio", Direction = System.Data.ParameterDirection.Input, Value = radio });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inOffset", Direction = System.Data.ParameterDirection.Input, Value = index });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inLimit", Direction = System.Data.ParameterDirection.Input, Value = cantidadResultados });
                var datos = DB.GetDataSet(command);

                if (datos.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < datos.Tables[0].Rows.Count; i++)
                    {
                        Reporte reporte = new Reporte();
                        reporte.Id = (Convert.ToInt64(datos.Tables[0].Rows[i]["Reporte_Id"]));
                        reporte.Descripcion = (datos.Tables[0].Rows[i]["Reporte_Descripcion"].ToString());
                        reporte.FechaExpedicion = Convert.ToDateTime(datos.Tables[0].Rows[i]["Reporte_Fecha"]);
                        reporte.Incidente = (TipoIncidente)(datos.Tables[0].Rows[i]["Reporte_Incidente"]);
                        reporte.Perfil = new Perfil();
                        reporte.Perfil.Id = (Convert.ToInt64(datos.Tables[0].Rows[i]["Perfil_Id"]));
                        reporte.Perfil.Nombre = (datos.Tables[0].Rows[i]["Perfil_Nombre"].ToString());
                        reporte.Perfil.UrlImagen = (datos.Tables[0].Rows[i]["Perfil_UrlImagen"].ToString());
                        reporte.Perfil.Cuenta = new Cuenta();
                        reporte.Perfil.Cuenta.Email = (datos.Tables[0].Rows[i]["Cuenta_Email"].ToString());
                        reporte.Perfil.Cuenta.Contrasena = (datos.Tables[0].Rows[i]["Cuenta_Contrasena"].ToString());
                        reporte.Ubicacion = new Ubicacion();
                        //FALTA NO OLVIDES
                        reportes.Add(reporte);

                    }
                    return reportes;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            return reportes;
        }

        //Buscar por tipo de incidente y ubicacion
        public List<Reporte> buscar(TipoIncidente incidenete, int pagina, int cantResult, Ubicacion ubicacion)
        {
            throw new System.NotImplementedException();
        }

        ////Buscar por fecha y Ubicacion
        //public List<Reporte> buscar(DateTime fecha, int pagina, int cantResult, Ubicacion ubicacion)
        //{
        //    throw new System.NotImplementedException();
        //}

        //Buscar por ubicacion
        public List<Reporte> buscar(Ubicacion ubicacion, int pagina, int cantResult)
        {
            throw new System.NotImplementedException();
        }

        public List<Reporte> BuscarPorAll(string termino, int pagina, int cantResult)
        {
            List<Reporte> reportes = new List<Reporte>();
            int index = pagina;
            if (pagina > 0)
                index = cantResult * (pagina - 1);

            try
            {
                var command = new MySqlCommand() { CommandText = "sp_Estanteria_Buscar_All", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inTermino", Direction = System.Data.ParameterDirection.Input, Value = termino });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inPage", Direction = System.Data.ParameterDirection.Input, Value = index });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inCantResult", Direction = System.Data.ParameterDirection.Input, Value = cantResult });
                var datos = DB.GetDataSet(command);

                if (datos.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < datos.Tables[0].Rows.Count; i++)
                    {

                        Reporte reporte = new Reporte();
                        Perfil perfil = new Perfil();
                        reporte.Id = Convert.ToInt64(datos.Tables[0].Rows[i]["Reporte_Id"]);
                        reporte.FechaExpedicion = Convert.ToDateTime(datos.Tables[0].Rows[i]["FechaExpedicion"]);
                        reporte.Descripcion = datos.Tables[0].Rows[i]["Descripcion"].ToString();
                        reporte.Ubicacion = new Ubicacion();
                        reporte.Ubicacion.Seleccionar(Convert.ToInt64(datos.Tables[0].Rows[i]["Ubicacion_Id"]));
                        reporte.Perfil = new Perfil();
                        reporte.Perfil.Seleccionar(Convert.ToInt64(datos.Tables[0].Rows[i]["Perfil_Id"]));
                        reporte.Incidente = (TipoIncidente)Convert.ToInt64(datos.Tables[0].Rows[i]["Incidente"]);
                        reporte.FechaUltimaModificacion = Convert.ToDateTime(datos.Tables[0].Rows[i]["UltimaModificacion"]);

                        reportes.Add(reporte);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            return reportes;

        }


        //Traer las utlimas publicaciones
        public List<Reporte> UltimosPublicados(int cantidad)
        {
            throw new System.NotImplementedException();
        }
    }
}
