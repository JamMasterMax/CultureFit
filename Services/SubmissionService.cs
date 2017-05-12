using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ZipHackathon.Domain;
using ZipHackathon.Models.Request;

namespace ZipHackathon.Services
{
    public class SubmissionService
    {
        public static int CreateSubmission(SubmissionCreateRequest application)
        {
            int id;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Submission_Insert", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameterCollection parameterCollection = command.Parameters;

                    parameterCollection.AddWithValue("@ListingId", application.ListingId);
                    parameterCollection.AddWithValue("@SeekerId", application.SeekerId);
                    parameterCollection.AddWithValue("@ResumeUrl", application.ResumeUrl);
                    parameterCollection.AddWithValue("@videoUrl", application.VideoUrl);

                    SqlParameter idParameter = new SqlParameter("@SubmissionId", SqlDbType.Int);
                    idParameter.Direction = ParameterDirection.Output;
                    parameterCollection.Add(idParameter);

                    connection.Open();
                    command.ExecuteNonQuery();

                    int.TryParse(idParameter.Value.ToString(), out id);
                }
            }
            return id;
        }

        public static Submission GetById(int id)
        {
            Submission application = new Submission();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Submission_SelectByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameterCollection parameterCollection = command.Parameters;

                    parameterCollection.AddWithValue("@SubmissionID", id);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int index = 0;
                                application.SubmissionId = reader.GetInt32(index++);
                                application.ListingId = reader.GetInt32(index++);
                                application.SeekerId = reader.GetInt32(index++);
                                application.ResumeUrl = reader.GetString(index++);
                                application.VideoUrl = reader.GetString(index++);
                            }
                        }
                    }

                }
            }
            return application;
        }

        // select all submissions for a listing
        public static List<Submission> GetByListingId(int id)
        {
            List<Submission> application = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Submission_SelectByListingID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameterCollection parameterCollection = command.Parameters;

                    parameterCollection.AddWithValue("@ListingID", id);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (application == null)
                        {
                            application = new List<Submission>();
                        }

                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                int index = 0;
                                Submission s = new Submission();

                                s.SubmissionId = reader.GetInt32(index++);
                                s.ListingId = reader.GetInt32(index++);
                                s.SeekerId = reader.GetInt32(index++);
                                s.ResumeUrl = reader.GetString(index++);
                                s.VideoUrl = reader.GetString(index++);

                                application.Add(s);
                            }
                        }

                    }
                }
                return application;
            }
        }

        public static Applicant GetApplicantById(int id)
        {
            Applicant applicant = new Applicant();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Submission_SelectByIdJoinUsersTable", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameterCollection parameterCollection = command.Parameters;

                    parameterCollection.AddWithValue("@submissionId", id);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int index = 0;

                                applicant.UserId = reader.GetInt32(index++);
                                applicant.FirstName = reader.GetString(index++);
                                applicant.LastName = reader.GetString(index++);
                                applicant.Role = reader.GetString(index++);
                                applicant.VideoPrompt = reader.GetString(index++);
                                applicant.VideoUrl = reader.GetString(index++);
                                applicant.SubmissionId = reader.GetInt32(index++);

                            }
                        }

                    }
                }
            }
            return applicant;
        }

    }
}