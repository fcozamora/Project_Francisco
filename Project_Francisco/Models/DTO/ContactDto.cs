using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Project_Francisco.Models.DTO
{
    public class ContactDto
    {
        public int ContactId { get; set; }
        
        [Required(ErrorMessage = "A name is required.")]
        [MinLength(3, ErrorMessage = "The minimum length is 1 character")]
        [MaxLength(25, ErrorMessage = "25 characters maximum.")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "This field must not contain special characters.")]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "A name is required.")]
        [MinLength(3, ErrorMessage = "The minimum length is 1 character")]
        [MaxLength(25, ErrorMessage = "25 characters maximum.")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "This field must not contain special characters.")]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [EmailAddress(ErrorMessage = "The Email doesn't have the right format.")]
        public string Email {  get; set; }

        [IntegerValidator]
        public int Phone { get; set; }
    }
}