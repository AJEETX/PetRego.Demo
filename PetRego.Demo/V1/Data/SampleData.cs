using PetRego.Demo.V1.Models;
using Swashbuckle.AspNetCore.Examples;
using System.Collections.Generic;

namespace PetRego.Demo.V1.Data
{
    public class SampleData : IExamplesProvider
    {
        public static IEnumerable<PetOwner<PetBasicDetail>> Owners
        {
            get
            {
                return new List<PetOwner<PetBasicDetail>> {
                new PetOwner<PetBasicDetail> { Id = 1, Name = "Owner1" , Pets=new List<PetBasicDetail>{ new PetBasicDetail { Name="Pussy1", Type=PetType.CAT},
                    new PetBasicDetail { Name = "Pussy2", Type=PetType.CAT } } },
                new PetOwner<PetBasicDetail> { Id = 2, Name = "Owner2" , Pets=new List<PetBasicDetail>{ new PetBasicDetail { Name="Tommy1", Type = PetType.DOG} } },
                new PetOwner<PetBasicDetail> { Id = 3, Name = "Owner3" , Pets=new List<PetBasicDetail>{ new PetBasicDetail { Name="Chick1", Type = PetType.CHICKEN} } },
                new PetOwner<PetBasicDetail> { Id = 4, Name = "Owner4" , Pets=new List<PetBasicDetail>{ new PetBasicDetail { Name="Pussy2", Type= PetType.CAT} } },
                new PetOwner<PetBasicDetail> { Id = 5, Name = "Owner5" , Pets=new List<PetBasicDetail>{ new PetBasicDetail { Name="Bamba1", Type=PetType.SNAKE},
                    new PetBasicDetail { Name = "Pussy2", Type=PetType.CAT } } }
            };
            }
        }

        public object GetExamples()
        {
            return new Link<PetOwner<PetBasicDetail>> {
                     Links=new List<LinkInfo>{ new LinkInfo { Href="endpoint", Method="http-method-name", Rel="self" } },
                      Data=new PetOwner<PetBasicDetail>{ Id=1, Name="Owner name", Pets=new List<PetBasicDetail>{ new PetBasicDetail { Name="Doggy", Type=PetType.DOG } } }
            };
        }
    }
}
