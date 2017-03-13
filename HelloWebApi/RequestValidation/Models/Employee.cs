using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RequestValidation.Models
{
    public class Employee : IValidatableObject
    {
        private const decimal PERCENTAGE = 0.75M;

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal AnnualIncome { get; set; }

        public decimal Contribution { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Id < 10000 || this.Id > 99999)
                yield return new ValidationResult("Id must be in the range 10000-99999");

            if (String.IsNullOrEmpty(this.LastName))
                yield return new ValidationResult("LastName is mandatory");
            else if (this.LastName.Length > 20)
                yield return new ValidationResult("You can enter only 20 charaters");

            if (this.Contribution > Decimal.Zero &&
                this.Contribution > this.AnnualIncome * PERCENTAGE)
                yield return new ValidationResult("You can contribute a maximum of 75% of your annual income to 401K");
        }
    }
}