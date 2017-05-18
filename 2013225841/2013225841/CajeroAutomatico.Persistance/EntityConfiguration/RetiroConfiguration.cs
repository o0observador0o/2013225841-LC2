using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using CajeroAutomatico.Entities;

namespace CajeroAutomatico.Persistance.EntityConfiguration
{
    public class RetiroConfiguration : EntityTypeConfiguration<Retiro>
    {

        public RetiroConfiguration()
       {
           
           ToTable("Retiro");

           HasKey(a => a.idRetiro);

       }

    }
}
