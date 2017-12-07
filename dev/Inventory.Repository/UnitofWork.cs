using Accounts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository
{
    public class UnitOfWork : IDisposable
    {
        private AccountsContext context = new AccountsContext();
        private GenericRepository<RawMaterials> rawMaterialRepository;
        //  private GenericRepository<User> userRepository;
        //  private GenericRepository<UserCar> userCarRepository;


        public GenericRepository<RawMaterials> RawMaterialRepository
        {
            get
            {
                return this.rawMaterialRepository ?? new GenericRepository<RawMaterials>(context);
            }
        }

        //public GenericRepository<Car> CarRepository
        //{
        //    get
        //    {
        //        return this.carRepository ?? new GenericRepository<Car>(context);
        //    }
        //}


        //public GenericRepository<User> UserRepository
        //{
        //    get
        //    {
        //        return this.userRepository ?? new GenericRepository<User>(context);
        //    }
        //}

        //public GenericRepository<UserCar> UserCarRepository
        //{
        //    get
        //    {
        //        return this.userCarRepository ?? new GenericRepository<UserCar>(context);
        //    }
        //}


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
