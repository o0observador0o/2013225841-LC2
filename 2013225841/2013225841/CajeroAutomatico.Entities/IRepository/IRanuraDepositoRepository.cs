using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico.Entities.IRepository
{
    public interface IRanuraDepositoRepository : Repository<RanuraDeposito>
    {
        IEnumerable<RanuraDeposito> getRanuraporATM(ATM ATM);
    }
}
