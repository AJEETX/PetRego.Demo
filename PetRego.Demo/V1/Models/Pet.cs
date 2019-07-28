using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace PetRego.Demo.V1.Models
{
    public class Pet
    {
        public string Name { get; set; }
        [EnumDataType(typeof(PetType))]
        [JsonConverter(typeof(StringEnumConverter))]
        public PetType Type { get; set; }
    }
}
