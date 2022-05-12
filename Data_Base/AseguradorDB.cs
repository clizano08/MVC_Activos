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
    public class AseguradorDB
    {
        public AseguradorEL GetAseguradorById(int pIdAsegurador)
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    AseguradorEL asegurador = null;

                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetAseguradorById";
                    command.Parameters.AddWithValue("@IdAsegurador", pIdAsegurador);



                    SqlDataReader dataReader = gDatos.ExecuteReader(command);

                    while (dataReader.Read())
                    {
                        asegurador = new AseguradorEL
                        {
                            IdAsegurador = dataReader.GetInt32(0),
                            Descripcion = dataReader.GetString(1),
                        };

                    }
                    dataReader.Close();
                    return asegurador;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public List<AseguradorEL> GetAllAsegurador()
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {

                    AseguradorEL asegurador = null;
                    List<AseguradorEL> listaAseguradores = new List<AseguradorEL>();


                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetAllAsegurador";

                    SqlDataReader dataReader = gDatos.ExecuteReader(command);

                    while (dataReader.Read())
                    {
                        asegurador = new AseguradorEL
                        {
                            IdAsegurador = dataReader.GetInt32(0),
                            Descripcion = dataReader.GetString(1),
                        };
                        listaAseguradores.Add(asegurador);
                    }
                    dataReader.Close();
                    return listaAseguradores;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public AseguradorEL InsertAsegurador(AseguradorEL pAsegurador)
        {


            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spInsertAsegurador";
                    command.Parameters.AddWithValue("@Descripcion", pAsegurador.Descripcion);


                    gDatos.ExecuteNonQuery(ref command);
                }
                AseguradorEL asegurador = GetAllAsegurador().Where(x => x.Descripcion == pAsegurador.Descripcion).FirstOrDefault();
                return asegurador;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public AseguradorEL UpdateAsegurador(AseguradorEL pAsegurador)
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spUpdateAsegurador";
                    command.Parameters.AddWithValue("@IdAsegurador", pAsegurador.IdAsegurador);
                    command.Parameters.AddWithValue("@Descripcion", pAsegurador.Descripcion);

                    gDatos.ExecuteNonQuery(ref command);

                    AseguradorEL asegurador = GetAseguradorById(pAsegurador.IdAsegurador);
                    return asegurador;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool DeleteAsegurador(int pIdAsegurador)
        {
            bool deleted = false;
            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {

                    SqlCommand command = new SqlCommand();

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spDeleteAsegurador";
                    command.Parameters.AddWithValue("@IdAsegurador", pIdAsegurador);


                    gDatos.ExecuteNonQuery(ref command);

                    if (this.GetAseguradorById(pIdAsegurador) == null)
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
