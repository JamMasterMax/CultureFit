using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ZipHackathon.Models.Request;

namespace ZipHackathon.Services
{
    public class ReviewService
    {

        public static int Create(ReviewCreateRequest review)
        {
            int id;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Review_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameterCollection parameterCollection = command.Parameters;

                    parameterCollection.AddWithValue("@SubmissionID", review.SubmissionId);
                    parameterCollection.AddWithValue("@Rating", review.Rating);
                    parameterCollection.AddWithValue("@Comment", review.Comment);
                    parameterCollection.AddWithValue("@DepartmentID", review.DepartmentId);
                    parameterCollection.AddWithValue("@EmployeeName", review.Employee);

                    SqlParameter reviewId = new SqlParameter("@ReviewID", SqlDbType.Int);
                    reviewId.Direction = ParameterDirection.Output;
                    parameterCollection.Add(reviewId);

                    connection.Open();
                    command.ExecuteNonQuery();

                    int.TryParse(reviewId.Value.ToString(), out id);
                }
            }
            return id;
        }
    }
}