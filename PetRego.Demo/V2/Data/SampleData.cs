using PetRego.Demo.V1.Models;
using PetRego.Demo.V2.Models;
using Swashbuckle.AspNetCore.Examples;
using System.Collections.Generic;

namespace PetRego.Demo.V2.Data
{
    public class SampleData : IExamplesProvider
    {
        public static List<PetOwner<PetMoreDetail>> Owners
        {
            get
            {
                return new List<PetOwner<PetMoreDetail>> {
                    new PetOwner<PetMoreDetail>{
                         Id=1, Name="Owner1", Pets=new List<PetMoreDetail>{ new PetMoreDetail {  Name="Pussy1", Type=PetType.CAT, FoodType=FoodType.Fish},
                             new PetMoreDetail { Name = "Python", Type = PetType.SNAKE, FoodType = FoodType.Mice } }
                    },
                    new PetOwner<PetMoreDetail>{
                         Id=2, Name="Owner2", Pets=new List<PetMoreDetail>{ new PetMoreDetail {  Name="Doggy", Type=PetType.DOG, FoodType=FoodType.Bones},
                         new PetMoreDetail {  Name="Chicky1", Type=PetType.CHICKEN, FoodType=FoodType.Corn} }
                    },
                    new PetOwner<PetMoreDetail>{
                         Id=3, Name="Owner3", Pets=new List<PetMoreDetail>{ new PetMoreDetail {  Name="Chicky2", Type=PetType.CHICKEN, FoodType=FoodType.Corn} }
                    },
                    new PetOwner<PetMoreDetail>{
                         Id=4, Name="Owner4", Pets=new List<PetMoreDetail>{ new PetMoreDetail {  Name="Bamba1", Type=PetType.SNAKE, FoodType=FoodType.Mice},
                             new PetMoreDetail { Name = "Tommy", Type = PetType.DOG, FoodType = FoodType.Bones } }
                    },
                    new PetOwner<PetMoreDetail>{
                         Id=5, Name="Owner5", Pets=new List<PetMoreDetail>{ new PetMoreDetail {  Name="Pussy1", Type=PetType.CAT, FoodType=FoodType.Fish} }
                    }
                };
            }
        }

        public object GetExamples()
        {
            return new Link<PetOwner<PetMoreDetail>> {
                Links = new List<LinkInfo> { new LinkInfo { Href = "endpoint", Method = "http-method-name", Rel = "self" } },
                Data= new PetOwner<PetMoreDetail>
                {
                    Id = 1,
                    Name = "Owner1",
                    Pets = new List<PetMoreDetail>
                    {
                        new PetMoreDetail
                        {
                             Name="Doggy", FoodType=FoodType.Bones, Type=PetType.DOG
                        }
                    }
                }
            };
        }
    }
}
