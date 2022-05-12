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
   public class MarcaDB
    {
        public MarcaEL GetMarcaById(int pIdMarca)
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    MarcaEL marca = null;

                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetMarcaById";
                    command.Parameters.AddWithValue("@IdMarca", pIdMarca);



                    SqlDataReader dataReader = gDatos.ExecuteReader(command);

                    while (dataReader.Read())
                    {
                        marca = new MarcaEL
                        {
                            IdMarca = dataReader.GetInt32(0),
                            Descripcion = dataReader.GetString(1),
                        };

                    }
                    dataReader.Close();
                    return marca;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public List<MarcaEL> GetAllMarca()
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {

                    MarcaEL marca = null;
                    List<MarcaEL> listaMarcas = new List<MarcaEL>();


                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetAllMarca";

                    SqlDataReader dataReader = gDatos.ExecuteReader(command);

                    while (dataReader.Read())
                    {
                        marca = new MarcaEL
                        {
                            IdMarca = dataReader.GetInt32(0),
                            Descripcion = dataReader.GetString(1),
                        };
                        listaMarcas.Add(marca);
                    }
                    dataReader.Close();
                    return listaMarcas;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MarcaEL InsertMarca(MarcaEL pMarca)
        {


            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spInsertMarca";
                    command.Parameters.AddWithValue("@Descripcion", pMarca.Descripcion);


                    gDatos.ExecuteNonQuery(ref command);
                }
                MarcaEL marca = GetAllMarca().Where(x => x.Descripcion == pMarca.Descripcion).FirstOrDefault();
                return marca;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public MarcaEL UpdateMarca(MarcaEL pMarca)
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spUpdateMarca";
                    command.Parameters.AddWithValue("@IdMarca", pMarca.IdMarca);
                    command.Parameters.AddWithValue("@Descripcion", pMarca.Descripcion);

                    gDatos.ExecuteNonQuery(ref command);

                    MarcaEL marca = GetMarcaById(pMarca.IdMarca);
                    return marca;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool DeleteMarca(int pIdMarca)
        {
            bool deleted = false;
            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {

                    SqlCommand command = new SqlCommand();

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spDeleteMarca";
                    command.Parameters.AddWithValue("@IdMarca", pIdMarca);


                    gDatos.ExecuteNonQuery(ref command);

                    if (this.GetMarcaById(pIdMarca) == null)
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
