using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRego.Demo.V1.Models
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
}
