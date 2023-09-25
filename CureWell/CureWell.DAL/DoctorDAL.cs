using CureWell.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWell.DAL
{
    public interface DoctorDAL
    {
        List<Doctor> GetAllDoctors();
        bool AddDoctor(Doctor doctor);
        bool UpdateDoctorDetails(Doctor doctor);
        bool DeleteDoctor(int id);
    }
}
