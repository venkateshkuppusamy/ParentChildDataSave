using Dapper;
using DapperParameters;
using ParentChildDataSave.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ParentChildDataSave
{
    class BulkUpdateService
    {

        string ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=BlogDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        IDbConnection db { get; set; }

        public BulkUpdateService()
        {
            db = new SqlConnection(this.ConnectionString);
        }

        public void AuthorBlogPostComment(List<Author> authors, List<Blog> blogs, List<Post> posts, List<Comment> comments)
        {
            using (db)
            {
                using (db)
                {
                    var parameters = new DynamicParameters();
                    parameters.AddTable("@author", nameof(Author), authors);
                    parameters.AddTable("@blog", nameof(Blog), blogs);
                    parameters.AddTable("@post", nameof(Post), posts);
                    parameters.AddTable("@comment", nameof(Comment), comments);

                    var result = db.Query("usp_InsertAuthorBlogPostComment", parameters, commandType: CommandType.StoredProcedure);
                }
            }
        }
    }
}
