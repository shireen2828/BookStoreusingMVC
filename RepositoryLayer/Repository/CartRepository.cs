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
    public class CartRepository : ICartRepository
    {
        private SqlConnection con;

        private void connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            con = new SqlConnection(connectionString);
        }

        public CartModel AddToCart(CartModel cart, string Email)
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
                            cart.UserId = Convert.ToInt32(dr["UserId"]);
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
                SqlCommand command = new SqlCommand("sp_Addtocart", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookId", cart.BookId);
                command.Parameters.AddWithValue("@UserId", cart.UserId);
                command.Parameters.AddWithValue("@Quantity", cart.Quantity);
                //command.Parameters.AddWithValue("@Email", Email);
                con.Open();
                int i = command.ExecuteNonQuery();

                if(i >= 1)
                {
                    return cart;
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

        public List<GetCartModel> Getcart()
        {
            connection();
            List<GetCartModel> cart = new List<GetCartModel>();
            SqlCommand command = new SqlCommand("sp_Getcart", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserId", 1);
            SqlDataAdapter sqlData = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            con.Open();
            sqlData.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                cart.Add(new GetCartModel
                {
                    BookId = Convert.ToInt32(row["BookId"]),
                    BookName = Convert.ToString(row["BookName"]),
                    Author = Convert.ToString(row["Author"]),
                    Price = Convert.ToInt32(row["Price"]),
                    Image = Convert.ToString(row["Image"]),
                    Quantity = Convert.ToInt32(row["Quantity"])
                });
            }
            return cart;
        }
    }
}
