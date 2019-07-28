using Microsoft.AspNetCore.Mvc;
using PetRego.Demo.Model;
using PetRego.Demo.Model.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRego.Demo.Domain
{
    public interface ILinkService
    {
        Link<PetOwner> GetLink(PetOwner model);

    }
    public class LinkService : ILinkService
    {
        readonly IUrlHelper _urlHelper;

        public LinkService(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }
        public Link<PetOwner> GetLink(PetOwner model)
        {
            Link<PetOwner> linksWrapper = default(Link<PetOwner>);
            if (model == default(PetOwner)) return linksWrapper;
            try
            {
                linksWrapper = new Link<PetOwner>
                {
                    PetOwner = new PetOwner
                    {
                        Name = model.Name,
                        Pets = model.Pets
                    },
                    Links = GetLinks_Model(model)
                };
            }
            catch (Exception)
            {
                // shout //yell //log
            }
            return linksWrapper;
        }
        List<LinkInfo> GetLinks_Model(PetOwner model)
        {
            var links = new List<LinkInfo>
            {
                new LinkInfo
                {
                    Href = _urlHelper.Link("GetPetOwner", new { id = model.Id }),
                    Rel = "self",
                    Method = "GET"
                }
            };
            return links;
        }
    }
}
