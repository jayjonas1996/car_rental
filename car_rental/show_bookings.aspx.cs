using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.Configuration;

namespace car_rental
{
    public partial class show_bookings : System.Web.UI.Page
    {
        static string constr = WebConfigurationManager.ConnectionStrings["conshivam"].ConnectionString;
        static SqlConnection con = new SqlConnection(constr);
        static double max = 0.0;
        static int global_id = 0;
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

            var cmd = new SqlCommand("select booking_id,vehicle_id,location,pickup_location,book_date,rent_date,return_date,paid_amt,cost_amt,kms,booking_status from booking_master where user_id = @user_id",con);
            cmd.Parameters.AddWithValue("@user_id",global_user_id);
            var bookings = new DataTable();
            var adapter = new SqlDataAdapter(cmd);

            con.Open();
            adapter.Fill(bookings);
            con.Close();

            Table1.Rows.Clear();

            var row_main = new TableRow();
            var cell_1_1 = new TableCell();
            cell_1_1.Text = "booking id";
            var cell_1_2 = new TableCell();
            cell_1_2.Text = "vehicle id";
            var cell_1_3 = new TableCell();
            cell_1_3.Text = "location";
            var cell_1_4 = new TableCell();
            cell_1_4.Text = "pickup";
            var cell_1_5 = new TableCell();
            cell_1_5.Text = "book date";
            var cell_1_6 = new TableCell();
            cell_1_6.Text = "renting date";
            var cell_1_7 = new TableCell();
            cell_1_7.Text = "return date";
            var cell_1_8 = new TableCell();
            cell_1_8.Text = "paid";
            var cell_1_9 = new TableCell();
            cell_1_9.Text = "cost";
            var cell_1_10 = new TableCell();
            cell_1_10.Text = "kms";
            var cell_1_11 = new TableCell();
            cell_1_11.Text = "Status";
   
            var cell_1_12 = new TableCell();
            cell_1_12.Text = "pay";
            var cell_1_13= new TableCell();
            cell_1_13.Text = "bill";
            var cell_1_14 = new TableCell();
            cell_1_14.Text = "Cancel";

            row_main.Cells.Add(cell_1_1);
            row_main.Cells.Add(cell_1_2);
            row_main.Cells.Add(cell_1_3);
            row_main.Cells.Add(cell_1_4);
            row_main.Cells.Add(cell_1_5);
            row_main.Cells.Add(cell_1_6);
            row_main.Cells.Add(cell_1_7);
            row_main.Cells.Add(cell_1_8);
            row_main.Cells.Add(cell_1_9);
            row_main.Cells.Add(cell_1_10);
            row_main.Cells.Add(cell_1_11);
            row_main.Cells.Add(cell_1_12);
            row_main.Cells.Add(cell_1_13);
            row_main.Cells.Add(cell_1_14);


            Table1.Rows.Add(row_main);

            for (int i = 0; i < bookings.Rows.Count; i++)
            {
                var new_row = new TableRow();

                var cell_2_1 = new TableCell();
                var cell_2_2 = new TableCell();
                var cell_2_3 = new TableCell();
                var cell_2_4 = new TableCell();
                var cell_2_5 = new TableCell();
                var cell_2_6 = new TableCell();
                var cell_2_7 = new TableCell();
                var cell_2_8 = new TableCell();
                var cell_2_9 = new TableCell();
                var cell_2_10 = new TableCell();
                var cell_2_11 = new TableCell();

                var cell_2_12 = new TableCell();
                var cell_2_13 = new TableCell();
                var cell_2_14 = new TableCell();

                cell_2_1.Text = bookings.Rows[i][0].ToString();
                cell_2_2.Text = bookings.Rows[i][1].ToString();
                cell_2_3.Text = bookings.Rows[i][2].ToString();
                cell_2_4.Text = bookings.Rows[i][3].ToString();
                cell_2_5.Text = bookings.Rows[i][4].ToString();
                cell_2_6.Text = bookings.Rows[i][5].ToString();
                cell_2_7.Text = bookings.Rows[i][6].ToString();
                try
                {
                    cell_2_8.Text = bookings.Rows[i][7].ToString();
                }
                catch
                {
                    cell_2_8.Text = "000.00";
                }
                cell_2_9.Text = bookings.Rows[i][8].ToString();
                cell_2_10.Text = bookings.Rows[i][9].ToString();
                cell_2_11.Text = bookings.Rows[i][10].ToString();

                var pay_btn = new Button();
                pay_btn.ID = bookings.Rows[i][0].ToString();
                pay_btn.Text = "Pay";
                pay_btn.Click += new EventHandler(pay_btn_pressed);
                var print = new Button();
                print.ID = "a" + bookings.Rows[i][0].ToString();
                print.Text = "Print Invoice";
                print.Click += new EventHandler(print_btn_pressed);

                if (cell_2_8.Text.ToString() != bookings.Rows[i][8].ToString() && bookings.Rows[i][10].ToString() != "CANCELLED")
                {
                    cell_2_12.Controls.Add(pay_btn);
                }
                else
                {
                    cell_2_13.Controls.Add(print);
                }

                if (bookings.Rows[i][10].ToString() == "PROCESSING" || bookings.Rows[i][10].ToString() == "CONFIRMED")
                {
                    var cancel_btn = new Button();
                    cancel_btn.Text = "Cancel";
                    cancel_btn.ID = "c" +bookings.Rows[i][0].ToString();
                    cancel_btn.Click += new EventHandler(cancel_tableBTN_pressed);
                    cell_2_14.Controls.Add(cancel_btn);
                }

                new_row.Cells.Add(cell_2_1);
                new_row.Cells.Add(cell_2_2);
                new_row.Cells.Add(cell_2_3);
                new_row.Cells.Add(cell_2_4);
                new_row.Cells.Add(cell_2_5);
                new_row.Cells.Add(cell_2_6);
                new_row.Cells.Add(cell_2_7);
                new_row.Cells.Add(cell_2_8);
                new_row.Cells.Add(cell_2_9);
                new_row.Cells.Add(cell_2_10);
                new_row.Cells.Add(cell_2_11);
                new_row.Cells.Add(cell_2_12);
                new_row.Cells.Add(cell_2_13);
                new_row.Cells.Add(cell_2_14);

                Table1.Rows.Add(new_row);


            }
        }

        protected void pay_btn_pressed(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            string id = pressed.ID.ToString();
            payment_div.Visible = true;
            display_id.Text = id;

            var cmd = new SqlCommand("select paid_amt,cost_amt from booking_master where booking_id = @booking_id",con);
            var result = new DataTable();
            var adapter = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@booking_id",id);

            con.Open();
            adapter.Fill(result);
            con.Close();

            if (result.Rows.Count > 0)
            {
                double paid = double.Parse( result.Rows[0][0].ToString());
                double cost = double.Parse(result.Rows[0][1].ToString());

                pay_amt.Text += " (max payable = "+(cost-paid).ToString()+")";
                max = cost - paid;
            }






           
        }

        protected void print_btn_pressed(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            string id = pressed.ID.ToString();
            id = id.Substring(1,id.Length -1);
            string redirectURL = "window.open(\'"+"print_invoice.aspx?id="+id+"\',\'_newtab\');";
            ClientScript.RegisterStartupScript(this.GetType(),"opennewwindowinvoice",redirectURL,true);
        }

        protected void do_payment_pressed(object sender, EventArgs e)
        {
            double paid_amount;
            string id = display_id.Text.ToString();
            var get = new SqlCommand("select paid_amt from booking_master where booking_id=@id",con);
            get.Parameters.AddWithValue("@id",id);
            
            con.Open();
            //paid_amount = double.Parse(get.ExecuteScalar().ToString());
            try
            {
                paid_amount = double.Parse( get.ExecuteScalar().ToString() );
            }
            catch 
            {

                paid_amount = 0000.00;
            }
            con.Close();


            if(card_box.Text != "" && amount_box.Text!="" && (double.Parse(amount_box.Text.ToString()) <= max)   )
            {
                double paying = double.Parse(amount_box.Text.ToString())   ;

                var cmd = new SqlCommand("update booking_master set paid_amt=@paid_amt,card_no=@card_no where booking_id=@booking_id",con);
                cmd.Parameters.AddWithValue("@paid_amt",paying + paid_amount);
                cmd.Parameters.AddWithValue("@booking_id",id);
                cmd.Parameters.AddWithValue("@card_no",card_box.Text.ToString());

                con.Open();
                int inserted = cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        protected void cancel_tableBTN_pressed(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            string id = pressed.ID.ToString();
            id = id.Substring(1, id.Length - 1);

            display_cncl_id.Text = id;
            cancel_div.Visible = true;
        }

        protected void do_cancel(object sender, EventArgs e)
        {
            string id = display_cncl_id.Text.ToString();

            if (cancel_box.Text != "")
            {
                var cmd = new SqlCommand("update booking_master set cancel_date=@cancel_date, cancel_msg = @cancel_msg,booking_status = @booking_status where booking_id = @booking_id", con);

                SqlParameter now = cmd.Parameters.Add("@cancel_date", System.Data.SqlDbType.DateTime);
                now.Value = DateTime.Now;
                cmd.Parameters.AddWithValue("@cancel_msg",cancel_box.Text.ToString());
                cmd.Parameters.AddWithValue("@booking_id",id);
                cmd.Parameters.AddWithValue("@booking_status","CANCELLED");

                con.Open();
                int cancelled = cmd.ExecuteNonQuery();
                con.Close();

                if (cancelled > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "cancelled", "alert('"+cancelled.ToString()+ " booking cancelled');", true);
                }


            }
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session["role"] = "null";
            Session["user_id"] = 0;
        }
    }
}