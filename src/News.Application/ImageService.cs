using System.Net.Mime;
using CSharpFunctionalExtensions;
using News.Domain;
using Microsoft.AspNetCore.Http;

namespace News.Application;

public class ImageService
{
    public async Task<Result<Image>> CreateImage(IFormFile titleImage, string path)
    {
        try
        {
            var fileName = Path.GetFileName(titleImage.FileName);
            var filePath=Path.Combine(path, fileName);

            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await titleImage.CopyToAsync(stream);
            }
            
            var image=Image.Create(filePath);
            return Result.Success<Image>(image.Value);;
        }
        catch (Exception e)
        {
            return Result.Failure<Image>(e.Message);
        } 
      
    }
}