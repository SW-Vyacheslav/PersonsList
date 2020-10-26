using System;
using System.Collections.Generic;

namespace PersonsList.Models.SortingModels.Sorters
{
    public class MergeSorter : ISorter<PersonDto>
    {
        public ISortComparer<PersonDto> Comparer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MergeSorter(ISortComparer<PersonDto> comparer)
        {
            Comparer = comparer;
        }

        public ICollection<PersonDto> Sort(ICollection<PersonDto> collection)
        {
            throw new NotImplementedException();
        }
    }
}
