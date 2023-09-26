using CureWellProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWellProject.DAL
{
    public interface DoctorSpecializationServices
    {
         List<DoctorSpecialization> GetDoctorsBySpecializations(string specializationCode);
         bool AddDoctorSpecialization(DoctorSpecialization doctorSpecialization);
    }
}
