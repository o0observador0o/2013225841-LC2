using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using CajeroAutomatico.Entities;

namespace CajeroAutomatico.Persistance.EntityConfiguration
{
    public class PantallaConfiguration : EntityTypeConfiguration<Pantalla>
    {

        public PantallaConfiguration()
       {
           
           ToTable("Pantalla");

           HasKey(a => a.idPantalla);
           HasOptional(c => c.Retiro).WithRequired(c => c.Pantalla);

       }

    }
}
