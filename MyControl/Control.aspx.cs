using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace MyControl
{
    public partial class _Default : System.Web.UI.Page
    {
        string host = ConfigurationManager.AppSettings["host"];
        string module = ConfigurationManager.AppSettings["module"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["auth"] == null || Convert.ToBoolean(Session["auth"]) == false)
            {
                Response.Redirect("Login.aspx", true);
                return;
            }
            if (!IsPostBack)
            {
                string K1 = ConfigurationManager.AppSettings["K1"];
                string K2 = ConfigurationManager.AppSettings["K2"];
                string K3 = ConfigurationManager.AppSettings["K3"];
                string K4 = ConfigurationManager.AppSettings["K4"];
                foreach (Control c in this.form1.Controls)
                {
                    if (c is Button)
                    {
                        Button b = c as Button;
                        if (b.Text.Contains("K1"))
                            b.Text = b.Text.Replace("K1", K1);
                        if (b.Text.Contains("K2"))
                            b.Text = b.Text.Replace("K2", K2);
                        if (b.Text.Contains("K3"))
                            b.Text = b.Text.Replace("K3", K3);
                        if (b.Text.Contains("K4"))
                            b.Text = b.Text.Replace("K4", K4);
                    }
                }
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            bool flag = DB.SendCmd(host, module, "setK1");
            btnSend.Enabled = !flag;
            button9.Enabled = flag;
        }

        protected void button9_Click(object sender, EventArgs e)
        {
            bool flag = DB.SendCmd(host, module, "resetK1");
            button9.Enabled = !flag;
            btnSend.Enabled = flag;
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            bool flag = DB.SendCmd(host, module, "setK2");
            button1.Enabled = !flag;
            button8.Enabled = flag;
        }

        protected void button8_Click(object sender, EventArgs e)
        {
            bool flag = DB.SendCmd(host, module, "resetK2");
            button8.Enabled = !flag;
            button1.Enabled = flag;
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            bool flag = DB.SendCmd(host, module, "setK3");
            button2.Enabled = !flag;
            button7.Enabled = flag;
        }

        protected void button7_Click(object sender, EventArgs e)
        {
            bool flag = DB.SendCmd(host, module, "resetK3");
            button7.Enabled = !flag;
            button2.Enabled = flag;
        }

        protected void button3_Click(object sender, EventArgs e)
        {
            bool flag = DB.SendCmd(host, module, "setK4");
            button3.Enabled = !flag;
            button5.Enabled = flag;
        }

        protected void button5_Click(object sender, EventArgs e)
        {
            bool flag = DB.SendCmd(host, module, "resetK4");
            button5.Enabled = !flag;
            button3.Enabled = flag;
        }

        protected void button4_Click(object sender, EventArgs e)
        {
            bool flag = DB.SendCmd(host, module, "setAll");
            btnSend.Enabled = button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = !flag;
            button5.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = button6.Enabled = flag;
        }

        protected void button6_Click(object sender, EventArgs e)
        {
            bool flag = DB.SendCmd(host, module, "resetAll");
            button5.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = button6.Enabled = !flag;
            btnSend.Enabled = button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = flag;
        }

        protected void QUIT_Click(object sender, EventArgs e)
        {
            Session["auth"] = false;
            Response.Redirect("Login.aspx", true);
        }
    }
}