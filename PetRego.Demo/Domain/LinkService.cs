using Microsoft.AspNetCore.Mvc;
using PetRego.Demo.V1.Models;
using PetRego.Demo.V2.Models;
using System;
using System.Collections.Generic;

namespace PetRego.Demo.Domain
{
    public interface ILinkService
    {
        Link<PetOwner<Pet>> GetLink(PetOwner<Pet> model);
        Link<PetOwner<PetDetail>> GetLink(PetOwner<PetDetail> model);

    }
    public class LinkService : ILinkService
    {
        readonly IUrlHelper _urlHelper;

        public LinkService(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }
        public Link<PetOwner<Pet>> GetLink(PetOwner<Pet> model)
        {
            Link<PetOwner<Pet>> linksWrapper = default(Link<PetOwner<Pet>>);
            if (model == default(PetOwner<Pet>)) return linksWrapper;
            try
            {
                linksWrapper = new Link<PetOwner<Pet>>
                {
                    Value = model,
                    Links = GetLinks_Model(model)
                };
            }
            catch (Exception)
            {
                // shout //yell //log
            }
            return linksWrapper;
        }

        public Link<PetOwner<PetDetail>> GetLink(PetOwner<PetDetail> model)
        {

            Link<PetOwner<PetDetail>> linksWrapper = default(Link<PetOwner<PetDetail>>);
            if (model == default(PetOwner<PetDetail>)) return linksWrapper;
            try
            {
                linksWrapper = new Link<PetOwner<PetDetail>>
                {
                    Value = model,
                    Links = GetLinks_Model(model)
                };
            }
            catch (Exception)
            {
                // shout //yell //log
            }
            return linksWrapper;
        }

        List<LinkInfo> GetLinks_Model(PetOwner<Pet> model)
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
        List<LinkInfo> GetLinks_Model(PetOwner<PetDetail> model)
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
