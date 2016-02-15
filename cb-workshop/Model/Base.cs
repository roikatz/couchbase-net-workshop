using Newtonsoft.Json;

namespace cb_workshop.Model
{
    public class Base
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        public Base()
        {
        }

        public Base(string type)
        {
            Type = type;
        }
    }
}
