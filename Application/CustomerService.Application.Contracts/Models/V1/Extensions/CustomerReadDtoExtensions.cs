using CustomerService.Domain.Model.Entities;

namespace CustomerService.Application.Contracts.Models.V1.Extensions
{
    public static class CustomerReadDtoExtensions
    {
        public static CustomerReadDto MapFrom(this CustomerReadDto @this, Customer that)
        {
            if (@this == null || that == null)
            {
                return null;
            }

            @this.PersonalNumber = that.PersonalNumber;
            @this.Address = that.Address;
            @this.EmailAddress = that.Email;
            @this.PhoneNumber = that.PhoneNumber;
            @this.ModifiedBy = that.ModifiedBy;
            @this.ModifiedDate = that.ModifiedDate;
            @this.CreatedBy = that.CreatedBy;
            @this.CreatedDate = that.CreatedDate;
            return @this;
        }
    }
}
