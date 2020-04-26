using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerService.Domain.Model.Entities
{
   public class Customer
    {
            public DateTime? CreatedDate { get; set; }
            public DateTime? ModifiedDate { get; set; }
            public string Address { get; set; }
            public string PersonalNumber { get; set; }
            public string ModifiedBy { get; set; }
            public string CreatedBy { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
    }
}
