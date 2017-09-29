using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Web.Security;
using System.Data.SqlClient;

namespace car_rental
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;


            DateTime today = DateTime.Now;
            int thisyear = today.Year;
            int x=thisyear-18;
            for (int i=1; i<43; i++)
            {

                if (i < 13)
                    DropDownList2.Items.Add(""+i);
                if (i < 32)
                    DropDownList1.Items.Add("" + i);
                DropDownList3.Items.Add(x+"");
                x--;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s1 = WebConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into user_master values (@user_id,@name,@address,@email_id,@city,@state,@dob,@contact_no,@pincode,@,liscense)";
            //cmd.Parameters.AddWithValue("@user_id",);
            cmd.Parameters.AddWithValue("@name",TextBox1.Text);
            cmd.Parameters.AddWithValue("@address",TextBox2.Text);
            cmd.Parameters.AddWithValue("@email_id",TextBox3.Text);
            cmd.Parameters.AddWithValue("@city",TextBox4.Text);
            cmd.Parameters.AddWithValue("@state",TextBox5.Text);
            cmd.Parameters.AddWithValue("@dob", DropDownList1.Text + "-" + DropDownList2.Text + "-" + DropDownList3.Text);
            cmd.Parameters.AddWithValue("@contact_no", TextBox6.Text);
            cmd.Parameters.AddWithValue("@pincode", TextBox7.Text);
            cmd.Parameters.AddWithValue("@liscense", TextBox8.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("login.aspx");
        }
    }
}