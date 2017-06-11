using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajeroAutomatico.Entities;
using CajeroAutomatico.Entities.IRepository;

namespace CajeroAutomatico.Persistance.Repositories
{
    public class TecladoRepository  : Repository<Teclado>, ITecladoRepository
    {
        public TecladoRepository(CajeroDBContext context)
            : base(context)
        {
        }

    }
}
