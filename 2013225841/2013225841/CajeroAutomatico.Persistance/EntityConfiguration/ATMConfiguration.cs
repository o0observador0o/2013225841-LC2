using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using CajeroAutomatico.Entities;

namespace CajeroAutomatico.Persistance
{
    public class ATMConfiguration : EntityTypeConfiguration<ATM>
    {

        public ATMConfiguration()
       {
           
           ToTable("ATM");

           HasKey(a => a.idATM);
           HasRequired(c => c.dispensadorEfectivo).WithRequiredPrincipal(c => c.ATM);
           HasRequired(c => c.pantalla).WithRequiredPrincipal(c => c.ATM);
           HasRequired(c => c.teclado).WithRequiredPrincipal(c => c.ATM);
           HasOptional(c => c.Retiro).WithRequired(c => c.ATM);
           HasRequired(c => c.ranuradeposito).WithRequiredPrincipal(c => c.ATM);


       }
    }
}
