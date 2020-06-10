using Exam.Entity;
using Exam.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam
{
    public class UnitOfWork : IDisposable
    {
        private readonly Context _context;
        private GenericRepository<Product> _productRepository;
        private GenericRepository<Storage> _storageRepository;

        public UnitOfWork(Context context)
        {
            this._context = context;
        }

        public GenericRepository<Product> ProductRepository
        {
            get
            {

                if (this._productRepository == null)
                {
                    this._productRepository = new GenericRepository<Product>(_context);
                }
                return _productRepository;
            }
        }
        public GenericRepository<Storage> StorageRepository
        {
            get
            {

                if (this._storageRepository == null)
                {
                    this._storageRepository = new GenericRepository<Storage>(_context);
                }
                return _storageRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
