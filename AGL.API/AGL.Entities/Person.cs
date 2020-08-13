using Newtonsoft.Json;
using System.Collections.Generic;

namespace AGL.Entities
{
    /// <summary>
    /// Class Person
    /// </summary>
    public class Person
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("gender")]
        public Gender Gender { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("pets")]
        public ICollection<Pet> Pets { get; set; }
    }
}
