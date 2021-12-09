using Xunit;
using Trainor.Storage;
using Trainor.Storage.Entities;

namespace Trainor.Storage.Tests{

    public class ResourceComparatorTests
    {
        [Fact]
        public void Given_Same_Name_And_Author_With_Two_ResourceDTOs_IsEqual_Returns_True() 
        {
            //Arrange
            var dto1 = new ResourceDto("skrrt", new []{"skrrtacus"});
            var dto2 = new ResourceDto("skrrt", new []{"skrrtacus"});

            //Act
            var equal = dto1.IsEqual(dto2);

            //Assert
            Assert.True(equal);
        }

        [Fact]
        public void Given_Same_Name_But_Separate_Author_With_Two_ResourceDTOs_IsEqual_Returns_False()
        {
            //Arrange
            var dto1 = new ResourceDto("skrrt", new []{"skrrtacus"});
            var dto2 = new ResourceDto("skrrt", new []{"gækkacus"});

            //Act
            var equal = dto1.IsEqual(dto2);

            //Assert
            Assert.False(equal);
        }

        [Fact]
        public void Given_Separate_Name_But_Same_Author_With_Two_ResourceDTOs_IsEqual_Returns_False()
        {
            //Arrange
            var dto1 = new ResourceDto("gæk", new []{"skrrtacus"});
            var dto2 = new ResourceDto("skrrt", new []{"skrrtacus"});

            //Act
            var equal = dto1.IsEqual(dto2);

            //Assert
            Assert.False(equal);
        }
    }
}