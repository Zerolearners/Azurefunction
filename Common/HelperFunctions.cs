using System.Globalization;
using System.Text.RegularExpressions;

namespace ai_finder_be_schedulers_donetcore.Common
{
    public class HelperFunctions
    {
        public string TitleCase(string content)
        {
            if (content != null)
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                string resp = textInfo.ToTitleCase(content);
                return resp;
            }
            else
            {
                return null;
            }
        }

        public string CustomCase(string content)
        {
            if (content != null)
            {
                var result = Regex.Replace(content, @"(^\w)|(\.\w)", m => m.Value.ToUpper());
                return Regex.Replace(result, @"(^\w)|(\. \w)", m => m.Value.ToUpper());

            }
            else return null;

        }
        public string RemoveLeadingZeros(string input)
        {
            if (input == null) { return null; }

            return Regex.Replace(input, @"^0+(?!$)", "");
        }
        public string ParagraphCase(string content)
        {
            if (content != null)
            {
                var result = Regex.Replace(content, @"(\.\s)", ".");
                result = Regex.Replace(result, @"(^\w)|(\.\w)", m => m.Value.ToUpper());
                return Regex.Replace(result, @"(\.)", ". ");
            }
            else return null;
        }

        public static bool CheckTypeIntegar(string value)
        {
            if (int.TryParse(value, out _))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}