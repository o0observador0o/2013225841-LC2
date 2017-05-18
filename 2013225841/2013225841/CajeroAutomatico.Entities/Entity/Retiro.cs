using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico.Entities
{
    public class Retiro
    {
        public int idRetiro { set; get; }
        public Double Monto { set; get; }

        public int idATM { set; get; }
        public ATM ATM { set; get; }

        public int idTeclado { set; get; }
        public Teclado Teclado { set; get; }

        public int idPantalla { set; get; }
        public Pantalla Pantalla { set; get; }

        public int idDispensadorEfectivo { set; get; }
        public DispensadorEfectivo Dispensadorefectivo { set; get; }
    }
}
