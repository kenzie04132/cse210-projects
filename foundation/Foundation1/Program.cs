using System;
using System.Collections.Generic;
using System.Linq;

public class Comment
{
    public string Content { get; private set; }
    public string Author { get; private set; }
    public DateTime Timestamp { get; private set; }

    public Comment(string content, string author)
    {
        Content = content;
        Author = author;
        Timestamp = DateTime.Now;
    }

    public void Edit(string newContent)
    {
        Content = newContent;
    }

    public string GetDetails()
    {
        return $"[{Timestamp}] {Author}: {Content}";
    }
}

public class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public TimeSpan Length { get; private set; }
    private List<Comment> _comments;

    public Video(string title, string author, TimeSpan length)
    {
        Title = title;
        Author = author;
        Length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public void RemoveComment(Comment comment)
    {
        _comments.Remove(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }

    public string GetDetails()
    {
        return $"Title: {Title}\nAuthor: {Author}\nLength: {Length}\nComments: {GetNumberOfComments()}";
    }
}

public class VideoManager
{
    private List<Video> _videos;

    public VideoManager()
    {
        _videos = new List<Video>();
    }

    public void AddVideo(Video video)
    {
        _videos.Add(video);
    }

    public void RemoveVideo(Video video)
    {
        _videos.Remove(video);
    }

    public Video GetVideo(string title)
    {
        return _videos.FirstOrDefault(v => v.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    public List<Video> SearchByTitle(string title)
    {
        return _videos.Where(v => v.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Video> GetVideos()
    {
        return _videos;
    }
}

public class CommentManager
{
    public List<Comment> SortCommentsByTimestamp(List<Comment> comments)
    {
        return comments.OrderBy(c => c.Timestamp).ToList();
    }

    public List<Comment> FilterCommentsByAuthor(List<Comment> comments, string author)
    {
        return comments.Where(c => c.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}

class Program
{
    static void Main(string[] args)
    {
        VideoManager videoManager = new VideoManager();
        CommentManager commentManager = new CommentManager();

        Video video1 = new Video("Sample Video", "Author1", TimeSpan.FromMinutes(5));
        videoManager.AddVideo(video1);

        Comment comment1 = new Comment("Great video!", "User1");
        Comment comment2 = new Comment("Thanks for sharing!", "User2");
        video1.AddComment(comment1);
        video1.AddComment(comment2);

        Console.WriteLine(video1.GetDetails());

        foreach (var comment in video1.GetComments())
        {
            Console.WriteLine(comment.GetDetails());
        }

        comment1.Edit("Awesome video!");
        Console.WriteLine("\nAfter editing the first comment:");
        foreach (var comment in video1.GetComments())
        {
            Console.WriteLine(comment.GetDetails());
        }

        var sortedComments = commentManager.SortCommentsByTimestamp(video1.GetComments());
        Console.WriteLine("\nSorted comments:");
        foreach (var comment in sortedComments)
        {
            Console.WriteLine(comment.GetDetails());
        }
    }
}