using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CajeroAutomatico.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace CajeroAutomatico.Persistance
{
    public class CajeroDBContext : DbContext
    {

        public DbSet<ATM> ATM { get; set; }
        public DbSet<BaseDatos> BaseDatos { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<DispensadorEfectivo> DispensadorEfectivo { get; set; }
        public DbSet<Pantalla> Pantalla { get; set; }
        public DbSet<RanuraDeposito> RanuraDeposito { get; set; }
        public DbSet<Retiro> Retiro { get; set; }
        public DbSet<Teclado> Teclado { get; set; }

        public CajeroDBContext()
			:base("CajeroDB")
		{

		}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        



            modelBuilder.Entity<ATM>().ToTable("ATM");
            modelBuilder.Entity<ATM>().HasKey(a => a.idATM);
            modelBuilder.Entity<ATM>().HasRequired(v => v.BaseDatos)
                .WithMany(g => g.ListATM)
                .HasForeignKey(v => v.idBaseDatos).WillCascadeOnDelete(false);

            
            modelBuilder.Entity<BaseDatos>().ToTable("BaseDatos");
            modelBuilder.Entity<BaseDatos>().HasKey(a => a.idBaseDatos);



            modelBuilder.Entity<Cuenta>().ToTable("Cuenta");
            modelBuilder.Entity<Cuenta>().HasKey(a => a.idCuenta);
            modelBuilder.Entity<Cuenta>().HasRequired(v => v.BaseDatos)
                .WithMany(g => g.listaCuentas)
                .HasForeignKey(v => v.idBaseDatos);


            modelBuilder.Entity<DispensadorEfectivo>().ToTable("DispensadorEfectivo");
            modelBuilder.Entity<DispensadorEfectivo>().HasKey(a => a.idDispensadorefectivo);
            modelBuilder.Entity<DispensadorEfectivo>().HasRequired(v => v.ATM)
                .WithMany(g => g.ListDispensadorEfectivo)
                .HasForeignKey(v => v.idATM).WillCascadeOnDelete(false);


            modelBuilder.Entity<Pantalla>().ToTable("Pantalla");
            modelBuilder.Entity<Pantalla>().HasKey(a => a.idPantalla);
            modelBuilder.Entity<Pantalla>().HasRequired(v => v.ATM)
                .WithMany(g => g.ListPantalla)
                .HasForeignKey(v => v.idATM).WillCascadeOnDelete(false);





            modelBuilder.Entity<RanuraDeposito>().ToTable("RanuraDeposito");
            modelBuilder.Entity<RanuraDeposito>().HasKey(a => a.idRanuraDeposito);
            modelBuilder.Entity<RanuraDeposito>().HasRequired(v => v.ATM)
                .WithMany(g => g.ListRanuraDeposito)
                .HasForeignKey(v => v.idATM).WillCascadeOnDelete(false);



            modelBuilder.Entity<Retiro>().ToTable("Retiro");
            modelBuilder.Entity<Retiro>().HasKey(a => a.idRetiro);
            //modelBuilder.Entity<Retiro>().HasRequired(v => v.Pantalla)
            //    .WithMany(g => g.ListRetiro)
            //    .HasForeignKey(v => v.idPantalla);
            //modelBuilder.Entity<Retiro>().HasRequired(v => v.Teclado)
            //    .WithMany(g => g.ListRetiro)
            //    .HasForeignKey(v => v.idTeclado);
            //modelBuilder.Entity<Retiro>().HasRequired(v => v.Dispensadorefectivo)
            //    .WithMany(g => g.ListRetiro)
            //    .HasForeignKey(v => v.idDispensadorEfectivo);
            modelBuilder.Entity<Retiro>().HasRequired(v => v.ATM)
                .WithMany(g => g.ListRetiro)
                .HasForeignKey(v => v.idATM).WillCascadeOnDelete(false);
            modelBuilder.Entity<Retiro>().HasRequired(v => v.Cuenta)
                .WithMany(g => g.ListRetiro)
                .HasForeignKey(v => v.idCuenta);





            modelBuilder.Entity<Teclado>().ToTable("Teclado");
            modelBuilder.Entity<Teclado>().HasKey(a => a.idTeclado);
            modelBuilder.Entity<Teclado>().HasRequired(v => v.ATM)
                .WithMany(g => g.ListTeclado)
                .HasForeignKey(v => v.idATM).WillCascadeOnDelete(false);



            base.OnModelCreating(modelBuilder);
        }
    }
}
