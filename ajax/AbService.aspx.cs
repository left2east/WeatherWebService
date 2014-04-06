using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AbServiceReference1;

public partial class ajax_AbService : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSourceForWeChatSrvSoapClient dsfcss = new DataSourceForWeChatSrvSoapClient();

        string str=dsfcss.GetNoticeBodyByID("1");
        Response.ClearContent();
        Response.Write(str);
        Response.End();
    }
}