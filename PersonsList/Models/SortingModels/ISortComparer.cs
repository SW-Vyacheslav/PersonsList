using System.Collections.Generic;

namespace PersonsList.Models.SortingModels
{
    public interface ISortComparer<T> : IComparer<T>
    {
        SortOrder Order { get; set; }
    }
}
