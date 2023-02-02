using System.Reflection;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ArrExporter.Shared.Converters
{
    /// <summary>
    /// JsonConverter which allows the JsonProperty attribute to specify a JSON path.
    /// <example>
    /// The following JSON:
    /// <code>
    /// {
    ///   "object": {
    ///     "nested": "property"
    ///   }    
    /// }
    /// </code>
    /// could be parsed using the following JSON path:
    /// <code>
    /// "object.nested"
    /// </code>
    /// This JSON path can be used in the JsonProperty's PropertyName parameter.
    /// </example>
    /// </summary>
    /// <seealso href="https://stackoverflow.com/a/33094930">Original source.</seealso>
    public class JsonPathConverter : JsonConverter
    {
        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The Newtonsoft.Json.JsonReader to read from.</param>
        /// <param name="type">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type type, object? existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            object? target = Activator.CreateInstance(type);

            if(target == null)
            {
                throw new JsonReaderException("Failed to create object.");
            }

            foreach(PropertyInfo property in type.GetProperties().Where(p => p.CanRead && p.CanWrite))
            {
                // The JsonProperty of the property.
                JsonPropertyAttribute? attr = property.GetCustomAttributes(true).OfType<JsonPropertyAttribute>().FirstOrDefault();

                // The JSON path from the model. If none is specified, use the propety name.
                string path = (attr != null && attr.PropertyName != null ? attr.PropertyName : property.Name);
                JToken? token = jo.SelectToken(path);

                if(token != null && token.Type != JTokenType.Null)
                {
                    object? value = token.ToObject(property.PropertyType, serializer);
                    property.SetValue(target, value, null);
                }
            }

            return target;
        }

        /// <summary>
        /// This will disallow use of WriteJson.
        /// </summary>
        public override bool CanWrite => false;

        /// <summary>
        /// Not used, as this converter doesn't allow writing.
        /// </summary>
        /// <returns>False.</returns>
        public override bool CanConvert(Type objectType) => false;

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <exception cref="NotImplementedException">Always thrown.</exception>
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException("JsonPathConverter is not meant to write Json, nor should it.");
        }
    }
}