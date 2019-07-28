using PetRego.Demo.Domain;
using PetRego.Demo.Models;
using PetRego.Demo.Models.V1;
using PetRego.Demo.Models.V2;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetRego.Demo.Test
{
    public class PetRegoServiceTest
    {
        [Fact]
        public void GetPetOwners_returns_list_of_Owners_successfully()
        {
            //given
            int petOwnerId = 1;
            var sut = new PetRegoService();

            //when
            var result = sut.GetPetOwnerAndPet(petOwnerId);

            //then
            Assert.IsAssignableFrom<PetOwner<Pet>>(result);
        }
    }
}
