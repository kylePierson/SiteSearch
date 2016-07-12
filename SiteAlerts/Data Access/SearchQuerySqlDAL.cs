using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteAlerts.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace SiteAlerts.Data_Access
{
    public class SearchQuerySqlDAL : ISearchQueryDAL
    {
        private string connectionString;

        //                                                                  |
        //rewrite these Sql queries so that they access the correct columns |
        //of the correct tables given the particular method thats called   \|/
        private const string SQL_GetAllSearchQueries = @"SELECT searchQuery.columns 
                                                        FROM searchQuery, appUser_searchQuery, appUser
                                                        WHERE  searchQuery.searchID = appUser_searchQuery.searchID
                                                               and appUser_searchQuery.userID = appUser.userID
                                                               and appUser.userID = @userid";

        public SearchQuerySqlDAL()
            : this(ConfigurationManager.ConnectionStrings["SearchAlertDB"].ConnectionString)
        {
        }

        // Single Parameter Constructor
        public SearchQuerySqlDAL(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public void AddSearchQuery(SearchQuery newSearchQuery)
        {
            throw new NotImplementedException();
        }

        public List<SearchQuery> GetAllSearchQueries(int userID)
        {
            List<SearchQuery> output = new List<SearchQuery>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetAllSearchQueries, conn);
                    cmd.Parameters.AddWithValue("@userid", userID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SearchQuery sQ = new SearchQuery();
                        sQ.SearchQueryID = Convert.ToInt32(reader["searchID"]);
                        //e.EmployeeId = Convert.ToInt32(reader["employee_id"]);
                        //e.LastName = Convert.ToString(reader["last_name"]);
                        //e.FirstName = Convert.ToString(reader["first_name"]);
                        //e.JobTitle = Convert.ToString(reader["job_title"]);
                        //e.DepartmentId = Convert.ToInt32(reader["department_id"]);
                        //e.BirthDate = Convert.ToDateTime(reader["birth_date"]);
                        //e.Gender = Convert.ToString(reader["gender"]);
                        //e.HireDate = Convert.ToDateTime(reader["hire_date"]);

                        output.Add(sQ);
                    }
                }

            }
            catch (SqlException ex)
            {
                throw;
            }
            return output;
        }

        public void RemoveSearchQuery(int searchQueryID)
        {
            throw new NotImplementedException();
        }
    }
}