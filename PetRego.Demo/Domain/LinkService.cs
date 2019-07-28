using Microsoft.AspNetCore.Mvc;
using PetRego.Demo.V1.Models;
using System;
using System.Collections.Generic;

namespace PetRego.Demo.Domain
{
    public interface ILinkService<T>
    {
        Link<PetOwner<T>> GetLink(PetOwner<T> model);
    }
    public class LinkService<T> : ILinkService<T>
    {
        readonly IUrlHelper _urlHelper;

        public LinkService(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }
        public Link<PetOwner<T>> GetLink(PetOwner<T> model)
        {
            Link<PetOwner<T>> linksWrapper = default(Link<PetOwner<T>>);
            if (model == default(PetOwner<T>)) return linksWrapper;
            try
            {
                linksWrapper = new Link<PetOwner<T>>
                {
                    Data = model,
                    Links = new List<LinkInfo>
                    {
                        new LinkInfo
                        {
                            Href = _urlHelper.Link("GetPetOwner", new { id = model.Id }),
                            Rel = "self",
                            Method = "GET"
                        }
                    }
                };
            }
            catch (Exception)
            {
                // shout //yell //log
            }
            return linksWrapper;
        }
    }
}
