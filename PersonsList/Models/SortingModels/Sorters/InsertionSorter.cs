using System;
using System.Collections.Generic;

namespace PersonsList.Models.SortingModels.Sorters
{
    public class InsertionSorter : ISorter<PersonDto>
    {
        public ISortComparer<PersonDto> Comparer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public InsertionSorter(ISortComparer<PersonDto> comparer)
        {
            Comparer = comparer;
        }

        public ICollection<PersonDto> Sort(ICollection<PersonDto> collection)
        {
            throw new NotImplementedException();
        }
    }
}
