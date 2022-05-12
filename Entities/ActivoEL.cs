using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class ActivoEL
    {
        public int IdActivo { get; set; }
        public UsuarioEL Usuario{ get; set; }
        public VendedorEL Vendedor { get; set; }
        public CategoriaActivoEL CategoriaActivo { get; set; }
        public AseguradorEL Asegurador { get; set; }
        public MarcaEL Marca { get; set; }
        public string NumeroSerie { get; set; }
        public string Modelo { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public decimal ValorActual { get; set; }
        public decimal CostoColones { get; set; }
        public decimal CostoDolares { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime VencimientoGarantia { get; set; }
        public DateTime VencimientoSeguro { get; set; }
        public byte[] ImgActivo { get; set; }
        public byte[] ImgFactura { get; set; }

    }
}
