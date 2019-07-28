using Microsoft.AspNetCore.Mvc;
using Moq;
using PetRego.Demo.Domain;
using PetRego.Demo.Test.FakeData;
using PetRego.Demo.V2.Controllers;
using PetRego.Demo.V1.Models;
using PetRego.Demo.V2.Data;
using PetRego.Demo.V2.Models;
using System;
using System.Linq;
using Xunit;

namespace PetRego.Demo.Test
{
    public class PetOwnerControllerTestV2:IDisposable
    {
        Mock<IPetRegoService> moqPetService;
        Mock<ILinkService<PetDetailData>> moqLinkService;
        public PetOwnerControllerTestV2()
        {
            moqPetService = new Mock<IPetRegoService>();
            moqLinkService = new Mock<ILinkService<PetDetailData>>();
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
            moqPetService.Setup(m => m.GetPetOwnerAndPet<PetDetailData>(It.IsAny<int>(),It.IsAny<int>())).Returns(OwnerAndPetDetailData.Owners.FirstOrDefault());
            moqLinkService.Setup(m => m.GetLink(It.IsAny<PetOwner<PetDetailData>>())).Returns(TestData.GetLinksDetailWrapper);
            var sut = new PetOwnersController(moqPetService.Object, moqLinkService.Object);

            //when
            var result = sut.Get(petOwnerId);
            OkObjectResult objectResult = result as OkObjectResult;
            Link<PetOwner<PetDetailData>> owners = objectResult.Value as Link<PetOwner<PetDetailData>>;

            //then
            Assert.NotNull(result);
            Assert.NotNull(objectResult);
            Assert.Equal(200, objectResult.StatusCode);
            Assert.NotNull(owners);
            moqPetService.Verify(v => v.GetPetOwnerAndPet<PetDetailData>(It.IsAny<int>(),It.IsAny<int>()), Times.Once);
        }
        [Fact]
        public void Get_with_invalid_Id_returns_status_500()
        {
            //given
            int petOwnerId = 1;
            moqPetService.Setup(m => m.GetPetOwnerAndPet<PetDetailData>(It.IsAny<int>(), It.IsAny<int>())).Throws(new Exception());
            var sut = new PetOwnersController(moqPetService.Object, moqLinkService.Object);

            //when
            var result = sut.Get(petOwnerId);
            StatusCodeResult objectResult = result as StatusCodeResult;

            //then
            Assert.NotNull(result);
            Assert.NotNull(objectResult);
            Assert.Equal(500, objectResult.StatusCode);
            moqPetService.Verify(v => v.GetPetOwnerAndPet<PetBasicData>(It.IsAny<int>(),It.IsAny<int>()), Times.Never);
        }
        [Fact]
        public void Get_with_invalid_Id_returns_status_404()
        {
            //given
            int petOwnerId = 1;
            moqPetService.Setup(m => m.GetPetOwnerAndPet<PetDetailData>(It.IsAny<int>(), It.IsAny<int>())).Returns(default(PetOwner<PetDetailData>));
            var sut = new PetOwnersController(moqPetService.Object, moqLinkService.Object);

            //when
            var result = sut.Get(petOwnerId);
            StatusCodeResult objectResult = result as StatusCodeResult;

            //then
            Assert.NotNull(result);
            Assert.NotNull(objectResult);
            Assert.Equal(404, objectResult.StatusCode);
            moqPetService.Verify(v => v.GetPetOwnerAndPet<PetDetailData>(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
    }
}
