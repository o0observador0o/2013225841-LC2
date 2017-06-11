using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajeroAutomatico.Entities.IRepository;
using CajeroAutomatico.Entities;
using CajeroAutomatico.Persistance.Repositories;
using CajeroAutomatico.Persistance;


namespace CajeroAutomatico.Persistance.Repositories
{
    public class ATMRepository : Repository<ATM>, IATMRepository
    {


        public ATMRepository(CajeroDBContext context)
            : base(context)
        {
        }

    }
}
