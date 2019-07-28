using PetRego.Demo.V1.Data;
using PetRego.Demo.V1.Models;
using PetRego.Demo.V2.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetRego.Demo.Domain
{
    public interface IPetRegoService
    {
        PetOwner<T> GetPetOwnerAndPet<T>(int version,int id);
        void AddPetOwner<T>(int version,PetOwner<T> model);
    }
    public class PetRegoService : IPetRegoService
    {
        Dictionary<int, IOwnerAndPetData> dict = new Dictionary<int, IOwnerAndPetData>();
        public PetRegoService(IOwnerAndPetBasicData ownerAndPetBasicData,IOwnerAndPetDetailData  ownerAndPetDetailData)
        {
            dict.Add(1, ownerAndPetBasicData);
            dict.Add(2, ownerAndPetDetailData);
        }

        public void AddPetOwner<T>(int version,PetOwner<T> model)
        {
            if (model == default(PetOwner<T>)) return;
            try
            {
                var petOwners = dict[version].GetPetOwnerData<T>().ToList();
                petOwners.Add(model);
            }
            catch (Exception)
            {
                // shout //yell //log
            }
        }

        public PetOwner<T> GetPetOwnerAndPet<T>(int version,int id)
        {
            PetOwner<T> petOwner = default(PetOwner<T>);
            if (version == default(int) || id == default(int)) return petOwner;
            try
            {
                petOwner = dict[version].GetPetOwnerData<T>().Where(o => o.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                // shout //yell //log
            }
            return petOwner;
        }
    }
}
