using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }
        public short SignupFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte? DiscountRate { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}