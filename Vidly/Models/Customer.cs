using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "input Customer's name")]
        [StringLength(250)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "membership Type")]
        [ForeignKey("MembershipType")]
        public byte MembershipTypeId  { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }
    }
}