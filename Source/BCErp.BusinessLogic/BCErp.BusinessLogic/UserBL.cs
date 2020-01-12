using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCErp.DataAccess;
using BCErp.DTO;


namespace BCErp.BusinessLogic
{
    public class UserBL
    {
        UserDAO userDAO = new UserDAO();

        public List<UserDTO> GetAll()
        {
            return userDAO.GetAll();
        }

    }
}
