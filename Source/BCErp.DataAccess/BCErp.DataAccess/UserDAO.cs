using BCErp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BCErp.DataAccess
{
    public class UserDAO
    {
        public List<UserDTO> GetAll()
        {
            List<UserDTO> userDTOs = new List<UserDTO>();

            SqlCommand cmd = new SqlCommand("SELECT u.*,r.Name RoleName FROM Administration.TblUser u INNER JOIN Administration.TblRole r ON u.RoleId=r.Id", DbConnector.Connect());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            DataTable dt = dataSet.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UserDTO roleDTO = new UserDTO()
                {
                    Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                    Code = Convert.ToString(dt.Rows[i]["Code"]),
                    Name = Convert.ToString(dt.Rows[i]["Name"]),
                    Email = Convert.ToString(dt.Rows[i]["Email"]),
                    Password = Convert.ToString(dt.Rows[i]["Password"]),
                    RoleId = Convert.ToInt32(dt.Rows[i]["RoleId"]),
                    RoleName = Convert.ToString(dt.Rows[i]["RoleName"]),
                    CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]),
                    CreatedBy = Convert.ToInt32(dt.Rows[i]["CreatedBy"]),
                    Active = Convert.ToBoolean(dt.Rows[i]["Active"])
                };

                if (dt.Rows[i]["ModifiedOn"] != DBNull.Value)
                    roleDTO.ModifiedOn = Convert.ToDateTime(dt.Rows[i]["ModifiedOn"]);
                if (dt.Rows[i]["ModifiedBy"] != DBNull.Value)
                    roleDTO.ModifiedBy = Convert.ToInt32(dt.Rows[i]["ModifiedBy"]);

                userDTOs.Add(roleDTO);
            }

            return userDTOs;
        }
    }
}
