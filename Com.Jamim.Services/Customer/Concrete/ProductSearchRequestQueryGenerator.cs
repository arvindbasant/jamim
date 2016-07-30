using System;
using System.Collections.Generic;
using System.Linq;
using Com.Jamim.Model.Catalog;
using Com.Jamim.Infrastructure.Querying;
using Com.Jamim.Services.Customer.Messaging.ProductCatalogService;

namespace Com.Jamim.Services.Customer.Concrete
{
    public class ProductSearchRequestQueryGenerator
    {
        public static Query CreateQueryFor(GetProductByCategoryRequest request)
        {
            Query productQuery = new Query();
            Query weightQuery = new Query();
            Query manufacturerQuery = new Query();

            productQuery.Add(Criterion.Create<Catalog>(p => p.RetailerId, request.RetailerId, CriteriaOperator.Equal));
            productQuery.Add(Criterion.Create<Catalog>(p => p.Product.Category.Id, request.CategoryId, CriteriaOperator.Equal, ConditionOperator.And));

            weightQuery.QueryOperator = QueryOperator.And;
            foreach (int id in request.WeightIds)
                weightQuery.Add(Criterion.Create<Catalog>(p => p.Product.Weight.Id, id, CriteriaOperator.Equal, ConditionOperator.Or));

            manufacturerQuery.QueryOperator = QueryOperator.And;
            foreach (int id in request.ManufacturerIds)
                manufacturerQuery.Add(Criterion.Create<Catalog>(p => p.Product.Manufacturer.Id, id, CriteriaOperator.Equal, ConditionOperator.Or));

            if (request.WeightIds.Count() > 0)
                productQuery.AddSubQuery(weightQuery);

            if (request.ManufacturerIds.Count() > 0)
                productQuery.AddSubQuery(manufacturerQuery);

            return productQuery;

        }
    }
}
