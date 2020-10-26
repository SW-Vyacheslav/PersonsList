using System.Collections.Generic;

namespace PersonsList.Models.SortingModels.Sorters
{
    public class BubbleSorter : ISorter<PersonDto>
    {
        public ISortComparer<PersonDto> Comparer { get; set; }

        public BubbleSorter(ISortComparer<PersonDto> comparer)
        {
            Comparer = comparer;
        }

        public ICollection<PersonDto> Sort(ICollection<PersonDto> collection)
        {
            List<PersonDto> sortedList = new List<PersonDto>(collection);

            for (int i = 0; i < sortedList.Count - 1; i++)
            {
                for (int j = 0; j < sortedList.Count - 1 - i; j++)
                {
                    if (Comparer.Compare(sortedList[j], sortedList[j + 1]) == 1)
                    {
                        PersonDto temp = sortedList[j];
                        sortedList[j] = sortedList[j + 1];
                        sortedList[j + 1] = temp;
                    }
                }
            }

            return sortedList;
        }
    }
}
