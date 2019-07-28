using PetRego.Demo.Models.V1;
using PetRego.Demo.Models.V2;
using Swashbuckle.AspNetCore.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRego.Demo.Helper
{
    public class Sample2Data: IExamplesProvider
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
