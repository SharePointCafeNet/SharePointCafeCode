namespace CachedRepositoryPattern.Models;

public class Notification
{
    public int Id { get; set; }
    public string Title { get; set; } 
    public string Url { get; set; }
    public DateTime CreatedDate { get; set;}
    public bool Status { get; set;}
}
