using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico.Entities.IRepository
{
    public interface IRetiroRepository : Repository<Retiro>
    {
        IEnumerable<Retiro> getRetiroxPantalla(Pantalla Pantalla);
        IEnumerable<Retiro> getRetiroxATM(ATM ATM);
        IEnumerable<Retiro> getRetiroxDispensador(DispensadorEfectivo DispensadorEfectivo);
        IEnumerable<Retiro> getRetiroxBasedeDatos(BaseDatos BaseDatos);
    }
}
