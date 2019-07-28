using PetRego.Demo.Model;
using PetRego.Demo.Model.V2;
using Swashbuckle.AspNetCore.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRego.Demo.Helper
{
    public class SampleData: IExamplesProvider
    {
        public static IEnumerable<PetOwner> Owners
        {
            get
            {
                return new List<PetOwner> {
                new PetOwner { Id = 1, Name = "Owner1" , Pets=new List<Pet>{ new Pet { Name="Pussy1", Type=PetType.CAT},
                    new Pet { Name = "Pussy2", Type=PetType.CAT } } },
                new PetOwner { Id = 2, Name = "Owner2" , Pets=new List<Pet>{ new Pet { Name="Tommy1",Type=PetType.DOG} } },
                new PetOwner { Id = 3, Name = "Owner3" , Pets=new List<Pet>{ new Pet { Name="Chick1",Type=PetType.CHICKEN} } },
                new PetOwner { Id = 4, Name = "Owner4" , Pets=new List<Pet>{ new Pet { Name="Pussy2", Type=PetType.CAT} } },
                new PetOwner { Id = 5, Name = "Owner5" , Pets=new List<Pet>{ new Pet { Name="Bamba1", Type=PetType.SNAKE},
                    new Pet { Name = "Pussy2", Type=PetType.CAT } } }
            };
            }
        }
        public static PetOwnerAndFooding GetPetOwnerAndFooding
        {
            get
            {
                return new PetOwnerAndFooding { Id=1, Name="Owner1",
                    Pets =new List<PetDetail>
                    {
                        new PetDetail
                        {
                             Name="Doggy", FoodType=FoodType.Bones, Type=PetType.DOG
                        }
                    }
                };
            }
        }

        public object GetExamples()
        {
            return new List<PetOwner> {
                new PetOwner { Id = 1, Name = "Owner1" , Pets=new List<Pet>{ new Pet { Name="Pussy1", Type=PetType.CAT},
                    new Pet { Name = "Pussy2", Type=PetType.CAT } } },
                new PetOwner { Id = 2, Name = "Owner2" , Pets=new List<Pet>{ new Pet { Name="Tommy1",Type=PetType.DOG} } },
                new PetOwner { Id = 3, Name = "Owner3" , Pets=new List<Pet>{ new Pet { Name="Chick1",Type=PetType.CHICKEN} } },
                new PetOwner { Id = 4, Name = "Owner4" , Pets=new List<Pet>{ new Pet { Name="Pussy2", Type=PetType.CAT} } },
                new PetOwner { Id = 5, Name = "Owner5" , Pets=new List<Pet>{ new Pet { Name="Bamba1", Type=PetType.SNAKE},
                    new Pet { Name = "Pussy2", Type=PetType.CAT } } } };
        }
    }
}
