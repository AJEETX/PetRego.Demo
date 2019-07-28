using PetRego.Demo.Helper;
using PetRego.Demo.Models;
using PetRego.Demo.Models.V1;
using PetRego.Demo.Models.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRego.Demo.Domain
{
    public interface IPetRegoService
    {
        PetOwner<Pet> GetPetOwnerAndPet(int id);

        PetOwner<PetDetail> GetPetOwnerAndPetFoodDetail(int id);

    }
    public class PetRegoService : IPetRegoService
    {
        public PetOwner<Pet> GetPetOwnerAndPet(int id)
        {
            return Sample1Data.Owners.Where(o => o.Id == id).FirstOrDefault();
        }
        public PetOwner<PetDetail> GetPetOwnerAndPetFoodDetail(int id)
        {
            return Sample2Data.GetPetOwnerAndFooding;
        }

    }
}
