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
        static List<PetBasicData> GetPets
        {
            get
            {
                return new List<PetBasicData> { Pet };
            }
        }
        static PetBasicData Pet
        {
            get
            {
                return new PetBasicData
                {
                    Name = "Doggy"
                };
            }
        }
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
        static PetOwner<PetBasicData> GetOwnerModel
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
