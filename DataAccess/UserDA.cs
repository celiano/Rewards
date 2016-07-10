using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RewardsWebApi.Models;
using System.Data.SqlClient;
using System.Data;
using RewardsWebApi.Conections;

namespace RewardsWebApi.DataAccess
{
    public class UserDA : IUserDA
    {
        public Response<User> Authentication(string userName, string password)
        {
            string connectionString = MainSqlConection.GetConnectionString();
            Response<User> response = new Response<User>();
            User user = new User();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand Command = con.CreateCommand();
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = "dbo.Authentication";

                Command.Parameters.Add("@userName", SqlDbType.VarChar).Value = userName;
                Command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

                SqlDataReader oReader = Command.ExecuteReader();
                while (oReader.Read())
                {
                    user.UserID = (int)oReader["UserID"];
                    user.UserName = oReader["UserName"].ToString();
                    user.FirstName = oReader["FirstName"].ToString();
                    user.LastName = oReader["LastName"].ToString();
                    user.UserType = oReader["UserType"].ToString();
                    user.BirthDate = (DateTime)oReader["BirthDate"];
                    user.Email = oReader["Email"].ToString();
                    user.Country = oReader["Country"].ToString();
                    user.Language = oReader["Language"].ToString();
                    user.CreateDate = (DateTime)oReader["CreateDate"];
                    user.Status = oReader["Status"].ToString();
                    user.Password = oReader["Password"].ToString();
                    response.Succeeded = true;
                }
                response.Data = user;
            }
            return response;
        }
    }
}