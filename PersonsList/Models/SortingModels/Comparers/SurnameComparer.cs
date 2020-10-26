namespace PersonsList.Models.SortingModels.Comparers
{
    public class SurnameComparer : ISortComparer<PersonDto>
    {
        public SortOrder Order { get; set; } = SortOrder.Ascending;

        public int Compare(PersonDto x, PersonDto y)
        {
            if (Order == SortOrder.Ascending)
                return x.Surname.CompareTo(y.Surname);
            else
                return y.Surname.CompareTo(x.Surname);
        }
    }
}
