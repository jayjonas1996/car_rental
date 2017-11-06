using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.Configuration;
using System.Data;

namespace car_rental
{
    public partial class add_admin : System.Web.UI.Page
    {
        static string constr = WebConfigurationManager.ConnectionStrings["conshivam"].ConnectionString;
        static SqlConnection con = new SqlConnection(constr);
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            try
            {
                if (Session["role"].ToString() == "admin")
                {

                }
                else if (Session["role"].ToString() == "user")
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

        protected void add_btn_pressed(object sender, EventArgs e)
        {
            if (password_box.Text.Length > 4 && password_re_box.Text.Length > 4 && username_box.Text.Length > 4 && password_re_box.Text == password_box.Text)
            {
                var cmd = new SqlCommand("addadmin",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username",username_box.Text.ToLower());
                cmd.Parameters.AddWithValue("@passhash",password_box.Text);

                con.Open();
                int inserted = cmd.ExecuteNonQuery();
                con.Close();

                if (inserted == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "created_new_admin", "alert('Admin Created');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(),"can't create","alert('make sure password fields match or try different username');",true);
                }
            }
        }

        protected void loginstatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session["role"] = "null";
        }
    }
}