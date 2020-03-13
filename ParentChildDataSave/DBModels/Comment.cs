using System;
using System.Collections.Generic;
using System.Text;

namespace ParentChildDataSave.Models
{
    class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
    }
}
