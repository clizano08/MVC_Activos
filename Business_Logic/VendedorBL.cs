using Data_Base;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class VendedorBL
    {
        public VendedorEL GetVendedorById(int pIdVendedor)
        {
            VendedorDB vendedorDB = new VendedorDB();
            return vendedorDB.GetVendedorById(pIdVendedor);
        }
        public VendedorEL GetVendedorByCedulaJuridica(string pCedulaJuridica)
        {
            VendedorDB vendedorDB = new VendedorDB();
            return vendedorDB.GetVendedorByCedulaJuridica(pCedulaJuridica);
        }
        public List<VendedorEL> GetAllVendedor()
        {
            VendedorDB vendedorDB = new VendedorDB();
            return vendedorDB.GetAllVendedor();
        }
        public VendedorEL InsertVendedor(VendedorEL pVendedor)
        {
            VendedorDB vendedorDB = new VendedorDB();
            return vendedorDB.InsertVendedor(pVendedor);
        }
        public VendedorEL UpdateVendedor(VendedorEL pVendedor)
        {
            VendedorDB vendedorDB = new VendedorDB();
            return vendedorDB.UpdateVendedor(pVendedor);
        }
        public bool DeleteVendedor(int pIdVendedor)
        {
            VendedorDB vendedorDB = new VendedorDB();
            return vendedorDB.DeleteVendedor(pIdVendedor);
        }
    }
}
