using Microsoft.AspNetCore.Mvc;
using Moq;
using PetRego.Demo.Domain;
using PetRego.Demo.Test.FakeData;
using PetRego.Demo.V1.Controllers;
using PetRego.Demo.V1.Data;
using PetRego.Demo.V1.Models;
using System;
using System.Linq;
using Xunit;

namespace PetRego.Demo.Test
{
    public class PetOwnerControllerTest:IDisposable
    {
        Mock<IPetRegoService> moqPetService;
        Mock<ILinkService> moqLinkService;
        public PetOwnerControllerTest()
        {
            moqPetService = new Mock<IPetRegoService>();
            moqLinkService = new Mock<ILinkService>();
        }

        public void Dispose()
        {
            moqPetService = null;
            moqLinkService = null;
        }

        [Fact]
        public void GetOwnerPet_returns_all_petOwner_pet_details_successfully()
        {
            //given
            int petOwnerId = 1;
            moqPetService.Setup(m => m.GetPetOwnerAndPet(It.IsAny<int>())).Returns(SampleData.Owners.FirstOrDefault());
            moqLinkService.Setup(m => m.GetLink(It.IsAny<PetOwner<Pet>>())).Returns(TestData.GetLinksWrapper);
            var sut = new PetOwnersController( moqPetService.Object, moqLinkService.Object);

            //when
            var result = sut.Get(petOwnerId);
            OkObjectResult objectResult = result as OkObjectResult;
            Link<PetOwner<Pet>> owners = objectResult.Value as Link<PetOwner<Pet>>;

            //then
            Assert.NotNull(result);
            Assert.NotNull(objectResult);
            Assert.NotNull(owners);
            moqPetService.Verify(v => v.GetPetOwnerAndPet(It.IsAny<int>()), Times.Once);
        }
        [Fact]
        public void GetOwnerPet_returns_all_petOwners_details_unsuccessfully_with_status_500()
        {
            //given
            int petOwnerId = 1;
            moqPetService.Setup(m => m.GetPetOwnerAndPet(It.IsAny<int>())).Throws(new Exception());
            var sut = new PetOwnersController(moqPetService.Object, moqLinkService.Object);

            //when
            var result = sut.Get(petOwnerId);
            StatusCodeResult objectResult = result as StatusCodeResult;

            //then
            Assert.NotNull(result);
            Assert.NotNull(objectResult);
            Assert.Equal(500, objectResult.StatusCode);
            moqPetService.Verify(v => v.GetPetOwnerAndPet(It.IsAny<int>()), Times.Once);
        }
    }
}
