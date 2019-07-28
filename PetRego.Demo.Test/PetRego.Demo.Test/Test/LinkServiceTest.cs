using Microsoft.AspNetCore.Mvc;
using Moq;
using PetRego.Demo.Domain;
using PetRego.Demo.Test.FakeData;
using PetRego.Demo.V1.Models;
using Xunit;

namespace PetRego.Demo.Test
{
    public class LinkServiceTest
    {
        [Fact]
        public void ToOutputModel_Links_returns_wrapper_links_successfully()
        {
            //given
            var input = TestData.Owner;
            var moqlUrlHelper = new Mock<IUrlHelper>();
            moqlUrlHelper.Setup(m => m.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("TestUrl").Verifiable();
            var sut = new LinkService(moqlUrlHelper.Object);

            //when
            var result = sut.GetLink(input);

            //then
            Assert.IsType<Link<PetOwner<Pet>>>(result);
            moqlUrlHelper.Verify(v => v.Link(It.IsAny<string>(), It.IsAny<object>()), Times.Exactly(1));
        }
        //[Fact]
        //public void ToOutputModel_Links_returns_null()
        //{
        //    //given
        //    List<Owner> input = null;
        //    var moqlUrlHelper = new Mock<IUrlHelper>();
        //    var sut = new LinkService(moqlUrlHelper.Object);

        //    //when
        //    var result = sut.GetLinks(input);

        //    //then
        //    Assert.Null(result);
        //    moqlUrlHelper.Verify(v => v.Link(It.IsAny<string>(), It.IsAny<object>()), Times.Exactly(0));
        //}
    }
}
