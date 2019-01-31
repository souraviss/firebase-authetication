using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace WEbFirebaseAuth.Models
{
    public class ClassDM
    {

        public int SaveData(string Email, string UKey)
        {
            int i = 0;
            using (SqlConnection con = new SqlConnection(ConnectionString.Connection))
            {
                using (SqlCommand cmd = new SqlCommand("[dbo].[sp_InsertSocialUser]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@UKey", UKey);
                    cmd.Parameters.Add("@status", SqlDbType.Int, 30);
                    cmd.Parameters["@status"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    i = Convert.ToInt32(cmd.Parameters["@status"].Value.ToString());
                }
            }
            return i;
        }
    }
}
