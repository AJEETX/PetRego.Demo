using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PetRego.Demo.Models.V1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetRego.Demo.Models.V2
{
    public class PetDetail : Pet
    {
        [EnumDataType(typeof(FoodType))]
        [JsonConverter(typeof(StringEnumConverter))]
        public FoodType FoodType { get; set; }
    }

    public enum FoodType
    {
        Bones, Fish, Corn, Mice
    }
}
