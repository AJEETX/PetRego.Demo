using PetRego.Demo.V1.Data;
using PetRego.Demo.V1.Models;
using PetRego.Demo.V2.Models;
using Swashbuckle.AspNetCore.Examples;
using System.Collections.Generic;

namespace PetRego.Demo.V2.Data
{
    public interface IOwnerAndPetDetailData : IOwnerAndPetData { }
    public class OwnerAndPetDetailData : IExamplesProvider, IOwnerAndPetDetailData
    {
        public static List<PetOwner<PetDetailData>> Owners
        {
            get
            {
                return new List<PetOwner<PetDetailData>> {
                    new PetOwner<PetDetailData>{
                         Id=1, Name="Owner1", Pets=new List<PetDetailData>{ new PetDetailData {  Name="Pussy1", Type=PetType.CAT, FoodType=FoodType.Fish},
                             new PetDetailData { Name = "Python", Type = PetType.SNAKE, FoodType = FoodType.Mice } }
                    },
                    new PetOwner<PetDetailData>{
                         Id=2, Name="Owner2", Pets=new List<PetDetailData>{ new PetDetailData {  Name="Doggy", Type=PetType.DOG, FoodType=FoodType.Bones},
                         new PetDetailData {  Name="Chicky1", Type=PetType.CHICKEN, FoodType=FoodType.Corn} }
                    },
                    new PetOwner<PetDetailData>{
                         Id=3, Name="Owner3", Pets=new List<PetDetailData>{ new PetDetailData {  Name="Chicky2", Type=PetType.CHICKEN, FoodType=FoodType.Corn} }
                    },
                    new PetOwner<PetDetailData>{
                         Id=4, Name="Owner4", Pets=new List<PetDetailData>{ new PetDetailData {  Name="Bamba1", Type=PetType.SNAKE, FoodType=FoodType.Mice},
                             new PetDetailData { Name = "Tommy", Type = PetType.DOG, FoodType = FoodType.Bones } }
                    },
                    new PetOwner<PetDetailData>{
                         Id=5, Name="Owner5", Pets=new List<PetDetailData>{ new PetDetailData {  Name="Pussy1", Type=PetType.CAT, FoodType=FoodType.Fish} }
                    }
                };
            }
        }

        public IEnumerable<PetOwner<T>> GetData<T>()
        {
            return Owners as IEnumerable<PetOwner<T>>;
        }

        public object GetExamples()
        {
            return new Link<PetOwner<PetDetailData>> {
                Links = new List<LinkInfo> { new LinkInfo { Href = "endpoint", Method = "http-method-name", Rel = "self" } },
                Data= new PetOwner<PetDetailData>
                {
                    Id = 1,
                    Name = "Owner1",
                    Pets = new List<PetDetailData>
                    {
                        new PetDetailData
                        {
                             Name="Doggy", FoodType=FoodType.Bones, Type=PetType.DOG
                        }
                    }
                }
            };
        }
    }
}
