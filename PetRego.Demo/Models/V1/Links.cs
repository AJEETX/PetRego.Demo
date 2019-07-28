using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRego.Demo.Models.V1
{
    public class LinkInfo
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }
    }
    public class Link<T>
    {
        public T Value { get; set; }
        public List<LinkInfo> Links { get; set; }
    }
    public class ResponseModel : PetOwnerBase
    {
        public List<LinkInfo> Links { get; set; }
        [JsonProperty("pets")]
        public List<Pet> Pets { get; set; }
    }
}
