using Microsoft.Extensions.Configuration;
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
    public class UserRepository : IUserRepository
    {
        private SqlConnection con;
        //private IConfiguration config;

        //public UserRepository(IConfiguration configuration)
        //{
        //    this.config = configuration;
        //}

        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            con = new SqlConnection(connectionString);
        }

        public RegisterModel RegisterUser(RegisterModel register)
        {
            try
            {
                Connection();
                string password = EncryptPassword(register.Password);
                SqlCommand command = new SqlCommand("sp_userRegister", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirstName", register.FirstName);
                command.Parameters.AddWithValue("@LastName", register.LastName);
                command.Parameters.AddWithValue("@Email", register.Email);
                command.Parameters.AddWithValue("@Password", password);

                con.Open();
                int i = command.ExecuteNonQuery();
                con.Close();
                if(i >= 1)
                {
                    return register;
                }
                else
                {
                    return null;
                }
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

        public LoginModel loginUser(LoginModel login)
        {
            try
            {
                Connection();
                string password = EncryptPassword(login.Password);
                SqlCommand command = new SqlCommand("sp_login", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Email", login.Email);
                command.Parameters.AddWithValue("@Password", password);

                con.Open();
                int i = command.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return login;
                }
                else
                {
                    return null;
                }
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

        public static string EncryptPassword(string password)
        {
            try
            {
                byte[] encryptData = new byte[password.Length];
                encryptData = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encryptData);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
    }
    }
