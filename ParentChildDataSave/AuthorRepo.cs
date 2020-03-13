using Dapper;
using DapperParameters;
using ParentChildDataSave.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ParentChildDataSave
{
    public class AuthorRepo
    {
        string ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=BlogDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        IDbConnection db { get; set; }

        public AuthorRepo()
        {
            db = new SqlConnection(this.ConnectionString);
        }

        public List<Author> GetAll()
        {
            using (db)
            {
                return db.Query<Author>("Select * from Authors").ToList();
            }
        }

        public Author Get(int id)
        {
            using (db)
            {
                return db.QueryFirstOrDefault<Author>("Select * from Authors where authorid = @id", new { id });
            }
        }
        /// <summary>
        /// Inserts author record 1 db hit per record.
        /// </summary>
        /// <param name="authors"></param>
        /// <returns></returns>
        public int InsertMany(List<Author> authors)
        {
            using (db)
            {
                return db.Execute("Insert into Authors values(@Name)",authors);
            }
        }

        public void BulkInsert(List<Author> authors)
        {
            using (db)
            {
                var parameters = new DynamicParameters();
                parameters.AddTable("@author", nameof(Author), authors);

                var result = db.Query("usp_InsertAuthors", parameters, commandType: CommandType.StoredProcedure);
            }

        }
            
    }

    
}
