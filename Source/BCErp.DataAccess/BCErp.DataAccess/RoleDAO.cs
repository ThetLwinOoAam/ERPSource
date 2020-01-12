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
   public class RoleDAO
    {
        public List<RoleDTO> GetAll()
        {
            List<RoleDTO> roleDTOs = new List<RoleDTO>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Administration.TblRole",DbConnector.Connect());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            DataTable dt = dataSet.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                RoleDTO roleDTO = new RoleDTO()
                {
                    Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                    Code = Convert.ToString(dt.Rows[i]["Code"]),
                    Name = Convert.ToString(dt.Rows[i]["Name"]),
                    CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]),
                    CreatedBy = Convert.ToInt32(dt.Rows[i]["CreatedBy"]),
                    Active = Convert.ToBoolean(dt.Rows[i]["Active"])
                };

                if (dt.Rows[i]["ModifiedOn"] != DBNull.Value)
                    roleDTO.ModifiedOn = Convert.ToDateTime(dt.Rows[i]["ModifiedOn"]);
                if (dt.Rows[i]["ModifiedBy"] != DBNull.Value)
                    roleDTO.ModifiedBy=Convert.ToInt32(dt.Rows[i]["ModifiedBy"]);

                roleDTOs.Add(roleDTO);
            }

            return roleDTOs;
        }
    }
}
