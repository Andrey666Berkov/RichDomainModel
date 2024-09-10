

using System.ComponentModel.DataAnnotations;
using News.Domain;

namespace News.Api.Contracts;

public record NewsRequest( [Required][MaxLength(Domain.News.MAX_TITLE_LENGTH)] string Title,
    [Required] string textData, 
    IFormFile titleImage)
{
   
}