using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico.Entities
{
    public class BaseDatos
    {
        public int idBaseDatos { set; get; }
        public String Administrador { set; get; }
        public List<Cuenta> listaCuentas { set; get; }

        public int idATM { set; get; }
        public ATM ATM { set; get; }

        

       

    }
}
