using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using CajeroAutomatico.Entities;

namespace CajeroAutomatico.Persistance.EntityConfiguration
{
    public class CuentaConfiguration : EntityTypeConfiguration<Cuenta>
    {
        public CuentaConfiguration()
       {
           
           ToTable("Cuenta");

           HasKey(a => a.idCuenta);
           HasRequired(c => c.BaseDatos).WithMany(g => g.listaCuentas).HasForeignKey(v => v.idBaseDatos);

       }

    }
}
