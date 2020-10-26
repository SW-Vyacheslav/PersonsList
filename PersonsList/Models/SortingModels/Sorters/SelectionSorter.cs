using System;
using System.Collections.Generic;

namespace PersonsList.Models.SortingModels.Sorters
{
    public class SelectionSorter : ISorter<PersonDto>
    {
        public ISortComparer<PersonDto> Comparer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public SelectionSorter(ISortComparer<PersonDto> comparer)
        {
            Comparer = comparer;
        }

        public ICollection<PersonDto> Sort(ICollection<PersonDto> collection)
        {
            throw new NotImplementedException();
        }
    }
}
