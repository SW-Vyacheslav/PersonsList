namespace PersonsList.Models.SortingModels.Comparers
{
    public class NameComparer : ISortComparer<PersonDto>
    {
        public SortOrder Order { get; set; } = SortOrder.Ascending;

        public int Compare(PersonDto x, PersonDto y)
        {
            if (Order == SortOrder.Ascending)
                return x.Name.CompareTo(y.Name);
            else
                return y.Name.CompareTo(x.Name);
        }
    }
}
