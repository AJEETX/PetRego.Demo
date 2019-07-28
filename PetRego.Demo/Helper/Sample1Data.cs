using PetRego.Demo.Models;
using PetRego.Demo.Models.V1;
using PetRego.Demo.Models.V2;
using Swashbuckle.AspNetCore.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRego.Demo.Helper
{
    public class Sample1Data: IExamplesProvider
    {
        public static IEnumerable<PetOwner<Pet>> Owners
        {
            get
            {
                return new List<PetOwner<Pet>> {
                new PetOwner<Pet> { Id = 1, Name = "Owner1" , Pets=new List<Pet>{ new Pet { Name="Pussy1", Type=PetType.CAT},
                    new Pet { Name = "Pussy2", Type=PetType.CAT } } },
                new PetOwner<Pet> { Id = 2, Name = "Owner2" , Pets=new List<Pet>{ new Pet { Name="Tommy1", Type = PetType.DOG} } },
                new PetOwner<Pet> { Id = 3, Name = "Owner3" , Pets=new List<Pet>{ new Pet { Name="Chick1", Type = PetType.CHICKEN} } },
                new PetOwner<Pet> { Id = 4, Name = "Owner4" , Pets=new List<Pet>{ new Pet { Name="Pussy2", Type= PetType.CAT} } },
                new PetOwner<Pet> { Id = 5, Name = "Owner5" , Pets=new List<Pet>{ new Pet { Name="Bamba1", Type=PetType.SNAKE},
                    new Pet { Name = "Pussy2", Type=PetType.CAT } } }
            };
            }
        }

        public object GetExamples()
        {
            return Owners;
        }
    }
}
