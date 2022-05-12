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
  public class CategoriaActivoDB
    {
        public CategoriaActivoEL GetCategoriaActivoById(int pIdCategoriaActivo)
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    CategoriaActivoEL categoriaActivo = null;

                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetCategoriaActivoById";
                    command.Parameters.AddWithValue("@IdCategoriaActivo", pIdCategoriaActivo);



                    SqlDataReader dataReader = gDatos.ExecuteReader(command);

                    while (dataReader.Read())
                    {
                        categoriaActivo = new CategoriaActivoEL
                        {
                            IdCatgoriaActivo = dataReader.GetInt32(0),
                            Descripcion = dataReader.GetString(1),
                        };

                    }
                    dataReader.Close();
                    return categoriaActivo;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public List<CategoriaActivoEL> GetAllCategoriaActivo()
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {

                    CategoriaActivoEL categoriaActivo = null;
                    List<CategoriaActivoEL> listaCategoriaActivos = new List<CategoriaActivoEL>();


                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetAllCategoriaActivo";

                    SqlDataReader dataReader = gDatos.ExecuteReader(command);

                    while (dataReader.Read())
                    {
                        categoriaActivo = new CategoriaActivoEL
                        {
                            IdCatgoriaActivo = dataReader.GetInt32(0),
                            Descripcion = dataReader.GetString(1),
                        };
                        listaCategoriaActivos.Add(categoriaActivo);
                    }
                    dataReader.Close();
                    return listaCategoriaActivos;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CategoriaActivoEL InsertCategoriaActivo(CategoriaActivoEL pCategoriaActivo)
        {


            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spInsertCategoriaActivo";
                    command.Parameters.AddWithValue("@Descripcion", pCategoriaActivo.Descripcion);


                    gDatos.ExecuteNonQuery(ref command);
                }
                CategoriaActivoEL categoriaActivo = GetAllCategoriaActivo().Where(x => x.Descripcion == pCategoriaActivo.Descripcion).FirstOrDefault();
                return categoriaActivo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public CategoriaActivoEL UpdateCategoriaActivo(CategoriaActivoEL pCategoriaActivo)
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spUpdateCategoriaActivo";
                    command.Parameters.AddWithValue("@IdCategoriaActivo", pCategoriaActivo.IdCatgoriaActivo);
                    command.Parameters.AddWithValue("@Descripcion", pCategoriaActivo.Descripcion);

                    gDatos.ExecuteNonQuery(ref command);

                    CategoriaActivoEL categoriaActivo = GetCategoriaActivoById(pCategoriaActivo.IdCatgoriaActivo);
                    return categoriaActivo;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool DeleteCategoriaActivo(int pIdCategoriaActivo)
        {
            bool deleted = false;
            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {

                    SqlCommand command = new SqlCommand();

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spDeleteCategoriaActivo";
                    command.Parameters.AddWithValue("@IdCategoriaActivo", pIdCategoriaActivo);


                    gDatos.ExecuteNonQuery(ref command);

                    if (this.GetCategoriaActivoById(pIdCategoriaActivo) == null)
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
