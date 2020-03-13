using System;
using System.Collections.Generic;
using System.Text;

namespace ParentChildDataSave.ViewModels
{
    public class ViewModel
    {
        public List<Author> Authors { get; set; }
    }

    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public List<Blog> Blogs { get; set; }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Name { get; set; }
        public List<Comment> Comments { get; set; }
    }

    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
    }


}
