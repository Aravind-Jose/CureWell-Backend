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
    public class DoctorSpecializationServicesImpl : DoctorSpecializationServices
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["dbConnect"].ConnectionString;

        public bool AddDoctorSpecialization(DoctorSpecialization doctorSpecialization)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO DoctorSpecialization VALUES (@Value1,@Value2,@Value3)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Value1", doctorSpecialization.DoctorId);
                        cmd.Parameters.AddWithValue("@Value2", doctorSpecialization.SpecializationCode);
                        cmd.Parameters.AddWithValue("@Value3", doctorSpecialization.SpecializationDate);

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

        public List<DoctorSpecialization> GetDoctorsBySpecializations(string specializationCode)
        {
            List<DoctorSpecialization> doctorSpecializations = new List<DoctorSpecialization>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT * FROM DoctorSpecialization where SpecializationCode=@Value1";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Value1", specializationCode);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DoctorSpecialization doctorSpecialization = new DoctorSpecialization
                                {
                                    DoctorId = Convert.ToInt32(reader["DoctorID"]),
                                    SpecializationCode = reader["SpecializationCode"].ToString(),
                                    SpecializationDate = Convert.ToDateTime(reader["SpecializationDate"])
                                };
                                doctorSpecializations.Add(doctorSpecialization);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return doctorSpecializations;
        }
    }
}
