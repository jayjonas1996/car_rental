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
using System.IO;

namespace car_rental
{
    public partial class notifications : System.Web.UI.Page
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

            var cmd = new SqlCommand("select booking_id from booking_master where user_id=@user_id order by booking_id desc",con);
            cmd.Parameters.AddWithValue("@user_id",global_user_id);
            var adapter = new SqlDataAdapter(cmd);
            var results = new DataTable();
            con.Open();
            adapter.Fill(results);
            con.Close();

            dropdown_bookid.Items.Clear();
            for (int i = 0; i < results.Rows.Count; i++)
            {
                dropdown_bookid.Items.Add(results.Rows[i][0].ToString());
            }
        }

        protected void loginstatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session["role"] = "null";
            Session["user_id"] = 0;
        }

        protected void show_notifications_Click(object sender, EventArgs e)
        {
            string booking_id = dropdown_bookid.SelectedValue.ToString();

            var cmd = new SqlCommand("select message,msg_date from message_master where booking_id=@booking_id order by msg_date asc", con);
            cmd.Parameters.AddWithValue("@booking_id", booking_id);
            var adapter = new SqlDataAdapter(cmd);
            var results = new DataTable();
            con.Open();
            adapter.Fill(results);
            con.Close();


            gridview1.DataSource = results;
            gridview1.DataBind();
        }
    }
}