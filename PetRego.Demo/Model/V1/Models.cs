﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetRego.Demo.Model
{
    public class PetOwnerBase
    {
        public int Id { get; set; }
        [JsonProperty("petOwnerName")]

        public string Name { get; set; }
    }
    public class Pet
    {
        public string Name { get; set; }
        [EnumDataType(typeof(PetType))]
        [JsonConverter(typeof(StringEnumConverter))]
        public PetType Type { get; set; }
    }

    public enum PetType
    {
        DOG, CAT, CHICKEN, SNAKE
    }
    public class PetOwner : PetOwnerBase
    {
        [JsonProperty("pets")]
        public List<Pet> Pets { get; set; }
    }
}
