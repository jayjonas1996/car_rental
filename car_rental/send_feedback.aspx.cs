using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.Configuration;

namespace car_rental
{
    public partial class send_feedback : System.Web.UI.Page
    {
        static string global_user_id;
        static string constr = WebConfigurationManager.ConnectionStrings["conshivam"].ConnectionString;
        static SqlConnection con = new SqlConnection(constr);
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
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session["role"] = "null";
            Session["user_id"] = 0;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (feeback_box.Text != "")
            {
                var cmd = new SqlCommand("insert into feedback_master (user_id,message,post_date) values(@user_id,@message,@post_date)",con);
                var now = cmd.Parameters.Add("@post_date",SqlDbType.DateTime2);
                now.Value = DateTime.Now;
                cmd.Parameters.AddWithValue("@message",feeback_box.Text.ToString());
                cmd.Parameters.AddWithValue("@user_id",global_user_id);

                con.Open();
                int inserted = cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}