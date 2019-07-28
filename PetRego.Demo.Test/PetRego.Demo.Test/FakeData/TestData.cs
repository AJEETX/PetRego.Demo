using PetRego.Demo.V1.Models;
using System.Collections.Generic;

namespace PetRego.Demo.Test.FakeData
{
    static class TestData
    {
        public static List<PetOwner<PetBasicDetail>> GetOwners
        {
            get
            {
                return new List<PetOwner<PetBasicDetail>> { Owner };
            }
        }
        public static PetOwner<PetBasicDetail> Owner
        {
            get
            {
                return new PetOwner<PetBasicDetail>
                {
                    Id = 1,
                    Name = "Owner1",
                    Pets = GetPets
                };
            }
        }
        public static List<PetBasicDetail> GetPets
        {
            get
            {
                return new List<PetBasicDetail> { Pet };
            }
        }
        public static PetBasicDetail Pet
        {
            get
            {
                return new PetBasicDetail
                {
                    Name = "Doggy"
                };
            }
        }
        //public static Links<PetOwner> GetLinksWrapperList
        //{
        //    get
        //    {
        //        return new Links<PetOwner>
        //        {
        //            LinkList = new List<LinkInfo> { GetLinkInfo },
        //            PetOwners = new List<Link<PetOwner>> {
        //                GetLinksWrapper }
        //        };
        //    }
        //}
        public static Link<PetOwner<PetBasicDetail>> GetLinksWrapper
        {
            get
            {
                return new Link<PetOwner<PetBasicDetail>>
                {
                    Links = new List<LinkInfo> { GetLinkInfo },
                    Data = GetOwnerModel
                };
            }
        }
        static LinkInfo GetLinkInfo
        {
            get
            {
                return new LinkInfo { Href = "Href", Method = "Method", Rel = "Rel" };
            }
        }
        public static PetOwner<PetBasicDetail> GetOwnerModel
        {
            get
            {
                return new PetOwner<PetBasicDetail>
                {
                    Name = "Owner1",
                    Pets = GetPets
                };
            }
        }
    }
}
