using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Infrastructure.Domain;

namespace Com.Jamim.Model.Products
{
    public interface IProductRepository : IRepository<Product, int> 
    {
        IQueryable<Product> GetProductByRetailerId(int id);
    }
}
