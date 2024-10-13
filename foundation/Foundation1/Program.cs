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
    public string Description { get; private set; }
    public string Url { get; private set; }
    public DateTime UploadDate { get; private set; }
    private List<Comment> comments;

    public Video(string title, string description, string url)
    {
        Title = title;
        Description = description;
        Url = url;
        UploadDate = DateTime.Now;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public void RemoveComment(Comment comment)
    {
        comments.Remove(comment);
    }

    public List<Comment> GetComments()
    {
        return comments;
    }

    public string GetDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nURL: {Url}\nUpload Date: {UploadDate}\nComments: {comments.Count}";
    }
}

public class VideoManager
{
    private List<Video> videos;

    public VideoManager()
    {
        videos = new List<Video>();
    }

    public void AddVideo(Video video)
    {
        videos.Add(video);
    }

    public void RemoveVideo(Video video)
    {
        videos.Remove(video);
    }

    public Video GetVideo(string title)
    {
        return videos.FirstOrDefault(v => v.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    public List<Video> SearchByTitle(string title)
    {
        return videos.Where(v => v.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Video> GetVideos()
    {
        return videos;
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

        Video video1 = new Video("Sample Video", "This is a description.", "http://youtube.com/sample");
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