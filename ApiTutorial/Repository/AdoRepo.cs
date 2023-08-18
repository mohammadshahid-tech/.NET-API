using ApiTutorial.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;

namespace ApiTutorial.Repository
{
    public class AdoRepo
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["constring"].ToString();

        ConnectionDb db = new ConnectionDb();

        public List<student> GetAllStudents()
        {
            var students = new List<student>();
            DataTable dt = db.ExecuteSelectQuery("select * from student_info");
            foreach (DataRow row in dt.Rows)
            {
                students.Add(new student
                {
                    studentID = row["studentID"].ToString(),
                    studentName = row["studentName"].ToString(),
                    address = row["address"].ToString(),
                    age = row["age"].ToString(),
                    contact = row["contact"].ToString(),
                });
            }
            return students;
        }


        public student GetSingleData(int id)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            string Query = "select * from student_info where studentID = @studentID ";
            var cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@studentID", id);

            DataRow row = db.ExecuteSingleSelectQuery(cmd);


            student Student = new student
            {
                studentName = row["studentName"].ToString(),
                address = row["address"].ToString(),
                age = row["age"].ToString(),
                contact = row["contact"].ToString()


            };
            return Student;
        }

        public int InsertData(int studentID,string studentName , string address , string age ,string contact)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            string Query = "insert into student_info (studentID, studentName , address,age,contact) values(@studentID, @studentName , @address,@age,@contact)";
            var cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@studentID", studentID);
            cmd.Parameters.AddWithValue("@studentName", studentName);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@contact", contact);

           var insert =  db.ExecuteNonQuery(cmd);
            if (insert > 0)
            {
                var msg = "row inserted";
            }
            return insert;
        }

        private string HttpNotFound()
        {
            throw new NotImplementedException();
        }
    }
}