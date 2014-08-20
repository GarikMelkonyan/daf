using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAF.DataAccess;

namespace DAF.Business
{
    public class ManagerBase
    {
        internal static Entities CreateDataContext()
        {
            return new Entities();
        }
    }
}
