using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceReference2;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FileRW frw = new FileRW();
        frw.FilePath = "D:\\kankan";
        frw.FileName = "LogonUserInfo.txt";
        string strTime = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        string strIP = GetIP();
        string strHost=null;
        try
        {
            strHost = System.Net.Dns.GetHostEntry(strIP).HostName;
        }
        catch
        {
            strHost = "Unknown";
        }
        bool tr=frw.WriteLine(strTime + "\t" + strIP + "\t" + strHost);
        if (!IsPostBack)
        {
            if (TextBox1.ForeColor == System.Drawing.Color.Gray)
                ClientScript.RegisterStartupScript(GetType(), "js", "<script>onFirstLoad();</script>");
            TextBox1.ForeColor = System.Drawing.Color.Gray;
            Button1.Attributes.Add("onclick", "return btnClick();");
        }
    }
    /// <summary>
    /// 获得当前页面客户端的IP
    /// </summary>
    /// <returns>当前页面客户端的IP</returns>
    public string GetIP()
    {
        string result = String.Empty;

        result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(result))
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        if (string.IsNullOrEmpty(result))
        {
            result = HttpContext.Current.Request.UserHostAddress;
        }
        if (string.IsNullOrEmpty(result))
        {
            return "127.0.0.1";
        }
        return result;
    }
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        this.MultiView1.ActiveViewIndex = int.Parse(e.Item.Value);
        if (int.Parse(e.Item.Value) == 0)
        {
            Menu1.BackColor = System.Drawing.Color.Blue;

        }
        else
        {
            Menu1.BackColor = System.Drawing.Color.White;
        }
    }
}