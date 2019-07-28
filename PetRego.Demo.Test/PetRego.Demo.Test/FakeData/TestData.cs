using PetRego.Demo.Model;
using PetRego.Demo.Model.V1;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetRego.Demo.Test.FakeData
{
    static class TestData
    {
        public static List<PetOwner> GetOwners
        {
            get
            {
                return new List<PetOwner> { Owner };
            }
        }
        public static PetOwner Owner
        {
            get
            {
                return new PetOwner
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
        public static Link<PetOwner> GetLinksWrapper
        {
            get
            {
                return new Link<PetOwner>
                {
                    Links = new List<LinkInfo> { GetLinkInfo },
                    PetOwner = GetOwnerModel
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
        public static PetOwner GetOwnerModel
        {
            get
            {
                return new PetOwner
                {
                    Name = "Owner1",
                    Pets = GetPets
                };
            }
        }
    }
}
