using ModelsLayer;
using RepositoryLayer.Interaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private SqlConnection con;

        private void connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            con = new SqlConnection(connectionString);
        }

        public BooksModel Addbooks(BooksModel books)
        {
            try
            {
                connection();
                SqlCommand command = new SqlCommand("sp_AddBooks", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookName", books.BookName);
                command.Parameters.AddWithValue("@Author", books.Author);
                command.Parameters.AddWithValue("@Details", books.Details);
                command.Parameters.AddWithValue("@Price", books.Price);
                command.Parameters.AddWithValue("@Image", books.Image);
                command.Parameters.AddWithValue("@Quantity", books.Quantity);
                con.Open();
                int i = command.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                    return books;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
