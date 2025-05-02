namespace ai_finder_be_schedulers_donetcore.Common
{
    public class LandLineModel
    {
        public long? CountryCode { get; set; }
        public string ISOCode { get; set; }
        //  [RegularExpression(RegularExpressions.StateCode, ErrorMessage = ValidationMessageConstant.STDCode)]
        public long? StateCode { get; set; }
        // [RegularExpression(RegularExpressions.LandLineNumber, ErrorMessage = ValidationMessageConstant.LandlinePhoneNumber)]
        public long? Number { get; set; }
    }
}