using System;

namespace CustomerService.Application.Contracts.Models.V1
{
    public class CustomerReadDto
    {

        public string PersonalNumber { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public string ModifiedBy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}