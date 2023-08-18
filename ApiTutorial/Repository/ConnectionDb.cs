using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ApiTutorial.Repository
{
    public class ConnectionDb
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["constring"].ToString();

        // Execute Select (Read) query
        public DataTable ExecuteSelectQuery(string query)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // Execute Insert, Update, Delete queries
        public int ExecuteNonQuery(SqlCommand query)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = query)
                {
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public DataRow ExecuteSingleSelectQuery(SqlCommand query)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                DataTable dt = new DataTable();

                con.Open();
                using (SqlCommand cmd = query)
                {

                    // Add parameters to the SQL command if any
                   

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }
    }
}