using Microsoft.AspNetCore.Mvc;
using Moq;
using PetRego.Demo.Controllers;
using PetRego.Demo.Controllers.V1;
using PetRego.Demo.Domain;
using PetRego.Demo.Helper;
using PetRego.Demo.Models;
using PetRego.Demo.Models.V1;
using PetRego.Demo.Models.V2;
using PetRego.Demo.Test.FakeData;
using System;
using System.Collections.Generic;
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
            moqPetService.Setup(m => m.GetPetOwnerAndPet(It.IsAny<int>())).Returns(Sample1Data.Owners.FirstOrDefault());
            moqLinkService.Setup(m => m.GetLink(It.IsAny<PetOwner<Pet>>())).Returns(TestData.GetLinksWrapper);
            var sut = new PetOwnersController( moqPetService.Object, moqLinkService.Object);

            //when
            var result = sut.GetOwnerPet(petOwnerId);
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
            var result = sut.GetOwnerPet(petOwnerId);
            StatusCodeResult objectResult = result as StatusCodeResult;

            //then
            Assert.NotNull(result);
            Assert.NotNull(objectResult);
            Assert.Equal(500, objectResult.StatusCode);
            moqPetService.Verify(v => v.GetPetOwnerAndPet(It.IsAny<int>()), Times.Once);
        }
    }
}
