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
using System.Data.Sql;

namespace car_rental
{
    public partial class manage_bookings : System.Web.UI.Page
    {
        static string constr = WebConfigurationManager.ConnectionStrings["conshivam"].ConnectionString;
        static SqlConnection con = new SqlConnection(constr);
        protected void Page_Load(object sender, EventArgs e)
        {


            var cmd = new SqlCommand("select booking_id,user_id,vehicle_name,registration_no,location,pickup_location,rent_date,return_date,booking_status,paid_amt,cost_amt, kms, cancel_date,cancel_msg,fuel_amt from booking_master join vehicle_master  on(booking_master.vehicle_id = vehicle_master.vehicle_id) order by book_date desc ", con);
            var results = new DataTable();
            var adapter = new SqlDataAdapter(cmd);

            con.Open();
            adapter.Fill(results);
            con.Close();

            table1.Rows.Clear();
            var main_row = new TableRow();

            var row_head_1 = new TableCell();
            var row_head_2 = new TableCell();
            var row_head_3 = new TableCell();
            var row_head_4 = new TableCell();
            var row_head_5 = new TableCell();
            var row_head_6 = new TableCell();
            var row_head_7 = new TableCell();
            var row_head_8 = new TableCell();
            var row_head_9 = new TableCell();
            var row_head_10 = new TableCell();
            var row_head_11 = new TableCell();
            var row_head_12 = new TableCell();
            var row_head_13 = new TableCell();
            var row_head_14 = new TableCell();
            var row_head_15 = new TableCell();
            var row_head_16 = new TableCell();

            var row_head_17 = new TableCell();  //message button here
            var row_head_18 = new TableCell();  //confirm/complete button here


            row_head_1.Text = "booking id";
            row_head_2.Text = "user id";
            row_head_3.Text = "vehicle name";
            row_head_4.Text = "registraion";
            row_head_5.Text = "location";
            row_head_6.Text = "pickup";
            row_head_7.Text = "rent date";
            row_head_8.Text = "return date";
            row_head_9.Text = "status";
            row_head_10.Text = "paid";
            row_head_11.Text = "cost";
            row_head_12.Text = "kms";
            row_head_13.Text = "cancel date";
            row_head_14.Text = "cancel reason";
            row_head_15.Text = "fuel used";

            row_head_17.Text = "Message";
            row_head_18.Text = "Action";

            main_row.Cells.Add(row_head_1);
            main_row.Cells.Add(row_head_2);
            main_row.Cells.Add(row_head_3);
            main_row.Cells.Add(row_head_4);
            main_row.Cells.Add(row_head_5);
            main_row.Cells.Add(row_head_6);
            main_row.Cells.Add(row_head_7);
            main_row.Cells.Add(row_head_8);
            main_row.Cells.Add(row_head_9);
            main_row.Cells.Add(row_head_10);
            main_row.Cells.Add(row_head_11);
            main_row.Cells.Add(row_head_12);
            main_row.Cells.Add(row_head_13);
            main_row.Cells.Add(row_head_14);
            main_row.Cells.Add(row_head_15);
            //main_row.Cells.Add(row_head_16);
            main_row.Cells.Add(row_head_17);
            main_row.Cells.Add(row_head_18);



            table1.Rows.Add(main_row);



            for (int i = 0; i < results.Rows.Count; i++)
            {
                var new_row = new TableRow();

                var cell_1_1 = new TableCell();
                var cell_1_2 = new TableCell();
                var cell_1_3 = new TableCell();
                var cell_1_4 = new TableCell();
                var cell_1_5 = new TableCell();
                var cell_1_6 = new TableCell();
                var cell_1_7 = new TableCell();
                var cell_1_8 = new TableCell();
                var cell_1_9 = new TableCell();
                var cell_1_10 = new TableCell();
                var cell_1_11 = new TableCell();
                var cell_1_12 = new TableCell();
                var cell_1_13 = new TableCell();
                var cell_1_14 = new TableCell();
                var cell_1_15 = new TableCell();
                //var cell_1_16 = new TableCell();

                var cell_1_17 = new TableCell(); //MESSAGE CELL
                var cell_1_18 = new TableCell(); //ACTION CELL

                var msg_btn = new Button();
                var action_btn = new Button();

                cell_1_1.Text = results.Rows[i][0].ToString();
                cell_1_2.Text = results.Rows[i][1].ToString();
                cell_1_3.Text = results.Rows[i][2].ToString();
                cell_1_4.Text = results.Rows[i][3].ToString();
                cell_1_5.Text = results.Rows[i][4].ToString();
                cell_1_6.Text = results.Rows[i][5].ToString();
                cell_1_7.Text = results.Rows[i][6].ToString();
                cell_1_8.Text = results.Rows[i][7].ToString();
                cell_1_9.Text = results.Rows[i][8].ToString();
                cell_1_10.Text = results.Rows[i][9].ToString();
                cell_1_11.Text = results.Rows[i][10].ToString();
                cell_1_12.Text = results.Rows[i][11].ToString();
                cell_1_13.Text = results.Rows[i][12].ToString();
                cell_1_14.Text = results.Rows[i][13].ToString();
                cell_1_15.Text = results.Rows[i][14].ToString();
                //cell_1_16.Text = results.Rows[i][15].ToString();

                msg_btn.Text = "Message";
                msg_btn.ID = results.Rows[i][0].ToString() +"_" + results.Rows[i][1].ToString();
                msg_btn.Click += new EventHandler(msg_btn_pressed);
                cell_1_17.Controls.Add(msg_btn);

                action_btn.ID = "a" + results.Rows[i][0].ToString()+"_" + results.Rows[i][1].ToString();
                action_btn.Click += new EventHandler(action_btn_pressed);

                if (results.Rows[i][8].ToString() == "PROCESSING")
                {
                    action_btn.Text = "CONFIRM";
                    cell_1_18.Controls.Add(action_btn);
                }
                else if (results.Rows[i][8].ToString() == "CONFIRMED")
                {
                    action_btn.Text = "START";
                    cell_1_18.Controls.Add(action_btn);
                }
                else if (results.Rows[i][8].ToString() == "ONGOING")
                {
                    action_btn.Text = "COMPLETE";
                    cell_1_18.Controls.Add(action_btn);
                }

                new_row.Cells.Add(cell_1_1);
                new_row.Cells.Add(cell_1_2);
                new_row.Cells.Add(cell_1_3);
                new_row.Cells.Add(cell_1_4);
                new_row.Cells.Add(cell_1_5);
                new_row.Cells.Add(cell_1_6);
                new_row.Cells.Add(cell_1_7);
                new_row.Cells.Add(cell_1_8);
                new_row.Cells.Add(cell_1_9);
                new_row.Cells.Add(cell_1_10);
                new_row.Cells.Add(cell_1_11);
                new_row.Cells.Add(cell_1_12);
                new_row.Cells.Add(cell_1_13);
                new_row.Cells.Add(cell_1_14);
                new_row.Cells.Add(cell_1_15);
                new_row.Cells.Add(cell_1_17);
                new_row.Cells.Add(cell_1_18);

                table1.Rows.Add(new_row);


            }
        }

        protected void msg_btn_pressed(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            string id = pressed.ID.ToString();

            string[] ids = id.Split('_');

            string b_id = ids[0].ToString();
            string u_id = ids[1].ToString();
            display_b_id.Text = b_id;
            display_u_id.Text = u_id;


            msg_div.Visible = true;

            var cmd = new SqlCommand("select booking_id,message,msg_date from message_master where booking_id = @booking_id order by msg_date asc",con);
            var adapter = new SqlDataAdapter(cmd);
            var messages = new DataTable();

            cmd.Parameters.AddWithValue("@booking_id",b_id);

            con.Open();
            adapter.Fill(messages);
            con.Close();
            
            datagrid1.DataSource = messages;
            datagrid1.DataBind();
        }

        protected void action_btn_pressed(object sender, EventArgs e)
        {
            Button pressed = (Button)sender;
            string id = pressed.ID.ToString();

            string[] ids = id.Split('_');

            string b_id = ids[0].ToString();
            string u_id = ids[1].ToString();
            b_id = b_id.Substring(1,b_id.Length - 1);

            if (pressed.Text == "CONFIRM")
            {
                var cmd = new SqlCommand("insert into message_master (user_id,booking_id,message,msg_date) values(@user_id,@booking_id,@message,@msg_date)", con);
                var now = cmd.Parameters.Add("@msg_date", System.Data.SqlDbType.DateTime2);
                now.Value = DateTime.Now;
                cmd.Parameters.AddWithValue("@user_id", u_id);
                cmd.Parameters.AddWithValue("@booking_id", b_id);
                cmd.Parameters.AddWithValue("@message", "Your Booking has been Confirmed");

                con.Open();
                int sent = cmd.ExecuteNonQuery();
                con.Close();

                var cmd2 = new SqlCommand("update booking_master set booking_status = @status where booking_id = @id", con);
                cmd2.Parameters.AddWithValue("@status", "CONFIRMED");
                cmd2.Parameters.AddWithValue("@id", b_id);

                con.Open();
                int done = cmd2.ExecuteNonQuery();
                con.Close();


            }
            else if (pressed.Text == "COMPLETE")
            {
                complete_div.Visible = true;
                display_booking_id.Text = b_id;
            }
            else if (pressed.Text == "START")
            {
                var cmd = new SqlCommand("update booking_master set booking_status = @status where booking_id=@id",con);
                cmd.Parameters.AddWithValue("@status","ONGOING");
                cmd.Parameters.AddWithValue("@id",b_id);

                con.Open();
                int updated = cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        protected void send_msg_pressed(object sender, EventArgs e)
        {
            string b_id = display_b_id.Text.ToString();
            string u_id = display_u_id.Text.ToString();

            if (message_box.Text != "")
            {
                var cmd = new SqlCommand("insert into message_master (user_id,booking_id,message,msg_date) values(@user_id,@booking_id,@message,@msg_date)", con);
                var now = cmd.Parameters.Add("@msg_date", System.Data.SqlDbType.DateTime2);
                now.Value = DateTime.Now;
                cmd.Parameters.AddWithValue("@user_id", u_id);
                cmd.Parameters.AddWithValue("@booking_id", b_id);
                cmd.Parameters.AddWithValue("@message",message_box.Text.ToString());

                con.Open();
                int inserted = cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        protected void complete_pressed(object sender, EventArgs e)
        {
            string b_id = display_booking_id.Text.ToString();

            if (kms_box.Text.Length > 1 && fuel_box.Text.Length > 1)
            {
                var cmd = new SqlCommand("select kms_used,booking_master.vehicle_id from booking_master join vehicle_master on (booking_master.vehicle_id = vehicle_master.vehicle_id) where booking_id=@id",con);
                cmd.Parameters.AddWithValue("@id",b_id);
                var adapter = new SqlDataAdapter(cmd);
                var result = new DataTable();

                con.Open();
                adapter.Fill(result);
                con.Close();
                
                double initial_value = double.Parse( result.Rows[0][0].ToString() );
                int v_id = int.Parse(result.Rows[0][1].ToString());
                

                double final_value = double.Parse( kms_box.Text.ToString()  );
                int fuel_amt = int.Parse( fuel_box.Text );

                double kms = final_value - initial_value;

                cmd.Parameters.Clear();

                cmd.CommandText = "update booking_master set kms = @kms, booking_status = @status,return_date = @return_date where booking_id = @id";
                var now = cmd.Parameters.Add("@return_date", System.Data.SqlDbType.DateTime2);
                now.Value = DateTime.Now;
                cmd.Parameters.AddWithValue("@kms",kms);
                cmd.Parameters.AddWithValue("@status","COMPLETED");
                cmd.Parameters.AddWithValue("@id",b_id);

                con.Open();
                int update_booking = cmd.ExecuteNonQuery();
                con.Close();
                cmd.Parameters.Clear();

                cmd.CommandText = "update vehicle_master set kms_used = @kms_used where vehicle_id = @v_id";
                cmd.Parameters.AddWithValue("@kms_used",final_value);
                cmd.Parameters.AddWithValue("@v_id",v_id);

                con.Open();
                int updated_vehicle = cmd.ExecuteNonQuery();
                con.Close();


                
            }
        }
    }
}