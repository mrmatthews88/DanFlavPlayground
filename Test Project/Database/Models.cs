using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Project.Database
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        // Navigation property
        public ICollection<Article> Articles { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }

    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign key
        public int UserId { get; set; }

        // Navigation property
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }

    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign keys
        public int UserId { get; set; }
        public int ArticleId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Article Article { get; set; }
    }

    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }

        // Navigation property
        public ICollection<Article> Articles { get; set; }
    }


    public class ArticleTag
    {
        // Composite key
        public int ArticleId { get; set; }
        public int TagId { get; set; }

        // Navigation properties
        public Article Article { get; set; }
        public Tag Tag { get; set; }
    }
}
