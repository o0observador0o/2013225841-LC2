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
        public String LenguajeNativo { set; get; }
        public Double CapacidadHDD { set; get; }

        public List<Cuenta> listaCuentas { set; get; }
        public List<ATM>  ListATM { set; get; }
        public List<Retiro> ListRetiro { set; get; }

        

       

    }
}
