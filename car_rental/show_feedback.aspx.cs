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
    public partial class show_feedback : System.Web.UI.Page
    {
        static string constr = WebConfigurationManager.ConnectionStrings["conshivam"].ConnectionString;
        static SqlConnection con = new SqlConnection(constr);
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
            
            var cmd = new SqlCommand("select name,message,post_date from feedback_master join user_master on(feedback_master.user_id = user_master.user_id) order by post_date asc",con);
            var adapter = new SqlDataAdapter(cmd);
            var results = new DataTable();

            con.Open();
            adapter.Fill(results);
            con.Close();

            dg1.DataSource = results;
            dg1.DataBind();
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session["role"] = "null";
        }
    }
}