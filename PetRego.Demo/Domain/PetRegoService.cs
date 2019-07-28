using PetRego.Demo.V1.Models;
using PetRego.Demo.V2.Models;
using System.Linq;

namespace PetRego.Demo.Domain
{
    public interface IPetRegoService
    {
        PetOwner<PetBasicDetail> GetPetOwnerAndPet(int id);

        PetOwner<PetMoreDetail> GetPetOwnerAndPetFoodDetail(int id);

    }
    public class PetRegoService : IPetRegoService
    {
        public PetOwner<PetBasicDetail> GetPetOwnerAndPet(int id)
        {
            return V1.Data.SampleData.Owners.Where(o => o.Id == id).FirstOrDefault();
        }
        public PetOwner<PetMoreDetail> GetPetOwnerAndPetFoodDetail(int id)
        {
            return V2.Data.SampleData.Owners.Where(o=>o.Id==id).FirstOrDefault();
        }
    }
}
