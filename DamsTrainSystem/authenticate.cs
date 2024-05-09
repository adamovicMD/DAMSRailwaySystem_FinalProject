using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DamsTrainSystem;

namespace DamsTrainSystem
{
    public class authenticate
    {
        public class DamsUsers
        {
            public string Username { get; set; }

            public class DatabaseManager
            {
                public static DamsUsers AuthenticateUser(string userEmail, string userPassword)
                {
                    DamsUsers user = RetrieveUserInformation(userEmail, userPassword);
                    return user;
                }

                private static DamsUsers RetrieveUserInformation(string userEmail, string userPassword)
                {
                    // Using statement ensures proper disposal of resources
                    using (SqlConnection sqlCon = new SqlConnection(@"Data Source=LAB109PC15\SQLEXPRESS; Initial Catalog=DamsTrainSystem; Integrated Security=True;"))
                    {
                        sqlCon.Open(); // Open SQL connection

                        string Query = "SELECT userName FROM DamsUsers WHERE userEmail=@userEmail AND userPassword=@userPassword";

                        SqlCommand cmd = new SqlCommand(Query, sqlCon);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@userEmail", userEmail); // pass userEmail parameter
                        cmd.Parameters.AddWithValue("@userPassword", userPassword); // pass userPassword parameter

                        string userName = cmd.ExecuteScalar() as string;

                        if (userName != null)
                        {
                            // Create a new DamsUsers object with the retrieved userName
                            return new DamsUsers { Username = userName };
                        }

                        return null; // Return null if no user is found with the specified userEmail and userPassword
                    }
                }
            }

        }
    }
}
