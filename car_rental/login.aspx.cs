using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security.Cryptography;
using System.Web.Configuration;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace car_rental
{
    public partial class login : System.Web.UI.Page
    {
        MD5 my5 = MD5.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string s1 = WebConfigurationManager.ConnectionStrings["conshivam"].ConnectionString;
            SqlConnection con = new SqlConnection(s1);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;


            string hash = GetHash(my5, Login1.Password);


            cmd.CommandText = "select user_id from user_login where username = @username and passhash = @passhash";
            cmd.Parameters.AddWithValue("@username", Login1.UserName.ToLower());
            cmd.Parameters.AddWithValue("@passhash", hash);

            int exist = 0;
            con.Open();
            try { exist = (int)cmd.ExecuteScalar(); }
            catch { exist = 0; }
            con.Close();
            cmd.Parameters.Clear();
            if (exist == 0)
            {

                cmd.CommandText = "select admin_id from admin_login where name =@username";
                cmd.Parameters.AddWithValue("@username", Login1.UserName);
                int admin_exists = 0;
                con.Open();
                try
                { admin_exists = (int)cmd.ExecuteScalar(); }
                catch
                { admin_exists = 0; }
                
                con.Close();
                cmd.Parameters.Clear();
                if(admin_exists !=0)
                {
                    cmd.CommandText = "select passhash from admin_login where name =@username";
                    cmd.Parameters.AddWithValue("@username", Login1.UserName);
                    SqlDataReader rdr;
                    con.Open();
                    rdr = cmd.ExecuteReader();
                    rdr.Read();
                    rdr["passhash"].ToString();
                    if (rdr["passhash"].ToString() == Login1.Password)//error here for anonymous user
                    {
                        con.Close();
                        Session["admin_id"] = admin_exists;
                        FormsAuthentication.RedirectFromLoginPage(Login1.UserName, true);           //LOGGING IN ADMIN
                    }
                    else
                    {
                        con.Close();
                        ClientScript.RegisterStartupScript(this.GetType(), "fail", "alert('incorrect login');", true);
                    }
                }
                try
                {
                    con.Close();
                }
                catch { }
            }
            else
            {
                Session["user_id"] = exist;
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName.ToLower(), true);         //LOGGING IN USER
            }
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