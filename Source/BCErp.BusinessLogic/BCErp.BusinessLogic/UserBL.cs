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

        public int Create(UserDTO userDTO)
        {
            return userDAO.Create(userDTO);
        }

        public int Edit(UserDTO userDTO)
        {
            return userDAO.Edit(userDTO);
        }
        public UserDTO GetById(int id)
        {
            return userDAO.GetById(id);
        }
    }
}
