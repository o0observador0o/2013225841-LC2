namespace CajeroAutomatico.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ATM",
                c => new
                    {
                        idATM = c.Int(nullable: false, identity: true),
                        Direccion = c.String(),
                        CodigoATM = c.String(),
                        idBaseDatos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idATM)
                .ForeignKey("dbo.BaseDatos", t => t.idBaseDatos)
                .Index(t => t.idBaseDatos);
            
            CreateTable(
                "dbo.BaseDatos",
                c => new
                    {
                        idBaseDatos = c.Int(nullable: false, identity: true),
                        Administrador = c.String(),
                        LenguajeNativo = c.String(),
                        CapacidadHDD = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.idBaseDatos);
            
            CreateTable(
                "dbo.Cuenta",
                c => new
                    {
                        idCuenta = c.Int(nullable: false, identity: true),
                        NumeroCuenta = c.Int(nullable: false),
                        pin = c.Int(nullable: false),
                        saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        idBaseDatos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCuenta)
                .ForeignKey("dbo.BaseDatos", t => t.idBaseDatos, cascadeDelete: true)
                .Index(t => t.idBaseDatos);
            
            CreateTable(
                "dbo.Retiro",
                c => new
                    {
                        idRetiro = c.Int(nullable: false, identity: true),
                        Monto = c.Double(nullable: false),
                        DNIPersona = c.String(),
                        NombrePersona = c.String(),
                        idATM = c.Int(nullable: false),
                        idCuenta = c.Int(nullable: false),
                        BaseDatos_idBaseDatos = c.Int(),
                    })
                .PrimaryKey(t => t.idRetiro)
                .ForeignKey("dbo.ATM", t => t.idATM)
                .ForeignKey("dbo.Cuenta", t => t.idCuenta, cascadeDelete: true)
                .ForeignKey("dbo.BaseDatos", t => t.BaseDatos_idBaseDatos)
                .Index(t => t.idATM)
                .Index(t => t.idCuenta)
                .Index(t => t.BaseDatos_idBaseDatos);
            
            CreateTable(
                "dbo.DispensadorEfectivo",
                c => new
                    {
                        idDispensadorefectivo = c.Int(nullable: false, identity: true),
                        contador = c.Double(nullable: false),
                        idATM = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idDispensadorefectivo)
                .ForeignKey("dbo.ATM", t => t.idATM)
                .Index(t => t.idATM);
            
            CreateTable(
                "dbo.Pantalla",
                c => new
                    {
                        idPantalla = c.Int(nullable: false, identity: true),
                        MarcaPantalla = c.String(),
                        idATM = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idPantalla)
                .ForeignKey("dbo.ATM", t => t.idATM)
                .Index(t => t.idATM);
            
            CreateTable(
                "dbo.RanuraDeposito",
                c => new
                    {
                        idRanuraDeposito = c.Int(nullable: false, identity: true),
                        MarcaRanura = c.String(),
                        idATM = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idRanuraDeposito)
                .ForeignKey("dbo.ATM", t => t.idATM)
                .Index(t => t.idATM);
            
            CreateTable(
                "dbo.Teclado",
                c => new
                    {
                        idTeclado = c.Int(nullable: false, identity: true),
                        MarcaTeclado = c.String(),
                        idATM = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idTeclado)
                .ForeignKey("dbo.ATM", t => t.idATM)
                .Index(t => t.idATM);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teclado", "idATM", "dbo.ATM");
            DropForeignKey("dbo.RanuraDeposito", "idATM", "dbo.ATM");
            DropForeignKey("dbo.Pantalla", "idATM", "dbo.ATM");
            DropForeignKey("dbo.DispensadorEfectivo", "idATM", "dbo.ATM");
            DropForeignKey("dbo.ATM", "idBaseDatos", "dbo.BaseDatos");
            DropForeignKey("dbo.Retiro", "BaseDatos_idBaseDatos", "dbo.BaseDatos");
            DropForeignKey("dbo.Retiro", "idCuenta", "dbo.Cuenta");
            DropForeignKey("dbo.Retiro", "idATM", "dbo.ATM");
            DropForeignKey("dbo.Cuenta", "idBaseDatos", "dbo.BaseDatos");
            DropIndex("dbo.Teclado", new[] { "idATM" });
            DropIndex("dbo.RanuraDeposito", new[] { "idATM" });
            DropIndex("dbo.Pantalla", new[] { "idATM" });
            DropIndex("dbo.DispensadorEfectivo", new[] { "idATM" });
            DropIndex("dbo.Retiro", new[] { "BaseDatos_idBaseDatos" });
            DropIndex("dbo.Retiro", new[] { "idCuenta" });
            DropIndex("dbo.Retiro", new[] { "idATM" });
            DropIndex("dbo.Cuenta", new[] { "idBaseDatos" });
            DropIndex("dbo.ATM", new[] { "idBaseDatos" });
            DropTable("dbo.Teclado");
            DropTable("dbo.RanuraDeposito");
            DropTable("dbo.Pantalla");
            DropTable("dbo.DispensadorEfectivo");
            DropTable("dbo.Retiro");
            DropTable("dbo.Cuenta");
            DropTable("dbo.BaseDatos");
            DropTable("dbo.ATM");
        }
    }
}
