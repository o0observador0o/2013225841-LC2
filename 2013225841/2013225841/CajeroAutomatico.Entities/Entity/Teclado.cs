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
        public String Marca { set; get; }

        public int idATM { set; get; }
        public ATM ATM { set; get; }

        public int idRetiro { set; get; }
        public Retiro Retiro { set; get; }
    }
}
