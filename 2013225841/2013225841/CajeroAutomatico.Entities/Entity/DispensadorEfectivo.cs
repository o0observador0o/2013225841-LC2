using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico.Entities
{
    public class DispensadorEfectivo
    {
        public int idDispensadorefectivo { set; get; }
        public double contador { set; get; }

        public int idATM { set; get; }
        public ATM ATM { set; get; }

        //public int idRetiro { set; get; }
        //public List<Retiro> ListRetiro { set; get; }

      
    }
}
