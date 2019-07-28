using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PetRego.Demo.V1.Models;
using System.ComponentModel.DataAnnotations;

namespace PetRego.Demo.V2.Models
{
    public class PetMoreDetail : PetBasicDetail
    {
        [EnumDataType(typeof(FoodType))]
        [JsonConverter(typeof(StringEnumConverter))]
        public FoodType FoodType { get; set; }
    }
}
