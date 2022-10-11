using Microsoft.EntityFrameworkCore;
using System.Text.Json;


using RedditAPI.Model;
namespace RedditAPI.Service;

public class RedditService
{
    private RedditContext db { get; }

    public RedditService(RedditContext db)
    {
        this.db = db;
    }
    public void SeedData()
    {
        User Uchecker = db.Users.FirstOrDefault()!;
        if (Uchecker == null)
        {
            User user1 = new User("William");
            User user2 = new User("Jesper");
            User user3 = new User("Mattias");
            db.Add(user1);
            db.Add(user2);
            db.Add(user3);
            db.SaveChanges();
            Post post1 = new Post("Hjælper vodka på tømmermænd?", "Altså jeg har det fucking dårligt og kan ikke nå min snus", db.Users.Where(u => u.Name == "William").First());
            Post post2 = new Post("Er husholdningssprit godt mod bumser?", "Har prøvet med de der facemasks men de er lort", db.Users.Where(u => u.Name == "Jesper").First());
            Post post3 = new Post("Kan man lære en kat at hente aviser?", "Min hund døde sidste uge og aviserne ligger stadig ude på fortorvet", db.Users.Where(u => u.Name == "Mattias").First());
            db.Add(post1);
            db.Add(post2);
            db.Add(post3);
            Comment C1 = new Comment("Tror du skal finde en kæreste", 1, db.Users.Where(u => u.Name == "Mattias").First());
            Comment C2 = new Comment("Bare du ikke drikker det, tror jeg det er okay!", 2, db.Users.Where(u => u.Name == "William").First());
            Comment C3 = new Comment("Hey der er udskrevet valg, bare hvis du ikke har fået noget nyheder de sidste par dage", 3, db.Users.Where(u => u.Name == "Jesper").First());
            db.Add(C1);
            db.Add(C2);
            db.Add(C3);
            db.SaveChanges();
            CommentVote(1, 2, true);
            PostVote(1, 2, true);
        }
        db.SaveChanges();
    }

    public List<Post> GetPosts()
    {
        return db.Posts.ToList();
    }
    public Post GetPost(long id)
    {
        return db.Posts.Where(p => p.PostId == id).First();
    }
    public List<Comment> GetComments(long id)
    {
        return db.Comments.Where(c => c.PostID == id).ToList();
    }
    public void CommentVote(long commentID, long userID, bool like)
    {
        var tempComment = db.Comments.Where(c => c.CommentId == commentID).First();
        var tempUser = db.Users.Where(u => u.UserId == userID).First();
        tempComment.UserVotes = new List<User>();
        tempComment.UserVotes.Add(tempUser);
        if (like) { tempComment.Votes++; }
        else { tempComment.Votes--; }
        db.SaveChanges();
    }
    public void PostVote(long postID, long userID, bool like)
    {
        var tempPost = db.Posts.Where(p => p.PostId == postID).First();
        var tempUser = db.Users.Where(u => u.UserId == userID).First();
        tempPost.UserVotes = new List<User>();
        tempPost.UserVotes.Add(tempUser);
        if (like) { tempPost.Votes++; }
        else { tempPost.Votes--; }
        db.SaveChanges();
    }
    public void CreatePost(string userName, string title, string body)
    {
        int checker = db.Users.Where(u => u.Name == userName).ToList().Count;
        if (checker < 1)
        {
            User newuser = new User(userName);
            db.Add(newuser);
        }
        Post newpost = new Post(title, body, db.Users.Where(u => u.Name == userName).First());
        db.Add(newpost);
        db.SaveChanges();
    }
    public void CreateComment(string userName, string body, long postID)
    {
        int checker = db.Users.Where(u => u.Name == userName).ToList().Count;
        if (checker < 1)
        {
            User newuser = new User(userName);
            db.Add(newuser);
        }
        db.Add(new Comment(body, postID, db.Users.Where(u => u.Name == userName).First()));
        db.SaveChanges();

    }
}