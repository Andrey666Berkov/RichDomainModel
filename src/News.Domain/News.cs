using CSharpFunctionalExtensions;

namespace News.Domain;

public class News
{
    private News(Guid id, string title, string textData, Image? image,DateTime createdDate )
    {
        Id = id;
        Title = title;
        TextData = textData;
        Image = image;
        CreatedDate = createdDate;
    }

    private readonly List<Image> images = new();
    public const int MAX_TITLE_LENGTH = 100;
    public Guid Id { get; }
    public string Title { get; }=string.Empty;
    public string TextData { get; }=String.Empty;
    public Image? Image { get; }
    public DateTime CreatedDate { get; }
    public  int Views { get; private set; } = 0;
    public Image? TitleImage { get; }

    public  IReadOnlyCollection<Image> ImagesList=> images;
    
    public void AssImages(Image image)=> images.Add(image);
    
    public  void CountView()=>Views++;

    public static Result<News> Create(Guid id, string title, string textData, Image? image)
    {
        if(string.IsNullOrWhiteSpace(title) || title.Length <MAX_TITLE_LENGTH)
            return Result.Failure<News>("Title length is invalid");
        if(string.IsNullOrWhiteSpace(textData) || textData.Length <MAX_TITLE_LENGTH)
            return Result.Failure<News>("Title length is invalid");
        
        var news=new News(id, title, textData, image, DateTime.Now);
        return Result.Success<News>(news);
    }

    
}