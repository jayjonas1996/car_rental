using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
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

        }

        protected void savebtn_Command(object sender, CommandEventArgs e)
        {






            if (t1.Text != "" && t2.Text != "" && t3.Text != "" && t4.Text != "" && fileupload_vimg.HasFile)
            {

                var FileExtension = Path.GetExtension(fileupload_vimg.PostedFile.FileName).Substring(1);
                if (!imageExtentions.Contains(FileExtension.ToLower()))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "img only", "alert('PLEASE UPLOAD CORRECT IMAGE FORMAT (SQUARE IS RECOMMEND)');", true);
                }
                else
                { 





                    var cmd = new SqlCommand("insert into vehicle_master (group_id,vehicle_name,availability,vehicle_status,kms_used,registration_no) values(@group_id,@vehicle_name,@availability,@vehicle_status,@kms_used,@registration_no)", con);

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
    }
}