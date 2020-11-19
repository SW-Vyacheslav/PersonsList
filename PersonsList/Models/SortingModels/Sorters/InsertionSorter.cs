using System.Collections.Generic;

namespace PersonsList.Models.SortingModels.Sorters
{
    public class InsertionSorter : ISorter<PersonDto>
    {
        public ISortComparer<PersonDto> Comparer { get; set; }

        public InsertionSorter(ISortComparer<PersonDto> comparer)
        {
            Comparer = comparer;
        }

        public ICollection<PersonDto> Sort(ICollection<PersonDto> collection)
        {
            List<PersonDto> sortedList = new List<PersonDto>(collection);

            for (int i = 1; i < sortedList.Count; ++i)
            {
                PersonDto x = sortedList[i];
                int j = i;
                while (j > 0 && (Comparer.Compare(sortedList[j - 1], x) == 1))
                {
                    sortedList[j] = sortedList[j - 1];
                    --j;
                }
                sortedList[j] = x;
            }

            return sortedList;
        }
    }
}
