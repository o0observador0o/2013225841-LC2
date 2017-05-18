using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico.Entities.IRepository
{
    public interface IPantallaRepository : Repository<Pantalla>
    {
        IEnumerable<Pantalla> getPantallaxATM(ATM ATM);
        IEnumerable<Pantalla> getPantallaxRetiro(Retiro Retiro);
    }
}
