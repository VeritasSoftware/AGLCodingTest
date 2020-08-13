using Newtonsoft.Json;

namespace AGL.Entities
{   
    public class Pet
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public PetType Type { get; set; }
    }
}
