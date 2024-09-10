namespace News.Application;

public class NewsService
{
    public async Task CountView(Domain.News news)
    {
        news.CountView();
    }
}