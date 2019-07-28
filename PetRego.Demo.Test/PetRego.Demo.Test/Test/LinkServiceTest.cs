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
            var sut = new LinkService<PetBasicData>(moqlUrlHelper.Object);

            //when
            var result = sut.GetLink(input);

            //then
            Assert.NotNull(result);
            Assert.IsType<Link<PetOwner<PetBasicData>>>(result);
            moqlUrlHelper.Verify(v => v.Link(It.IsAny<string>(), It.IsAny<object>()), Times.Exactly(1));
        }
        [Fact]
        public void GetLink_with_invalid_input_returns_null()
        {
            //given
            PetOwner<PetBasicData> input = default(PetOwner<PetBasicData>);
            var sut = new LinkService<PetBasicData>(moqlUrlHelper.Object);

            //when
            var result = sut.GetLink(input);

            //then
            Assert.Null(result);
            moqlUrlHelper.Verify(v => v.Link(It.IsAny<string>(), It.IsAny<object>()), Times.Exactly(0));
        }
        [Fact]
        public void GetLink_with_valid_input_on_error_returns_null()
        {
            //given
            PetOwner<PetBasicData> input = TestData.Owner;
            moqlUrlHelper.Setup(m => m.Link(It.IsAny<string>(), It.IsAny<object>())).Throws(new Exception());
            var sut = new LinkService<PetBasicData>(moqlUrlHelper.Object);

            //when
            var result = sut.GetLink(input);

            //then
            Assert.Null(result);
            moqlUrlHelper.Verify(v => v.Link(It.IsAny<string>(), It.IsAny<object>()), Times.Exactly(1));
        }
        public void Dispose()
        {
            moqlUrlHelper=null;
        }
    }
}
