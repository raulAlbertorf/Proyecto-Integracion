using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
        public Int32 CodigoPostal { get; set; }

        public List<Ubicacion> Seleciconar(string delegacion)
        {
            throw new NotImplementedException();
        }

        public List<Ubicacion> Seleciconar(Int32 cp)
        {
            throw new NotImplementedException();
        }

        //CRUD
        public bool Crear()
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_ubicacion_crear", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inLatitude", Direction = System.Data.ParameterDirection.Input, Value = this.Latitud });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inLongitude", Direction = System.Data.ParameterDirection.Input, Value = this.Longitud });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "outId", Direction = System.Data.ParameterDirection.Output });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inDelegacion", Direction = System.Data.ParameterDirection.Input, Value = this.Delegacion });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inCodigoPostal", Direction = System.Data.ParameterDirection.Input, Value = this.CodigoPostal });
                var temp = DB.QueryCommand(command);
                if (temp == 1)
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
                var command = new MySqlCommand() { CommandText = "sp_ubicacion_seleccionar", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inId", Direction = System.Data.ParameterDirection.Input, Value = Id });
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
                var command = new MySqlCommand() { CommandText = "sp_ubicacion_modificar", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inLatitude", Direction = System.Data.ParameterDirection.Input, Value = this.Latitud });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inLongitude", Direction = System.Data.ParameterDirection.Input, Value = this.Longitud });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inId", Direction = System.Data.ParameterDirection.Input, Value = this.Id });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inDelegacion", Direction = System.Data.ParameterDirection.Input, Value = this.Delegacion });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inCodigoPostal", Direction = System.Data.ParameterDirection.Input, Value = this.CodigoPostal });

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
                var command = new MySqlCommand() { CommandText = "sp_ubicacion_eliminar", CommandType = System.Data.CommandType.StoredProcedure };
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
            var latitud =  Convert.ToDouble( dr[ "Latitude" ] ).ToString( System.Globalization.CultureInfo.InvariantCulture );
            var longitud = Convert.ToDouble( dr[ "Longitude" ] ).ToString( System.Globalization.CultureInfo.InvariantCulture );
            this.Latitud = float.Parse( latitud , System.Globalization.CultureInfo.InvariantCulture );
            this.Longitud = float.Parse( longitud , System.Globalization.CultureInfo.InvariantCulture );
            this.Delegacion = dr["Delegacion"].ToString();
            this.CodigoPostal = Convert.ToInt32(dr["CodigoPostal"]);
        }
    }
}

