using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PetRego.Demo.V1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetRego.Demo.V2.Models
{
    public class PetDetail : Pet
    {
        [EnumDataType(typeof(FoodType))]
        [JsonConverter(typeof(StringEnumConverter))]
        public FoodType FoodType { get; set; }
    }
}
