using CustomerService.Domain.Model.Entities;

namespace CustomerService.Application.Contracts.Models.V1.Extensions
{
    public static class CustomerUpdateDtoExtensions
    {
        public static Customer MapTo(this CustomerUpdateDto @this, Customer that)
        {
            if (@this == null || that == null)
            {
                return null;
            }
            that.PersonalNumber = @this.PersonalNumber;
            that.Address = @this.Address;
            that.Email = @this.EmailAddress;
            that.PhoneNumber = @this.PhoneNumber;
            return that;
        }

      
    }
}
