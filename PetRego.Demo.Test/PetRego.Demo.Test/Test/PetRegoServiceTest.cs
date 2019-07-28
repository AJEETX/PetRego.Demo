using Moq;
using PetRego.Demo.Domain;
using PetRego.Demo.V1.Data;
using PetRego.Demo.V1.Models;
using PetRego.Demo.V2.Data;
using System;
using Xunit;

namespace PetRego.Demo.Test
{
    public class PetRegoServiceTest:IDisposable
    {
        Mock<IOwnerAndPetBasicData> moqOwnerAndPetBasicData;
        Mock<IOwnerAndPetDetailData> moqOwnerAndPetDetailData;
        public PetRegoServiceTest()
        {
            moqOwnerAndPetBasicData = new Mock<IOwnerAndPetBasicData>();
            moqOwnerAndPetDetailData = new Mock<IOwnerAndPetDetailData>();
        }

        public void Dispose()
        {
            moqOwnerAndPetBasicData = null;
            moqOwnerAndPetDetailData=null;
        }

        [Fact]
        public void GetPetOwnerAndPet_returns_list_of_Owners_successfully()
        {
            //given
            int version=1, petOwnerId = 1;
            moqOwnerAndPetBasicData.Setup(m => m.GetData<PetBasicData>()).Returns(FakeData.TestData.GetOwners);
            var sut = new PetRegoService(moqOwnerAndPetBasicData.Object,moqOwnerAndPetDetailData.Object);

            //when
            var result = sut.GetPetOwnerAndPet<PetBasicData>(version, petOwnerId);

            //then
            Assert.NotNull(result);
            Assert.IsAssignableFrom<PetOwner<PetBasicData>>(result);
            moqOwnerAndPetBasicData.Verify(v => v.GetData<PetBasicData>(), Times.Once);
        }
        [Theory]
        [InlineData(1,0)]
        [InlineData(0,1)]
        public void GetPetOwnerAndPet_with_invalid_id_returns_null(int version,int petOwnerId)
        {
            //given
            var sut = new PetRegoService(moqOwnerAndPetBasicData.Object, moqOwnerAndPetDetailData.Object);

            //when
            var result = sut.GetPetOwnerAndPet<PetBasicData>(version, petOwnerId);

            //then
            Assert.Null(result);
            moqOwnerAndPetBasicData.Verify(v => v.GetData<PetBasicData>(), Times.Never);
        }
        [Fact]
        public void GetPetOwnerAndPet_with_valid_input_on_error_returns_null()
        {
            //given
            int version = 1, petOwnerId = 1;
            moqOwnerAndPetBasicData.Setup(m => m.GetData<PetBasicData>()).Throws(new Exception());
            var sut = new PetRegoService(moqOwnerAndPetBasicData.Object, moqOwnerAndPetDetailData.Object);

            //when
            var result = sut.GetPetOwnerAndPet<PetBasicData>(version, petOwnerId);

            //then
            Assert.Null(result);
            moqOwnerAndPetBasicData.Verify(v => v.GetData<PetBasicData>(), Times.Once);
        }
    }
}
