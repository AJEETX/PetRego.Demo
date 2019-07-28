using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRego.Demo.V1.Models
{
    public class PetOwnerBase
    {
        public int Id { get; set; }
        [JsonProperty("petOwnerName")]

        public string Name { get; set; }
    }
}
