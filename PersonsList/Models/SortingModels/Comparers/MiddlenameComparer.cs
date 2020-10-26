namespace PersonsList.Models.SortingModels.Comparers
{
    public class MiddlenameComparer : ISortComparer<PersonDto>
    {
        public SortOrder Order { get; set; } = SortOrder.Ascending;

        public int Compare(PersonDto x, PersonDto y)
        {
            if (Order == SortOrder.Ascending)
                return string.Compare(x.Middlename, y.Middlename);
            else
                return string.Compare(y.Middlename, x.Middlename);
        }
    }
}
