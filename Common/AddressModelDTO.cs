using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class AddressModelDTO
    {
        HelperFunctions helperFunction = new HelperFunctions();
        private string address = null;
        public int? AddressLine { get; set; }

        [StringLength(200, ErrorMessage = ValidationMessageConstant.MaximumCharecterLimit + "200")]
       // [RegularExpression(RegularExpressions.AlphaNumericWithSomeSymbolsAndEnter, ErrorMessage = ValidationMessageConstant.AllowedCharecterAddress)]
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = helperFunction.CustomCase(value);
            }
        }
        public string Type { get; set; }
    }
}