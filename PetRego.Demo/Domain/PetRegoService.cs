using PetRego.Demo.Helper;
using PetRego.Demo.Model;
using PetRego.Demo.Model.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRego.Demo.Domain
{
    public interface IPetRegoService
    {
        IEnumerable<PetOwner> GetPetOwners();

        PetOwnerAndFooding GetOwnerPetFoodingDetail(int id);

    }
    public class PetRegoService : IPetRegoService
    {
        public PetOwnerAndFooding GetOwnerPetFoodingDetail(int id)
        {
            return SampleData.GetPetOwnerAndFooding;
        }

        public IEnumerable<PetOwner> GetPetOwners()
        {
            return SampleData.Owners;
        }
    }
}
