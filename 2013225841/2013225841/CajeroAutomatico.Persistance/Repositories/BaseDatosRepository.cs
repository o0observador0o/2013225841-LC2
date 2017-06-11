using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajeroAutomatico.Entities;
using CajeroAutomatico.Entities.IRepository;

namespace CajeroAutomatico.Persistance.Repositories
{
    public class BaseDatosRepository : Repository<BaseDatos>, IBaseDatosRepository
    {

        public BaseDatosRepository(CajeroDBContext context)
            : base(context)
        {
        }

    }
}
