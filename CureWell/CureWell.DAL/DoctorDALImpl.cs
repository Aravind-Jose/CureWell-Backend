using CureWell.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CureWell.DAL
{
    public class DoctorDALImpl : DoctorDAL
    {
        private SqlConnection conn;
        private SqlCommand comm;
        public DoctorDALImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
            comm.Connection = conn;
        }
        public bool AddDoctor(Doctor doctor)
        {

            comm.CommandText = "insert into Employee values('" + doctor.DoctorId + "','" + doctor.DoctorName + "')";
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            if (rows > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool DeleteDoctor(int id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAllDoctors()
        {
            throw new NotImplementedException();
        }

        public bool UpdateDoctorDetails(Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
