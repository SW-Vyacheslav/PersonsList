using PersonsList.Models;
using PersonsList.Models.Extensions;
using PersonsList.Models.SortingModels;
using System.Collections.Generic;

namespace PersonsList.Test.Models
{
    public class TestSelectionSorter : ISorter<PersonDto>
    {
        public ISortComparer<PersonDto> Comparer { get; set; }

        public TestSelectionSorter(ISortComparer<PersonDto> comparer)
        {
            Comparer = comparer;
        }

        public int J { get; set; }

        public bool IsUseTestJ { get; set; }

        public ICollection<PersonDto> Sort(ICollection<PersonDto> collection)
        {
            List<PersonDto> sortedList = new List<PersonDto>(collection);

            for (int i = 0; i < sortedList.Count - 1; i++)
            {
                int lower = i;
                for (int j = IsUseTestJ ? J : i + 1; j < sortedList.Count; j++)
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
