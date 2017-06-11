using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico.Entities.EntitiesDTO
{
    public class DispensadorEfectivoDTO
    {
        public int idDispensadorefectivo { set; get; }
        public double contador { set; get; }

        public int idATM { set; get; }
        public ATM ATM { set; get; }


      
    }
}
