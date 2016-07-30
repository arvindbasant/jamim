using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Jamim.Services.Customer.ViewModels;
using Com.Jamim.Model.Products;
using AutoMapper;

namespace Com.Jamim.Services.Customer.Mapping
{
    public static class IProductAttributeMapper
    {
        public static RefinementGroup convertToRefinementGroup(
            this IEnumerable<IProductAttribute> productAttributes,RefinementGroupings refinementGoupType)           
        {
            RefinementGroup refinementGroup = new RefinementGroup()
            {
                Name = refinementGoupType.ToString(),
                GroupId = (int)refinementGoupType
            };
            refinementGroup.Refinements =
                Mapper.Map<IEnumerable<IProductAttribute>, IEnumerable<Refinement>>(productAttributes);

            return refinementGroup;
        }
    }
}
