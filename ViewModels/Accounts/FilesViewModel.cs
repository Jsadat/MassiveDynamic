using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MassiveDynamicSimpleMembershipApp.Models.Accounts;
using MassiveDynamicSimpleMembershipApp.Models.Clients;
using MassiveDynamicSimpleMembershipApp.Models.General;
using WebMatrix.WebData;

namespace MassiveDynamicSimpleMembershipApp.ViewModels.Accounts
{
    public class FilesViewModel
    {
        public static string CheckUniqueID(string UniqueID)
        {
            List<ClientsModel> info = new List<ClientsModel>();

            using (SqlConnection conn = new SqlConnection(Appsetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("[ClientUniqueID]", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UniqueID", UniqueID);
                    conn.Open();

                    string k = (string)cmd.ExecuteScalar();
                    conn.Close();
                    return k;

                }
            }

        }

        internal static void InsertFile(RegisterModel filesModel)
        {
            using (SqlConnection conn = new SqlConnection(Appsetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("[InsertFileAndUniqueIdData]", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserName", filesModel.UserName);
                    cmd.Parameters.AddWithValue("@FilePath", filesModel.FilePath);
                    cmd.Parameters.AddWithValue("@ClientID", filesModel.ClientUniqueID);
                    cmd.Parameters.AddWithValue("@FileName", filesModel.FileName);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();



                }
            }
        }
    }
}