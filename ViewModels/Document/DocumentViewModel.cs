using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MassiveDynamicSimpleMembershipApp.Models.Accounts;
using MassiveDynamicSimpleMembershipApp.Models.Clients;
using MassiveDynamicSimpleMembershipApp.Models.Document;
using MassiveDynamicSimpleMembershipApp.Models.General;

namespace MassiveDynamicSimpleMembershipApp.ViewModels.Document
{
    public class DocumentViewModel
    {
        //Insert File info to DB
        internal static void InsertDocument(Document_Model filesModel)
        {
            using (SqlConnection conn = new SqlConnection(Appsetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("[InsertFileData]", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", filesModel.UserID);
                    cmd.Parameters.AddWithValue("@FilePath", filesModel.FilePath);
                    cmd.Parameters.AddWithValue("@FileName", filesModel.FileName);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        // this function check the Unique ID of the if it's exist or not and return single value
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

        //to insert Document and assign Unique ID for client into differen tables
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