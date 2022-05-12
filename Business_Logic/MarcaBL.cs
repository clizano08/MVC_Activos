using Data_Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class MarcaBL
    {
        public MarcaEL GetMarcaById(int pIdMarca)
        {
            MarcaDB marcaDB = new MarcaDB();
            return marcaDB.GetMarcaById(pIdMarca);
        }
        public List<MarcaEL> GetAllMarca()
        {
            MarcaDB marcaDB = new MarcaDB();
            return marcaDB.GetAllMarca();
        }
        public MarcaEL InsertMarca(MarcaEL pMarca)
        {
            MarcaDB marcaDB = new MarcaDB();
            return marcaDB.InsertMarca(pMarca);
        }
        public MarcaEL UpdateMarca(MarcaEL pMarca)
        {
            MarcaDB marcaDB = new MarcaDB();
            return marcaDB.UpdateMarca(pMarca);
        }
        public bool DeleteMarca(int pIdMarca)
        {
            MarcaDB marcaDB = new MarcaDB();
            return marcaDB.DeleteMarca(pIdMarca);
        }
    }
}
