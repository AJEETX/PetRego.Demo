using Microsoft.AspNetCore.Mvc;
using Moq;
using PetRego.Demo.Controllers;
using PetRego.Demo.Domain;
using PetRego.Demo.Helper;
using PetRego.Demo.Model;
using PetRego.Demo.Model.V1;
using PetRego.Demo.Test.FakeData;
using System;
using System.Collections.Generic;
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
        public void GetPetOwners_returns_all_petOwners_details_successfully()
        {
            //given
            moqPetService.Setup(m => m.GetPetOwners()).Returns(SampleData.Owners);
            moqLinkService.Setup(m => m.GetLink(It.IsAny<PetOwner>())).Returns(TestData.GetLinksWrapper);
            var sut = new PetOwnersController( moqPetService.Object, moqLinkService.Object);

            //when
            var result = sut.Get();
            OkObjectResult objectResult = result as OkObjectResult;
            IEnumerable<Link<PetOwner>> owners = objectResult.Value as IEnumerable<Link<PetOwner>>;

            //then
            Assert.NotNull(result);
            Assert.NotNull(objectResult);
            Assert.NotNull(owners);
            moqPetService.Verify(v => v.GetPetOwners(), Times.Once);
        }
        [Fact]
        public void GetPetOwners_returns_all_petOwners_details_unsuccessfully_with_status_500()
        {
            //given
            moqPetService.Setup(m => m.GetPetOwners()).Throws(new Exception());
            var sut = new PetOwnersController(moqPetService.Object, moqLinkService.Object);

            //when
            var result = sut.Get();
            StatusCodeResult objectResult = result as StatusCodeResult;

            //then
            Assert.NotNull(result);
            Assert.NotNull(objectResult);
            Assert.Equal(500, objectResult.StatusCode);
            moqPetService.Verify(v => v.GetPetOwners(), Times.Once);
        }
    }
}
