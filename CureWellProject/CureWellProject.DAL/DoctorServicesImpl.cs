using CureWellProject.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWellProject.DAL
{
    public class DoctorServicesImpl : DoctorService
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["dbConnect"].ConnectionString;
        private SqlConnection conn;
        private SqlCommand comm;
        public bool AddDoctor(Doctor doctor)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO Doctor VALUES (@Value1)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Value1", doctor.DoctorName);
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


        public bool DeleteDoctor(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string insertQuery = "delete from Doctor where DoctorId= @Value1";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Value1", id);
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

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT * FROM doctor";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Doctor product = new Doctor
                                {
                                    DoctorId = Convert.ToInt32(reader["DoctorID"]),
                                    DoctorName = reader["DoctorName"].ToString()
                                };
                                doctors.Add(product);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message); 
            }
            return doctors;
        }
        public bool UpdateDoctorDetails(Doctor doctor)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string Query = "update Doctor set DoctorName=@Value1 where DoctorID=@value2";
                    using (SqlCommand cmd = new SqlCommand(Query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Value1", doctor.DoctorName);
                        cmd.Parameters.AddWithValue("@Value2", doctor.DoctorId);
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
