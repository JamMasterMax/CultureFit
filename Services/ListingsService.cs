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
    public class ListingsService
    {
        public static List<Listing> GetAll()
        {
            List<Listing> jobListings = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Listing_SelectAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameterCollection parameterCollection = command.Parameters;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int index = 0;
                                Listing jobListing = new Listing();

                                jobListing = ListingMapper(reader, index);

                                if (jobListings == null)
                                {
                                    jobListings = new List<Listing>();
                                }

                                jobListings.Add(jobListing);
                            }
                        }
                    }
                }
            }
            return jobListings;
        }

        public static int Create(ListingCreateRequest model)
        {
            int id;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Listing_Insert", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameterCollection parameterCollection = command.Parameters;

                    parameterCollection.AddWithValue("@ManagerID", model.ManagerID);
                    parameterCollection.AddWithValue("@City", model.City);
                    parameterCollection.AddWithValue("@State", model.State);
                    parameterCollection.AddWithValue("@Role", model.Role);
                    parameterCollection.AddWithValue("@Description", model.Description);
                    parameterCollection.AddWithValue("@VideoIsEnabled", model.VideoIsEnabled);
                    parameterCollection.AddWithValue("@VideoPrompt", model.VideoPrompt);


                    SqlParameter idParameter = new SqlParameter("@ListingID", SqlDbType.Int);
                    idParameter.Direction = ParameterDirection.Output;
                    parameterCollection.Add(idParameter);

                    connection.Open();
                    command.ExecuteNonQuery();

                    int.TryParse(idParameter.Value.ToString(), out id);
                }
            }
            return id;
        }

        public static List<Listing> GetByDepartmentId(ListingSelectByDepartmentIdRequest model)
        {
            List<Listing> jobListings = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Listing_SelectByDepartment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameterCollection parameterCollection = command.Parameters;

                    parameterCollection.AddWithValue("@DepartmentID", model.DepartmentId);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int index = 0;
                            Listing jobListing = new Listing();

                            reader.Read();
                            while (reader.Read())
                            {
                                jobListing = ListingMapper(reader, index);

                                if (jobListings == null)
                                {
                                    jobListings = new List<Listing>();
                                }

                                jobListings.Add(jobListing);
                            }
                        }
                    }
                    return jobListings;
                }
            }
        }

        public static List<Listing> GetByListingId(ListingSelectByListingIdRequest model)
        {
            List<Listing> jobListings = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Listing_SelectByListingID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameterCollection parameterCollection = command.Parameters;

                    parameterCollection.AddWithValue("@ListingID", model.ListingID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int index = 0;
                            Listing jobListing = new Listing();

                            reader.Read();
                            while (reader.Read())
                            {
                                jobListing = ListingMapper(reader, index);

                                if (jobListings == null)
                                {
                                    jobListings = new List<Listing>();
                                }

                                jobListings.Add(jobListing);
                            }
                        }
                    }
                    return jobListings;
                }
            }
        }

        public static List<Listing> GetByManagerId(ListingSelectByManagerIdRequest model)
        {
            List<Listing> jobListings = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Listing_SelectByManagerID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameterCollection parameterCollection = command.Parameters;

                    parameterCollection.AddWithValue("@ManagerID", model.ManagerID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int index = 0;
                            Listing jobListing = new Listing();

                            reader.Read();
                            while (reader.Read())
                            {
                                jobListing = ListingMapper(reader, index);

                                if (jobListings == null)
                                {
                                    jobListings = new List<Listing>();
                                }

                                jobListings.Add(jobListing);
                            }
                        }
                    }
                    return jobListings;
                }
            }
        }

        public static List<Listing> GetByManagerIdDepartmentId(ListingSelectByManagerIdDepartmentIdRequest model)
        {
            List<Listing> jobListings = null;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Listing_SelectByManagerIDAndDepartmentID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameterCollection parameterCollection = command.Parameters;

                    parameterCollection.AddWithValue("@ManagerID", model.ManagerID);
                    parameterCollection.AddWithValue("@DepartmentID", model.DepartmentID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int index = 0;
                                Listing jobListing = new Listing();

                                jobListing = ListingMapper(reader, index);

                                if (jobListings == null)
                                {
                                    jobListings = new List<Listing>();
                                }

                                jobListings.Add(jobListing);
                            }
                        }
                    }
                    return jobListings;
                }
            }
        }

        public static List<ListingApplicant> GetAllSeekersByListingId(int id)
        {
            List<ListingApplicant> listingApplicants = null;
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Listing_SelectAllSeekersByListingId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameterCollection parameterCollection = command.Parameters;

                    parameterCollection.AddWithValue("@listingId", id);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int index = 0;
                                ListingApplicant applicant = new ListingApplicant();

                                applicant.UserId = reader.GetInt32(index++);
                                applicant.FirstName = reader.GetString(index++);
                                applicant.LastName = reader.GetString(index++);
                                applicant.Email = reader.GetString(index++);
                                applicant.PhoneNumber = reader.GetString(index++);
                                applicant.Rating = reader.GetInt32(index++);
                                applicant.VideoUrl = reader.GetString(index++);
                                applicant.ResumeUrl = reader.GetString(index++);
                                applicant.SubmissionId = reader.GetInt32(index++);

                                if (listingApplicants == null)
                                {
                                    listingApplicants = new List<ListingApplicant>();
                                }

                                listingApplicants.Add(applicant);
                            }
                        }
                    }
                }
            }
            return listingApplicants;
        }

        private static Listing ListingMapper(SqlDataReader reader, int index)
        {
            Listing jobListing = new Listing();

            jobListing.ListingID = reader.GetInt32(index++);
            jobListing.ManagerID = reader.GetInt32(index++);
            jobListing.DepartmentID = reader.GetInt32(index++);
            jobListing.City = reader.GetString(index++);
            jobListing.State = reader.GetString(index++);
            jobListing.Role = reader.GetString(index++);
            jobListing.Description = reader.GetString(index++);
            jobListing.VideoIsEnabled = reader.GetBoolean(index++);
            jobListing.VideoPrompt = reader.GetString(index++);

            return jobListing;
        }


    }
}