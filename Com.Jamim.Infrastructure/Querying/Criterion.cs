using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Com.Jamim.Infrastructure.Querying
{
    public class Criterion
    {
        private string _propertyName;
        private object _value;
        private CriteriaOperator _criteriaOperator;
        private ConditionOperator _conditionOperator;

        public Criterion(
            string propertyName,
            object value,
            CriteriaOperator criteriaOperator,
            ConditionOperator conditionOperator)
        {
            this._propertyName = propertyName;
            this._value = value;
            this._criteriaOperator = criteriaOperator;
            this._conditionOperator = conditionOperator;
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public object Value
        {
            get { return _value; }
        }

        public CriteriaOperator CriteriaOperator
        {
            get { return _criteriaOperator; }
        }

        public ConditionOperator ConditionOperator
        {
            get { return _conditionOperator; }
        }

        public static Criterion Create<T>(
            Expression<Func<T, object>> expression,
            object value,
            CriteriaOperator criteriaOperator,
            ConditionOperator conditionOperator = ConditionOperator.NotApplicable)
        {
            string propertyName = PropertyNameHelper.ResolvePropertyName<T>(expression);
            Criterion myCriterion = new Criterion(propertyName, value, criteriaOperator, conditionOperator);
            return myCriterion;
        }



        //public static TEntity Get<TEntity>(String propertyToUse, Object valueToCompare, IQueryable<TEntity> lstData)
        //{
        //    ParameterExpression pe = Expression.Parameter(typeof(TEntity), "x");

        //    var propToUse = Expression.Property(pe, propertyToUse);

        //    var constToUse = Expression.Constant(valueToCompare);

        //    var qry = Expression.Equal(propToUse, constToUse);

        //    MethodCallExpression whereCallExp = Expression.Call(
        //        typeof(Queryable),
        //        "where",
        //        new Type[] { lstData.ElementType },
        //        lstData.Expression,
        //        Expression.Lambda<Func<TEntity, bool>>(qry, new ParameterExpression[] { pe }));

        //    return lstData.Provider.CreateQuery<TEntity>(whereCallExp).FirstOrDefault();

        //}

    }
}
