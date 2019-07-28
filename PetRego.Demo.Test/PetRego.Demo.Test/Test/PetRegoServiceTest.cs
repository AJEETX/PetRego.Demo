using PetRego.Demo.Domain;
using PetRego.Demo.Model;
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
            var sut = new PetRegoService();

            //when
            var result = sut.GetPetOwners();

            //then
            Assert.IsAssignableFrom<IEnumerable<PetOwner>>(result);
        }
    }
}
