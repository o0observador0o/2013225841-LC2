using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico.Entities
{
    public class Teclado
    {
        public int idTeclado { set; get; }
        public String MarcaTeclado { set; get; }

        public int idATM { set; get; }
        public ATM ATM { set; get; }

        //public List<Retiro> ListRetiro { set; get; }
    }
}
