using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ZipHackathon.Domain;

namespace ZipHackathon.Services
{
    public class TestService
    {
        public static int TestInsert()
        {
            int id;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Users_Insert", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameterCollection parameterCollection = command.Parameters;

                    parameterCollection.AddWithValue("@FirstName", "HeyThere");
                    parameterCollection.AddWithValue("@LastName", "ZipHACK!!");

                    SqlParameter idParameter = new SqlParameter("@UserId", SqlDbType.Int);
                    idParameter.Direction = ParameterDirection.Output;
                    parameterCollection.Add(idParameter);

                    connection.Open();
                    command.ExecuteNonQuery();

                    int.TryParse(idParameter.Value.ToString(), out id);
                }
            }
            return id;
        }
        public static List<TestPerson> GetAll()
        {
            List<TestPerson> people = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Users_SelectAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameterCollection parameterCollection = command.Parameters;

                    //parameterCollection.AddWithValue("@id", 0);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                          
                            while (reader.Read())
                            {
                                int index = 0;
                                TestPerson person = new TestPerson();

                                person.Id = reader.GetInt32(index++);
                                person.FirstName = reader.GetString(index++);
                                person.LastName = reader.GetString(index++);
                                person.DateCreated = reader.GetDateTime(index++);
                                person.DateModified = reader.GetDateTime(index++);

                                if (people == null)
                                {
                                    people = new List<TestPerson>();
                                }

                                people.Add(person);
                            }
                        }
                    }
                }

            }
            return people;
        }
    }
}