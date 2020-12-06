using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PersonsList.Test.Models;
using PersonsList.Models.SortingModels.Comparers;
using PersonsList.Models.SortingModels;
using PersonsList.Models;
using System.Linq;

namespace PersonsList.Test
{
    [TestClass]
    public class ShakerSorterTest
    {
        [TestMethod]
        public void Scenario1()
        {
            List<PersonDto> people = new List<PersonDto>();
            TestShakerSorter sorter = new TestShakerSorter(new AgeComparer() { Order = SortOrder.Ascending });

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
            TestShakerSorter sorter = new TestShakerSorter(new AgeComparer() { Order = SortOrder.Ascending })
            {
                Left = 2,
                Right = 1
            };

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
                new PersonDto() { Age = 2 },
                new PersonDto() { Age = 5 }
            };
            TestShakerSorter sorter = new TestShakerSorter(new AgeComparer() { Order = SortOrder.Ascending })
            {
                Left = 0,
                Right = 0
            };

            var expected = new List<PersonDto>()
            {
                new PersonDto() { Age = 2 },
                new PersonDto() { Age = 5 }
            };
            var actual = sorter.Sort(people).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scenario4()
        {
            List<PersonDto> people = new List<PersonDto>()
            {
                new PersonDto() { Age = 2 },
                new PersonDto() { Age = 5 }
            };
            TestShakerSorter sorter = new TestShakerSorter(new AgeComparer() { Order = SortOrder.Ascending })
            {
                Left = 0,
                Right = people.Count - 1
            };

            var expected = new List<PersonDto>()
            {
                new PersonDto() { Age = 2 },
                new PersonDto() { Age = 5 }
            };
            var actual = sorter.Sort(people).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scenario5()
        {
            List<PersonDto> people = new List<PersonDto>()
            {
                new PersonDto() { Age = 5 },
                new PersonDto() { Age = 2 }
            };
            TestShakerSorter sorter = new TestShakerSorter(new AgeComparer() { Order = SortOrder.Ascending })
            {
                Left = 0,
                Right = people.Count - 1
            };

            var expected = new List<PersonDto>()
            {
                new PersonDto() { Age = 2 },
                new PersonDto() { Age = 5 }
            };
            var actual = sorter.Sort(people).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scenario6()
        {
            List<PersonDto> people = new List<PersonDto>()
            {
                new PersonDto() { Age = 1 },
                new PersonDto() { Age = 2 },
                new PersonDto() { Age = 5 }
            };
            TestShakerSorter sorter = new TestShakerSorter(new AgeComparer() { Order = SortOrder.Ascending })
            {
                Left = 0,
                Right = people.Count - 1,
                IsSkipFirstLoop = true
            };

            var expected = new List<PersonDto>()
            {
                new PersonDto() { Age = 1 },
                new PersonDto() { Age = 2 },
                new PersonDto() { Age = 5 }
            };
            var actual = sorter.Sort(people).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scenario7()
        {
            List<PersonDto> people = new List<PersonDto>()
            {
                new PersonDto() { Age = 1 },
                new PersonDto() { Age = 5 },
                new PersonDto() { Age = 2 }
            };
            TestShakerSorter sorter = new TestShakerSorter(new AgeComparer() { Order = SortOrder.Ascending })
            {
                Left = 0,
                Right = people.Count - 1,
                IsSkipFirstLoop = true
            };

            var expected = new List<PersonDto>()
            {
                new PersonDto() { Age = 1 },
                new PersonDto() { Age = 2 },
                new PersonDto() { Age = 5 }
            };
            var actual = sorter.Sort(people).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
