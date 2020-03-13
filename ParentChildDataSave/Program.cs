using Dapper;
using Newtonsoft.Json;
using ParentChildDataSave.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ParentChildDataSave
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //AuthorRepo authorRepo = new AuthorRepo();
            //var authors = authorRepo.GetAll();
            //foreach (var item in authors)
            //{
            //    Console.WriteLine($"Authors Repo-- ID:{item.AuthorId}, Name:{item.Name}");
            //}
            //AuthorRepo authorRepo1 = new AuthorRepo();
            //var author = authorRepo1.Get(5);
            //Console.WriteLine($"Authors Repo-- ID:{author.AuthorId}, Name:{author.Name}");

            //AuthorRepo authorRepo = new AuthorRepo();
            //List<Author> authors = new List<Author>();
            //authors.Add(new Author() { Name = "Kuppusamy" });
            //authors.Add(new Author() { Name = "Mohana" });

            //authorRepo.InsertMany(authors);
            //authorRepo.BulkInsert(authors);

            //BulkUpdateService bulkUpdate = new BulkUpdateService();

            //var authors = new List<Author>() { new Author() { Name = "IronMan" }, new Author() { Name = "Captain America" } };
            //var blogs = new List<Blog>() { new Blog() { Name = "Blog1" }, new Blog() { Name = "Blog 10" } };
            //var posts = new List<Post>() { new Post() { Name = "Post1" }, new Post() { Name = "Post 10" } };
            //var comments = new List<Comment>() { new Comment { Content = "Content 1" }, new Comment { Content = "Content 2" } };
            //bulkUpdate.AuthorBlogPostComment(authors, blogs, posts, comments);
            string str = GetJsonData();

            var viewModel = JsonConvert.DeserializeObject<ViewModels.ViewModel>(str);

            List<Author> authors = new List<Author>();
            List<Blog> blogs = new List<Blog>();

            foreach (var author in viewModel.Authors)
            {
                var auth = new Author() { Name = author.Name };
                authors.Add(auth);
                foreach (var blog in author.Blogs)
                {
                    blogs.Add(new Blog() { Name = blog.Name, tempAuthorId = auth.tempAuthorId });
                }
            }

            Console.ReadLine();
        }

        static string GetJsonData()
        {
            return "{'authors':[{'name':'Anandraj','Blogs':[{'name':'Blog 10','Posts':[{'name':'Post 10','Comments':[{'Content':'Good Post'}]}]}]},{'name':'Sravanthi','Blogs':[{'name':'Blog 1','Posts':[{'name':'Post 11','Comments':[{'Content':'Excellent Post'}]}]}]},{'name':'KP','Blogs':[{'name':'Blog 1','Posts':[{'name':'Post 11','Comments':[{'Content':'I am KP fan, please add me in KFC club.'}]}]}]}]}";
        }
    }
}
