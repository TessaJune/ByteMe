using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Npgsql.Logging;
using Trainor.Storage;
using Trainor.Storage.Entities;
using Xunit;

namespace Trainor.App.Tests;

public class Tests
{
    private Mock<ResourceDto> resourceDtoMock;
    private Mock<ISearch> iSearchMock;
    private Mock<IResourceRepository> iRepoMock;
    private List<ResourceDto> resourceList;
    private ResourceDto resourceDto;
    private Search search;
    
    public Tests()
    {
        resourceDto = new ResourceDto(0, null, "www", null, null, null, null);
        resourceDtoMock = new();
        iSearchMock = new();
        iRepoMock = new();
        resourceList = new();
    }
    
    [Fact]
    public async Task SearchWithoutFilterReturnsList()
    {
        //Arrange
        resourceList.Add(resourceDto);
        iRepoMock.Setup(i => i.ReadAsync()).ReturnsAsync((CrudStatus.Ok, resourceList));
        search = new Search(iRepoMock.Object);

        //Act
        var result = await search.SearchAllAsync();

        //Assert
        Assert.Equal("www", result.ElementAt(0).link);
    }
    
}