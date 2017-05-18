using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using CajeroAutomatico.Entities;

namespace CajeroAutomatico.Persistance.EntityConfiguration
{
    public class TecladoConfiguration : EntityTypeConfiguration<Teclado>
    {


        public TecladoConfiguration()
       {

           ToTable("Teclado");

           HasKey(a => a.idTeclado);
           HasOptional(c => c.Retiro).WithRequired(c => c.Teclado);

       }
    }
}
