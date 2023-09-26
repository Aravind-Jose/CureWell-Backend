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
    public class SurgeryServicesImpl : SurgerySevices
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["dbConnect"].ConnectionString;
        public List<Surgery> GetAllSurgeryTypeForToday()
        {
            List<Surgery> surgeries = new List<Surgery>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT * FROM Surgery";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Surgery surgery = new Surgery
                                {
                                    SurgeryId = Convert.ToInt32( reader["SurgeryID"]),
                                    DoctorId = Convert.ToInt32(reader["DoctorID"]),
                                    StartTime= Convert.ToDecimal(reader["StartTime"]),
                                    EndTime = Convert.ToDecimal(reader["EndTime"]),
                                    SurgeryCategory = reader["SurgeryCategory"].ToString(),
                                    SurgeryDate= Convert.ToDateTime(reader["SurgeryDate"])
                                };
                                surgeries.Add(surgery);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return surgeries;
        }

        public bool UpdateSurgery(Surgery surgery)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string Query = "update Surgery set StartTime=@Value1,EndTime=@Value2,SurgeryCategory=@Value3 where SurgeryId=@value4";
                    using (SqlCommand cmd = new SqlCommand(Query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Value1", surgery.StartTime);
                        cmd.Parameters.AddWithValue("@Value2", surgery.EndTime);
                        cmd.Parameters.AddWithValue("@Value3", surgery.SurgeryCategory);
                        cmd.Parameters.AddWithValue("@Value4", surgery.SurgeryId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Data inserted successfully!");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Data insertion failed.");
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
