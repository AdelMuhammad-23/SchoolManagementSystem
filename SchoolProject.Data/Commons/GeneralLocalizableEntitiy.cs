using System.Globalization;

namespace SchoolProject.Data.Commons
{
    public class GeneralLocalizableEntitiy
    {

        public string GetLocalized(string textAr, string textEn)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return textAr;

            return textEn;
        }
    }
}
