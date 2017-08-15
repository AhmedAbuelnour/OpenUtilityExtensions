using Newtonsoft.Json;
using System;

namespace OpenUtilityExtensions.JsonExtensions
{
    public static class JsonExtension
    {
        /// <summary>
        /// Serialize a .NET Object to JSON format
        /// </summary>
        /// <typeparam name="T">The Current Object type</typeparam>
        /// <param name="Value">The Current Object Value</param>
        /// <exception cref="ArgumentNullException"
        /// <returns>JSON of the serialized object</returns>
        public static string SerializeObjectToJson<T>(this T Value) where T : class
        {
            return JsonConvert.SerializeObject(Value ?? throw new ArgumentNullException());
        }
        /// <summary>
        /// Deserialize a JSON  to a .NET Object
        /// </summary>
        /// <typeparam name="T">The Returned Object type</typeparam>
        /// <param name="Value">The Current JSON Value</param>
        /// <exception cref="ArgumentNullException"
        /// <returns>Object of the desrialized JSON</returns>
        public static T DeserializeJsonToObject<T>(this string Value) where T : class
        {
            return JsonConvert.DeserializeObject<T>(Value ?? throw new ArgumentNullException());
        }
    }
}
