using PersonsList.Models;
using PersonsList.Models.SortingModels;
using System.Collections.Generic;

namespace PersonsList.Test.Models
{
    public class TestBubbleSort : ISorter<PersonDto>
    {
        public ISortComparer<PersonDto> Comparer { get; set; }

        public TestBubbleSort(ISortComparer<PersonDto> comparer)
        {
            Comparer = comparer;
        }

        public int J { get; set; }

        public ICollection<PersonDto> Sort(ICollection<PersonDto> collection)
        {
            List<PersonDto> sortedList = new List<PersonDto>(collection);

            for (int i = 0; i < sortedList.Count - 1; i++)
            {
                for (; J < sortedList.Count - 1 - i; J++)
                {
                    if (Comparer.Compare(sortedList[J], sortedList[J + 1]) == 1)
                    {
                        PersonDto temp = sortedList[J];
                        sortedList[J] = sortedList[J + 1];
                        sortedList[J + 1] = temp;
                    }
                }
            }

            return sortedList;
        }
    }
}
