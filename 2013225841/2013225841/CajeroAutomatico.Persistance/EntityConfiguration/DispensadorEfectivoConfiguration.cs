using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using CajeroAutomatico.Entities;

namespace CajeroAutomatico.Persistance.EntityConfiguration
{
    public class DispensadorEfectivoConfiguration : EntityTypeConfiguration<DispensadorEfectivo>
    {

        public DispensadorEfectivoConfiguration()
       {
           
           ToTable("DispensadorEfectivo");

           HasKey(a => a.idDispensadorefectivo);
           HasOptional(c => c.Retiro).WithRequired(c => c.Dispensadorefectivo);
       }
    }
}
