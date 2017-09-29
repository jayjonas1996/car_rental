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
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string s1 = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(s1);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select passhash from admin_login where name ='" + Login1.UserName + "'";
            SqlDataReader rdr;
            con.Open();
            rdr = cmd.ExecuteReader();
            rdr.Read();

            if(rdr["passhash"].ToString()==Login1.Password)
            {
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, true);
            }
            con.Close();


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

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void LoginView1_ViewChanged(object sender, EventArgs e)
        {

        }
    }
}