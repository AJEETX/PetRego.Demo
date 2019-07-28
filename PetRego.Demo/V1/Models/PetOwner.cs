using Newtonsoft.Json;
using System.Collections.Generic;

namespace PetRego.Demo.V1.Models
{
    public class PetOwner<T> : PetOwnerBase
    {
        [JsonProperty("pets")]
        public List<T> Pets { get; set; }
    }
}
