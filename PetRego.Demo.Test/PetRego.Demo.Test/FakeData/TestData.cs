using PetRego.Demo.V1.Models;
using System.Collections.Generic;

namespace PetRego.Demo.Test.FakeData
{
    static class TestData
    {
        public static List<PetOwner<PetBasicData>> GetOwners
        {
            get
            {
                return new List<PetOwner<PetBasicData>> { Owner };
            }
        }
        public static PetOwner<PetBasicData> Owner
        {
            get
            {
                return new PetOwner<PetBasicData>
                {
                    Id = 1,
                    Name = "Owner1",
                    Pets = GetPets
                };
            }
        }
        public static List<PetBasicData> GetPets
        {
            get
            {
                return new List<PetBasicData> { Pet };
            }
        }
        public static PetBasicData Pet
        {
            get
            {
                return new PetBasicData
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
        public static Link<PetOwner<PetBasicData>> GetLinksWrapper
        {
            get
            {
                return new Link<PetOwner<PetBasicData>>
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
        public static PetOwner<PetBasicData> GetOwnerModel
        {
            get
            {
                return new PetOwner<PetBasicData>
                {
                    Name = "Owner1",
                    Pets = GetPets
                };
            }
        }
    }
}
