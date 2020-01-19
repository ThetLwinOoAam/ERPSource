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

        public UserDTO GetById(int id)
        {
            UserDTO userDTO = new UserDTO();

            SqlCommand cmd = new SqlCommand("SELECT u.*,r.Name RoleName FROM Administration.TblUser u INNER JOIN Administration.TblRole r ON u.RoleId=r.Id WHERE u.Id=@Id", DbConnector.Connect());
            cmd.Parameters.AddWithValue("@Id",id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            DataTable dt = dataSet.Tables[0];
            if(dt.Rows.Count>0)
            {
                userDTO = new UserDTO()
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    Code = Convert.ToString(dt.Rows[0]["Code"]),
                    Name = Convert.ToString(dt.Rows[0]["Name"]),
                    Email = Convert.ToString(dt.Rows[0]["Email"]),
                    Password = Convert.ToString(dt.Rows[0]["Password"]),
                    RoleId = Convert.ToInt32(dt.Rows[0]["RoleId"]),
                    RoleName = Convert.ToString(dt.Rows[0]["RoleName"]),
                    CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]),
                    CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]),
                    Active = Convert.ToBoolean(dt.Rows[0]["Active"])
                };

                if (dt.Rows[0]["ModifiedOn"] != DBNull.Value)
                    userDTO.ModifiedOn = Convert.ToDateTime(dt.Rows[0]["ModifiedOn"]);
                if (dt.Rows[0]["ModifiedBy"] != DBNull.Value)
                    userDTO.ModifiedBy = Convert.ToInt32(dt.Rows[0]["ModifiedBy"]);

                
            }

            return userDTO;
        }

        public int Create(UserDTO userDTO)
        {
            SqlCommand cmd = new SqlCommand("SpCreateUser", DbConnector.Connect());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Code", userDTO.Code);
            cmd.Parameters.AddWithValue("@Name", userDTO.Name);
            cmd.Parameters.AddWithValue("@Email", userDTO.Email);
            cmd.Parameters.AddWithValue("@Password", userDTO.Password);
            cmd.Parameters.AddWithValue("@RoleId", userDTO.RoleId);
            cmd.Parameters.AddWithValue("@CreatedBy", userDTO.CreatedBy);
            cmd.Parameters.AddWithValue("@Active", userDTO.Active);

            return cmd.ExecuteNonQuery();

        }
    }
}
