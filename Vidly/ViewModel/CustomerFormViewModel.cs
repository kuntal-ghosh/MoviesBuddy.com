using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> Memberships { get; set; }
        public Customer Customer { get; set; }
    }
}