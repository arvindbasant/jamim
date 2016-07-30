using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Com.Jamim.Infrastructure.Domain;

namespace Com.Jamim.Model.Locations
{
    public interface IServiceAreaRepository : IReadOnlyRepository<ServiceArea, int>
    {
    }
}
