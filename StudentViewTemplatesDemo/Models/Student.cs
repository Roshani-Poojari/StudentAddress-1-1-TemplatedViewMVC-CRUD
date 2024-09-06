using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;

namespace StudentViewTemplatesDemo.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z]+(?:\\s[a-zA-Z]+)*$", ErrorMessage = "Name can only contain alphabets.")]

        public string Name { get; set; }
        [Required]
        [Range(16, 28)]
        public int Age { get; set; }
        public Address Address { get; set; }
    }
}