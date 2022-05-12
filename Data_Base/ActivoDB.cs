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
    public class ActivoDB
    {
        public ActivoEL GetActivoById(int pIdActivo)
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    ActivoEL activo = null;

                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetActivoById";
                    command.Parameters.AddWithValue("@IdActivo", pIdActivo);



                    SqlDataReader dataReader = gDatos.ExecuteReader(command);

                    while (dataReader.Read())
                    {
                        activo = new ActivoEL
                        {
                            IdActivo = dataReader.GetInt32(0),
                            Usuario = new UsuarioDB().GetUsuarioById(dataReader.GetInt32(1)),
                            Vendedor = new VendedorDB().GetVendedorById(dataReader.GetInt32(2)),
                            CategoriaActivo = new CategoriaActivoDB().GetCategoriaActivoById(dataReader.GetInt32(3)),
                            Asegurador = new AseguradorDB().GetAseguradorById(dataReader.GetInt32(4)),
                            Marca = new MarcaDB().GetMarcaById(dataReader.GetInt32(5)),
                            NumeroSerie = dataReader.GetString(6),
                            Modelo = dataReader.GetString(7),
                            Estado = dataReader.GetString(8),
                            Descripcion = dataReader.GetString(9),
                            ValorActual = dataReader.GetDecimal(10),
                            CostoColones = dataReader.GetDecimal(11),
                            CostoDolares = dataReader.GetDecimal(12),
                            FechaCompra = dataReader.GetDateTime(13),
                            VencimientoGarantia = dataReader.GetDateTime(14),
                            VencimientoSeguro = dataReader.GetDateTime(15),
                            ImgActivo = Convert.FromBase64String(dataReader.GetString(16)),
                            ImgFactura = Convert.FromBase64String(dataReader.GetString(17))
                        };

                    }
                    dataReader.Close();
                    return activo;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public List<ActivoEL> GetAllActivo()
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {

                    ActivoEL activo = null;
                    List<ActivoEL> listaActivos = new List<ActivoEL>();


                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetAllActivo";

                    SqlDataReader dataReader = gDatos.ExecuteReader(command);

                    while (dataReader.Read())
                    {
                        activo = new ActivoEL
                        {
                            IdActivo = dataReader.GetInt32(0),
                            Usuario = new UsuarioDB().GetUsuarioById(dataReader.GetInt32(1)),
                            Vendedor = new VendedorDB().GetVendedorById(dataReader.GetInt32(2)),
                            CategoriaActivo = new CategoriaActivoDB().GetCategoriaActivoById(dataReader.GetInt32(3)),
                            Asegurador = new AseguradorDB().GetAseguradorById(dataReader.GetInt32(4)),
                            Marca = new MarcaDB().GetMarcaById(dataReader.GetInt32(5)),
                            NumeroSerie = dataReader.GetString(6),
                            Modelo = dataReader.GetString(7),
                            Estado = dataReader.GetString(8),
                            Descripcion = dataReader.GetString(9),
                            ValorActual = dataReader.GetDecimal(10),
                            CostoColones = dataReader.GetDecimal(11),
                            CostoDolares = dataReader.GetDecimal(12),
                            FechaCompra = dataReader.GetDateTime(13),
                            VencimientoGarantia = dataReader.GetDateTime(14),
                            VencimientoSeguro = dataReader.GetDateTime(15),
                            ImgActivo = Convert.FromBase64String(dataReader.GetString(16)),
                            ImgFactura = Convert.FromBase64String(dataReader.GetString(17))
                        };
                        listaActivos.Add(activo);
                    }
                    dataReader.Close();
                    return listaActivos;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActivoEL InsertActivo(ActivoEL pActivo)
        {


            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spInsertActivo";
                    command.Parameters.AddWithValue("@IdUsuario", pActivo.Usuario.IdUsuario);
                    command.Parameters.AddWithValue("@IdVendedor", pActivo.Vendedor.IdVendedor);
                    command.Parameters.AddWithValue("@IdCategoriaActivo", pActivo.CategoriaActivo.IdCatgoriaActivo);
                    command.Parameters.AddWithValue("@IdAsegurador", pActivo.Asegurador.IdAsegurador);
                    command.Parameters.AddWithValue("@IdMarca", pActivo.Marca.IdMarca);
                    command.Parameters.AddWithValue("@NumeroSerie", pActivo.NumeroSerie);
                    command.Parameters.AddWithValue("@Modelo", pActivo.Modelo);
                    command.Parameters.AddWithValue("@Estado", pActivo.Estado);
                    command.Parameters.AddWithValue("@Descripcion", pActivo.Descripcion);
                    command.Parameters.AddWithValue("@ValorActual", pActivo.ValorActual);
                    command.Parameters.AddWithValue("@CostoColones", pActivo.CostoColones);
                    command.Parameters.AddWithValue("@CostoDolares", pActivo.CostoDolares);
                    command.Parameters.AddWithValue("@FechaCompra", pActivo.FechaCompra);
                    command.Parameters.AddWithValue("@VencimientoGarantia", pActivo.VencimientoGarantia);
                    command.Parameters.AddWithValue("@VencimientoSeguro", pActivo.VencimientoSeguro);
                    command.Parameters.AddWithValue("@ImgActivo", pActivo.ImgActivo);
                    command.Parameters.AddWithValue("@ImgFactura", pActivo.ImgFactura);

                    gDatos.ExecuteNonQuery(ref command);
                }
                ActivoEL activo = GetActivoById(pActivo.IdActivo);
                return activo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ActivoEL UpdateActivo(ActivoEL pActivo)
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spUpdateActivo";
                    command.Parameters.AddWithValue("@IdActivo", pActivo.IdActivo);
                    command.Parameters.AddWithValue("@IdUsuario", pActivo.Usuario.IdUsuario);
                    command.Parameters.AddWithValue("@IdVendedor", pActivo.Vendedor.IdVendedor);
                    command.Parameters.AddWithValue("@IdCategoriaActivo", pActivo.CategoriaActivo.IdCatgoriaActivo);
                    command.Parameters.AddWithValue("@IdAsegurador", pActivo.Asegurador.IdAsegurador);
                    command.Parameters.AddWithValue("@IdMarca", pActivo.Marca.IdMarca);
                    command.Parameters.AddWithValue("@NumeroSerie", pActivo.NumeroSerie);
                    command.Parameters.AddWithValue("@Modelo", pActivo.Modelo);
                    command.Parameters.AddWithValue("@Estado", pActivo.Estado);
                    command.Parameters.AddWithValue("@Descripcion", pActivo.Descripcion);
                    command.Parameters.AddWithValue("@ValorActual", pActivo.ValorActual);
                    command.Parameters.AddWithValue("@CostoColones", pActivo.CostoColones);
                    command.Parameters.AddWithValue("@CostoDolares", pActivo.CostoDolares);
                    command.Parameters.AddWithValue("@FechaCompra", pActivo.FechaCompra);
                    command.Parameters.AddWithValue("@VencimientoGarantia", pActivo.VencimientoGarantia);
                    command.Parameters.AddWithValue("@VencimientoSeguro", pActivo.VencimientoSeguro);
                    command.Parameters.AddWithValue("@ImgActivo", pActivo.ImgActivo.ToString());
                    command.Parameters.AddWithValue("@ImgFactura", pActivo.ImgFactura.ToString());

                    gDatos.ExecuteNonQuery(ref command);

                    ActivoEL activo = GetActivoById(pActivo.IdActivo);
                    return activo;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool DeleteActivo(int pIdActivo)
        {
            bool deleted = false;
            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {

                    SqlCommand command = new SqlCommand();

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spDeleteActivo";
                    command.Parameters.AddWithValue("@IdActivo", pIdActivo);


                    gDatos.ExecuteNonQuery(ref command);

                    if (this.GetActivoById(pIdActivo) == null)
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
        public List<ActivoEL> GetActivoByIdCategoriaActivo(int pIdCategoriaActivo)
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {

                    ActivoEL activo = null;
                    List<ActivoEL> listaActivos = new List<ActivoEL>();


                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetActivoByIdCategoriaActivo";
                    command.Parameters.AddWithValue("@IdCategoriaActivo", pIdCategoriaActivo);

                    SqlDataReader dataReader = gDatos.ExecuteReader(command);

                    while (dataReader.Read())
                    {
                        activo = new ActivoEL
                        {
                            IdActivo = dataReader.GetInt32(0),
                            Usuario = new UsuarioDB().GetUsuarioById(dataReader.GetInt32(1)),
                            Vendedor = new VendedorDB().GetVendedorById(dataReader.GetInt32(2)),
                            CategoriaActivo = new CategoriaActivoDB().GetCategoriaActivoById(dataReader.GetInt32(3)),
                            Asegurador = new AseguradorDB().GetAseguradorById(dataReader.GetInt32(4)),
                            Marca = new MarcaDB().GetMarcaById(dataReader.GetInt32(5)),
                            NumeroSerie = dataReader.GetString(6),
                            Modelo = dataReader.GetString(7),
                            Estado = dataReader.GetString(8),
                            Descripcion = dataReader.GetString(9),
                            ValorActual = dataReader.GetDecimal(10),
                            CostoColones = dataReader.GetDecimal(11),
                            CostoDolares = dataReader.GetDecimal(12),
                            FechaCompra = dataReader.GetDateTime(13),
                            VencimientoGarantia = dataReader.GetDateTime(14),
                            VencimientoSeguro = dataReader.GetDateTime(15),
                            ImgActivo = Convert.FromBase64String(dataReader.GetString(16)),
                            ImgFactura = Convert.FromBase64String(dataReader.GetString(17))
                        };
                        listaActivos.Add(activo);
                    }
                    dataReader.Close();
                    return listaActivos;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ActivoEL> GetActivoByIdMarca(int pIdMarca)
        {

            try
            {
                using (DB_ActivosPractica gDatos = new DB_ActivosPractica())
                {

                    ActivoEL activo = null;
                    List<ActivoEL> listaActivos = new List<ActivoEL>();


                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spGetActivoByIdMarca";
                    command.Parameters.AddWithValue("@IdMarca", pIdMarca);

                    SqlDataReader dataReader = gDatos.ExecuteReader(command);

                    while (dataReader.Read())
                    {
                        activo = new ActivoEL
                        {
                            IdActivo = dataReader.GetInt32(0),
                            Usuario = new UsuarioDB().GetUsuarioById(dataReader.GetInt32(1)),
                            Vendedor = new VendedorDB().GetVendedorById(dataReader.GetInt32(2)),
                            CategoriaActivo = new CategoriaActivoDB().GetCategoriaActivoById(dataReader.GetInt32(3)),
                            Asegurador = new AseguradorDB().GetAseguradorById(dataReader.GetInt32(4)),
                            Marca = new MarcaDB().GetMarcaById(dataReader.GetInt32(5)),
                            NumeroSerie = dataReader.GetString(6),
                            Modelo = dataReader.GetString(7),
                            Estado = dataReader.GetString(8),
                            Descripcion = dataReader.GetString(9),
                            ValorActual = dataReader.GetDecimal(10),
                            CostoColones = dataReader.GetDecimal(11),
                            CostoDolares = dataReader.GetDecimal(12),
                            FechaCompra = dataReader.GetDateTime(13),
                            VencimientoGarantia = dataReader.GetDateTime(14),
                            VencimientoSeguro = dataReader.GetDateTime(15),
                            ImgActivo = Convert.FromBase64String(dataReader.GetString(16)),
                            ImgFactura = Convert.FromBase64String(dataReader.GetString(17))
                        };
                        listaActivos.Add(activo);
                    }
                    dataReader.Close();
                    return listaActivos;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
