using PersonsList.Models.Extensions;
using System.Collections.Generic;

namespace PersonsList.Models.SortingModels.Sorters
{
    public class SelectionSorter : ISorter<PersonDto>
    {
        public ISortComparer<PersonDto> Comparer { get; set; }

        public SelectionSorter(ISortComparer<PersonDto> comparer)
        {
            Comparer = comparer;
        }

        public ICollection<PersonDto> Sort(ICollection<PersonDto> collection)
        {
            List<PersonDto> sortedList = new List<PersonDto>(collection);

            for (int i = 0; i < sortedList.Count - 1; i++)
            {
                int lower = i;
                for (int j = i + 1; j < sortedList.Count; j++)
                {
                    if (Comparer.Compare(sortedList[lower], sortedList[j]) == 1)
                    {
                        lower = j;
                    }
                }
                sortedList.Swap(lower, i);
            }

            return sortedList;
        }
    }
}
