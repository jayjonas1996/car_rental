using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
    }
}