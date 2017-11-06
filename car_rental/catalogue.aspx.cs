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
    public partial class catalogue : System.Web.UI.Page
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


            var cmd = new SqlCommand("select group_id,vehicle_name,fuel_type,seats,charges from vehicle_master where availability='Y' group by group_id,vehicle_name,fuel_type,seats,charges ", con);
            var catalogue_query = new DataTable();
            var adapter = new SqlDataAdapter(cmd);
            
            con.Open();
            adapter.Fill(catalogue_query);
            con.Close();

            for (int i = 0; i < catalogue_query.Rows.Count; i++)
            {
                var table = new Table();
                //table.GridLines = GridLines.Both;

                //finding images
                DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(Server.MapPath("~/files/vimg/"));
                FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles(catalogue_query.Rows[i][0].ToString() + "*.*");
                string filename = filesInDir[0].Name;

                //Row for images
                var row_1_img = new TableRow();
                var cell_1_1 = new TableCell();
                cell_1_1.ColumnSpan = 4;
                var product_img = new Image();
                product_img.Height = Unit.Pixel( 100);
                product_img.ImageUrl = "~//files//vimg//" + filename;
                cell_1_1.Controls.Add(product_img);
                row_1_img.Cells.Add(cell_1_1);

                //Row for vehicle name
                var row_2 = new TableRow();
                var cell_2_1 = new TableCell();
                cell_2_1.ColumnSpan = 4;
                cell_2_1.HorizontalAlign = HorizontalAlign.Center;
                cell_2_1.Text = catalogue_query.Rows[i][1].ToString();
                row_2.Cells.Add(cell_2_1);

                //Row for vehicle's fuel type and seat count
                var row_3 = new TableRow();
                var cell_3_1 = new TableCell();
                var cell_3_2 = new TableCell();
                var cell_3_3 = new TableCell();
                var cell_3_4 = new TableCell();
                var image_fuel = new Image();
                var image_seat = new Image();
                image_fuel.CssClass = "prop_img";
                image_seat.CssClass = "prop_img";
                image_fuel.ImageUrl = "~//assets//fuel.png";
                image_seat.ImageUrl = "~//assets//seat.png";
                cell_3_1.HorizontalAlign = HorizontalAlign.Right;
                cell_3_3.HorizontalAlign = HorizontalAlign.Right;
                cell_3_2.HorizontalAlign = HorizontalAlign.Left;
                cell_3_4.HorizontalAlign = HorizontalAlign.Left;
                cell_3_1.Controls.Add(image_fuel);
                cell_3_3.Controls.Add(image_seat);
                cell_3_2.Text = catalogue_query.Rows[i][2].ToString();
                cell_3_4.Text = catalogue_query.Rows[i][3].ToString();
                row_3.Cells.Add(cell_3_1);
                row_3.Cells.Add(cell_3_2);
                row_3.Cells.Add(cell_3_3);
                row_3.Cells.Add(cell_3_4);

                //Row for charges amount
                var row_4 = new TableRow();
                var cell_4_1 = new TableCell();
                cell_4_1.HorizontalAlign = HorizontalAlign.Center;
                cell_4_1.Text = "₹ " + catalogue_query.Rows[i][4].ToString() ;
                row_4.Cells.Add(cell_4_1);

                //Row for booking button
                var row_5 = new TableRow();
                var cell_5_1 = new TableCell();
                var book_btn = new Button();
                book_btn.Text = "Book"+ catalogue_query.Rows[i][1].ToString(); ;
                book_btn.ID = catalogue_query.Rows[i][0].ToString();
                cell_5_1.CssClass = "book_btn";
                cell_5_1.HorizontalAlign = HorizontalAlign.Center;
                cell_5_1.ColumnSpan = 4;
                book_btn.Click +=new EventHandler(book_button_presed);
                cell_5_1.Controls.Add(book_btn);
                row_5.Cells.Add(cell_5_1);

                table.Rows.Add(row_1_img);
                table.Rows.Add(row_2);
                table.Rows.Add(row_3);
                table.Rows.Add(row_4);
                table.Rows.Add(row_5);

                table.CssClass = "catalogue_table";

                Product_Panel.Controls.Add(table);


            }
        }

        protected void book_button_presed(object sender, EventArgs e)
        {
            var sender_btn = (Button)sender;
            string group_id = sender_btn.ID;

            Response.Redirect("new_booking.aspx?id="+group_id);
        }

        protected void loginstatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session["role"] = "null";
            Session["user_id"] = 0;
        }
    }
}