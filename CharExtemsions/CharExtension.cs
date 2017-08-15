namespace OpenUtilityExtensions.CharExtemsions
{
    public static class CharExtension
    {
        /// <summary>
        /// Convert the current Char Array to a string
        /// </summary>
        /// <param name="Value">The current Char Array</param>
        /// <returns>A string of the array of characters</returns>
        public static string GetString(this char[] Value)
        {
            return new string(Value);
        }
    }
}
