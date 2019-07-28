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
        Mock<ILinkService<PetBasicData>> moqLinkService;
        public PetOwnerControllerTest()
        {
            moqPetService = new Mock<IPetRegoService>();
            moqLinkService = new Mock<ILinkService<PetBasicData>>();
        }

        public void Dispose()
        {
            moqPetService = null;
            moqLinkService = null;
        }

        [Fact]
        public void Get_with_valid_id_returns_petOwner_and_pet_details_successfully()
        {
            //given
            int petOwnerId = 1;
            moqPetService.Setup(m => m.GetPetOwnerAndPet<PetBasicData>(It.IsAny<int>(),It.IsAny<int>())).Returns(OwnerAndPetBasicData.Owners.FirstOrDefault());
            moqLinkService.Setup(m => m.GetLink(It.IsAny<PetOwner<PetBasicData>>())).Returns(TestData.GetLinksWrapper);
            var sut = new PetOwnersController( moqPetService.Object, moqLinkService.Object);

            //when
            var result = sut.Get(petOwnerId);
            OkObjectResult objectResult = result as OkObjectResult;
            Link<PetOwner<PetBasicData>> owners = objectResult.Value as Link<PetOwner<PetBasicData>>;

            //then
            Assert.NotNull(result);
            Assert.NotNull(objectResult);
            Assert.NotNull(owners);
            moqPetService.Verify(v => v.GetPetOwnerAndPet<PetBasicData>(It.IsAny<int>(),It.IsAny<int>()), Times.Once);
        }
        [Fact]
        public void Get_with_invalid_Id_returns_status_500()
        {
            //given
            int petOwnerId = 1;
            moqPetService.Setup(m => m.GetPetOwnerAndPet<PetBasicData>(It.IsAny<int>(), It.IsAny<int>())).Throws(new Exception());
            var sut = new PetOwnersController(moqPetService.Object, moqLinkService.Object);

            //when
            var result = sut.Get(petOwnerId);
            StatusCodeResult objectResult = result as StatusCodeResult;

            //then
            Assert.NotNull(result);
            Assert.NotNull(objectResult);
            Assert.Equal(500, objectResult.StatusCode);
            moqPetService.Verify(v => v.GetPetOwnerAndPet<PetBasicData>(It.IsAny<int>(),It.IsAny<int>()), Times.Once);
        }
        [Fact]
        public void Get_with_invalid_Id_returns_status_404()
        {
            //given
            int petOwnerId = 1;
            moqPetService.Setup(m => m.GetPetOwnerAndPet<PetBasicData>(It.IsAny<int>(), It.IsAny<int>())).Returns(default(PetOwner<PetBasicData>));
            var sut = new PetOwnersController(moqPetService.Object, moqLinkService.Object);

            //when
            var result = sut.Get(petOwnerId);
            StatusCodeResult objectResult = result as StatusCodeResult;

            //then
            Assert.NotNull(result);
            Assert.NotNull(objectResult);
            Assert.Equal(404, objectResult.StatusCode);
            moqPetService.Verify(v => v.GetPetOwnerAndPet<PetBasicData>(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
    }
}
