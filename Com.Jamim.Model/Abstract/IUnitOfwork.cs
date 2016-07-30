using Com.Jamim.Infrastructure.Domain;

namespace Com.Jamim.Model.Abstract
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUnitOfwork : IUnitOfWorkRepository
    {
        void Dispose();
        void Save(); 
    }
}
