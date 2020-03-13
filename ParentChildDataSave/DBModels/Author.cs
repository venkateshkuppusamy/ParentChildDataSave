using System;
using System.Collections.Generic;
using System.Text;

namespace ParentChildDataSave.Models
{
    public class Author
    {
        static int _tempid = 1;
        public Author()
        {
            tempAuthorId = _tempid;
            _tempid++;
        }

        public int AuthorId { get; set; }
        public string Name { get; set; }
        public int tempAuthorId { get; }
    }
}
