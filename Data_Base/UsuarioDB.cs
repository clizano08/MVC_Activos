using Conexion.Data_Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Base
{
    public class UsuarioDB
    {
        public UsuarioEL GetUsuarioById(int pIdUsuario)
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    UsuarioEL usuario = null;

                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetUsuarioById";
                    command.Parameters.AddWithValue("@IdUsuario", pIdUsuario);



                    SqlDataReader dataReader = gDatos.ExecuteReader(command);

                    while (dataReader.Read())
                    {
                        usuario = new UsuarioEL
                        {
                            IdUsuario = dataReader.GetInt32(0),
                            CategoriaUsuario = new CategoriaUsuarioDB().GetCategoriaUsuarioById(dataReader.GetInt32(1)),
                            Cedula = dataReader.GetString(2),
                            Nombre = dataReader.GetString(3),
                            PrimerApellido = dataReader.GetString(4),
                            SegundoApellido = dataReader.GetString(5),
                            Telefono = dataReader.GetString(6),
                            Correo = dataReader.GetString(7),
                            Direccion = dataReader.GetString(8)

                        };

                    }
                    dataReader.Close();
                    return usuario;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public UsuarioEL GetUsuarioByCedula(string pCedula)
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    UsuarioEL usuario = null;

                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetUsuarioById";
                    command.Parameters.AddWithValue("@Cedula", pCedula);



                    SqlDataReader dataReader = gDatos.ExecuteReader(command);

                    while (dataReader.Read())
                    {
                        usuario = new UsuarioEL
                        {
                            IdUsuario = dataReader.GetInt32(0),
                            CategoriaUsuario = new CategoriaUsuarioDB().GetCategoriaUsuarioById(dataReader.GetInt32(1)),
                            Cedula = dataReader.GetString(2),
                            Nombre = dataReader.GetString(3),
                            PrimerApellido = dataReader.GetString(4),
                            SegundoApellido = dataReader.GetString(5),
                            Telefono = dataReader.GetString(6),
                            Correo = dataReader.GetString(7),
                            Direccion = dataReader.GetString(8)

                        };

                    }
                    dataReader.Close();
                    return usuario;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public List<UsuarioEL> GetAllUsuario()
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {

                    UsuarioEL usuario = null;
                    List<UsuarioEL> listaUsuarios = new List<UsuarioEL>();


                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetAllUsuario";

                    SqlDataReader dataReader = gDatos.ExecuteReader(command);

                    while (dataReader.Read())
                    {
                        usuario = new UsuarioEL
                        {
                            IdUsuario = dataReader.GetInt32(0),
                            CategoriaUsuario = new CategoriaUsuarioDB().GetCategoriaUsuarioById(dataReader.GetInt32(1)),
                            Cedula = dataReader.GetString(2),
                            Nombre = dataReader.GetString(3),
                            PrimerApellido = dataReader.GetString(4),
                            SegundoApellido = dataReader.GetString(5),
                            Telefono = dataReader.GetString(6),
                            Correo = dataReader.GetString(7),
                            Direccion = dataReader.GetString(8)
                        };
                        listaUsuarios.Add(usuario);
                    }
                    dataReader.Close();
                    return listaUsuarios;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UsuarioEL InsertUsuario(UsuarioEL pUsuario)
        {


            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spInsertUsuario";
                    command.Parameters.AddWithValue("@IdCategoriaUsuario", pUsuario.CategoriaUsuario.IdCategoriaUsuario);
                    command.Parameters.AddWithValue("@Cedula", pUsuario.Cedula);
                    command.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
                    command.Parameters.AddWithValue("@PrimerApellido", pUsuario.PrimerApellido);
                    command.Parameters.AddWithValue("@SegundoApellido", pUsuario.SegundoApellido);
                    command.Parameters.AddWithValue("@Telefono", pUsuario.Telefono);
                    command.Parameters.AddWithValue("@Correo", pUsuario.Correo);
                    command.Parameters.AddWithValue("@Direccion", pUsuario.Direccion);
                    command.Parameters.AddWithValue("@Contrasenna", pUsuario.Contrasenna);

                    gDatos.ExecuteNonQuery(ref command);
                }
                UsuarioEL usuario = GetUsuarioByCedula(pUsuario.Cedula);
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public UsuarioEL UpdateUsuario(UsuarioEL pUsuario)
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spUpdateUsuario";
                    command.Parameters.AddWithValue("@IdUsuario", pUsuario.IdUsuario);
                    command.Parameters.AddWithValue("@IdCategoriaUsuario", pUsuario.CategoriaUsuario.IdCategoriaUsuario);
                    command.Parameters.AddWithValue("@Cedula", pUsuario.Cedula);
                    command.Parameters.AddWithValue("@Nombre", pUsuario.Nombre);
                    command.Parameters.AddWithValue("@PrimerApellido", pUsuario.PrimerApellido);
                    command.Parameters.AddWithValue("@SegundoApellido", pUsuario.SegundoApellido);
                    command.Parameters.AddWithValue("@Telefono", pUsuario.Telefono);
                    command.Parameters.AddWithValue("@Correo", pUsuario.Correo);
                    command.Parameters.AddWithValue("@Direccion", pUsuario.Direccion);

                    gDatos.ExecuteNonQuery(ref command);

                    UsuarioEL usuario = GetUsuarioByCedula(pUsuario.Cedula);
                    return usuario;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public UsuarioEL UpdatePasswordUsuario(UsuarioEL pUsuario)
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spUpdatePasswordUsuario";
                    command.Parameters.AddWithValue("@IdUsuario", pUsuario.IdUsuario);
                    command.Parameters.AddWithValue("@Cedula", pUsuario.Cedula);
                    command.Parameters.AddWithValue("@Contrasenna", pUsuario.Contrasenna);

                    gDatos.ExecuteNonQuery(ref command);

                    UsuarioEL usuario = GetUsuarioByCedula(pUsuario.Cedula);
                    return usuario;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool DeleteUsuario(int pIdUsuario)
        {
            bool deleted = false;
            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {

                    SqlCommand command = new SqlCommand();

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spDeleteUsuario";
                    command.Parameters.AddWithValue("@IdUsuario", pIdUsuario);


                    gDatos.ExecuteNonQuery(ref command);

                    if (this.GetUsuarioById(pIdUsuario) == null)
                    {
                        deleted = true;
                    }

                    return deleted;
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
}
