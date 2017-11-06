using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace car_rental
{
    public partial class profile : System.Web.UI.Page
    {
        MD5 my5 = MD5.Create();
        static string constr = WebConfigurationManager.ConnectionStrings["conshivam"].ConnectionString;
        static SqlConnection con = new SqlConnection(constr);
        static string global_user_id,global_license;
        static string[] extensions = {".jpg",".png",".jpeg",".tiff" }; 
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].ToString() == "user")
                {
                    global_user_id = Session["user_id"].ToString();
                }
                else if (Session["role"].ToString() == "admin")
                {
                    Response.Redirect("default.aspx");
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
            catch
            {
                Response.Redirect("login.aspx");
            }

            var cmd = new SqlCommand("select username,name,address,dob,email_id,city,state,pincode,license_no from user_master where user_id=@user_id",con);
            cmd.Parameters.AddWithValue("@user_id",global_user_id);
            var adapter = new SqlDataAdapter(cmd);
            var data = new DataTable();
            con.Open();
            adapter.Fill(data);
            con.Close();

            detailview1.DataSource = data;
            detailview1.DataBind();

            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(Server.MapPath("~/files/limg/"));
            FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles(data.Rows[0][8].ToString() + ".jpg");

            global_license = data.Rows[0][8].ToString();
            if (filesInDir.Length > 0)
            {
                Image1.ImageUrl = "~/files/limg/"+data.Rows[0][8].ToString()+".jpg";
            }

        }

        protected void loginstatus2_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session["role"] = "null";
            Session["user_id"] = 0;
        }

        protected void change_pass_btn_Click(object sender, EventArgs e)
        {
            if (old_pass_box.Text.ToString() != "" && new_password_box.Text.ToString() != "" && new_password_re_box.Text.ToString() != "" && new_password_re_box.Text.ToString() == new_password_box.Text.ToString() && new_password_box.Text.ToString() != old_pass_box.Text.ToString())
            {
                string old_hash = GetHash(my5, old_pass_box.Text.ToString());
                string new_hash = GetHash(my5, new_password_box.Text.ToString());

                var cmd = new SqlCommand("changepassword",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id",global_user_id);
                cmd.Parameters.AddWithValue("@old_hash",old_hash);
                cmd.Parameters.AddWithValue("@new_hash",new_hash);

                con.Open();
                int changed = cmd.ExecuteNonQuery();
                con.Close();

                if (changed == 1)
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "success changed", "alert('password chanaged');", false);
                }

            }
            else
            {
                //ClientScript.RegisterStartupScript(this.GetType(),"incomplete","alert('please provide correct input and a different password');",false);
            }
        }

        protected void upload_btn_Click(object sender, EventArgs e)
        {
            if (fup1.HasFile)
            {
                string extension = Path.GetExtension(fup1.FileName);
                if (extensions.Contains(extension))
                {
                    fup1.SaveAs(Path.Combine(Server.MapPath("~/files/limg/"),global_license  + ".jpg"));
                }
            }
        
        }

        protected void delete_acc_Click(object sender, EventArgs e)
        {
            if (confirm_pass_box.Text != "")
            {
                string hash = GetHash(my5, confirm_pass_box.Text.ToString());

                var cmd = new SqlCommand("deleteaccount",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id",global_user_id.ToString());
                cmd.Parameters.AddWithValue("@hash",hash);

                con.Open();
                int deleted = cmd.ExecuteNonQuery();
                con.Close();

                if (deleted > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "deleted", "alert('Deleted');", true);
                    Session["role"] = "null";
                    Session["user_id"] = 0;
                    Response.Redirect("login.aspx");
                }


            }
        }

        static string GetHash(MD5 my5, string input)
        {
            byte[] hash = my5.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sbuilder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            { sbuilder.Append(hash[i].ToString("x2")); }
            return sbuilder.ToString();
        }
    }
}