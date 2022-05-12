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
    public class CategoriaUsuarioDB
    {
        public CategoriaUsuarioEL GetCategoriaUsuarioById(int pIdCategoriaUsuario)
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    CategoriaUsuarioEL categoriaUsuario = null;

                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetCategoriaUsuarioById";
                    command.Parameters.AddWithValue("@IdCategoriaUsuario", pIdCategoriaUsuario);



                    SqlDataReader dataReader = gDatos.ExecuteReader(command);

                    while (dataReader.Read())
                    {
                        categoriaUsuario = new CategoriaUsuarioEL
                        {
                            IdCategoriaUsuario = dataReader.GetInt32(0),
                            Descripcion = dataReader.GetString(1),
                        };

                    }
                    dataReader.Close();
                    return categoriaUsuario;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public List<CategoriaUsuarioEL> GetAllCategoriaUsuario()
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {

                    CategoriaUsuarioEL categoriaUsuario = null;
                    List<CategoriaUsuarioEL> listaCategoriaUsuarios = new List<CategoriaUsuarioEL>();


                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetAllCategoriaUsuario";

                    SqlDataReader dataReader = gDatos.ExecuteReader(command);

                    while (dataReader.Read())
                    {
                        categoriaUsuario = new CategoriaUsuarioEL
                        {
                            IdCategoriaUsuario = dataReader.GetInt32(0),
                            Descripcion = dataReader.GetString(1),
                        };
                        listaCategoriaUsuarios.Add(categoriaUsuario);
                    }
                    dataReader.Close();
                    return listaCategoriaUsuarios;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CategoriaUsuarioEL InsertCategoriaUsuario(CategoriaUsuarioEL pCategoriaUsuario)
        {


            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spInsertCategoriaUsuario";
                    command.Parameters.AddWithValue("@Descripcion", pCategoriaUsuario.Descripcion);


                    gDatos.ExecuteNonQuery(ref command);
                }
                CategoriaUsuarioEL categoriaUsuario = GetAllCategoriaUsuario().Where(x => x.Descripcion == pCategoriaUsuario.Descripcion).FirstOrDefault();
                return categoriaUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public CategoriaUsuarioEL UpdateCategoriaUsuario(CategoriaUsuarioEL pCategoriaUsuario)
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spUpdateCategoriaUsuario";
                    command.Parameters.AddWithValue("@IdCategoriaUsuario", pCategoriaUsuario.IdCategoriaUsuario);
                    command.Parameters.AddWithValue("@Descripcion", pCategoriaUsuario.Descripcion);

                    gDatos.ExecuteNonQuery(ref command);

                   CategoriaUsuarioEL categoriaUsuario = GetCategoriaUsuarioById(pCategoriaUsuario.IdCategoriaUsuario);
                    return categoriaUsuario;

                }

            }
            catch (Exception ex)
            {
               
                throw ex;
            }

        }
        public bool DeleteCategoriaUsuario(int pIdCategoriaUsuario)
        {
            bool deleted = false; 
            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {

                    SqlCommand command = new SqlCommand();

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spDeleteCategoriaUsuario";
                    command.Parameters.AddWithValue("@IdCategoriaUsuario", pIdCategoriaUsuario);


                    gDatos.ExecuteNonQuery(ref command);

                    if (this.GetCategoriaUsuarioById(pIdCategoriaUsuario) == null )
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
