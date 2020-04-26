namespace CustomerService.Application.Contracts.Models.V1
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class CustomerUpdateDto
    {

     
        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        [StringLength(12, ErrorMessage = "Max 12 digits")]
        public string PersonalNumber { get; set; }

        [Required]
        [CustomAddressValidation]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [RegularExpression("^\\+[1-9]{1}[0-9]{3,14}$", ErrorMessage = "Please enter valid Mobile")]
        public string PhoneNumber { get; set; }
    }


    public class CustomAddressValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customerUpdateDto = (CustomerUpdateDto)validationContext.ObjectInstance;
            bool isValidPhone = false;
            if (customerUpdateDto.Address != null )
            {
                var postalCode = GetPostCode(customerUpdateDto.Address);

                if (string.IsNullOrEmpty(postalCode) || postalCode.Length >5)
                {
                    return new ValidationResult($"Postal code cannot be empty and it should be valid");
                }

                var country = GetCountry(customerUpdateDto.Address);

                if (country== CountryEnum.NONE )
                {
                    return new ValidationResult($"Enter Valid Contry");
                }

                switch (country)
                {
                    case CountryEnum.SWEDEN:
                        isValidPhone = customerUpdateDto.PhoneNumber.StartsWith("+46") || (customerUpdateDto.PhoneNumber.StartsWith("0") && customerUpdateDto.PhoneNumber.Length == 10);
                        break;
                    case CountryEnum.DENMARK:
                        isValidPhone = customerUpdateDto.PhoneNumber.StartsWith("+45");
                        break;
                    case CountryEnum.NORWAY:
                        isValidPhone = customerUpdateDto.PhoneNumber.StartsWith("+47");
                        break;
                    case CountryEnum.FINLAND:
                        isValidPhone = customerUpdateDto.PhoneNumber.StartsWith("+358");
                        break;
                }
                if (!isValidPhone)
                {
                    return new ValidationResult($"Phonenumber does not belongs to your Country");
                }
            }

            return ValidationResult.Success;
        }
    private string GetPostCode(string address)
        {
            string result = string.Empty;

            string[] list = address.Split(',');
            list.Reverse();
            foreach (var item in list)
            {
                // if item contains numeric postcode 
                Regex re = new Regex(@"\d+");
                Match m = re.Match(item);
                result = m.Value;
                if (!string.IsNullOrEmpty(result))
                    break;
            }

            return result;
        }
        private CountryEnum GetCountry(string address)
        {
            string result = string.Empty;
            CountryEnum countryName = CountryEnum.NONE  ;
            string[] list = address.Split(',');
            list.Reverse();
            foreach (var item in list)
            {
                if (CountryEnum.IsDefined(typeof(CountryEnum), item.ToUpper()))
                {
                    countryName = (CountryEnum)Enum.Parse(typeof(CountryEnum), (string)item.ToUpper());
                    break;
                }
            }

            return countryName;
        }


    }



}

