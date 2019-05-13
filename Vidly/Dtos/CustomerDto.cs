using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "input Customer's name")]
        [StringLength(250)]
        public string Name { get; set; }
        public byte MembershipTypeId { get; set; }

        [Required]
        public bool IsSubscribedToNewsletter { get; set; }
        [Display(Name = "Date of Birth")]
        [Required]
        public DateTime? Birthdate { get; set; }
    }
}