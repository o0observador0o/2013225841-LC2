using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico.Entities
{
    public class Pantalla
    {
        public int idPantalla { set; get; }
        public String MarcaPantalla { set; get; }

        public int idATM { set; get; }
        public ATM ATM { set; get; }

        //public int idRetiro { set; get; }
        //public List<Retiro> ListRetiro { set; get; }
    }
}
