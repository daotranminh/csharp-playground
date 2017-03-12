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
        [MaxLength(20)]
        public string LastName { get; set; }

        [RegularExpression("[0-1][0-9]")]
        public string Department { get; set; }
    }
}