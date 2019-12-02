namespace PosterStore.Models
{
  public class PosterImage
  {
    public int Id { get; set; }
    public string Url { get; set; }
     public bool isMain { get; set; }

     public Poster Poster { get; set; }
     public int PosterId { get; set; }

  }
}