using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonsList.Models;
using PersonsList.Models.SortingModels;
using PersonsList.Models.SortingModels.Comparers;
using PersonsList.Models.SortingModels.Sorters;
using System.Collections.Generic;
using System.Linq;

namespace PersonsList.Test
{
    [TestClass]
    public class InsertionSorterTest
    {
        [TestMethod]
        public void Scenario1()
        {
            List<PersonDto> people = new List<PersonDto>();
            InsertionSorter sorter = new InsertionSorter(new AgeComparer() { Order = SortOrder.Ascending });

            var expected = new List<PersonDto>();
            var actual = sorter.Sort(people).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scenario2()
        {
            List<PersonDto> people = new List<PersonDto>()
            {
                new PersonDto() { Age = 2 },
                new PersonDto() { Age = 5 }
            };
            InsertionSorter sorter = new InsertionSorter(new AgeComparer() { Order = SortOrder.Ascending });

            var expected = new List<PersonDto>()
            {
                new PersonDto() { Age = 2 },
                new PersonDto() { Age = 5 }
            };
            var actual = sorter.Sort(people).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scenario3()
        {
            List<PersonDto> people = new List<PersonDto>()
            {
                new PersonDto() { Age = 5 },
                new PersonDto() { Age = 2 }
            };
            InsertionSorter sorter = new InsertionSorter(new AgeComparer() { Order = SortOrder.Ascending });

            var expected = new List<PersonDto>()
            {
                new PersonDto() { Age = 2 },
                new PersonDto() { Age = 5 }
            };
            var actual = sorter.Sort(people).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
