using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajeroAutomatico.Entities;
using CajeroAutomatico.Entities.IRepository;

namespace CajeroAutomatico.Persistance.Repositories
{
    public class RetiroRepository : Repository<Retiro>, IRetiroRepository
    {
        public RetiroRepository(CajeroDBContext context)
            : base(context)
        {
        }

    }
}
