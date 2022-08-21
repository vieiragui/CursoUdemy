namespace Blog.Models
{
    public class Post : BaseModel
    {
        public string? Title { get; set; }

        public string? Resume { get; set; }

        public string? Content { get; set; }

        public DateTime DatePost { get; set; }

        public byte[]? Image { get; set; }

        public Post(string? title, string? resume, string? content, byte[]? image)
        {
            Title = title;
            Resume = resume;
            Content = content;
            DatePost = DateTime.Now;
            Image = image;
        }
    }
}
