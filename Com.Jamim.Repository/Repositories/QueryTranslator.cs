using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Com.Jamim.Infrastructure.Querying;

namespace Com.Jamim.Repository.Repositories
{
    public static class QueryTranslator
    {
        public static string Translate(Query query)
        {
            string rule = string.Empty;

            if (query.Criteria.Count == 0 && query.SubQuery.Count == 0)
                return null;
            if (query.Criteria.Count > 0)
            {
                rule = CreateCriteria(query.Criteria);
            }
            foreach (Query subquery in query.SubQuery)
            {
                if (subquery.QueryOperator == QueryOperator.Or)
                    rule = rule.Or(CreateCriteria(subquery.Criteria));
                else
                    rule = rule.And(CreateCriteria(subquery.Criteria));
            }
            return rule;

        }

        private static string CreateCriteria(IList<Criterion> criterias)
        {
            if (criterias.Count == 0)
                return null;

            string exp = string.Empty;

            if (criterias.Count == 1)
                exp = CreateCriteria(criterias[0]);
            else if (criterias.Count == 2)
                exp = CreateCriteria(criterias[0], criterias[1]);
            else
            {
                while (criterias.Count > 0)
                {
                    var f1 = criterias[0];
                    var f2 = criterias[1];

                    if (exp == null)
                        exp = CreateCriteria(criterias[0], criterias[1]);
                    else
                    {
                        if (criterias[0].ConditionOperator == ConditionOperator.Or)
                            exp = string.Format(" {0} OR {1} ", criterias[0], criterias[1]);
                        else
                            exp = string.Format(" {0} AND {1} ", criterias[0], criterias[1]);
                    }
                    criterias.Remove(f1);
                    criterias.Remove(f2);

                    if (criterias.Count == 1)
                    {
                        if (criterias[0].ConditionOperator == ConditionOperator.Or)
                            exp = string.Format(" OR {0} ", criterias[0]);
                        else
                            exp = string.Format(" AND {0} ", criterias[0]);
                        criterias.RemoveAt(0);
                    }
                }
            }

            return exp;
        }

        private static string CreateCriteria(Criterion criteria)
        {
            string member = criteria.PropertyName;
            string constant = criteria.Value.ToString();

            switch (criteria.CriteriaOperator)
            {
                case CriteriaOperator.Equal:
                    return string.Format("{0} = {1} ", member, constant);

                case CriteriaOperator.GreaterThan:
                    return string.Format("{0} > {1} ", member, constant);

                case CriteriaOperator.GreaterThanOrEqual:
                    return string.Format("{0} >= {1} ", member, constant);

                case CriteriaOperator.LessThan:
                    return string.Format("{0} < {1} ", member, constant);

                case CriteriaOperator.LessThanOrEqual:
                    return string.Format("{0} <= {1} ", member, constant);

                case CriteriaOperator.Contains:
                    return string.Format("{0} LIKE %{1}% ", member, constant);

                case CriteriaOperator.StartsWith:
                    return string.Format("{0} LIKE {1}% ", member, constant);

                case CriteriaOperator.EndsWith:
                    return string.Format("{0} LIKE %{1} ", member, constant);
            }

            return null;
        }

        private static string CreateCriteria(Criterion c1, Criterion c2)
        {
            string bin1 = CreateCriteria(c1);
            string bin2 = CreateCriteria(c2);
            if (c2.ConditionOperator == ConditionOperator.Or)
                return string.Format(" {0} OR {1} ", bin1, bin2);
            return string.Format(" {0} AND {1} ", bin1, bin2);
        }

        private static string And(this string left, string right)
        {
            return string.Format(" {0} AND ({1})", left, right);
        }

        private static string Or(this string left, string right)
        {
            return string.Format(" {0} OR ({1})", left, right); ;
        }
    }
}
