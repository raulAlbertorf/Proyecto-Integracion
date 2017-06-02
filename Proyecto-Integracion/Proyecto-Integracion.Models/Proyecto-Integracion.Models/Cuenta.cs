using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Integracion.Models
{
    public class Cuenta
    {
        public string Email { get; set; }
        public string Contrasena { get; set; }

        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        public bool IniciarSesion()
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_cuenta_inicio_sesion", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inEmail", Direction = System.Data.ParameterDirection.Input, Value = this.Email });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inContrasena", Direction = System.Data.ParameterDirection.Input, Value = this.Contrasena });
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
        public bool CerrarSesion()
        {
            throw new System.NotImplementedException();
        }

        public bool AgregarPerfil(Perfil Perfil)
        {
            try
            {
                Perfil.Cuenta = this;
                Perfil.Crear();
                return true;
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return false;
        }
        public bool RemoverPerfil(Perfil Perfil)
        {
            try
            {
                Perfil.Eliminar();
                return false;
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return false;
        }

        //  CRUD
        public bool Crear()
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_cuenta_crear", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inEmail", Direction = System.Data.ParameterDirection.Input, Value = this.Email });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inContrasena", Direction = System.Data.ParameterDirection.Input, Value = this.Contrasena });
                var datos = DB.QueryCommand(command);

                if (datos == 1)
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

        public bool Seleccionar(string Email)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_cuenta_seleccionar", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inEmail", Direction = System.Data.ParameterDirection.Input, Value = Email });
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

        public bool CambiarContrasena(string nuevaContrasena)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_cuenta_modificar", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inEmail", Direction = System.Data.ParameterDirection.Input, Value = this.Email });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inContrasena", Direction = System.Data.ParameterDirection.Input, Value = nuevaContrasena });
                var datos = DB.QueryCommand(command);

                if (datos > 0)
                {
                    this.Contrasena = nuevaContrasena;
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
                var command = new MySqlCommand() { CommandText = "sp_cuenta_eliminar", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "inEmail", Direction = System.Data.ParameterDirection.Input, Value = this.Email });
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
            this.Email = dr["Email"].ToString();
            this.Contrasena = dr["Contrasena"].ToString();
        }
    }
}
