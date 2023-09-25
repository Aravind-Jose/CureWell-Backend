using CureWellProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWellProject.DAL
{
    public interface DoctorService
    {
        List<Doctor> GetAllDoctors();
        bool AddDoctor(Doctor doctor);
        bool UpdateDoctorDetails(Doctor doctor);
        bool DeleteDoctor(int id);
    }
}
