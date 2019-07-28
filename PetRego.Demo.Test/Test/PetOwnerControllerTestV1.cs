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
    public class PetOwnerControllerTestV1:IDisposable
    {
        Mock<IPetRegoService> moqPetService;
        Mock<ILinkService<PetBasicData>> moqLinkService;
        public PetOwnerControllerTestV1()
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
            Assert.Equal(200, objectResult.StatusCode);
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
        [Fact]
        public void Post_with_valid_input_adds_petOwner_successfully()
        {
            //given
            PetOwner<PetBasicData> input = TestData.Owner;
            moqPetService.Setup(m => m.AddPetOwner<PetBasicData>(It.IsAny<int>(), It.IsAny<PetOwner<PetBasicData>>())).Verifiable();
            var sut = new PetOwnersController(moqPetService.Object, moqLinkService.Object);

            //when
            var result = sut.Post(TestData.Owner);

            //then
            CreatedAtRouteResult objectResult = result as CreatedAtRouteResult;

            //then
            Assert.NotNull(result);
            Assert.NotNull(objectResult);
            Assert.Equal(201, objectResult.StatusCode);
            moqPetService.Verify(v => v.AddPetOwner<PetBasicData>(It.IsAny<int>(), It.IsAny<PetOwner<PetBasicData>>()), Times.Once);
        }
        [Fact]
        public void Post_with_invalid_input_returns_400()
        {
            //given
            PetOwner<PetBasicData> input = default(PetOwner<PetBasicData>);
            moqPetService.Setup(m => m.AddPetOwner<PetBasicData>(It.IsAny<int>(), It.IsAny<PetOwner<PetBasicData>>())).Verifiable();
            var sut = new PetOwnersController(moqPetService.Object, moqLinkService.Object);

            //when
            var result = sut.Post(input);

            //then
            BadRequestResult objectResult = result as BadRequestResult;

            //then
            Assert.NotNull(result);
            Assert.NotNull(objectResult);
            Assert.Equal(400, objectResult.StatusCode);
            moqPetService.Verify(v => v.AddPetOwner<PetBasicData>(It.IsAny<int>(), It.IsAny<PetOwner<PetBasicData>>()), Times.Never);
        }
        [Fact]
        public void Post_when_throws_error_returns_500()
        {
            //given
            PetOwner<PetBasicData> input = TestData.Owner;
            moqPetService.Setup(m => m.AddPetOwner<PetBasicData>(It.IsAny<int>(), It.IsAny<PetOwner<PetBasicData>>())).Throws(new Exception());
            var sut = new PetOwnersController(moqPetService.Object, moqLinkService.Object);

            //when
            var result = sut.Post(input);

            //then
            StatusCodeResult objectResult = result as StatusCodeResult;

            //then
            Assert.NotNull(result);
            Assert.NotNull(objectResult);
            Assert.Equal(500, objectResult.StatusCode);
            moqPetService.Verify(v => v.AddPetOwner<PetBasicData>(It.IsAny<int>(), It.IsAny<PetOwner<PetBasicData>>()), Times.Once);
        }
    }
}
