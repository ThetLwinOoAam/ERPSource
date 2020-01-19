using BCErp.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCErp.DataAccess
{
    public class SupplierDAO
    {
        public List<SupplierDTO> GetAll()
        {
            List<SupplierDTO> suppierDTOs = new List<SupplierDTO>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Purchase.TblSupplier", DbConnector.Connect());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            DataTable dt = dataSet.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SupplierDTO supplierDTO = new SupplierDTO()
                {
                    Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                    Code = Convert.ToString(dt.Rows[i]["Code"]),
                    Name = Convert.ToString(dt.Rows[i]["Name"]),
                    PhoneNo = Convert.ToString(dt.Rows[i]["PhoneNo"]),
                    Address = Convert.ToString(dt.Rows[i]["Address"]),
                    RegisterDate = Convert.ToDateTime(dt.Rows[i]["RegisterDate"]),
                    CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]),
                    CreatedBy = Convert.ToInt32(dt.Rows[i]["CreatedBy"]),
                    Active = Convert.ToBoolean(dt.Rows[i]["Active"])
                };

                if (dt.Rows[i]["ModifiedOn"] != DBNull.Value)
                    supplierDTO.ModifiedOn = Convert.ToDateTime(dt.Rows[i]["ModifiedOn"]);
                if (dt.Rows[i]["ModifiedBy"] != DBNull.Value)
                    supplierDTO.ModifiedBy = Convert.ToInt32(dt.Rows[i]["ModifiedBy"]);

                suppierDTOs.Add(supplierDTO);
            }

            return suppierDTOs;
        }
    }
}
