using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MassiveDynamicSimpleMembershipApp.Models.Clients;
using MassiveDynamicSimpleMembershipApp.Models.General;



namespace MassiveDynamicSimpleMembershipApp.ViewModels.Clients
{
    public class ClientsViewModel
    {
        //This is user fitch all Client from Database
        public static List<ClientsModel> GetAllClient()
        {
            List<ClientsModel> client = new List<ClientsModel>();

            using (SqlConnection conn = new SqlConnection(Appsetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllClient", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ClientsModel item = new ClientsModel();
                        item.UserId = (int)reader["UserId"];
                        item.Name = reader["Name"].ToString();
                        item.UserName = reader["UserName"].ToString();
                        item.Email = reader["Email"].ToString();
                        item.UniqueID = reader["ClientUniqueID"].ToString();

                        client.Add(item);
                    }

                }
            }
            return client;
        }

        public static List<ClientsModel> FindClient(string SearchTerm)
        {
            List<ClientsModel> info = new List<ClientsModel>();

            using (SqlConnection conn = new SqlConnection(Appsetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("[GetClientByUniqueID]", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@UniqueID", SearchTerm);
                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();

                    ClientsModel item = new ClientsModel();
                    item.UserId = (int)reader["UserId"];
                    item.Name = reader["Name"].ToString();
                    item.UserName = reader["UserName"].ToString();
                    item.Email = reader["Email"].ToString();
                    item.UniqueID = reader["ClientUniqueID"].ToString();


                    info.Add(item);


                }
            }
            return info;
        }

        internal static ClientProfileModel GetClientProfile(int currentUserId)
        {
            ClientProfileModel ClientProfile = new ClientProfileModel();
            using (SqlConnection conn = new SqlConnection(Appsetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("[GetClientByUSerID]", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@UserID", currentUserId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    ClientProfile.Name = reader["Name"].ToString();
                    ClientProfile.UserName = reader["UserName"].ToString();
                    ClientProfile.Email = reader["Email"].ToString();
                    ClientProfile.UniqueId = reader["ClientUniqueID"].ToString();


                }
            }
            return ClientProfile;
        }

        //this function is user Get All Document of specific Client
        public static List<ClientsModel> GetDocumentsOfClient(int UserId)
        {
            List<ClientsModel> Doc = new List<ClientsModel>();

            using (SqlConnection conn = new SqlConnection(Appsetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("GetDocumentsByUserId", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ClientsModel item = new ClientsModel();
                        item.ID = (int)reader["id"];
                        item.FileName = reader["FileName"].ToString();
                        item.FilePath = reader["FilePath"].ToString();

                        Doc.Add(item);
                    }

                }
            }
            return Doc;
        }

        //Is Used to Delete only the documnet of client by Admin
        internal static void DeleteDocument(int id)
        {
            using (SqlConnection conn = new SqlConnection(Appsetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("[Delete_Document]", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        //This fucntion is used to get Client info for edit
        public static ClientsModel GetClientByUserID(int UserId)
        {
            ClientsModel item = new ClientsModel();
            using (SqlConnection conn = new SqlConnection(Appsetting.ConnectionString()))
            {

                using (SqlCommand cmd = new SqlCommand("[GetClientByUSerID]", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();


                    item.UserId = (int)reader["UserId"];
                    item.Name = reader["Name"].ToString();
                    item.UserName = reader["UserName"].ToString();
                    item.Email = reader["Email"].ToString();


                }
            }
            return item;
        }
        internal static void EditClientInfo(ClientsModel model)
        {
            using (SqlConnection conn = new SqlConnection(Appsetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("[Update_clients]", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", model.UserId);
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@UserName", model.UserName);
                    cmd.Parameters.AddWithValue("@Email", model.Email);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        internal static void DeleteClientInfo(int UserId)
        {
            using (SqlConnection conn = new SqlConnection(Appsetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("[Delete_Users]", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", UserId);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

    }
}