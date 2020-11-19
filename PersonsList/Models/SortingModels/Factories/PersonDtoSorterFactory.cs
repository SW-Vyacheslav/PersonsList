using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsList.Models.SortingModels.Factories
{
    public class PersonDtoSorterFactory : SorterFactory<PersonDto>
    {
        public static readonly List<string> SortFields;

        public static readonly List<string> SortMethods;

        static PersonDtoSorterFactory()
        {
            SortFields = new List<string>()
            {
                "Name",
                "Surname",
                "Middlename",
                "Email",
                "Age"
            };

            SortMethods = new List<string>()
            {
                "BubbleSort",
                "ShakerSort",
                "InsertionSort",
                "SelectionSort",
                "MergeSort"
            };
        }

        private string _sortMethod { get; set; }

        private string _sortField { get; set; }

        private SortOrder _sortOrder { get; set; }

        public PersonDtoSorterFactory(string sortMethod = null, string sortField = null, SortOrder? sortOrder = null)
        {
            _sortMethod = sortMethod ?? SortMethods[0];
            _sortField = sortField ?? SortFields[0];
            _sortOrder = sortOrder ?? SortOrder.Ascending;

            if (!SortMethods.Contains(_sortMethod))
                _sortMethod = SortMethods[0];

            if (!SortFields.Contains(_sortField))
                _sortField = SortFields[0];
        }

        public override ISorter<PersonDto> CreateSorter()
        {
            dynamic sorter = null;
            dynamic comparer = null;

            Type sorterType = typeof(ISorter<PersonDto>);
            List<Type> sorters = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => sorterType.IsAssignableFrom(t))
                .ToList();

            Type comparerType = typeof(ISortComparer<PersonDto>);
            List<Type> comparers = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => comparerType.IsAssignableFrom(t))
                .ToList();

            foreach (Type item in comparers)
            {
                if (item.Name.Contains(_sortField))
                {
                    comparer = Activator.CreateInstance(item);
                    comparer.Order = _sortOrder;
                    break;
                }
            }

            foreach (Type item in sorters)
            {
                if (item.Name.Contains(_sortMethod))
                {
                    sorter = Activator.CreateInstance(item, comparer);
                    break;
                }
            }

            return sorter;
        }
    }
}
