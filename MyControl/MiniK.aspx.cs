using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Threading;
using System.Data;
using System.ComponentModel;

namespace MyControl
{
    public partial class MiniK : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Session["auth"] == null || Convert.ToBoolean(Session["auth"]) == false)
            {
                Response.Redirect("Login.aspx", true);
                return;
            }
            if (!IsPostBack)
            {
                //ScriptManager.GetCurrent(this.Page).RegisterAsyncPostBackControl(Switch);
                //ScriptManager.GetCurrent(this.Page).RegisterAsyncPostBackControl(TurnOff);
                LoginInfo loginInfo = new LoginInfo() { ClientId = ConfigurationManager.AppSettings["clientId"], ClientSecret = ConfigurationManager.AppSettings["clientsecret"], Username = ConfigurationManager.AppSettings["username"], Password = ConfigurationManager.AppSettings["password"] };
                Thread th = new Thread(new ParameterizedThreadStart(DoLogin));
                th.SetApartmentState(ApartmentState.STA);//属性设置成单线程
                th.IsBackground = true;
                th.Start(loginInfo);
                th.Join();                
            }
        }

        protected void DoLogin(object o)
        {
            LoginInfo li = o as LoginInfo;
            if (li != null)
            {
                Konke.Controler control = new Konke.Controler(li.ClientId, li.ClientSecret, li.Username, li.Password);
                Session["control"] = control;
                DataTable dt = ConvertToDataTable(control.GetKList(control.Accesstoken, control.UserId()));
                DataList1.DataSource = dt.DefaultView;
                DataList1.DataBind();
                //this.DataBind();
            }
        }

        private DataTable ConvertToDataTable(List<Konke.MiniK> list)
        {
            DataTable dt = new DataTable("设备列表");
            dt.Columns.Add("设备ID");
            dt.Columns.Add("设备名称");
            //dt.Columns.Add("MAC地址");
            dt.Columns.Add("设备类型");
            //dt.Columns.Add("所属用户");
            dt.Columns.Add("开关状态");
            dt.Columns.Add("在线状态");
            foreach (Konke.MiniK k in list)
            {
                DataRow row = dt.NewRow();
                row.ItemArray = new object[] { k.kid, k.device_name, k.device_type, k.state, k.online };
                dt.Rows.Add(row);
            }
            return dt;
        }

        protected void QUIT_Click(object sender, EventArgs e)
        {
            Session["auth"] = false;
            Session["control"] = null;
            Response.Redirect("Login.aspx", true);
        }

        protected void chkall_onchanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                CheckBox cb = DataList1.Items[i].Cells[0].FindControl("select") as CheckBox;
                cb.Checked = c.Checked;
            }
        }

        protected void select_onchanged(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                CheckBox cb = DataList1.Items[i].Cells[0].FindControl("select") as CheckBox;
                if (cb.Checked) count++;
            }
            checkall.Checked = count == DataList1.Items.Count;
        }

        protected void Switch_Click(object sender, EventArgs e)
        {
            bool f = false;
            List<string> selectKids = new List<string>();
            Konke.Controler control = Session["control"] as Konke.Controler;
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                CheckBox cb = DataList1.Items[i].Cells[0].FindControl("select") as CheckBox;
                if (cb.Checked)
                {
                    string kid = DataList1.DataKeys[i].ToString();
                    selectKids.Add(kid);
                    if (control != null)
                    {
                        f = control.Turn(kid, true);
                        if (f)
                        {
                            //this.ClientScript.RegisterStartupScript(this.GetType(), "x", "<script>alert('开启成功！')</script>");
                            //Response.Redirect("MiniK.aspx");
                        }
                        else
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "y", "<script>alert('开启失败！')</script>");
                        }
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "z", "<script>alert('Konke.Controler为空，请重新登录！')</script>");
                    }
                }
            }
            if (f)
            {
                DataTable dt = ConvertToDataTable(control.GetKList(control.Accesstoken, control.UserId()));
                DataList1.DataSource = dt;
                DataList1.DataBind();
                for (int i = 0; i < DataList1.Items.Count; i++)
                {
                    if (selectKids.Contains(DataList1.DataKeys[i].ToString()))
                    {
                        CheckBox cb = DataList1.Items[i].Cells[0].FindControl("select") as CheckBox;
                        cb.Checked = true;
                    }
                }
            }
        }

        protected void TurnOff_Click(object sender, EventArgs e)
        {
            bool f = false;
            List<string> selectKids = new List<string>();
            Konke.Controler control = Session["control"] as Konke.Controler;
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                CheckBox cb = DataList1.Items[i].Cells[0].FindControl("select") as CheckBox;
                if (cb.Checked)
                {
                    string kid = DataList1.DataKeys[i].ToString();
                    selectKids.Add(kid);
                    if (control != null)
                    {
                        f = control.Turn(kid, false);
                        if (f)
                        {
                            //this.ClientScript.RegisterStartupScript(this.GetType(), "x", "<script>alert('关闭成功！')</script>");
                            //Response.Redirect("MiniK.aspx");
                        }
                        else
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "y", "<script>alert('关闭失败！')</script>");
                        }
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "z", "<script>alert('Konke.Controler为空，请重新登录！')</script>");
                    }
                }
            }
            if (f)
            {
                DataTable dt = ConvertToDataTable(control.GetKList(control.Accesstoken, control.UserId()));
                DataList1.DataSource = dt;
                DataList1.DataBind();
                for (int i = 0; i < DataList1.Items.Count; i++)
                {
                    if (selectKids.Contains(DataList1.DataKeys[i].ToString()))
                    {
                        CheckBox cb = DataList1.Items[i].Cells[0].FindControl("select") as CheckBox;
                        cb.Checked = true;
                    }
                }
            }
        }

        protected void SwitchKT1_Click(object sender, EventArgs e)
        {
            bool f = false;
            List<string> selectKids = new List<string>();
            Konke.Controler control = Session["control"] as Konke.Controler;
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                CheckBox cb = DataList1.Items[i].Cells[0].FindControl("select") as CheckBox;
                if (cb.Checked)
                {
                    string kid = DataList1.DataKeys[i].ToString();
                    selectKids.Add(kid);
                    if (control != null)
                    {
                        Konke.ACRemoter r = control.GetACRemoters(control.UserId()).Find(a => a.kid.Equals(kid, StringComparison.InvariantCultureIgnoreCase));
                        if (r != null)
                        {
                            f = control.ACRemote(r, Konke.ACState.FromString("1." + orderKT1.Text.Trim()+"."+ orderKT2.Text.Trim() + "."+ orderKT3.Text.Trim()));
                            if (f)
                            {
                                //this.ClientScript.RegisterStartupScript(this.GetType(), "x", "<script>alert('开启成功！')</script>");
                                //Response.Redirect("MiniK.aspx");
                            }
                            else
                            {
                                this.ClientScript.RegisterStartupScript(this.GetType(), "y", "<script>alert('开启失败！')</script>");
                            }
                        }
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "z", "<script>alert('Konke.Controler为空，请重新登录！')</script>");
                    }
                }
            }
            if (f)
            {
                DataTable dt = ConvertToDataTable(control.GetKList(control.Accesstoken, control.UserId()));
                DataList1.DataSource = dt;
                DataList1.DataBind();
                for (int i = 0; i < DataList1.Items.Count; i++)
                {
                    if (selectKids.Contains(DataList1.DataKeys[i].ToString()))
                    {
                        CheckBox cb = DataList1.Items[i].Cells[0].FindControl("select") as CheckBox;
                        cb.Checked = true;
                    }
                }
            }
        }

        protected void SwitchKT0_Click(object sender, EventArgs e)
        {
            bool f = false;
            List<string> selectKids = new List<string>();
            Konke.Controler control = Session["control"] as Konke.Controler;
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                CheckBox cb = DataList1.Items[i].Cells[0].FindControl("select") as CheckBox;
                if (cb.Checked)
                {
                    string kid = DataList1.DataKeys[i].ToString();
                    selectKids.Add(kid);
                    if (control != null)
                    {
                        Konke.ACRemoter r = control.GetACRemoters(control.UserId()).Find(a => a.kid.Equals(kid, StringComparison.InvariantCultureIgnoreCase));
                        if (r != null)
                        {
                            f = control.ACRemote(r, Konke.ACState.FromString("0." + orderKT1.Text.Trim() + "." + orderKT2.Text.Trim() + "." + orderKT3.Text.Trim()));
                            if (f)
                            {
                                //this.ClientScript.RegisterStartupScript(this.GetType(), "x", "<script>alert('开启成功！')</script>");
                                //Response.Redirect("MiniK.aspx");
                            }
                            else
                            {
                                this.ClientScript.RegisterStartupScript(this.GetType(), "y", "<script>alert('开启失败！')</script>");
                            }
                        }
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "z", "<script>alert('Konke.Controler为空，请重新登录！')</script>");
                    }
                }
            }
            if (f)
            {
                DataTable dt = ConvertToDataTable(control.GetKList(control.Accesstoken, control.UserId()));
                DataList1.DataSource = dt;
                DataList1.DataBind();
                for (int i = 0; i < DataList1.Items.Count; i++)
                {
                    if (selectKids.Contains(DataList1.DataKeys[i].ToString()))
                    {
                        CheckBox cb = DataList1.Items[i].Cells[0].FindControl("select") as CheckBox;
                        cb.Checked = true;
                    }
                }
            }
        }

        protected void DoControl_Click(object sender, EventArgs e)
        {
            bool f = false;
            List<string> selectKids = new List<string>();
            Konke.Controler control = Session["control"] as Konke.Controler;
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                CheckBox cb = DataList1.Items[i].Cells[0].FindControl("select") as CheckBox;
                if (cb.Checked)
                {
                    string kid = DataList1.DataKeys[i].ToString();
                    selectKids.Add(kid);
                    if (control != null)
                    {
                        Konke.Remoter r = control.GetRemoters(control.UserId()).Find(a => a.kid.Equals(kid, StringComparison.InvariantCultureIgnoreCase));
                        if (r != null)
                        {
                            f = control.Remote(r, order.Text.Trim());
                            if (f)
                            {
                                //this.ClientScript.RegisterStartupScript(this.GetType(), "x", "<script>alert('遥控器命令执行成功！')</script>");
                                //Response.Redirect("MiniK.aspx");
                            }
                            else
                            {
                                this.ClientScript.RegisterStartupScript(this.GetType(), "y", "<script>alert('遥控器命令执行失败！')</script>");
                            }
                        }
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "z", "<script>alert('Konke.Controler为空，请重新登录！')</script>");
                    }
                }
            }
            if (f)
            {
                DataTable dt = ConvertToDataTable(control.GetKList(control.Accesstoken, control.UserId()));
                DataList1.DataSource = dt;
                DataList1.DataBind();
                for (int i = 0; i < DataList1.Items.Count; i++)
                {
                    if (selectKids.Contains(DataList1.DataKeys[i].ToString()))
                    {
                        CheckBox cb = DataList1.Items[i].Cells[0].FindControl("select") as CheckBox;
                        cb.Checked = true;
                    }
                }
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            TableCell tc = e.Item.Cells[1]; //定义第一列
            tc.Visible = false; //隐藏所有行中的第一列数据
            //顺便隐藏列头
            //DataList1.HeaderRow.Cells[0].Visible = false;
        }

        //protected void DataList1_ItemCreated(object sender, DataGridItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Header)
        //    {
        //        CheckBox cb = e.Item.FindControl("checkall") as CheckBox;
        //        if (cb != null)
        //            ScriptManager.GetCurrent(this.Page).RegisterAsyncPostBackControl(cb);
        //    }
        //}
    }
    public class LoginInfo
    {
        string clientId;

        public string ClientId
        {
            get { return clientId; }
            set { clientId = value; }
        }
        string clientSecret;

        public string ClientSecret
        {
            get { return clientSecret; }
            set { clientSecret = value; }
        }
        string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}