using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace VinylShopper.Infrastructure
{
    public class JsonParser
    {
        public T Parse<T>(string result)
        {
            var deserialized = JsonConvert.DeserializeObject<List<T>>(result);
            return deserialized.First();
        }
    }
}
