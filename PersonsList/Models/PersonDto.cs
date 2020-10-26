using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PersonsList.Models
{
    public class PersonDto : IValidatableObject, ICloneable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Middlename { get; set; }

        public string Email { get; set; }

        public int? Age { get; set; }

        public object Clone()
        {
            return new PersonDto()
            {
                Id = Id,
                Name = (string)Name.Clone(),
                Surname = (string)Surname.Clone(),
                Middlename = (string)Middlename.Clone(),
                Email = (string)Email.Clone(),
                Age = Age
            };
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(Name))
            {
                if (Name == null)
                    errors.Add(new ValidationResult("Name cannot be empty"));
                else
                    errors.Add(new ValidationResult("Name cannot contain only spaces"));
            }

            if (string.IsNullOrWhiteSpace(Surname))
            {
                if (Surname == null)
                    errors.Add(new ValidationResult("Surname cannot be empty"));
                else
                    errors.Add(new ValidationResult("Surname cannot contain only spaces"));
            }

            if (string.IsNullOrWhiteSpace(Middlename))
            {
                if (Middlename != null)
                    errors.Add(new ValidationResult("Middlename cannot contain spaces"));
            }

            if (Age < 0 || Age > 1000)
                errors.Add(new ValidationResult("Incorrect age. Age: 0 - 1000"));

            Regex emailRegex = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            if (string.IsNullOrEmpty(Email))
                errors.Add(new ValidationResult("Email cannot be empty"));
            else if (!emailRegex.IsMatch(Email))
                errors.Add(new ValidationResult("Incorrect email format"));

            return errors;
        }
    }
}
