using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebReportingTool
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e) // Logo
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e) // Log in
        {
            MultiView1.ActiveViewIndex = 3;
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e) // Register
        {
            MultiView1.ActiveViewIndex = 4;
        }
    }
}