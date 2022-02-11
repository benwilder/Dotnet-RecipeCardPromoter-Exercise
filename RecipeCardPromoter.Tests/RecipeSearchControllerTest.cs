using Xunit;
using RecipeCardPromoter.Api.Controllers;
using RecipeCardPromoter.Api.Models;
using RecipeCardPromoter.Api.Contracts;
using RecipeCardPromoter.Api.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;

namespace RecipeCardPromoter.tests;

public class RecipeSearchControllerTest
{
    RecipeSearchController _controller;
    public RecipeSearchControllerTest()
    {
        var _mockLogger = Mock.Of<ILogger<RecipeSearchController>>();
        var _mockServiceLogger = Mock.Of<ILogger<RecipeSearchService>>();

        var _service = new RecipeSearchService(_mockServiceLogger);
        _controller = new RecipeSearchController(_mockLogger,_service);

    }

    [Fact]
    public void GetAllTest()
    {
        // Arrange
        string[] testSearchArray = new string[]{"oil"};
        
        // Act
        var result = _controller.Search(testSearchArray);
        
        // Assert
        
        // Check that we have an "OK" result
        Assert.IsType<OkObjectResult>(result.Result);
        var list = result.Result as OkObjectResult;

        // Check that the items are RecipeSearchResult items
        Assert.IsType<List<RecipeSearchResult>>(list?.Value);

        // Check that we have 5 items
        var listRecipeResults = list?.Value as List<RecipeSearchResult>;
        Assert.Equal(5, listRecipeResults?.Count);
    }

    [Fact]
    public void GetOrderedTest()
    {
        // Arrange
        string[] testSearchArray = new string[]{"oil","tomatoes","bacon"};
        
        // Act
        var result = _controller.Search(testSearchArray);
        
        // Assert
        
        // Check that we have an "OK" result
        Assert.IsType<OkObjectResult>(result.Result);
        var list = result.Result as OkObjectResult;

        // Check that the items are RecipeSearchResult items
        Assert.IsType<List<RecipeSearchResult>>(list?.Value);

        // Check that we have 5 items
        var listRecipeResults = list?.Value as List<RecipeSearchResult>;
        Assert.Equal(5, listRecipeResults?.Count);

        // Check item order and count
        Assert.Equal(3, listRecipeResults?[0].matches);
        Assert.Equal(2, listRecipeResults?[1].matches);
        Assert.Equal(2, listRecipeResults?[2].matches);
        Assert.Equal(1, listRecipeResults?[3].matches);
        Assert.Equal(1, listRecipeResults?[4].matches);
    }

    //[Fact]
    public void GetCasingTest()
    {
        //TODO
    }
}
