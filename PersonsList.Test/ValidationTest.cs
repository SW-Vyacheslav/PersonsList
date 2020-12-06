using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonsList.Models;
using System.Linq;

namespace PersonsList.Test
{
    [TestClass]
    public class ValidationTest
    {
        [TestMethod]
        public void Scenario1()
        {
            PersonDto person = new PersonDto()
            {
                Name = "",
                Surname = "A",
                Age = 1,
                Email = "mail@mail.com"
            };

            string expected = "Name cannot be empty";

            string actual = person.Validate(null)
                .Select(vr => vr.ErrorMessage)
                .FirstOrDefault();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scenario2()
        {
            PersonDto person = new PersonDto()
            {
                Name = "A",
                Surname = "",
                Age = 1,
                Email = "mail@mail.com"
            };

            string expected = "Surname cannot be empty";

            string actual = person.Validate(null)
                .Select(vr => vr.ErrorMessage)
                .FirstOrDefault();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scenario3()
        {
            PersonDto person = new PersonDto()
            {
                Name = "A",
                Surname = "A",
                Age = -1,
                Email = "mail@mail.com"
            };

            string expected = "Incorrect age. Age: 0 - 1000";

            string actual = person.Validate(null)
                .Select(vr => vr.ErrorMessage)
                .FirstOrDefault();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scenario4()
        {
            PersonDto person = new PersonDto()
            {
                Name = "A",
                Surname = "A",
                Age = 1,
                Email = ""
            };

            string expected = "Email cannot be empty";

            string actual = person.Validate(null)
                .Select(vr => vr.ErrorMessage)
                .FirstOrDefault();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scenario5()
        {
            PersonDto person = new PersonDto()
            {
                Name = "A",
                Surname = "A",
                Age = 1,
                Email = "abc"
            };

            string expected = "Incorrect email format";

            string actual = person.Validate(null)
                .Select(vr => vr.ErrorMessage)
                .FirstOrDefault();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scenario6()
        {
            PersonDto person = new PersonDto()
            {
                Name = "A",
                Surname = "A",
                Age = 1,
                Email = "mail@mail.com"
            };

            string expected = null;

            string actual = person.Validate(null)
                .Select(vr => vr.ErrorMessage)
                .FirstOrDefault();

            Assert.AreEqual(expected, actual);
        }
    }
}
