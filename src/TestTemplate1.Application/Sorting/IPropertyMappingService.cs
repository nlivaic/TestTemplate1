using System.Collections.Generic;
using TestTemplate1.Application.Sorting.Models;

namespace TestTemplate1.Application.Sorting
{
    public interface IPropertyMappingService
    {
        IEnumerable<SortCriteria> Resolve(BaseSortable sortableSource, BaseSortable sortableTarget);
    }
}
