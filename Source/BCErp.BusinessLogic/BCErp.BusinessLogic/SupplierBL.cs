using BCErp.DataAccess;
using BCErp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCErp.BusinessLogic
{
    public class SupplierBL
    {
        SupplierDAO supplierDAO = new SupplierDAO();

        public List<SupplierDTO> GetAll()
        {
            return supplierDAO.GetAll();
        }
    }
}
