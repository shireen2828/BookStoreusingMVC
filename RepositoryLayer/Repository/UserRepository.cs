﻿using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration configuration;

        public UserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            con = new SqlConnection(connectionString);
        }

        public bool RegisterUser(RegisterModel register)
        {
            try
            {
                Connection();
                SqlCommand command = new SqlCommand("sp_userRegister", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirstName", register.FirstName);
                command.Parameters.AddWithValue("@LastNme", register.LastName);
                command.Parameters.AddWithValue("@Email", register.Email);
                command.Parameters.AddWithValue("@Password", register.Password);

                con.Open();
                int i = command.ExecuteNonQuery();
                con.Close();
                if(i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
