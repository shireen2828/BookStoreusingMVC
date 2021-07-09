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
    public class WishlistRepository : IWishlistRepository
    {
        private SqlConnection con;

        private void connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            con = new SqlConnection(connectionString);
        }

        public WishlistModel AddToWishlist(WishlistModel wishlist, string Email)
        {

            try
            {
                connection();
                string query = @"select * from UserRegisteration";
                SqlCommand command1 = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = command1.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (Convert.ToString(dr["Email"]) == Email)
                        {
                            wishlist.UserId = Convert.ToInt32(dr["UserId"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            try
            {
                connection();
                SqlCommand command = new SqlCommand("sp_Addtowishlist", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookId", wishlist.BookId);
                command.Parameters.AddWithValue("@UserId", wishlist.UserId);
                command.Parameters.AddWithValue("@Quantity", wishlist.Quantity);
                con.Open();
                int i = command.ExecuteNonQuery();

                if (i >= 1)
                {
                    return wishlist;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public List<GetWishlistModel> Getwishlist()
        {
            connection();
            List<GetWishlistModel> wishlist = new List<GetWishlistModel>();
            SqlCommand command = new SqlCommand("sp_Wishlist", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserId", 1);
            SqlDataAdapter sqlData = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            con.Open();
            sqlData.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                wishlist.Add(new GetWishlistModel
                {
                    BookId = Convert.ToInt32(row["BookId"]),
                    BookName = Convert.ToString(row["BookName"]),
                    Author = Convert.ToString(row["Author"]),
                    Price = Convert.ToInt32(row["Price"]),
                    Image = Convert.ToString(row["Image"]),
                    Quantity = Convert.ToInt32(row["Quantity"])
                });
            }
            return wishlist;
        }
    }
}
