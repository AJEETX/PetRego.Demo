using PetRego.Demo.V1.Data;
using PetRego.Demo.V1.Models;
using PetRego.Demo.V2.Data;
using PetRego.Demo.V2.Models;
using System.Linq;

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
            return V1.Data.SampleData.Owners.Where(o => o.Id == id).FirstOrDefault();
        }
        public PetOwner<PetDetail> GetPetOwnerAndPetFoodDetail(int id)
        {
            return V2.Data.SampleData.GetPetOwnerAndFooding;
        }
    }
}
