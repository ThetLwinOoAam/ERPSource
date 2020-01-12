using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCErp.DataAccess;
using BCErp.DTO;


namespace BCErp.BusinessLogic
{
    public class RoleBL
    {
        RoleDAO roleDAO = new RoleDAO();

        public List<RoleDTO> GetAll()
        {
            return roleDAO.GetAll();
        }

    }
}
