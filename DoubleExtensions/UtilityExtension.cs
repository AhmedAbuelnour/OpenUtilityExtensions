using System.Globalization;

namespace OpenUtilityExtensions.DoubleExtensions
{
    public static class UtilityExtension
    {    
         /// <summary>
         /// Convert a double value to currency representation
         /// </summary>
         /// <param name="value">The Current double Money value</param>
         /// <param name="cultureName">the language and the country, ex en-US or ar-eg or ar-sa</param>
         /// <returns>Formatted Currency</returns>
        public static string ToCurrency(this double value, string cultureName)
        {
            return (string.Format(new CultureInfo(cultureName), "{0:C}", value));
        }
    }
}
