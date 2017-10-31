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
    public partial class manage_vehicles : System.Web.UI.Page
    {

        static string[] imageExtentions = { "jpg","png","jpeg","gif","heif", "tiff" };
        static string constr = WebConfigurationManager.ConnectionStrings["conshivam"].ConnectionString;
        static SqlConnection con = new SqlConnection(constr);


        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select group_id,vehicle_name,count(availability),charges,fuel_type,seats from vehicle_master group by group_id,vehicle_name,availability,fuel_type,seats,charges", con);
            DataTable group_table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            con.Open();
            adapter.Fill(group_table);
            con.Close();


            for(int i =0; i < group_table.Rows.Count; i++)
            {
                string group_id = group_table.Rows[i][0].ToString();
                string imagefull_url,image_relative_url;

                //Row for image and group_id
                var row_1 = new TableRow();
                var cell_1_1 = new TableCell();
                var image = new Image();

                DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(Server.MapPath("~/files/vimg/"));
                FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles(group_id  + "*.*");
                imagefull_url = filesInDir[0].FullName;                                                     //UNUSED
                string filename = filesInDir[0].Name;
                image_relative_url = "~\\files\\vimg\\" +filename;
                image.ImageUrl = image_relative_url;
                image.AlternateText = group_id;
                image.Width = 128;
                image.Height = 128;
                cell_1_1.Controls.Add(image);
                var cell_1_2 = new TableCell();
                cell_1_2.Text = "Model Name; "+group_id;
                var label_1 = new Label();
                label_1.Text = group_id;
                cell_1_2.Controls.Add(label_1);
                cell_1_1.RowSpan = 6;
                row_1.Cells.Add(cell_1_1);
                row_1.Cells.Add(cell_1_2);


                //Row for vehicle name
                var row_2 = new TableRow();
                var cell_2_1 = new TableCell();
                cell_2_1.Text = "Name: "+ group_table.Rows[i][1].ToString();
                row_2.Cells.Add(cell_2_1);

                //Row for displaying total vehicles
                var row_3 = new TableRow();
                var cell_3_1 = new TableCell();
                cell_3_1.Text = "Total: " + group_table.Rows[i][2].ToString();
                row_3.Cells.Add(cell_3_1);

                //Row to display number of seats
                var row_7 = new TableRow();
                var cell_7_1 = new TableCell();
                cell_7_1.Text = "Charges Amount: " + group_table.Rows[i][3].ToString();
                row_7.Cells.Add(cell_7_1);

                //Row to display fuel type
                var row_8 = new TableRow();
                var cell_8_1 = new TableCell();
                cell_8_1.Text = group_table.Rows[i][4].ToString();
                row_8.Cells.Add(cell_8_1);

                //Row to display  seats
                var row_9 = new TableRow();
                var cell_9_1 = new TableCell();
                cell_9_1.Text = group_table.Rows[i][2].ToString()+" Seater";
                row_9.Cells.Add(cell_9_1);

                //Row for uploading more images button
                var row_4 = new TableRow();
                var cell_4_1 = new TableCell();
                var btn_1 = new Button();
                btn_1.Text = "Upload more Images";
                btn_1.ID = group_id+"1";
                btn_1.Click += new EventHandler(upload_images_btn);
                cell_4_1.Controls.Add(btn_1);
                row_4.Cells.Add(cell_4_1);

                //Rows for placing SHOW ALL button 
                var row_5 = new TableRow();
                var cell_5_1 = new TableCell();
                var btn_2 = new Button();
                btn_2.Text = "Show All";
                btn_2.ID = group_id + "2";
                btn_2.Click += new EventHandler(show_all_btn);
                cell_5_1.Controls.Add(btn_2);
                row_5.Cells.Add(cell_5_1);

                //Row for placing edit name button
                var row_6 = new TableRow();
                var cell_6_1 = new TableCell();
                var btn_3 = new Button();
                btn_3.Text = "Edit Name";
                btn_3.ID = group_id+"3";
                btn_3.Click += new EventHandler(edit_name_btn);
                cell_6_1.Controls.Add(btn_3);
                row_6.Cells.Add(cell_6_1);



                Table1.Rows.Add(row_1);
                Table1.Rows.Add(row_2);
                Table1.Rows.Add(row_3);
                Table1.Rows.Add(row_7);
                Table1.Rows.Add(row_8);
                Table1.Rows.Add(row_9);
                Table1.Rows.Add(row_4);
                Table1.Rows.Add(row_5);
                Table1.Rows.Add(row_6);
            }
        }

        protected void savebtn_Command(object sender, CommandEventArgs e)
        {

            if (t1.Text != "" && t2.Text != "" && t3.Text != "" && t4.Text != "" && Textbox4.Text !="" && fileupload_vimg.HasFile)
            {

                var FileExtension = Path.GetExtension(fileupload_vimg.PostedFile.FileName).Substring(1);
                if (!imageExtentions.Contains(FileExtension.ToLower()))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "img only", "alert('PLEASE UPLOAD CORRECT IMAGE FORMAT (SQUARE IS RECOMMEND)');", true);
                }
                else
                { 





                    var cmd = new SqlCommand("insert into vehicle_master (group_id,vehicle_name,availability,vehicle_status,kms_used,fuel_type,seats,charges,registration_no) values(@group_id,@vehicle_name,@availability,@vehicle_status,@kms_used,@fuel_type,@seats,@charges,@registration_no)", con);

                    cmd.Parameters.AddWithValue("@group_id", t1.Text.ToString());
                    cmd.Parameters.AddWithValue("@vehicle_name", t2.Text.ToString());
                    if (yncheckbox.Checked)
                    {
                        cmd.Parameters.AddWithValue("@availability", 'Y');
                        cmd.Parameters.AddWithValue("@vehicle_status", "none");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@availability", 'N');

                    }
                    cmd.Parameters.AddWithValue("@kms_used", int.Parse(t3.Text));
                    cmd.Parameters.AddWithValue("@registration_no", t4.Text.ToString());

                    if (RadioButton1.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@fuel_type", "Petrol");
                    }
                    else if (RadioButton2.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@seats","Diesel");
                    }

                    cmd.Parameters.AddWithValue("@seats",seats_list.SelectedValue);
                    cmd.Parameters.AddWithValue("@charges",Textbox4.Text);
                    con.Open();
                    int inserted = cmd.ExecuteNonQuery();
                    con.Close();

                    //if (File.Exists(t1.Text.ToString())) 


                    fileupload_vimg.SaveAs(Path.Combine(Server.MapPath("~/files/vimg/"), t1.Text.ToString() + "." + FileExtension.ToLower()));




                    if (inserted == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "vehicle inserted", "alert('NEW MODEL SUCCESSFULLY ADDED');", true);
                        Response.Redirect("manage_vehicles.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "not inserted", "alert('ERROR, CHECK DATA, GROUP ID SHOULD NOT ALREADY EXIST');", true);
                    }
                }
            }
        }

        protected void upload_images_btn(object sender, EventArgs e)
        {
        }

        protected void show_all_btn(object sender, EventArgs e)
        {
            Table2.Visible = true;
            add_vehicle.Visible = true;

            SqlCommand cmd = new SqlCommand("select group_id,vehicle_name,availability,vehicle_status,kms_used,registration_no from vehicle_master where group_id=@group_id", con);
            DataTable vehicle_table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            var incomingbutton = (Button)sender;
            string group_id = incomingbutton.ID.Remove(incomingbutton.ID.Length - 1); ;
            add_vehicle.Text = "Add new " + group_id;
            Label3.Text = group_id;
            

            cmd.Parameters.AddWithValue("@group_id", group_id);

            con.Open();
            adapter.Fill(vehicle_table);
            con.Close();

            Table2.Rows.Clear();
            for (int i = 0; i < vehicle_table.Rows.Count; i++)
            {
                string availability = vehicle_table.Rows[i][2].ToString();
                Label11.Text = vehicle_table.Rows[i][1].ToString();
                //Row for displaying model name
                var row_1 = new TableRow();
                var cell_1_1 = new TableCell();
                cell_1_1.Text = "Model Name";
                var cell_1_2 = new TableCell();
                cell_1_2.HorizontalAlign = HorizontalAlign.Center;
                cell_1_2.Text = vehicle_table.Rows[i][0].ToString();
                row_1.Cells.Add(cell_1_1);
                row_1.Cells.Add(cell_1_2);

                //Row for displaying name
                var row_2 = new TableRow();
                var cell_2_1 = new TableCell();
                cell_2_1.Text = "Vehicle Name";
                var cell_2_2 = new TableCell();
                cell_2_2.HorizontalAlign = HorizontalAlign.Center;
                cell_2_2.Text = vehicle_table.Rows[i][1].ToString();
                row_2.Cells.Add(cell_2_1);
                row_2.Cells.Add(cell_2_2);

                //Row for displaying availability
                var row_3 = new TableRow();
                var cell_3_1 = new TableCell();
                cell_3_1.Text = "availability";
                var cell_3_2 = new TableCell();
                cell_3_2.HorizontalAlign = HorizontalAlign.Center;
                if (availability == "N" || availability == "n")
                {
                    cell_3_2.Text = "NOT AVAILABLE";
                }
                else if (availability == "Y" || availability == "y")
                {
                    cell_3_2.Text = "YES";
                }
                else
                {
                    cell_3_2.Text = availability;

                }
                row_3.Cells.Add(cell_3_1);
                row_3.Cells.Add(cell_3_2);

                //Row for displaying status
                var row_4 = new TableRow();
                var cell_4_1 = new TableCell();
                cell_4_1.Text = "Status";
                var cell_4_2 = new TableCell();
                cell_4_2.HorizontalAlign = HorizontalAlign.Center;
                try
                {
                    cell_4_2.Text = vehicle_table.Rows[i][3].ToString();
                }catch
                {
                    cell_4_2.Text = "No status";
                }               
                row_4.Cells.Add(cell_4_1);
                row_4.Cells.Add(cell_4_2);

                //Row for displaying kilometers used
                var row_5 = new TableRow();
                var cell_5_1 = new TableCell();
                cell_5_1.Text = "Kilometers used";
                var cell_5_2 = new TableCell();
                cell_5_2.HorizontalAlign = HorizontalAlign.Center;
                cell_5_2.Text = vehicle_table.Rows[i][4].ToString()+" KM";
                row_5.Cells.Add(cell_5_1);
                row_5.Cells.Add(cell_5_2);

                //Row for displaying registration number
                var row_6 = new TableRow();
                var cell_6_1 = new TableCell();
                cell_6_1.Text = "Registration Number";
                var cell_6_2 = new TableCell();
                cell_6_2.HorizontalAlign = HorizontalAlign.Center;
                cell_6_2.Text = vehicle_table.Rows[i][5].ToString();
                row_6.Cells.Add(cell_6_1);
                row_6.Cells.Add(cell_6_2);

                var empty_row = new TableRow();
                var empty_cell = new TableCell();
                empty_row.Height = Unit.Pixel(14);
                empty_cell.ColumnSpan = 2;
                empty_row.Cells.Add(empty_cell);
                

                Table2.Rows.Add(row_1);
                Table2.Rows.Add(row_2);
                Table2.Rows.Add(row_3);
                Table2.Rows.Add(row_4);
                Table2.Rows.Add(row_5);
                Table2.Rows.Add(row_6);
                Table2.Rows.Add(empty_row);

            }
        }

        protected void edit_name_btn(object sender, EventArgs e)
        {
        }

        protected void insert_vehicle_Click(object sender, EventArgs e)
        {
            int affected = 0;
            if (Textbox3.Text != "" && Textbox2.Text != "")
            {

                SqlCommand cmd = new SqlCommand("insert into vehicle_master (group_id,vehicle_name,availability,vehicle_status,kms_used,registration_no) values(@group_id,@vehicle_name,@availability,@status,@kms_used,@registration_no)", con);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@group_id", Label3.Text.ToString());
                cmd.Parameters.AddWithValue("@vehicle_name", Label11.Text.ToString());
                cmd.Parameters.AddWithValue("@availability", dropdown_yn.SelectedValue);
                if (dropdown_yn.SelectedValue == "N")
                {
                    if (Textbox1.Text != "")
                    {
                        cmd.Parameters.AddWithValue("@status", Textbox1.Text.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@status", "IN maintenance");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@status", "none");
                }

                cmd.Parameters.AddWithValue("@kms_used",Textbox2.Text.ToString());
                cmd.Parameters.AddWithValue("@registration_no",Textbox3.Text.ToString());

                try
                {
                    con.Open();
                    affected = cmd.ExecuteNonQuery();
                }
                finally
                { con.Close(); }

                

            }
            if (affected == 1)
            { ClientScript.RegisterStartupScript(this.GetType(), "inserted", "alert('Vehicle added');", true); }
            else
            { ClientScript.RegisterStartupScript(this.GetType(), "not inserted", "alert('ERROR, Be Sure to insert all the data');", true); }
        }
    }
}