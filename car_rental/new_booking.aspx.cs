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

namespace car_rental
{
    public partial class new_booking : System.Web.UI.Page
    {
        static string constr = WebConfigurationManager.ConnectionStrings["conshivam"].ConnectionString;
        static SqlConnection con = new SqlConnection(constr);

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod()]
        protected void Page_Load(object sender, EventArgs e)
        {
            string id="0";
            try
            {
                id = Request.QueryString["id"].ToString();
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

            string role = Session["role"].ToString();
        }
    }
}