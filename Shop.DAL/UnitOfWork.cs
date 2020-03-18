using Shop.DAL;
using ShopDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopDAL
{
    public class UnitOfWork : IDisposable
    {
        private CarDBContext context = new CarDBContext();
        private GenericRepository<Car> carRepository;

        private bool disposed = false;

        public GenericRepository<Car> CarRepository
        {
            get
            {
                if (this.carRepository == null)
                    this.carRepository = new GenericRepository<Car>(this.context);

                return this.carRepository;
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    this.context.Dispose();

            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}