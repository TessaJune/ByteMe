using Xunit;
using Trainor.Storage.Entities;
using Trainer.Storage;

namespace Trainor.Storage.Tests{

    public class ResourceComparatorTests
    {

        /*
        4 x 3 tests. 4 Methods with 3 scenarios
        4 IsEqual methods to handle different DTOs in different orders
        3 Scenarios: Name & Author equal, Name equal but Author not equal, Name not equal but Author equal 
        */

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
        //Above Tests for IsEqual containing two ResourceDTOs

        [Fact]
        public void Given_Same_Name_And_Author_With_One_ResourceDto_One_ResourceDetailsDTO_IsEqual_Returns_True()
        {
            //Arrange
            var dto1 = new ResourceDto("skrrt", new []{"skrrtacus"});
            var dto2 = new ResourceDetailsDto(1,"skrrt", "www.lmao.dk", new []{"skrrtacus"}, TypeTag.DOCUMENT, new []{SubjectTag.C_SHARP},System.DateTime.Now);

            //Act
            var equal = dto1.IsEqual(dto2);

            //Assert
            Assert.True(equal);
        }

        [Fact]
        public void Given_Same_Name_But_Separate_Author_With_One_ResourceDto_One_ResourceDetailsDTO_IsEqual_Returns_False()
        {
            //Arrange
            var dto1 = new ResourceDto("skrrt", new []{"ed-boy"});
            var dto2 = new ResourceDetailsDto(1,"skrrt", "www.lmao.dk", new []{"skrrtacus"}, TypeTag.DOCUMENT, new []{SubjectTag.C_SHARP},System.DateTime.Now);

            //Act
            var equal = dto1.IsEqual(dto2);

            //Assert
            Assert.False(equal);
        }

        [Fact]
        public void Given_Separate_Name_But_Same_Author_With_One_ResourceDto_One_ResourceDetailsDTO_IsEqual_Returns_False()
        {
            //Arrange
            var dto1 = new ResourceDto("gækkington bear", new []{"skrrtacus"});
            var dto2 = new ResourceDetailsDto(1,"skrrt", "www.lmao.dk", new []{"skrrtacus"}, TypeTag.DOCUMENT, new []{SubjectTag.C_SHARP},System.DateTime.Now);

            //Act
            var equal = dto1.IsEqual(dto2);

            //Assert
            Assert.False(equal);
        }

        //Above Tests for IsEqual containing one ResourceDTO and one ResourceDetailsDTO in that order

        [Fact]
        public void Given_Same_Name_And_Author_With_One_ResourceDetailsDto_One_ResourceDTO_IsEqual_Returns_True()
        {
            //Arrange
            var dto1 = new ResourceDetailsDto(1,"skrrt", "www.lmao.dk", new []{"skrrtacus"}, TypeTag.DOCUMENT, new []{SubjectTag.C_SHARP},System.DateTime.Now);
            var dto2 = new ResourceDto("skrrt", new []{"skrrtacus"});
            

            //Act
            var equal = dto1.IsEqual(dto2);

            //Assert
            Assert.True(equal);
        }
        
        [Fact]
        public void Given_Same_Name_But_Separate_Author_With_One_ResourceDetailsDto_One_ResourceDTO_IsEqual_Returns_False()
        {
            //Arrange
            var dto1 = new ResourceDetailsDto(1,"skrrt", "www.lmao.dk", new []{"skrrtacus"}, TypeTag.DOCUMENT, new []{SubjectTag.C_SHARP},System.DateTime.Now);
            var dto2 = new ResourceDto("skrrt", new []{"Edward Gamerhands"});
            

            //Act
            var equal = dto1.IsEqual(dto2);

            //Assert
            Assert.False(equal);
        }
        
        [Fact]
        public void Given_Separate_Name_But_Same_Author_With_One_ResourceDetailsDto_One_ResourceDTO_IsEqual_Returns_False()
        {
            //Arrange
            var dto1 = new ResourceDetailsDto(1,"Lars", "www.lmao.dk", new []{"skrrtacus"}, TypeTag.DOCUMENT, new []{SubjectTag.C_SHARP},System.DateTime.Now);
            var dto2 = new ResourceDto("skrrt", new []{"skrrtacus"});
            

            //Act
            var equal = dto1.IsEqual(dto2);

            //Assert
            Assert.False(equal);
        }

        //Above Tests for isEqual containing one ResourceDetailsDTO and one ResourceDTO in that order
        
        [Fact]
        public void Given_Same_Name_And_Author_With_Two_ResourceDetailsDTOs_IsEqual_Returns_True()
        {
            //Arrange
            var dto1 = new ResourceDetailsDto(1,"skrrt", "www.lmao.dk", new []{"skrrtacus"}, TypeTag.DOCUMENT, new []{SubjectTag.C_SHARP},System.DateTime.Now);
            var dto2 = new ResourceDetailsDto(3,"skrrt", "www.lmaohvadskerder.dk", new []{"skrrtacus"}, TypeTag.PICTURE, new []{SubjectTag.C_SHARP},System.DateTime.Now);
            

            //Act
            var equal = dto1.IsEqual(dto2);

            //Assert
            Assert.True(equal);
        }
                
        [Fact]
        public void Given_Same_Name_But_Separate_Author_With_Two_ResourceDetailsDTOs_IsEqual_Returns_False()
        {
            //Arrange
            var dto1 = new ResourceDetailsDto(1,"skrrt", "www.lmao.dk", new []{"skrrtacus"}, TypeTag.DOCUMENT, new []{SubjectTag.C_SHARP},System.DateTime.Now);
            var dto2 = new ResourceDetailsDto(1,"skrrt", "www.lmao.dk", new []{"First Name: The, Last Name: Author"}, TypeTag.DOCUMENT, new []{SubjectTag.C_SHARP},System.DateTime.Now);
            

            //Act
            var equal = dto1.IsEqual(dto2);

            //Assert
            Assert.False(equal);
        }
                        
        [Fact]
        public void Given_Separate_Name_But_Same_Author_With_Two_ResourceDetailsDTOs_IsEqual_Returns_False()
        {
            //Arrange
            var dto1 = new ResourceDetailsDto(1,"skrrt", "www.lmao.dk", new []{"skrrtacus"}, TypeTag.DOCUMENT, new []{SubjectTag.C_SHARP},System.DateTime.Now);
            var dto2 = new ResourceDetailsDto(1,"Very Cool Name", "www.lmao.dk", new []{"skrrtacus"}, TypeTag.DOCUMENT, new []{SubjectTag.C_SHARP},System.DateTime.Now);
            

            //Act
            var equal = dto1.IsEqual(dto2);

            //Assert
            Assert.False(equal);
        }
    }
}