using PetRego.Demo.V1.Models;
using PetRego.Demo.V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetRego.Demo.Domain
{
    public interface IPetRegoService
    {
        PetOwner<T> GetPetOwnerAndPet<T>(int id);
        PetOwner<PetBasicDetail> GetPetOwnerAndPet(int id);

        PetOwner<PetMoreDetail> GetPetOwnerAndPetFoodDetail(int id);
    }
    public class PetRegoService : IPetRegoService
    {
        public PetOwner<T> GetPetOwnerAndPet<T>(int id)
        {
            Dictionary<PetOwner<T>, int> dict = new Dictionary<PetOwner<T>, int>();
            dict.Add(new PetOwner<T>(), 1);
            throw new NotImplementedException();
        }
        public PetOwner<PetBasicDetail> GetPetOwnerAndPet(int id)
        {
            PetOwner<PetBasicDetail> petOwner = default(PetOwner<PetBasicDetail>);
            if (id == default(int)) return petOwner;
            try
            {
                petOwner= V1.Data.SampleData.Owners.Where(o => o.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                // shout //yell //log
            }
            return petOwner;
        }

        public PetOwner<PetMoreDetail> GetPetOwnerAndPetFoodDetail(int id)
        {
            PetOwner<PetMoreDetail> petOwner = default(PetOwner<PetMoreDetail>);
            if (id == default(int)) return petOwner;
            try
            {
                petOwner = V2.Data.SampleData.Owners.Where(o => o.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                // shout //yell //log
            }
            return petOwner;
        }
    }
}
