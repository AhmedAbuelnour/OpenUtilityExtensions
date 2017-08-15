using OpenUtilityExtensions.ByteExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Text.RegularExpressions;

namespace OpenUtilityExtensions.StringExtensions
{
    public static class UtilityExtension
    {
        /// <summary>
        /// Indicate if the current value is equals to at least to one of the given list of values
        /// </summary>
        /// <param name="Value">Current Value</param>
        /// <param name="Items">List of options</param>
        /// <returns></returns>
        public static bool IsInRangeOf(this string Value, params string[] Items)
        {
            foreach (var item in Items)
            {
                if (Value.Equals(item)) return true;
            }
            return false;
        }
        public static async Task<string> StreamToStringAsync(this Stream StreamValue)
        {
            return (await new StreamReader(StreamValue ?? throw new ArgumentNullException("StreamValue")).ReadToEndAsync());
        }
        public static async Task<Stream> StringToStreamAsync(this string Value)
        {
            return await Task.Run(() => { return new MemoryStream(Value?.ConvertStringToByteArray()); });
        }
        public static string RemoveCharacters(this string Value , params char[] Characters)
        {
            return new string(Value?.Where(x=>!Characters.Contains(x)).ToArray());
        }
        public static string RemoveStrings(this string Value, params string[] Strings)
        {
            return string.Join(" ", Value?.Split(' ').Where(x => !Strings.Contains(x)));
        }
        public static bool IsMatchPattern(this string Value, string Pattern)
        {
            return Regex.Match(Value ?? throw new ArgumentNullException("String Value"), Pattern ?? throw new ArgumentNullException("Pattern")).Success;
        }
        public static string MatchPattern(this string Value, string Pattern)
        {
            return Regex.Match(Value ?? throw new ArgumentNullException("String Value"), Pattern ?? throw new ArgumentNullException("Pattern")).Value;
        }
        public static IEnumerable<string> MatchesPattern(this string Value, string Pattern)
        {
            foreach (Match Match in Regex.Matches(Value ?? throw new ArgumentNullException("String Value"), Pattern ?? throw new ArgumentNullException("Pattern")))
            {
                yield return Match.Value;
            }
        }
        public static string[] SplitAtEachLine(this string Value, bool IncludeEmptyLines = false)
        {
            return Value.Split(new string[] { Environment.NewLine }, IncludeEmptyLines == true ? StringSplitOptions.None : StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
