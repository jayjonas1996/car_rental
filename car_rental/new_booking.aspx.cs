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
using System.Xml;
using System.Globalization;
using System.Threading;

namespace car_rental
{
    public partial class new_booking : System.Web.UI.Page
    {
        static string constr = WebConfigurationManager.ConnectionStrings["conshivam"].ConnectionString;
        static SqlConnection con = new SqlConnection(constr);
        static string global_location,global_group,global_pickup,global_user_id;
        static DateTime global_start, global_end;

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session["role"] = "null";
            Session["user_id"] = 0;
        }

        static double global_cost = 0;

        
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod()]
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

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

            string id="0";
            try
            {
                id = Request.QueryString["id"].ToString();
                display_id_label.Text = id;
                global_group = id;
            }
            catch 
            {

                Response.Redirect("catalogue.aspx");
            }

            var cmd = new SqlCommand("select",con);
            cmd.CommandText = "validategroup";
            cmd.CommandType = CommandType.StoredProcedure;

            var exist = new SqlParameter();
            exist.ParameterName = "@exist";
            exist.SqlDbType = SqlDbType.Int;
            exist.Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@group_id",id);
            cmd.Parameters.Add(exist);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            string yn = exist.Value.ToString();

            //string role = Session["role"].ToString();

            var doc = new XmlDocument();
            doc.Load(Server.MapPath("~/pickup.xml"));
            XmlNodeList li = doc.SelectNodes("/pickup/location");

            foreach (XmlNode g in li)
            {
                var att = g.Attributes["value"];
                pickuplocs.Items.Add(att.Value);
            }
        }

        protected void estimate_btn_Click(object sender, EventArgs e)
        {
            if (rent_start_date.Text != "" && rent_till_date.Text != "" && location_box.Text != "")
            {
                CultureInfo my = new CultureInfo("en-IN");
                Thread.CurrentThread.CurrentCulture = my;

                string d1 = rent_start_date.Text.ToString();
                d1 += " 08:00:00 AM";
                var start = DateTime.Parse(d1);
                global_start = start;

                string d2 = rent_till_date.Text.ToString();
                d2 += " 07:00:00 PM";
                var end = DateTime.Parse(d2);
                global_end = end;

                var today = DateTime.Today;
                string location = location_box.Text.ToString();
                global_location = location;

                global_pickup =  pickuplocs.SelectedValue.ToString();

                if (start.Date < end.Date && start.Date > today.Date && (start - today).TotalDays >= 3)
                {
                    var vehicles = new DataTable();                   
                    var cmd = new SqlCommand("SELECT VEHICLE_ID,vehicle_name,fuel_type,seats,CHARGES FROM VEHICLE_MASTER WHERE AVAILABILITY = 'Y' AND VEHICLE_ID NOT IN(select vehicle_id from booking_master where booking_status = 'PROCESSING' OR booking_status = 'ONGOING' OR booking_status = 'CONFIRMED');",con);
                    var adapter = new SqlDataAdapter(cmd);

                    con.Open();
                    adapter.Fill(vehicles);
                    con.Close();

                    if (vehicles.Rows.Count > 0)
                    {
                        string id = vehicles.Rows[0][0].ToString();
                        book_btn.Visible = true;
                        Table1.Visible = true;
                        Table1.Rows.Clear();

                        //Heading row
                        var row_1 = new TableRow();
                        var cell_1_1 = new TableCell();
                        cell_1_1.Text = "Estimated Booking";
                        cell_1_1.ColumnSpan = 2;
                        row_1.Cells.Add(cell_1_1);

                        //Display name
                        var row_2 = new TableRow();
                        var cell_2_1 = new TableCell();
                        var cell_2_2 = new TableCell();
                        cell_2_1.Text = "Name:";
                        cell_2_2.Text = vehicles.Rows[0][1].ToString();
                        row_2.Cells.Add(cell_2_1);
                        row_2.Cells.Add(cell_2_2);

                        //Starting date
                        var row_3 = new TableRow();
                        var cell_3_1 = new TableCell();
                        var cell_3_2 = new TableCell();
                        cell_3_1.Text = "booked from";
                        cell_3_2.Text = start.Date.ToString().Substring(0, 10) + " " + start.TimeOfDay;
                        row_3.Cells.Add(cell_3_1);
                        row_3.Cells.Add(cell_3_2);

                        //ending date
                        var row_4 = new TableRow();
                        var cell_4_1 = new TableCell();
                        var cell_4_2 = new TableCell();
                        cell_4_1.Text = "booked till";
                        cell_4_2.Text = end.Date.ToString().Substring(0, 10) + " " + end.TimeOfDay;
                        row_4.Cells.Add(cell_4_1);
                        row_4.Cells.Add(cell_4_2);

                        //fuel type
                        var row_5 = new TableRow();
                        var cell_5_1 = new TableCell();
                        var cell_5_2 = new TableCell();
                        cell_5_1.Text = "Fuel type";
                        cell_5_2.Text = vehicles.Rows[0][2].ToString();
                        row_5.Cells.Add(cell_5_1);
                        row_5.Cells.Add(cell_5_2);

                        //number of seats
                        var row_6 = new TableRow();
                        var cell_6_1 = new TableCell();
                        var cell_6_2 = new TableCell();
                        cell_6_1.Text = "seats";
                        cell_6_2.Text = vehicles.Rows[0][3].ToString();
                        row_6.Cells.Add(cell_6_1);
                        row_6.Cells.Add(cell_6_2);

                        //number of cars available
                        var row_7 = new TableRow();
                        var cell_7_1 = new TableCell();
                        var cell_7_2 = new TableCell();
                        cell_7_1.Text = "Available";
                        cell_7_2.Text = vehicles.Rows.Count.ToString();
                        row_7.Cells.Add(cell_7_1);
                        row_7.Cells.Add(cell_7_2);

                        //charges approx
                        var row_8 = new TableRow();
                        var cell_8_1 = new TableCell();
                        cell_8_1.ColumnSpan = 2;
                        if ((end.Date - start.Date).TotalDays == 0)
                        {
                            cell_8_1.Text = "Estimated Cost: " + "₹ " + vehicles.Rows[0][4].ToString();
                            global_cost = int.Parse(vehicles.Rows[0][4].ToString());
                        }
                        else
                        {
                            Int64 amount = int.Parse(vehicles.Rows[0][4].ToString());
                            cell_8_1.Text = "Estimated Cost: " + "₹ " + (amount * (end.Date - start.Date).TotalDays);
                            global_cost = (amount * (end.Date - start.Date).TotalDays);
                        }
                        row_8.Cells.Add(cell_8_1);


                        Table1.Rows.Add(row_1);
                        Table1.Rows.Add(row_2);
                        Table1.Rows.Add(row_3);
                        Table1.Rows.Add(row_4);
                        Table1.Rows.Add(row_5);
                        Table1.Rows.Add(row_6);
                        Table1.Rows.Add(row_7);
                        Table1.Rows.Add(row_8);

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "no cars", "alert('Sorry no cars available');", true);
                    }

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "invaliddates", "alert('invalid dates');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "incompleteinfo", "alert('please provide all the information');", true);
            }
        }

        protected void book_btn_Click(object sender, EventArgs e)
        {
            var vehicles = new DataTable();
            var cmd = new SqlCommand("SELECT VEHICLE_ID,vehicle_name,fuel_type,seats,CHARGES FROM VEHICLE_MASTER WHERE AVAILABILITY = 'Y' AND group_id=@group_id and VEHICLE_ID NOT IN(select vehicle_id from booking_master where booking_status = 'PROCESSING' OR booking_status = 'ONGOING' OR booking_status = 'CONFIRMED');", con);
            var adapter = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@group_id",global_group.ToString());

            con.Open(); ;
            adapter.Fill(vehicles);
            con.Close();

            if (vehicles.Rows.Count > 0)
            {
                var insertcmd = new SqlCommand("insert into booking_master (user_id,vehicle_id,location,pickup_location,book_date,rent_date,return_date,paid_amt,cost_amt,booking_status) values(@user_id,@vehicle_id,@location,@pickup_location,@book_date,@rent_date,@return_date,@paid_amt,@cost_amt,@booking_status)",con);
                insertcmd.Parameters.AddWithValue("@user_id",global_user_id);
                insertcmd.Parameters.AddWithValue("@vehicle_id",vehicles.Rows[0][0]);
                insertcmd.Parameters.AddWithValue("@location",global_location);
                insertcmd.Parameters.AddWithValue("@pickup_location",global_pickup);
                SqlParameter now = insertcmd.Parameters.Add("@book_date", System.Data.SqlDbType.DateTime);
                now.Value = DateTime.Now;
                SqlParameter rent = insertcmd.Parameters.Add("@rent_date", System.Data.SqlDbType.DateTime);
                rent.Value = global_start.Date;
                SqlParameter ret  = insertcmd.Parameters.Add("@return_date", System.Data.SqlDbType.DateTime);
                ret.Value = global_end.Date;
                
                insertcmd.Parameters.AddWithValue("@paid_amt",0);
                insertcmd.Parameters.AddWithValue("@cost_amt",global_cost);
                insertcmd.Parameters.AddWithValue("@booking_status", "PROCESSING");

                con.Open();
                int inserted = insertcmd.ExecuteNonQuery();
                con.Close();

                if (inserted > 0)
                {
                    var getid = new SqlCommand("select max(booking_id) from booking_master where user_id = @user_id order by book_date",con);
                    getid.Parameters.AddWithValue("@user_id",global_user_id);

                    con.Open();
                    int book_id = (int)cmd.ExecuteScalar();
                    con.Close();

                    var insertmsg = new SqlCommand("insert into message_master (user_id,booking_id,message,msg_date) values(@user_id,@booking_id,@message,@msg_date)",con);
                    SqlParameter today = insertmsg.Parameters.Add("@msg_date", System.Data.SqlDbType.DateTime);
                    today.Value = DateTime.Now;
                    insertmsg.Parameters.AddWithValue("@user_id",global_user_id);
                    insertmsg.Parameters.AddWithValue("@booking_id",book_id);
                    insertmsg.Parameters.AddWithValue("@message","Your booking is being processed");

                    con.Open();
                    int msginserted =  insertmsg.ExecuteNonQuery();
                    con.Close();


                    ClientScript.RegisterStartupScript(this.GetType(), "booked", "alert('booking successful, check my booking page');", true);
                }
                


            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "not booked", "alert('car was unavailable Sorry');", true);
            }

        }
    }
}