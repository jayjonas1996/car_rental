using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace car_rental
{
    public partial class signup : System.Web.UI.Page
    {
        MD5 my5 = MD5.Create();
        static string s1 = WebConfigurationManager.ConnectionStrings["conshivam"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            try
            {
                if (Session["role"].ToString() == "user")
                {
                    Response.Redirect("default.aspx");
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
                
            }


            DateTime today = DateTime.Now;
            int thisyear = today.Year;
            int x=thisyear-18;

            for (int i=1; i<58; i++)
            {
                if (i < 13)
                    DropDownList2.Items.Add(""+i);
                if (i < 32)
                    DropDownList1.Items.Add("" + i);
                DropDownList3.Items.Add(x+"");
                x--;
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //DECLARATIONS
            SqlConnection con = new SqlConnection(s1);
            SqlCommand cmd = new SqlCommand();
            //SqlDataReader reader;
            cmd.Connection = con;

            //CHECK IF EMAIL ALREADY EXISTS
            cmd.CommandText = "createnewuser";
            cmd.CommandType = CommandType.StoredProcedure;
            

           

                //CREATE USER
                cmd.Parameters.Clear();
                string hash = GetHash(my5, TextBox13.Text);

                string fullname = TextBox1.Text +" "+ TextBox11.Text;

                cmd.Parameters.AddWithValue("@name", fullname);
                cmd.Parameters.AddWithValue("@address", TextBox2.Text);
                cmd.Parameters.AddWithValue("@email_id", TextBox3.Text.ToLower());
                cmd.Parameters.AddWithValue("@username",TextBox14.Text.ToLower());
                cmd.Parameters.AddWithValue("@city", TextBox4.Text);
                cmd.Parameters.AddWithValue("@state", TextBox5.Text);
                cmd.Parameters.AddWithValue("@dob", DropDownList1.Text + "-" + DropDownList2.Text + "-" + DropDownList3.Text);
                cmd.Parameters.AddWithValue("@contact_no", TextBox6.Text);
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text);
                cmd.Parameters.AddWithValue("@license_no", TextBox8.Text);
                cmd.Parameters.AddWithValue("@passhash",hash);

                var output_id = new SqlParameter();
                output_id.ParameterName = "@id";
                output_id.SqlDbType = SqlDbType.Int;
                output_id.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(output_id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                string id = output_id.Value.ToString();
                int int_id;
                try { int_id = int.Parse(id); }
                catch { int_id = 0; }

                if (int_id != 0 )
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "success", "alert('USER CREATED');", true);
                    //Response.Redirect("login.aspx");
                }
                else
                {
                ClientScript.RegisterStartupScript(this.GetType(), "exist", "alert('THE USERNAME OR EMAIL ALREADY EXIST PLEASE TRY ANOTHE ONE');", true);
                }
                /*
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Parameters.Clear();

                //create login for user
                cmd.CommandText = "select user_id from user_master where email_id=@email";
                cmd.Parameters.AddWithValue("@email", TextBox3.Text);

                con.Open();
                int user = (int)cmd.ExecuteScalar();
                con.Close();
                string hash = GetHash(my5, TextBox13.Text);

                cmd.Parameters.Clear();
                cmd.CommandText = "insert into user_login values(@id,@email,@hash)";
                cmd.Parameters.AddWithValue("@id", user);
                cmd.Parameters.AddWithValue("@email", TextBox3.Text);
                cmd.Parameters.AddWithValue("@hash", hash);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                */


                //Response.Redirect("login.aspx");
            
        }


        static string GetHash(MD5 my5, string input)
        {
            byte[] hash = my5.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sbuilder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            { sbuilder.Append(hash[i].ToString("x2")); }
            return sbuilder.ToString();
        }

        static bool VerifyHash(MD5 my5, string input, string hash)
        {
            string newhash = GetHash(my5, input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(newhash, hash))
            { return true; }
            else { return false; }
        }
    }
}