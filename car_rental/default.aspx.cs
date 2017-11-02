using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace car_rental
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string role = "";
            try
            {
                role = Session["role"].ToString();
            }
            catch
            {
                Response.Redirect("login.aspx");
            }

            if (role == "admin")
            {
                user_div.Visible = false;
            }
            else if (role == "user")
            {
                admin_div.Visible = false;
            }
            else
            {
                Response.Redirect("login.aspx");
            }


        }
    }
}