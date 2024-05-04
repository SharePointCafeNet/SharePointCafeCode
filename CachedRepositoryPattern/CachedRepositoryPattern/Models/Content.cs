namespace CachedRepositoryPattern.Models;

public class Content
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string Url { get; set; }

  

    public int CategoryId { get; set; }
    public bool Status { get; set; }

    public string? SEOTitle { get; set; }
    public string? MetaDescription { get; set; }
    public string? MetaKeyword { get; set; }
    public string? OGImage { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime TransactionDate { get; set; }

    public bool? IsGoodStuff { get; set; }

}
