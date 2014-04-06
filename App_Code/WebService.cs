using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    [WebMethod]

    public string GetWeather(string city)
    {
        string weacherhtml = string.Empty;
        //转换输入参数的编码类型
        string mycity = System.Web.HttpUtility.UrlEncode(city, System.Text.UnicodeEncoding.GetEncoding("GB2312"));
        //初始化新的 WebRequest
        HttpWebRequest webrt = (HttpWebRequest)WebRequest.Create("http://php.weather.sina.com.cn/search.php?city="+ mycity);
        HttpWebResponse webrs=null;
        try
        {
            webrs = (HttpWebResponse)webrt.GetResponse();
        }
        catch (TimeoutException e)
        {
            return "连接超时";
        }
        catch (System.Net.Sockets.SocketException e1)
        {
            return "新浪响应超时";
        }
        catch
        {
            return "不知道";
        }
        //从Internet资源返回数据流 
        Stream stream = webrs.GetResponseStream();
        //读取数据流
        StreamReader srm = new StreamReader(stream, System.Text.UnicodeEncoding.GetEncoding("GB2312"));
        //读取数据
        weacherhtml = srm.ReadToEnd();
        srm.Close();
        stream.Close();
        webrs.Close();
        //针对不同的网站，请查看HTML源文件
        weacherhtml = GetValue(weacherhtml, "<!-- 右侧主内容 begin -->", "<!-- 右侧主内容 end -->");
        if (weacherhtml == "")
            return "对不起，没有城市 <strong>"+city+"</strong> 的天气信息";
        string strShare = GetValue(weacherhtml, "<!-- bShare分享 begin -->", "<!-- bShare分享 end -->");
        weacherhtml = weacherhtml.Replace(strShare, "");
        string strEx = GetValue(weacherhtml, "<ul class=\"list_01\">", "</ul>");
        return weacherhtml.Replace(strEx, "").Replace("style=\"position: relative;\"", "");

        /*
        int start = weacherhtml.IndexOf("<!-- 右侧主内容 begin -->"); //取的字符位置
        int end = weacherhtml.IndexOf("<!-- 右侧主内容 end -->");
        if (start < 0 || end < 0)
            return "对不起，没有城市"+city+"的天气信息";
        return weacherhtml.Substring(start,end-start);*/
    }

    /// <summary>
    /// 获得字符串中开始和结束字符串中间得值
    /// </summary>
    /// <param name="str">字符串</param>
    /// <param name="s">开始</param>
    /// <param name="e">结束</param>
    /// <returns></returns> 
    public static string GetValue(string str, string s, string e)
    {
        Regex rg = new Regex("(?<=(" + s + "))[.\\s\\S]*?(?=(" + e + "))", RegexOptions.Multiline | RegexOptions.Singleline);
        return rg.Match(str).Value;
    }
}
