using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajeroAutomatico.Persistance.Repositories;
using CajeroAutomatico.Entities.IRepository;

namespace CajeroAutomatico.Persistance.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {


        private readonly CajeroDBContext _Context;
        private static UnityOfWork _Instance;
        private static readonly object _Lock = new object();

        public IATMRepository ATM { set; get; }
        public IBaseDatosRepository BaseDatos { set; get; }
        public ICuentaRepository Cuenta { set; get; }
        public IPantallaRepository Pantalla { set; get; }
        public IRanuraDepositoRepository RanuraDeposito { set; get; }
        public IRetiroRepository Retiro { set; get; }
        public ITecladoRepository Teclado { set; get; }

        public UnityOfWork()
        {
            _Context = new CajeroDBContext();

            ATM = new ATMRepository(_Context);
            BaseDatos = new BaseDatosRepository(_Context);
            Cuenta = new CuentaRepository(_Context);
            Pantalla = new PantallaRepository(_Context);
            RanuraDeposito = new RanuraDepositoRepository(_Context);
            Retiro = new RetiroRepository(_Context);
            Teclado = new TecladoRepository(_Context);
        }


        public static UnityOfWork Instance
        {
            get
            {
                lock (_Lock)
                {
                    if (_Instance == null)
                        _Instance = new UnityOfWork();
                }
                return _Instance;
            }
        }

        

        //}
        public void Dispose()
        {
            _Context.Dispose();
        }

        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }

        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }

    }
}
