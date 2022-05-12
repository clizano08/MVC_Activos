using Data_Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
   public class CategoriaActivoBL
    {
        public CategoriaActivoEL GetCategoriaActivoById(int pIdCategoriaActivo)
        {
            CategoriaActivoDB categoriaActivoDB = new CategoriaActivoDB();
            return categoriaActivoDB.GetCategoriaActivoById(pIdCategoriaActivo);
        }
        public List<CategoriaActivoEL> GetAllCategoriaActivo()
        {
            CategoriaActivoDB categoriaActivoDB = new CategoriaActivoDB();
            return categoriaActivoDB.GetAllCategoriaActivo();
        }
        public CategoriaActivoEL InsertCategoriaActivo(CategoriaActivoEL pCategoriaActivo)
        {
            CategoriaActivoDB categoriaActivoDB = new CategoriaActivoDB();
            return categoriaActivoDB.InsertCategoriaActivo(pCategoriaActivo);
        }
        public CategoriaActivoEL UpdateCategoriaActivo(CategoriaActivoEL pCategoriaActivo)
        {
            CategoriaActivoDB categoriaActivoDB = new CategoriaActivoDB();
            return categoriaActivoDB.UpdateCategoriaActivo(pCategoriaActivo);
        }
        public bool DeleteCategoriaActivo(int pIdCategoriaActivo)
        {
            CategoriaActivoDB CategoriaActivoDB = new CategoriaActivoDB();
            return CategoriaActivoDB.DeleteCategoriaActivo(pIdCategoriaActivo);
        }
    }
}
