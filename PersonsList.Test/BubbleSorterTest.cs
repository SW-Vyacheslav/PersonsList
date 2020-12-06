using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonsList.Models;
using PersonsList.Models.SortingModels;
using PersonsList.Models.SortingModels.Comparers;
using PersonsList.Test.Models;
using System.Collections.Generic;
using System.Linq;

namespace PersonsList.Test
{
    [TestClass]
    public class BubbleSorterTest
    {
        [TestMethod]
        public void Scenario1()
        {
            List<PersonDto> people = new List<PersonDto>();
            TestBubbleSort sort = new TestBubbleSort(new AgeComparer() { Order = SortOrder.Ascending });

            var expected = new List<PersonDto>();
            var actual = sort.Sort(people).ToList();

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
            TestBubbleSort sort = new TestBubbleSort(new AgeComparer() { Order = SortOrder.Ascending })
            {
                J = 1
            };

            var expected = new List<PersonDto>()
            {
                new PersonDto() { Age = 2 },
                new PersonDto() { Age = 5 }
            };
            var actual = sort.Sort(people).ToList();

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
            TestBubbleSort sort = new TestBubbleSort(new AgeComparer() { Order = SortOrder.Ascending });

            var expected = new List<PersonDto>() 
            {
                new PersonDto() { Age = 2 },
                new PersonDto() { Age = 5 }
            };
            var actual = sort.Sort(people).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scenario4()
        {
            List<PersonDto> people = new List<PersonDto>()
            {
                new PersonDto() { Age = 5 },
                new PersonDto() { Age = 2 }
            };
            TestBubbleSort sort = new TestBubbleSort(new AgeComparer() { Order = SortOrder.Ascending });

            var expected = new List<PersonDto>()
            {
                new PersonDto() { Age = 2 },
                new PersonDto() { Age = 5 }
            };
            var actual = sort.Sort(people).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
