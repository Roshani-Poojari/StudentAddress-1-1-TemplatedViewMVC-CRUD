using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentViewTemplatesDemo.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z]+(?:[\\s-][a-zA-Z]+)*$", ErrorMessage = "Country name can only contain alphabets.")]
        public string Country { get; set; }
        [Required]
        //[RegularExpression("^[a-zA-Z]+$", ErrorMessage = "City name can only contain alphabets.")]
        [RegularExpression("^[a-zA-Z]+(?:[\\s-][a-zA-Z]+)*$", ErrorMessage = "City name can only contain alphabets.")]
        public string City { get; set; }
        [Required]
        //[RegularExpression("^[a-zA-Z]+$", ErrorMessage = "State name can only contain alphabets.")]
        [RegularExpression("^[a-zA-Z]+(?:[\\s-][a-zA-Z]+)*$", ErrorMessage = "State name can only contain alphabets.")]
        public string State { get; set; }
    }
}