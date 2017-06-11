using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico.Entities
{
    public class ATM
    {
        public int idATM {set;get;}

       
        public List<Retiro>ListRetiro{set;get;}
        public List<Pantalla> ListPantalla { set; get; }
        public List<DispensadorEfectivo> ListDispensadorEfectivo { set; get; }
        public List<Teclado> ListTeclado { set; get; }
        public List<RanuraDeposito> ListRanuraDeposito { set; get; }

        public String Direccion { set; get; }
        public String CodigoATM { set; get; }

        public int idBaseDatos { set; get; }
        public BaseDatos BaseDatos { set; get; }

    }
}
