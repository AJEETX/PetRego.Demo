using PetRego.Demo.V1.Models;
using PetRego.Demo.V2.Models;
using Swashbuckle.AspNetCore.Examples;
using System.Collections.Generic;

namespace PetRego.Demo.V2.Data
{
    public class SampleData : IExamplesProvider
    {
        public static PetOwner<PetDetail> GetPetOwnerAndFooding
        {
            get
            {
                return new PetOwner<PetDetail>
                {
                    Id = 1,
                    Name = "Owner1",
                    Pets = new List<PetDetail>
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
            return GetPetOwnerAndFooding;
        }
    }
}
