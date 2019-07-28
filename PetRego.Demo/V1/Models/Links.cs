using System.Collections.Generic;

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
        public T Data { get; set; }
        public List<LinkInfo> Links { get; set; }
    }
}
