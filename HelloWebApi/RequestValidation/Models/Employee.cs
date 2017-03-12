using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RequestValidation.Models
{
    public class Employee
    {
        [Range(10000, 99999)]
        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage="You can enter only 20 characters!")]
        public string LastName { get; set; }

        [MemberRange(0, 9)]
        public List<int> Department { get; set; }

        public decimal AnnualIncome { get; set; }

        [LimitChecker("AnnualIncome", 75)]
        public decimal Contribution { get; set; }
    }
}