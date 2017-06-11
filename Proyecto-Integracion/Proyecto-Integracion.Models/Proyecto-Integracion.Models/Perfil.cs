using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Integracion.Models
{
    public class Perfil
    {
        public Int64 Id { get; set; }
        public string UrlImagen { get; set; }
        public string Nombre { get; set; }
        public Cuenta Cuenta { get; set; }
        public Ubicacion Ubicacion { get; set; }

        public List<Reporte> MisReportes()
        {
            List<Reporte> reportes = new List<Reporte>();
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_reporte_seleccionar_perfil", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inId_perfil", Direction = System.Data.ParameterDirection.Input, Value = this.Id });
                var datos = DB.GetDataSet(command);

                if (datos.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < datos.Tables[0].Rows.Count; i++)
                    {
                        Reporte reporte = new Reporte();
                        reporte.Id = (Convert.ToInt64(datos.Tables[0].Rows[i]["Id"]));
                        reporte.Descripcion = (datos.Tables[0].Rows[i]["Descripcion"].ToString());
                        reporte.FechaExpedicion = Convert.ToDateTime(datos.Tables[0].Rows[i]["Fecha"]);
                        reporte.Incidente = (TipoIncidente)(Convert.ToInt16(datos.Tables[0].Rows[i]["Incidente"]));
                        reporte.Perfil = this;
                        var id_u = Convert.ToInt64(datos.Tables[0].Rows[i]["Ubicacion_Id"]);
                        Ubicacion u = new Ubicacion();
                        u.Seleccionar(id_u);
                        reporte.Ubicacion = u;
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

        public bool ModificarImagen()
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_perfil_modificar", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inId", Direction = System.Data.ParameterDirection.Input, Value = this.Id });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inNombre", Direction = System.Data.ParameterDirection.Input, Value = this.Nombre });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inUrl", Direction = System.Data.ParameterDirection.Input, Value = this.UrlImagen });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inEmail", Direction = System.Data.ParameterDirection.Input, Value = this.Cuenta.Email });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inUbicacion", Direction = System.Data.ParameterDirection.Input, Value = this.Ubicacion.Id });
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

        public bool AgregarReporte(Reporte Reporte)
        {
            Reporte.Perfil = this;
            try
            {
                return Reporte.Crear();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return false;
        }
        public bool RemoverReporte(Reporte Reporte)
        {
            try
            {
                return Reporte.Eliminar();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return false;
        }

        //CRUD
        public bool Crear()
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_perfil_crear", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inNombre", Direction = System.Data.ParameterDirection.Input, Value = this.Nombre });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inUrlImagen", Direction = System.Data.ParameterDirection.Input, Value = this.UrlImagen });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inEmail", Direction = System.Data.ParameterDirection.Input, Value = this.Cuenta.Email });
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
        public bool Seleccionar(Int64 Perfil_Id)
        {

            try
            {
                var command = new MySqlCommand() { CommandText = "sp_perfil_seleccionar", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inId", Direction = System.Data.ParameterDirection.Input, Value = Perfil_Id });
                var datos = DB.GetDataSet(command);
                if (datos.Tables[0].Rows.Count > 0)
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

        public bool Seleccionar(string email)
        {

            try
            {
                var command = new MySqlCommand() { CommandText = "sp_perfil_seleccionar_email", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inEmail", Direction = System.Data.ParameterDirection.Input, Value = email });
                var datos = DB.GetDataSet(command);
                if (datos.Tables[0].Rows.Count > 0)
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
                var command = new MySqlCommand() { CommandText = "sp_perfil_modificar", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inId", Direction = System.Data.ParameterDirection.Input, Value = this.Id });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inNombre", Direction = System.Data.ParameterDirection.Input, Value = this.Nombre });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inUrl", Direction = System.Data.ParameterDirection.Input, Value = this.UrlImagen });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inEmail", Direction = System.Data.ParameterDirection.Input, Value = this.Cuenta.Email });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inUbicacion", Direction = System.Data.ParameterDirection.Input, Value = this.Ubicacion.Id });
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
        public bool Eliminar()
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_perfil_eliminar", CommandType = System.Data.CommandType.StoredProcedure };
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
            this.Nombre = dr["Nombre"].ToString();
            this.UrlImagen = dr["UrlImagen"].ToString();
            this.Cuenta = new Cuenta();
            this.Cuenta.Seleccionar(dr["Cuenta_Email"].ToString());
            this.Ubicacion = new Ubicacion();
            this.Ubicacion.Seleccionar(Convert.ToInt64(dr["Ubicacion_Id"]));

        }

    }
}