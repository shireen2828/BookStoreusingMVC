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

        public List<BooksModel> GetBooks()
        {
            try
            {
                connection();
                List<BooksModel> books = new List<BooksModel>();
                SqlCommand command = new SqlCommand("sp_GetBooks", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlData = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                con.Open();
                sqlData.Fill(table);
                con.Close();

                foreach (DataRow Row in table.Rows)
                {
                    books.Add(new BooksModel
                    {
                        BookId = Convert.ToInt32(Row["BookId"]),
                        BookName = Convert.ToString(Row["BookName"]),
                        Author = Convert.ToString(Row["Author"]),
                        Details = Convert.ToString(Row["Details"]),
                        Price = Convert.ToDouble(Row["Price"]),
                        Quantity = Convert.ToInt32(Row["Quantity"]),
                        Image = Convert.ToString(Row["Image"])
                    });
                }
                return books;
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

        public bool UploadImage(int BookId, string addImage)
        {
            connection();
            SqlCommand command = new SqlCommand("sp_AddImage", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@BookId", BookId);
            command.Parameters.AddWithValue("@Image", addImage);
            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
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
