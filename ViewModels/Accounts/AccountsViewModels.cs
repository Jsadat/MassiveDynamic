using MassiveDynamicSimpleMembershipApp.Models.General;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MassiveDynamicSimpleMembershipApp.Models.Accounts;

namespace MassiveDynamicSimpleMembershipApp.ViewModels.Accounts
{
    public class AccountsViewModels
    {
      //  this is comment

        //This is Used to Bind the Roles with dropDownlist
        public static List<SelectListItem> GetAllRoles(int RoleId)
        {
            List<SelectListItem> roles = new List<SelectListItem>();

            using (SqlConnection conn = new SqlConnection(Appsetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("GetRolesbyRolesID", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@RoleId", RoleId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SelectListItem item = new SelectListItem();
                        item.Value = reader["RoleName"].ToString();
                        item.Text = reader["RoleName"].ToString();
                        roles.Add(item);
                    }

                }
            }
            return roles;
        }


        //this Function is used to Get all Users Information for Admin
        public static List<UserModel> GetAllUser()
        {
            List<UserModel> users = new List<UserModel>();

            using (SqlConnection conn = new SqlConnection(Appsetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllUserList", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        UserModel item = new UserModel();
                        item.UserId = (int)reader["UserId"];
                        item.Name = reader["Name"].ToString();
                        item.UserName = reader["UserName"].ToString();
                        item.Email = reader["Email"].ToString();
                        item.Role = reader["RoleName"].ToString();
                        users.Add(item);
                    }
                }
            }
            return users;
        }

        //this allow admin to delete all users releated data through store procdure
        internal static void DeleteUsers(int userid)
        {
            using (SqlConnection conn = new SqlConnection(Appsetting.ConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("[Delete_Users]", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", userid);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}