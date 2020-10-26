namespace PersonsList.Models.SortingModels.Comparers
{
    public class EmailComparer : ISortComparer<PersonDto>
    {
        public SortOrder Order { get; set; } = SortOrder.Ascending;

        public int Compare(PersonDto x, PersonDto y)
        {
            if (Order == SortOrder.Ascending)
                return x.Email.CompareTo(y.Email);
            else
                return y.Email.CompareTo(x.Email);
        }
    }
}
