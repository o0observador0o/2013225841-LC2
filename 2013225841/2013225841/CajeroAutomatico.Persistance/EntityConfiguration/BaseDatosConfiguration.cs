using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using CajeroAutomatico.Entities;

namespace CajeroAutomatico.Persistance.EntityConfiguration
{
    public class BaseDatosConfiguration : EntityTypeConfiguration<BaseDatos>
    {

        public BaseDatosConfiguration()
       {
           
           ToTable("BaseDatos");

           HasKey(a => a.idBaseDatos);
           HasOptional(c => c.ATM).WithRequired(c => c.BaseDatos);

       }

    }
}
