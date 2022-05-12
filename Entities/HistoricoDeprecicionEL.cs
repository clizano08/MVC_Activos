using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class HistoricoDeprecicionEL
    {
        public int HistoricoDeprecicion { get; set; }
        public ActivoEL Activo { get; set; }
        public decimal ValorDeprecicion { get; set; }
        public DateTime RegistroDeprecicion { get; set; }
    }
}
