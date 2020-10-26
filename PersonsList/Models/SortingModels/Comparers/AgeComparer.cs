using System;

namespace PersonsList.Models.SortingModels.Comparers
{
    public class AgeComparer : ISortComparer<PersonDto>
    {
        public SortOrder Order { get; set; } = SortOrder.Ascending;

        public int Compare(PersonDto x, PersonDto y)
        {
            if (Order == SortOrder.Ascending)
                return Nullable.Compare(x.Age, y.Age);
            else
                return Nullable.Compare(y.Age, x.Age);
        }
    }
}
