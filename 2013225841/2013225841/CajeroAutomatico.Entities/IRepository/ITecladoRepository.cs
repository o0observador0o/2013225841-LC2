﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico.Entities.IRepository
{
    public interface ITecladoRepository : Repository<Teclado>
    {

        IEnumerable<Teclado> getTecladoporATM(ATM ATM);
        IEnumerable<Teclado> getTecladoporRetiro(Retiro Retiro);
    }
}