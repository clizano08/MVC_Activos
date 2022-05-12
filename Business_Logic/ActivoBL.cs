using Data_Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class ActivoBL
    {
        public ActivoEL GetActivoById(int pIdActivo)
        {
            ActivoDB activoDB = new ActivoDB();
            return activoDB.GetActivoById(pIdActivo);
        }
        public List<ActivoEL> GetAllActivo()
        {
            ActivoDB activoDB = new ActivoDB();
            return activoDB.GetAllActivo();
        }
        public ActivoEL InsertActivo(ActivoEL pActivo)
        {
            ActivoDB activoDB = new ActivoDB();
            return activoDB.InsertActivo(pActivo);
        }
        public ActivoEL UpdateActivo(ActivoEL pActivo)
        {
            ActivoDB activoDB = new ActivoDB();
            return activoDB.UpdateActivo(pActivo);
        }
        public bool DeleteActivo(int pIdActivo)
        {
            ActivoDB activoDB = new ActivoDB();
            return activoDB.DeleteActivo(pIdActivo);
        }
        public List<ActivoEL> GetActivoByIdCategoriaActivo(int pIdCategoriaActivo)
        {
            ActivoDB activoDB = new ActivoDB();
            return activoDB.GetActivoByIdCategoriaActivo(pIdCategoriaActivo);
        }
        public List<ActivoEL> GetActivoByIdMarca(int pIdMarca)
        {
            ActivoDB activoDB = new ActivoDB();
            return activoDB.GetActivoByIdMarca(pIdMarca);
        }
    }
}
