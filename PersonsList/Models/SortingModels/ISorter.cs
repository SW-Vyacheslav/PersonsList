using System.Collections.Generic;

namespace PersonsList.Models.SortingModels
{
    public enum SortOrder
    {
        Ascending,
        Descending
    }

    public interface ISorter<T>
    {
        ISortComparer<T> Comparer { get; set; }

        ICollection<T> Sort(ICollection<T> collection);
    }
}
