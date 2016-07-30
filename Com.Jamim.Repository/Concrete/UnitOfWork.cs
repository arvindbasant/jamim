using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.Jamim.Model.Abstract;


namespace Com.Jamim.Repository
{
    public class UnitOfWork : IUnitOfwork, IDisposable
    {
        private JamimDataContext _context = new JamimDataContext();
        private ProductRepository _productRepository;
        private bool _disposed = false;

        public IProductRepository ProductRepository
        {
            get
            {
                if (this._productRepository == null)
                {
                    this._productRepository = new ProductRepository(_context);
                }
                return _productRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }


    }

    public class test
    {
        private readonly IUnitOfwork _uow;

        public test(IUnitOfwork uow)
        {
            this._uow = uow;
        }

        void tee()
        {
           //_uow.ProductRepository.Get()
        }
    }



}
