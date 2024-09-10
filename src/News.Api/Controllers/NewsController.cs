using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using News.Api.Contracts;
using News.Application;

namespace News.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class NewsController: ControllerBase
{
    private readonly string _staticFilePath=
            Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles/Images");
    private readonly NewsService _newsService;
    private readonly ImageService _imageService;
    public NewsController(NewsService newsService, ImageService imageService)
    {
        _imageService = imageService;
        _newsService = newsService;
    }
     [HttpPost]
    public async Task<IActionResult> CreateNews( NewsRequest newsRequest)
    {
        var imageResult=await _imageService.CreateImage(newsRequest.titleImage, _staticFilePath);
        if(imageResult.IsFailure)
            return BadRequest(imageResult.Error);
        var newsResult=Domain.News.Create(
            Guid.NewGuid(), 
            newsRequest.Title,
            newsRequest.textData, 
            imageResult.Value);
        if(newsResult.IsFailure)
            return BadRequest(newsResult.Error);
        return Ok(newsResult.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CountView(Domain.News news)
    {
        await _newsService.CountView(news);
        return Ok();
    }
}