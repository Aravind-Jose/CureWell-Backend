using CureWellProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureWellProject.DAL
{
    public interface SurgerySevices
    {
        List<Surgery> GetAllSurgeryTypeForToday();
        bool UpdateSurgery(Surgery surgery);

    }
}
