using System;
using Xunit;

namespace Trainor.App.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GetByNameReturnsCorrectList()
        {
            //Arrange
            List<Resource> queriedReturnedResources = new List<Resource>();
            for (int i = 0; i < 5; i++) 
            {
                queriedReturnedResources(i) = new Resource("Res" + i, "www", "oskar", "file", new DateTime(2000, 10, 10));
                queriedReturnedResources(i) = new Resource("Res" + i, "www", "oskar", "file", new DateTime(2000, 10, 10));
            }
            List<Resource> desiredReturnedResources = new List<Resource>();
            for (int i = 0; i < 1; i++) 
            {
                desiredReturnedResources(i) = new Resource("Res" + i, "www", "oskar", "file", new DateTime(2000, 10, 10));
                desiredReturnedResources(i) = new Resource("Res" + i, "www", "oskar", "file", new DateTime(2000, 10, 10));
            }
            List<Resource> actualReturnedResources;

            //Act
            actualReturnedResources = Search

            //Assert


        }
    }
}
