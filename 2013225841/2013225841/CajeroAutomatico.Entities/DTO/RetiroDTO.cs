using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico.Entities.EntitiesDTO
{
    public class RetiroDTO
    {
        public int idRetiro { set; get; }
        public Double Monto { set; get; }
        public String DNIPersona { set; get; }
        public String NombrePersona { set; get; }
        public int idATM { set; get; }       
        public int idCuenta { set; get; }

        //public int idBaseDatos { set; get; }
        //public BaseDatos BaseDatos { set; get; }
    }
}
