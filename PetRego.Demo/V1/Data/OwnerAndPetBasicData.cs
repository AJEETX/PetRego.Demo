using PetRego.Demo.V1.Models;
using PetRego.Demo.V2.Data;
using Swashbuckle.AspNetCore.Examples;
using System.Collections.Generic;

namespace PetRego.Demo.V1.Data
{
    public interface IOwnerAndPetData
    {
        IEnumerable<PetOwner<T>> GetPetOwnerData<T>();
        void AddPetOwner<T>(PetOwner<T> petOwner);
    }
    public interface IOwnerAndPetBasicData : IOwnerAndPetData { }
    public class OwnerAndPetBasicData : IExamplesProvider, IOwnerAndPetBasicData
    {
        static List<PetOwner<PetBasicData>> PetOwners;
        public static IEnumerable<PetOwner<PetBasicData>> Owners
        {
            get
            {
                PetOwners= new List<PetOwner<PetBasicData>> {
                new PetOwner<PetBasicData> { Id = 1, Name = "Owner1" , Pets=new List<PetBasicData>{ new PetBasicData { Name="Pussy1", Type=PetType.CAT},
                    new PetBasicData { Name = "Pussy2", Type=PetType.CAT } } },
                new PetOwner<PetBasicData> { Id = 2, Name = "Owner2" , Pets=new List<PetBasicData>{ new PetBasicData { Name="Tommy1", Type = PetType.DOG} } },
                new PetOwner<PetBasicData> { Id = 3, Name = "Owner3" , Pets=new List<PetBasicData>{ new PetBasicData { Name="Chick1", Type = PetType.CHICKEN} } },
                new PetOwner<PetBasicData> { Id = 4, Name = "Owner4" , Pets=new List<PetBasicData>{ new PetBasicData { Name="Pussy2", Type= PetType.CAT} } },
                new PetOwner<PetBasicData> { Id = 5, Name = "Owner5" , Pets=new List<PetBasicData>{ new PetBasicData { Name="Bamba1", Type=PetType.SNAKE},
                    new PetBasicData { Name = "Pussy2", Type=PetType.CAT } } }
            };
                return PetOwners;
            }
        }

        public IEnumerable<PetOwner<T>> GetPetOwnerData<T>()
        {
            return Owners as IEnumerable<PetOwner<T>>;
        }

        public object GetExamples()
        {
            return new Link<PetOwner<PetBasicData>> {
                     Links=new List<LinkInfo>{ new LinkInfo { Href="endpoint", Method="http-method-name", Rel="self" } },
                      Data=new PetOwner<PetBasicData>{ Id=1, Name="Owner name", Pets=new List<PetBasicData>{ new PetBasicData { Name="Doggy", Type=PetType.DOG } } }
            };
        }

        public void AddPetOwner<T>(PetOwner<T> petOwner)
        {
            PetOwners.Add(petOwner as PetOwner<PetBasicData>);
        }
    }
}
