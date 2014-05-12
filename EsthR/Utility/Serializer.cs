using Newtonsoft.Json;

namespace EsthR.Utility
{
    internal static class Serializer
    {
        public static T Deserialize<T>(string input)
            where T : class 
        {
            T result;
            try
            {
                result = JsonConvert.DeserializeObject<T>(input);
            }
            catch (JsonException)
            {
                return default(T);
            }

            return result;
        }

        public static string Serialize<T>(T input)
        {
            string result;
            try
            {
                result = JsonConvert.SerializeObject(input);
            }
            catch (JsonException)
            {
                return string.Empty;
            }

            return result;
        }
    }
}
