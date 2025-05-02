using System.ComponentModel.DataAnnotations;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class EmailModel
    {
        private string emailId = null;
        private string alternateEmailId = null;
        //  [RegularExpression(RegularExpressions.Email, ErrorMessage = ValidationMessageConstant.EmailID)]
        [StringLength(100, ErrorMessage = ValidationMessageConstant.MaximumCharecterLimit + "100")]
        public string EmailId
        {
            get
            {
                return emailId;
            }
            set
            {
                emailId = value?.ToLower();
            }
        }

        // [RegularExpression(RegularExpressions.Email, ErrorMessage = ValidationMessageConstant.EmailID)]
        [StringLength(100, ErrorMessage = ValidationMessageConstant.MaximumCharecterLimit + "100")]
        public string AlternateEmailId
        {
            get
            {
                return alternateEmailId;
            }
            set
            {
                alternateEmailId = value?.ToLower();
            }
        }
    }
}