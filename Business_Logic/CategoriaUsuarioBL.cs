using Data_Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class CategoriaUsuarioBL
    {
        public CategoriaUsuarioEL GetCategoriaUsuarioById(int pIdCategoriaUsuario)
        {
            CategoriaUsuarioDB categoriaUsuarioDB = new CategoriaUsuarioDB();
            return categoriaUsuarioDB.GetCategoriaUsuarioById(pIdCategoriaUsuario);
        }
        public List<CategoriaUsuarioEL> GetAllCategoriaUsuario()
        {
            CategoriaUsuarioDB categoriaUsuarioDB = new CategoriaUsuarioDB();
            return categoriaUsuarioDB.GetAllCategoriaUsuario();
        }
        public CategoriaUsuarioEL InsertCategoriaUsuario(CategoriaUsuarioEL pCategoriaUsuario)
        {
            CategoriaUsuarioDB categoriaUsuarioDB = new CategoriaUsuarioDB();
            return categoriaUsuarioDB.InsertCategoriaUsuario(pCategoriaUsuario);
        }
        public CategoriaUsuarioEL UpdateCategoriaUsuario(CategoriaUsuarioEL pCategoriaUsuario)
        {
            CategoriaUsuarioDB categoriaUsuarioDB = new CategoriaUsuarioDB();
            return categoriaUsuarioDB.UpdateCategoriaUsuario(pCategoriaUsuario);
        }
        public bool DeleteCategoriaUsuario(int pIdCategoriaUsuario)
        {
            CategoriaUsuarioDB categoriaUsuarioDB = new CategoriaUsuarioDB();
            return categoriaUsuarioDB.DeleteCategoriaUsuario(pIdCategoriaUsuario);
        }
    }
}
