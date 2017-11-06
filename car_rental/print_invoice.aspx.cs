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
    public partial class print_invoice : System.Web.UI.Page
    {
        static string global_book_id;
        static string constr = WebConfigurationManager.ConnectionStrings["conshivam"].ConnectionString;
        static SqlConnection con = new SqlConnection(constr);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].ToString() == "user")
                {
                    //global_book_id = Session["user_id"].ToString();
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
            try
            {
                global_book_id = Request.QueryString["id"].ToString();
            }
            catch
            {
                global_book_id = "0";
            }

            var cmd = new SqlCommand("select booking_id,name,vehicle_name,location,pickup_location,rent_date,return_date,paid_amt as Paid,kms,fuel_amt from booking_master join user_master on(booking_master.user_id = user_master.user_id) join vehicle_master on(booking_master.vehicle_id = vehicle_master.vehicle_id) where booking_id=@id",con);
            cmd.Parameters.AddWithValue("@id",global_book_id);
            var adapter = new SqlDataAdapter(cmd);
            var result = new DataTable();


            con.Open();
            adapter.Fill(result);
            con.Close();

            if (result.Rows.Count == 1)
            {
                DetailsView1.DataSource = result;
                DetailsView1.DataBind();
                Label2.Text = result.Rows[0][7].ToString();
            }
            else
            {
                Response.Redirect("show_bookings.aspx");
            }

            
        }
    }
}