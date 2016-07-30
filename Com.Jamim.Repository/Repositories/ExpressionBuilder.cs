using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

using Com.Jamim.Infrastructure.Querying;
using System.Reflection;

namespace Com.Jamim.Repository.Repositories
{
    public static class ExpressionBuilder
    {
        private static MethodInfo containsMethod = typeof(string).GetMethod("Contains");
        private static MethodInfo startsWithMethod =
        typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
        private static MethodInfo endsWithMethod =
        typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });

        public static Expression<Func<T, bool>> CreateExpression<T>(Query query)
        {
            var rule = Begin<T>();

            if (query.Criteria.Count == 0 && query.SubQuery.Count == 0)
                return null;
            if (query.Criteria.Count > 0)
            {
                rule = GetExpression<T>(query.Criteria);
            }
            foreach (Query subquery in query.SubQuery)
            {
                if (subquery.QueryOperator == QueryOperator.Or)
                    rule = rule.Or(GetExpression<T>(subquery.Criteria));
                else
                    rule = rule.And(GetExpression<T>(subquery.Criteria));
            }
            return rule;
        }

        private static Expression<Func<T, bool>>
            GetExpression<T>(IList<Criterion> criterias)
        {
            if (criterias.Count == 0)
                return null;

            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            Expression exp = null;

            if (criterias.Count == 1)
                exp = GetExpression<T>(param, criterias[0]);
            else if (criterias.Count == 2)
                exp = GetExpression<T>(param, criterias[0], criterias[1]);
            else
            {
                while (criterias.Count > 0)
                {
                    var f1 = criterias[0];
                    var f2 = criterias[1];

                    if (exp == null)
                        exp = GetExpression<T>(param, criterias[0], criterias[1]);
                    else
                    {
                        if (criterias[0].ConditionOperator == ConditionOperator.Or)
                            exp = Expression.OrElse(exp, GetExpression<T>(param, criterias[0], criterias[1]));
                        else
                            exp = Expression.AndAlso(exp, GetExpression<T>(param, criterias[0], criterias[1]));
                    }
                    criterias.Remove(f1);
                    criterias.Remove(f2);

                    if (criterias.Count == 1)
                    {
                        if (criterias[0].ConditionOperator == ConditionOperator.Or)
                            exp = Expression.OrElse(exp, GetExpression<T>(param, criterias[0]));
                        else
                            exp = Expression.AndAlso(exp, GetExpression<T>(param, criterias[0]));
                        criterias.RemoveAt(0);
                    }
                }
            }

            return Expression.Lambda<Func<T, bool>>(exp, param);
        }

        private static Expression GetExpression<T>(ParameterExpression param, Criterion criteria)
        {
            MemberExpression member = Expression.Property(param, criteria.PropertyName);
            ConstantExpression constant = Expression.Constant(criteria.Value);

            switch (criteria.CriteriaOperator)
            {
                case CriteriaOperator.Equal:
                    return Expression.Equal(member, constant);

                case CriteriaOperator.GreaterThan:
                    return Expression.GreaterThan(member, constant);

                case CriteriaOperator.GreaterThanOrEqual:
                    return Expression.GreaterThanOrEqual(member, constant);

                case CriteriaOperator.LessThan:
                    return Expression.LessThan(member, constant);

                case CriteriaOperator.LessThanOrEqual:
                    return Expression.LessThanOrEqual(member, constant);

                case CriteriaOperator.Contains:
                    return Expression.Call(member, containsMethod, constant);

                case CriteriaOperator.StartsWith:
                    return Expression.Call(member, startsWithMethod, constant);

                case CriteriaOperator.EndsWith:
                    return Expression.Call(member, endsWithMethod, constant);
            }

            return null;
        }

        private static BinaryExpression GetExpression<T>
        (ParameterExpression param, Criterion c1, Criterion c2)
        {
            Expression bin1 = GetExpression<T>(param, c1);
            Expression bin2 = GetExpression<T>(param, c2);
            if (c2.ConditionOperator == ConditionOperator.Or)
                return Expression.OrElse(bin1, bin2);
            return Expression.AndAlso(bin1, bin2);
        }

        private static Expression<Func<T, bool>> Begin<T>(bool value = false)
        {
            if (value)
                return parameter => true; //value cannot be used in place of true/false

            return parameter => false;
        }

        private static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right)
        {
            return CombineLambdas(left, right, ExpressionType.AndAlso);
        }

        private static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right)
        {
            return CombineLambdas(left, right, ExpressionType.OrElse);
        }

        private static Expression<Func<T, bool>> CombineLambdas<T>(this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right, ExpressionType expressionType)
        {
            //Remove expressions created with Begin<T>()
            if (IsExpressionBodyConstant(left))
                return (right);

            ParameterExpression p = left.Parameters[0];

            SubstituteParameterVisitor visitor = new SubstituteParameterVisitor();
            visitor.Sub[right.Parameters[0]] = p;

            Expression body = Expression.MakeBinary(expressionType, left.Body, visitor.Visit(right.Body));
            return Expression.Lambda<Func<T, bool>>(body, p);
        }

        private static bool IsExpressionBodyConstant<T>(Expression<Func<T, bool>> left)
        {
            return left.Body.NodeType == ExpressionType.Constant;
        }

        internal class SubstituteParameterVisitor : ExpressionVisitor
        {
            public Dictionary<Expression, Expression> Sub = new Dictionary<Expression, Expression>();

            protected override Expression VisitParameter(ParameterExpression node)
            {
                Expression newValue;
                if (Sub.TryGetValue(node, out newValue))
                {
                    return newValue;
                }
                return node;
            }
        }

    }

}


