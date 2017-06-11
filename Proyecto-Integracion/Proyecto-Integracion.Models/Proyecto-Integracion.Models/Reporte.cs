using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Integracion.Models
{
    public class Reporte
    {
        public Int64 Id { get; set; }
        public Perfil Perfil { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public string Descripcion { get; set; }
        public Ubicacion Ubicacion { get; set; }
        public TipoIncidente Incidente { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }

        //CRUD
        public bool Crear()
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_reporte_crear", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inPerfil_Id", Direction = System.Data.ParameterDirection.Input, Value = this.Perfil.Id });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inFecha", Direction = System.Data.ParameterDirection.Input, Value = this.FechaExpedicion });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inIncidente", Direction = System.Data.ParameterDirection.Input, Value = this.Incidente });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inDescripcion", Direction = System.Data.ParameterDirection.Input, Value = this.Descripcion });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inUbicacion", Direction = System.Data.ParameterDirection.Input, Value = this.Ubicacion.Id });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "outId", Direction = System.Data.ParameterDirection.Output });
                var datos = DB.QueryCommand(command);
                if (datos == 1)
                {
                    this.Id = Convert.ToInt64(command.Parameters["outId"].Value);
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return false;
        }
        public bool Seleccionar(Int64 ID)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_reporte_seleccionar", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inId", Direction = System.Data.ParameterDirection.Input, Value = ID });
                var datos = DB.GetDataSet(command);
                if (datos.Tables[0].Rows.Count == 1)
                {
                    this.SetDesde(datos.Tables[0].Rows[0]);
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return false;
        }
        public bool Modificar()
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_reporte_ modificar", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inId", Direction = System.Data.ParameterDirection.Input, Value = this.Id });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inPerfil_Id", Direction = System.Data.ParameterDirection.Input, Value = this.Perfil.Id });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inFecha", Direction = System.Data.ParameterDirection.Input, Value = this.FechaExpedicion });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inIncidente", Direction = System.Data.ParameterDirection.Input, Value = this.Incidente });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inDescripcion", Direction = System.Data.ParameterDirection.Input, Value = this.Descripcion });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inUbicacion", Direction = System.Data.ParameterDirection.Input, Value = this.Ubicacion.Id });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "outUltimaModificacion", Direction = System.Data.ParameterDirection.Output });
                var datos = DB.QueryCommand(command);
                if (datos == 1)
                {
                    this.FechaUltimaModificacion = Convert.ToDateTime(command.Parameters["outUltimaModificacion"].Value);
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return false;
        }
        public bool Eliminar()
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_reporte_eliminar", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inId", Direction = System.Data.ParameterDirection.Input, Value = this.Id });
                var temp = DB.QueryCommand(command);
                if (temp == 1)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return false;
        }
        private void SetDesde(DataRow dr)
        {
            this.Id = Convert.ToInt64(dr["Id"]);
            this.FechaExpedicion = Convert.ToDateTime(dr["Fecha"]);
            this.Descripcion = dr["Descripcion"].ToString();
            this.Ubicacion = new Ubicacion();
            this.Ubicacion.Seleccionar(Convert.ToInt64(dr["Ubicacion_Id"]));
            this.Perfil = new Perfil();
            this.Perfil.Seleccionar(Convert.ToInt64(dr["Perfil_Id"]));
            this.Incidente = (TipoIncidente)Convert.ToInt64(dr["Incidente"]);
            this.FechaUltimaModificacion = Convert.ToDateTime(dr["UltimaModificacion"]);
        }
    }
}
