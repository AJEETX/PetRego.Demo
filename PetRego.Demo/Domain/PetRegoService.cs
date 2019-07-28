using PetRego.Demo.Helper;
using PetRego.Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRego.Demo.Domain
{
    public interface IPetRegoService
    {
        IEnumerable<PetOwner> GetPetOwners();

    }
    public class PetRegoService : IPetRegoService
    {
        public IEnumerable<PetOwner> GetPetOwners()
        {
            return SampleData.Owners;
        }
    }
}
