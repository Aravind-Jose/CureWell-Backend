using CureWellProject.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWellProject.DAL
{
    public class SpecializationServicesImpl : SpecializationServices
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["dbConnect"].ConnectionString;
    
       

        public List<Specialization> GetAllSpecializations()
        {
            List<Specialization> specializations = new List<Specialization>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT * FROM Specialization";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Specialization specialization = new Specialization
                                {
                                    SpecializationCode = reader["SpecializationCode"].ToString(),
                                    SpecializationName = reader["SpecializationName"].ToString()
                                };
                                specializations.Add(specialization);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return specializations;
        }

       
    }
}
