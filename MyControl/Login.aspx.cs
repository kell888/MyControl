using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace MyControl
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label2.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string auth = TextBox1.Text.ToLower();
            if (auth != string.Empty)
            {
                if (auth.Length >= 8)
                {
                    if (auth == DateTime.Now.ToString("yyMMddHH") + ConfigurationManager.AppSettings["auth"].ToLower())
                    {
                        Session["auth"] = true;
                        Response.Redirect("Control.aspx", true);
                        return;
                    }
                }
            }
            Label2.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string auth = TextBox1.Text.ToLower();
            if (auth != string.Empty)
            {
                if (auth.Length >= 8)
                {
                    if (auth == DateTime.Now.ToString("yyMMddHH") + ConfigurationManager.AppSettings["auth"].ToLower())
                    {
                        Session["auth"] = true;
                        Response.Redirect("MiniK.aspx", true);
                        return;
                    }
                }
            }
            Label2.Visible = true;
        }
    }
}