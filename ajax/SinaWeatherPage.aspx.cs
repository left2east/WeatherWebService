using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ajax_SinaWeatherPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string cityName = Server.UrlDecode(Request.QueryString["city"]);
        
        WebService ws = new WebService();
        string strWeather1 = string.Empty;
        if (cityName == string.Empty)
        {
            strWeather1 = "城市名称怎么是空的？";
        }
        else
        {
            strWeather1 = ws.GetWeather(cityName);
            strWeather1 = strWeather1 + "来自 <a href='http://php.weather.sina.com.cn' target='_blank'>新浪天气</a>";
        }
        Response.ClearContent();
        Response.Write(strWeather1);
        Response.End();
    }
}