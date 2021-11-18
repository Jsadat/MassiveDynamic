using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MassiveDynamicSimpleMembershipApp.Models.Document;
using MassiveDynamicSimpleMembershipApp.Models.General;

namespace MassiveDynamicSimpleMembershipApp.ViewModels.Document
{
    public class DocumentViewModel
    {
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
    }

}