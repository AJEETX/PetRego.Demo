using PetRego.Demo.Models;
using PetRego.Demo.Models.V1;
using PetRego.Demo.Models.V2;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetRego.Demo.Test.FakeData
{
    static class TestData
    {
        public static List<PetOwner<Pet>> GetOwners
        {
            get
            {
                return new List<PetOwner<Pet>> { Owner };
            }
        }
        public static PetOwner<Pet> Owner
        {
            get
            {
                return new PetOwner<Pet>
                {
                    Id = 1,
                    Name = "Owner1",
                    Pets = GetPets
                };
            }
        }
        public static List<Pet> GetPets
        {
            get
            {
                return new List<Pet> { Pet };
            }
        }
        public static Pet Pet
        {
            get
            {
                return new Pet
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
        public static Link<PetOwner<Pet>> GetLinksWrapper
        {
            get
            {
                return new Link<PetOwner<Pet>>
                {
                    Links = new List<LinkInfo> { GetLinkInfo },
                    Value = GetOwnerModel
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
        public static PetOwner<Pet> GetOwnerModel
        {
            get
            {
                return new PetOwner<Pet>
                {
                    Name = "Owner1",
                    Pets = GetPets
                };
            }
        }
    }
}
