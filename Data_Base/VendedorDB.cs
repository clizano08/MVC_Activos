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
    public class VendedorDB
    {
        public VendedorEL GetVendedorById(int pIdVendedor)
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    VendedorEL vendedor = null;

                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetVendedorById";
                    command.Parameters.AddWithValue("@IdVendedor", pIdVendedor);



                    SqlDataReader dataReader = gDatos.ExecuteReader(command);

                    while (dataReader.Read())
                    {
                        vendedor = new VendedorEL
                        {
                            IdVendedor = dataReader.GetInt32(0),
                            CedulaJuridica = dataReader.GetString(1),
                            Nombre = dataReader.GetString(2),
                            PrimerApellido = dataReader.GetString(3),
                            SegundoApellido = dataReader.GetString(4),
                            Telefono = dataReader.GetString(5),
                            Correo = dataReader.GetString(6),
                            Direccion = dataReader.GetString(7)

                        };

                    }
                    dataReader.Close();
                    return vendedor;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public VendedorEL GetVendedorByCedulaJuridica(string pCedulaJuridica)
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    VendedorEL vendedor = null;

                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetVendedorByCedulaJuridica";
                    command.Parameters.AddWithValue("@CedulaJuridica", pCedulaJuridica);



                    SqlDataReader dataReader = gDatos.ExecuteReader(command);

                    while (dataReader.Read())
                    {
                        vendedor = new VendedorEL
                        {
                            IdVendedor = dataReader.GetInt32(0),
                            CedulaJuridica = dataReader.GetString(1),
                            Nombre = dataReader.GetString(2),
                            PrimerApellido = dataReader.GetString(3),
                            SegundoApellido = dataReader.GetString(4),
                            Telefono = dataReader.GetString(5),
                            Correo = dataReader.GetString(6),
                            Direccion = dataReader.GetString(7)

                        };

                    }
                    dataReader.Close();
                    return vendedor;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public List<VendedorEL> GetAllVendedor()
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {

                    VendedorEL vendedor = null;
                    List<VendedorEL> listaVendedores = new List<VendedorEL>();


                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetAllVendedor";

                    SqlDataReader dataReader = gDatos.ExecuteReader(command);

                    while (dataReader.Read())
                    {
                        vendedor = new VendedorEL
                        {
                            IdVendedor = dataReader.GetInt32(0),
                            CedulaJuridica = dataReader.GetString(2),
                            Nombre = dataReader.GetString(3),
                            PrimerApellido = dataReader.GetString(4),
                            SegundoApellido = dataReader.GetString(5),
                            Telefono = dataReader.GetString(6),
                            Correo = dataReader.GetString(7),
                            Direccion = dataReader.GetString(8)
                        };
                        listaVendedores.Add(vendedor);
                    }
                    dataReader.Close();
                    return listaVendedores;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VendedorEL InsertVendedor(VendedorEL pVendedor)
        {


            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spInsertVendedor";
                    command.Parameters.AddWithValue("@CedulaJuridica", pVendedor.CedulaJuridica);
                    command.Parameters.AddWithValue("@Nombre", pVendedor.Nombre);
                    command.Parameters.AddWithValue("@PrimerApellido", pVendedor.PrimerApellido);
                    command.Parameters.AddWithValue("@SegundoApellido", pVendedor.SegundoApellido);
                    command.Parameters.AddWithValue("@Telefono", pVendedor.Telefono);
                    command.Parameters.AddWithValue("@Correo", pVendedor.Correo);
                    command.Parameters.AddWithValue("@Direccion", pVendedor.Direccion);

                    gDatos.ExecuteNonQuery(ref command);
                }
                VendedorEL vendedor = GetVendedorByCedulaJuridica(pVendedor.CedulaJuridica);
                return vendedor;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public VendedorEL UpdateVendedor(VendedorEL pVendedor)
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spUpdateVendedor";
                    command.Parameters.AddWithValue("@IdVendedor", pVendedor.IdVendedor);
                    command.Parameters.AddWithValue("@CedulaJuridica", pVendedor.CedulaJuridica);
                    command.Parameters.AddWithValue("@Nombre", pVendedor.Nombre);
                    command.Parameters.AddWithValue("@PrimerApellido", pVendedor.PrimerApellido);
                    command.Parameters.AddWithValue("@SegundoApellido", pVendedor.SegundoApellido);
                    command.Parameters.AddWithValue("@Telefono", pVendedor.Telefono);
                    command.Parameters.AddWithValue("@Correo", pVendedor.Correo);
                    command.Parameters.AddWithValue("@Direccion", pVendedor.Direccion);

                    gDatos.ExecuteNonQuery(ref command);

                    VendedorEL vendedor = GetVendedorByCedulaJuridica(pVendedor.CedulaJuridica);
                    return vendedor;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool DeleteVendedor(int pIdVendedor)
        {
            bool deleted = false;
            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {

                    SqlCommand command = new SqlCommand();

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spDeleteVendedor";
                    command.Parameters.AddWithValue("@IdVendedor", pIdVendedor);


                    gDatos.ExecuteNonQuery(ref command);

                    if (this.GetVendedorById(pIdVendedor) == null)
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
