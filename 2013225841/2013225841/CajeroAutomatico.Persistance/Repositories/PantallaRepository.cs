using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajeroAutomatico.Entities;
using CajeroAutomatico.Entities.IRepository;

namespace CajeroAutomatico.Persistance.Repositories
{
    public class PantallaRepository : Repository<Pantalla>, IPantallaRepository
    {

        public PantallaRepository(CajeroDBContext context)
            : base(context)
        {
        }

    }
}
