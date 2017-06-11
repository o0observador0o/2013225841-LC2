using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajeroAutomatico.Entities;
using CajeroAutomatico.Entities.IRepository;

namespace CajeroAutomatico.Persistance.Repositories
{
    public class RanuraDepositoRepository : Repository<RanuraDeposito>, IRanuraDepositoRepository
    {

        public RanuraDepositoRepository(CajeroDBContext context)
            : base(context)
        {


        }
    }
}
