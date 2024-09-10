using CSharpFunctionalExtensions;

namespace News.Domain;

public class Image
{
    private Image(string fileName)
    {
        FileName = fileName;
    }
    public Guid NewsId { get; set; }
    public string FileName { get; set; }=string.Empty;
    public static Result<Image> Create(string fileName)
    {
        if(string.IsNullOrWhiteSpace(fileName))
            return Result.Failure<Image>("Title length is invalid");
       
        
        var image=new Image(fileName);
        return Result.Success<Image>(image);
    }
    
    
    
    
}