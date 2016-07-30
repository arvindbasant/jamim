using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.Jamim.Infrastructure.Domain;
using Com.Jamim.Model.Entities;
using Com.Jamim.Model.Products;

namespace Com.Jamim.Model.Abstract
{
    public interface IProductRepository : IRepository<Product, int> { }
}
