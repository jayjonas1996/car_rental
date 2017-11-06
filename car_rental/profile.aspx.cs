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
namespace car_rental
{
    public partial class profile : System.Web.UI.Page
    {

        static string constr = WebConfigurationManager.ConnectionStrings["conshivam"].ConnectionString;
        static SqlConnection con = new SqlConnection(constr);
        static string global_user_id;
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
        }

        protected void loginstatus2_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session["role"] = "null";
            Session["user_id"] = 0;
        }
    }
}