using PersonsList.Models.Extensions;
using System.Collections.Generic;

namespace PersonsList.Models.SortingModels.Sorters
{
    public class ShakerSorter : ISorter<PersonDto>
    {
        public ISortComparer<PersonDto> Comparer { get; set; }

        public ShakerSorter(ISortComparer<PersonDto> comparer)
        {
            Comparer = comparer;
        }

        public ICollection<PersonDto> Sort(ICollection<PersonDto> collection)
        {
            List<PersonDto> sortedList = new List<PersonDto>(collection);

            if (sortedList.Count != 0)
            {
                int left = 0;
                int right = sortedList.Count - 1;
                while (left <= right)
                {
                    for (int i = right; i > left; --i)
                    {
                        if (Comparer.Compare(sortedList[i - 1], sortedList[i]) == 1)
                        {
                            sortedList.Swap(i - 1, i);
                        }
                    }
                    ++left;
                    for (int i = left; i < right; ++i)
                    {
                        if (Comparer.Compare(sortedList[i], sortedList[i + 1]) == 1)
                        {
                            sortedList.Swap(i, i + 1);
                        }
                    }
                    --right;
                }
            }

            return sortedList;
        }
    }
}
