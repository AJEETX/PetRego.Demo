using PetRego.Demo.Domain;
using PetRego.Demo.V1.Models;
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
