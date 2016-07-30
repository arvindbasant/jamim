
using Com.Jamim.Infrastructure.Domain;

namespace Com.Jamim.Model.Abstract
{
    public interface IUnitOfWorkRepository
    {
        IProductRepository ProductRepository { get; }   
    }
}
