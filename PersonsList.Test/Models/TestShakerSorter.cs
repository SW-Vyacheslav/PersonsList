using PersonsList.Models;
using PersonsList.Models.Extensions;
using PersonsList.Models.SortingModels;
using System.Collections.Generic;

namespace PersonsList.Test.Models
{
    public class TestShakerSorter : ISorter<PersonDto>
    {
        public ISortComparer<PersonDto> Comparer { get; set; }

        public TestShakerSorter(ISortComparer<PersonDto> comparer)
        {
            Comparer = comparer;
        }

        public int Left { get; set; }

        public int Right { get; set; }

        public bool IsSkipFirstLoop { get; set; }

        public ICollection<PersonDto> Sort(ICollection<PersonDto> collection)
        {
            List<PersonDto> sortedList = new List<PersonDto>(collection);

            if (sortedList.Count != 0)
            {
                while (Left <= Right)
                {
                    for (int i = Right; (i > Left) && !IsSkipFirstLoop; --i)
                    {
                        if (Comparer.Compare(sortedList[i - 1], sortedList[i]) == 1)
                        {
                            sortedList.Swap(i - 1, i);
                        }
                    }
                    ++Left;
                    for (int i = Left; i < Right; ++i)
                    {
                        if (Comparer.Compare(sortedList[i], sortedList[i + 1]) == 1)
                        {
                            sortedList.Swap(i, i + 1);
                        }
                    }
                    --Right;
                }
            }

            return sortedList;
        }
    }
}
