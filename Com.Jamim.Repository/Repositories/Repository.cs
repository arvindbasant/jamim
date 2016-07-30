using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.Jamim.Infrastructure.Domain;
using Com.Jamim.Infrastructure.UnitOfWork;
using Com.Jamim.Infrastructure.Querying;
using System.Linq.Dynamic;

namespace Com.Jamim.Repository.Repositories
{
    public abstract class Repository<T, EntityKey> : IUnitOfWorkRepository where T : IAggregateRoot
    {
        private IUnitOfWork _uow;
       
        public Repository(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public void Add(T entity)
        {
            _uow.RegisterNew(entity, this);
        }

        public void Remove(T entity)
        {
            _uow.RegisterRemoved(entity, this);
        }

        public void Save(T entity)
        {
            // Do nothing as EF tracks changes
        }

        public abstract IQueryable<T> GetDbSet();
        public abstract string GetEntitySetName();
        public abstract T FindBy(EntityKey Id);
   
        public IEnumerable<T> FindAll()
        {
            return GetDbSet().ToList<T>();
        }

        public IEnumerable<T> FindAll(int index, int count)
        {
            return GetDbSet().Skip(index).Take(count).ToList<T>();
        }

        public IEnumerable<T> FindBy(Query query)
        {
            if (ContainsReferenceProperties(query))
            {
                string exp = QueryTranslator.Translate(query);
                return GetDbSet().Where(exp).ToList<T>().AsQueryable();
            }
            else
            {
                var exp = ExpressionBuilder.CreateExpression<T>(query);
                return GetDbSet().Where(exp).ToList<T>().AsQueryable();
            }
        }

        private bool ContainsReferenceProperties(Query query)
        {
            foreach (Criterion c in query.Criteria)
            {
                if (c.PropertyName.Contains('.'))
                    return true;
            }
            foreach (Query q in query.SubQuery)
            {
                foreach (Criterion c in q.Criteria)
                {
                    if (c.PropertyName.Contains('.'))
                        return true;
                }
            }
            return false;
        }


        public IEnumerable<T> FindBy(Query query, int index, int count)
        {
            var deleg = ExpressionBuilder.CreateExpression<T>(query).Compile();
            return GetDbSet().Where(deleg).Skip(index).Take(count).ToList<T>();
        }

        public void PersistCreationOf(IAggregateRoot entity)
        {
            DataContextFactory.GetDataContext().Set<IAggregateRoot>().Add(entity);
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            DataContextFactory.GetDataContext().Set<IAggregateRoot>().Remove(entity);
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            // Do nothing as EF tracks changes
        }
    }
}
