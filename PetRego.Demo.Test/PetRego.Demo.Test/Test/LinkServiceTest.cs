using Microsoft.AspNetCore.Mvc;
using Moq;
using PetRego.Demo.Domain;
using PetRego.Demo.Test.FakeData;
using PetRego.Demo.V1.Models;
using System;
using Xunit;

namespace PetRego.Demo.Test
{
    public class LinkServiceTest:IDisposable
    {
        Mock<IUrlHelper> moqlUrlHelper;
        public LinkServiceTest()
        {
            moqlUrlHelper = new Mock<IUrlHelper>();
        }
        [Fact]
        public void GetLink_with_valid_input_returns_wrapper_links_successfully()
        {
            //given
            var input = TestData.Owner;
            moqlUrlHelper.Setup(m => m.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("TestUrl").Verifiable();
            var sut = new LinkService<PetBasicDetail>(moqlUrlHelper.Object);

            //when
            var result = sut.GetLink(input);

            //then
            Assert.NotNull(result);
            Assert.IsType<Link<PetOwner<PetBasicDetail>>>(result);
            moqlUrlHelper.Verify(v => v.Link(It.IsAny<string>(), It.IsAny<object>()), Times.Exactly(1));
        }
        [Fact]
        public void GetLink_with_valid_input_returns_null()
        {
            //given
            PetOwner<PetBasicDetail> input = null;
            var sut = new LinkService<PetBasicDetail>(moqlUrlHelper.Object);

            //when
            var result = sut.GetLink(input);

            //then
            Assert.Null(result);
            moqlUrlHelper.Verify(v => v.Link(It.IsAny<string>(), It.IsAny<object>()), Times.Exactly(0));
        }

        public void Dispose()
        {
            moqlUrlHelper=null;
        }
    }
}
