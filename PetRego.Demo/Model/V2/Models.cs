using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetRego.Demo.Model.V2
{
    public class PetDetail : Pet
    {
        [EnumDataType(typeof(FoodType))]
        [JsonConverter(typeof(StringEnumConverter))]
        public FoodType FoodType { get; set; }
    }
    public class PetOwnerAndFooding:PetOwnerBase
    {
        [JsonProperty("pets")]
        public List<PetDetail> Pets { get; set; }
    }
    public enum FoodType
    {
        Bones, Fish, Corn, Mice
    }
}
