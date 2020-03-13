using System;
using System.Collections.Generic;
using System.Text;

namespace ParentChildDataSave.Models
{
    public class Blog
    {
        static int _tempid = 1;
        public Blog()
        {
            tempBlogId = _tempid;
            _tempid++;
        }
        public int BlogId { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int tempBlogId { get; }
        public int tempAuthorId { get; set; }
    }
}
