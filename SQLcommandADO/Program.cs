using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.ComponentModel.Design;

namespace SQLcommandADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program.SQL_CMD();
            Console.ReadLine();
        }

        static void SQL_CMD()
        {
            //string cs = "Data Source = LAPTOP-OUNKEU6V\\SQLEXPRESS; Initial Catalog = Student_db; Integrated security = true;";
            string cs = ConfigurationManager.ConnectionStrings["vaibhav"].ConnectionString;
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(cs))
                {
                    //string query = "Select * from Student";
                    string query = "spgetStudent";    // To pass Store Procedure as a query
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.StoredProcedure;   // CommandType is use for indication of query getting Storeprocedure Name.
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        Console.WriteLine("ID: " + dr["ID"]+ " FName: " + dr["FName"]+ " LName: " + dr["LName"]+ " Marks: " + dr["Marks"]+ " City: " + dr["City"]);
                    }

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
