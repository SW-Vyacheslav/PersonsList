namespace PersonsList.Models.SortingModels
{
    public abstract class SorterFactory<T>
    {
        public abstract ISorter<T> CreateSorter();
    }
}
