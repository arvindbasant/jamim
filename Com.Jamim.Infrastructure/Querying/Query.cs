using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Jamim.Infrastructure.Querying
{
    public class Query
    {
        private QueryName _queryName;
        private List<Criterion> _criteria;
        private List<Query> _subQuery;

        public Query()
            : this(QueryName.Dynamic, new List<Criterion>(), new List<Query>()) { }

        private Query(QueryName queryName, List<Criterion> criteria, List<Query> subQuery)
        {
            this._criteria = criteria;
            this._queryName = queryName;
            this._subQuery = subQuery;
        }

        public QueryName Name
        {
            get { return _queryName; }
        }

        public bool IsNamedQuery()
        {
            return Name != QueryName.Dynamic;
        }

        public List<Criterion> Criteria
        {
            get { return _criteria; }
        }

        public List<Query> SubQuery
        {
            get { return _subQuery; }
        }

        public void Add(Criterion criterion)
        {
            if (!IsNamedQuery())
                _criteria.Add(criterion);
            else
                throw new ApplicationException("You Cannot add additional criteria to named query.");
        }

        public void AddSubQuery(Query query)
        {
            _subQuery.Add(query);
        }

        public QueryOperator QueryOperator { get; set; }
        public OrderByClause OrderByProperty { get; set; }


    }
        
}
