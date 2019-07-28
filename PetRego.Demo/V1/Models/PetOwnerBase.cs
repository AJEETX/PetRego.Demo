using Newtonsoft.Json;

namespace PetRego.Demo.V1.Models
{
    public abstract class PetOwnerBase
    {
        public int Id { get; set; }
        [JsonProperty("petOwnerName")]

        public string Name { get; set; }
    }
}
