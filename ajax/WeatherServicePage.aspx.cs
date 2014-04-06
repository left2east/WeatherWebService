using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceReference2;

public partial class ajax_WeatherServicePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.ClearContent();
        Response.Write(GetWeather());
        Response.End();
    }

    private string StaticTreeView()
    {
        return "<ul id=\"navigation\"><li>直辖市<ul><li>北京</li><li>上海</li><li>天津</li><li>重庆</li></ul></li><li>特别行政区<ul><li>香港</li><li>澳门</li></ul></li><li>黑龙江<ul><li>哈尔滨</li><li>齐齐哈尔</li><li>牡丹江</li><li>大庆</li><li>伊春</li><li>双鸭山</li><li>鹤岗</li><li>鸡西</li><li>佳木斯</li><li>七台河</li><li>黑河</li><li>绥化</li><li>大兴安岭</li></ul></li><li>吉林<ul><li>长春</li><li>吉林</li><li>白山</li><li>白城</li><li>四平</li><li>松原</li><li>辽源</li><li>大安</li><li>通化</li></ul></li><li>辽宁<ul><li>沈阳</li><li>大连</li><li>葫芦岛</li><li>旅顺</li><li>本溪</li><li>抚顺</li><li>铁岭</li><li>辽阳</li><li>营口</li><li>阜新</li><li>朝阳</li><li>锦州</li><li>丹东</li><li>鞍山</li></ul></li><li>内蒙古<ul><li>呼和浩特</li><li>锡林浩特</li><li>包头</li><li>赤峰</li><li>海拉尔</li><li>乌海</li><li>鄂尔多斯</li><li>锡林浩特</li><li>通辽</li></ul></li><li>河北<ul><li>石家庄</li><li>唐山</li><li>张家口</li><li>廊坊</li><li>邢台</li><li>邯郸</li><li>沧州</li><li>衡水</li><li>承德</li><li>保定</li><li>秦皇岛</li></ul></li><li>河南<ul><li>郑州</li><li>开封</li><li>洛阳</li><li>平顶山</li><li>焦作</li><li>鹤壁</li><li>新乡</li><li>安阳</li><li>濮阳</li><li>许昌</li><li>漯河</li><li>三门峡</li><li>南阳</li><li>商丘</li><li>信阳</li><li>周口</li><li>驻马店</li></ul></li><li>山东<ul><li>济南</li><li>青岛</li><li>淄博</li><li>威海</li><li>曲阜</li><li>临沂</li><li>烟台</li><li>枣庄</li><li>聊城</li><li>济宁</li><li>菏泽</li><li>泰安</li><li>日照</li><li>东营</li><li>德州</li><li>滨州</li><li>莱芜</li><li>潍坊</li></ul></li><li>山西<ul><li>太原</li><li>阳泉</li><li>晋城</li><li>晋中</li><li>临汾</li><li>运城</li><li>长治</li><li>朔州</li><li>忻州</li><li>大同</li><li>吕梁</li></ul></li><li>江苏<ul><li>南京</li><li>苏州</li><li>昆山</li><li>南通</li><li>太仓</li><li>吴县</li><li>徐州</li><li>宜兴</li><li>镇江</li><li>淮安</li><li>常熟</li><li>盐城</li><li>泰州</li><li>无锡</li><li>连云港</li><li>扬州</li><li>常州</li><li>宿迁</li></ul></li><li>安徽<ul><li>合肥</li><li>巢湖</li><li>蚌埠</li><li>安庆</li><li>六安</li><li>滁州</li><li>马鞍山</li><li>阜阳</li><li>宣城</li><li>铜陵</li><li>淮北</li><li>芜湖</li><li>宿州</li><li>淮南</li><li>池州</li></ul></li><li>陕西<ul><li>西安</li><li>韩城</li><li>安康</li><li>汉中</li><li>宝鸡</li><li>咸阳</li><li>榆林</li><li>渭南</li><li>商洛</li><li>铜川</li><li>延安</li></ul></li><li>宁夏<ul><li>银川</li><li>固原</li><li>中卫</li><li>石嘴山</li><li>吴忠</li></ul></li><li>甘肃<ul><li>兰州</li><li>白银</li><li>庆阳</li><li>酒泉</li><li>天水</li><li>武威</li><li>张掖</li><li>甘南</li><li>临夏</li><li>平凉</li><li>定西</li><li>金昌</li></ul></li><li>青海<ul><li>西宁</li><li>海北</li><li>海西</li><li>黄南</li><li>果洛</li><li>玉树</li><li>海东</li><li>海南</li></ul></li><li>湖北<ul><li>武汉</li><li>宜昌</li><li>黄冈</li><li>恩施</li><li>荆州</li><li>神农架</li><li>十堰</li><li>咸宁</li><li>襄樊</li><li>孝感</li><li>随州</li><li>黄石</li><li>荆门</li><li>鄂州</li></ul></li><li>湖南<ul><li>长沙</li><li>邵阳</li><li>常德</li><li>郴州</li><li>吉首</li><li>株洲</li><li>娄底</li><li>湘潭</li><li>益阳</li><li>永州</li><li>岳阳</li><li>衡阳</li><li>怀化</li><li>韶山</li><li>张家界</li></ul></li><li>浙江<ul><li>杭州</li><li>湖州</li><li>金华</li><li>宁波</li><li>丽水</li><li>绍兴</li><li>衢州</li><li>嘉兴</li><li>台州</li><li>舟山</li><li>温州</li></ul></li><li>江西<ul><li>南昌</li><li>萍乡</li><li>九江</li><li>上饶</li><li>抚州</li><li>吉安</li><li>鹰潭</li><li>宜春</li><li>新余</li><li>景德镇</li><li>赣州</li></ul></li><li>福建<ul><li>福州</li><li>厦门</li><li>龙岩</li><li>南平</li><li>宁德</li><li>莆田</li><li>泉州</li><li>三明</li><li>漳州</li></ul></li><li>贵州<ul><li>贵阳</li><li>安顺</li><li>赤水</li><li>遵义</li><li>铜仁</li><li>六盘水</li><li>毕节</li><li>凯里</li><li>都匀</li></ul></li><li>四川<ul><li>成都</li><li>泸州</li><li>内江</li><li>凉山</li><li>阿坝</li><li>巴中</li><li>广元</li><li>乐山</li><li>绵阳</li><li>德阳</li><li>攀枝花</li><li>雅安</li><li>宜宾</li><li>自贡</li><li>甘孜州</li><li>达州</li><li>资阳</li><li>广安</li><li>遂宁</li><li>眉山</li><li>南充</li></ul></li><li>广东<ul><li>广州</li><li>深圳</li><li>潮州</li><li>韶关</li><li>湛江</li><li>惠州</li><li>清远</li><li>东莞</li><li>江门</li><li>茂名</li><li>肇庆</li><li>汕尾</li><li>河源</li><li>揭阳</li><li>梅州</li><li>中山</li><li>德庆</li><li>阳江</li><li>云浮</li><li>珠海</li><li>汕头</li><li>佛山</li></ul></li><li>广西<ul><li>南宁</li><li>桂林</li><li>阳朔</li><li>柳州</li><li>梧州</li><li>玉林</li><li>桂平</li><li>贺州</li><li>钦州</li><li>贵港</li><li>防城港</li><li>百色</li><li>北海</li><li>河池</li><li>来宾</li><li>崇左</li></ul></li><li>云南<ul><li>昆明</li><li>保山</li><li>楚雄</li><li>德宏</li><li>红河</li><li>临沧</li><li>怒江</li><li>曲靖</li><li>思茅</li><li>文山</li><li>玉溪</li><li>昭通</li><li>丽江</li><li>大理</li></ul></li><li>海南<ul><li>海口</li><li>三亚</li><li>儋州</li><li>琼山</li><li>通什</li><li>文昌</li></ul></li><li>新疆<ul><li>乌鲁木齐</li><li>阿勒泰</li><li>阿克苏</li><li>昌吉</li><li>哈密</li><li>和田</li><li>喀什</li><li>克拉玛依</li><li>石河子</li><li>塔城</li><li>库尔勒</li><li>吐鲁番</li><li>伊宁</li></ul></li><li>西藏<ul><li>拉萨</li><li>阿里</li><li>昌都</li><li>那曲</li><li>日喀则</li><li>山南</li><li>林芝</li></ul></li><li>台湾<ul><li>台北</li><li>高雄</li></ul></li><li>亚洲<ul><li>伊斯坦布尔</li><li>德黑兰</li><li>卡拉奇</li><li>新德里</li><li>科伦坡</li><li>首尔</li><li>釜山</li><li>东京</li><li>仰光</li><li>曼谷</li><li>吉隆坡</li><li>河内</li><li>北京</li><li>雅加达</li></ul></li><li>欧洲<ul><li>汉堡</li><li>柏林</li><li>法兰克福</li><li>维也纳</li><li>米兰</li><li>罗马</li><li>雅典</li><li>斯德哥尔摩</li><li>莫斯科</li><li>曼彻斯特</li><li>伦敦</li><li>阿姆斯特丹</li><li>布鲁塞尔</li><li>苏黎世</li><li>日内瓦</li></ul></li><li>非洲<ul><li>巴马科</li><li>亚的斯亚贝巴</li><li>内罗毕</li><li>阿克拉</li><li>马普托</li><li>约翰内斯堡</li><li>曼齐尼</li><li>开普敦</li></ul></li><li>北美洲<ul><li>多伦多</li><li>蒙特利尔</li><li>渥太华</li><li>温哥华</li><li>迈阿密</li><li>亚特兰大</li><li>休斯敦</li><li>洛杉矶</li><li>拉斯维加斯</li><li>华盛顿</li><li>纽约</li><li>波士顿</li><li>芝加哥</li><li>西雅图</li><li>圣地亚哥</li></ul></li><li>南美洲<ul><li>波哥大</li><li>利马</li><li>蒙特港</li><li>布宜诺斯艾利斯</li></ul></li><li>大洋洲<ul><li>奥克兰</li><li>惠灵顿</li><li>悉尼</li><li>墨尔本</li><li>堪培拉</li></ul></li></ul>";
    }

    private string GetTreeView()
    {
        string strHTML="<ul id=\"navigation\">";
        WeatherWebServiceSoapClient wws = new WeatherWebServiceSoapClient("WeatherWebServiceSoap121");

        string []ProvinceNames = wws.getSupportProvince();
        foreach (string province in ProvinceNames)
        {
            strHTML += "<li>"+province+"<ul>";
            string[] cities = wws.getSupportCity(province);
            foreach (string city in cities)
            {
                int x = city.IndexOf(' ');
                if (x > 0)
                    strHTML += "<li>" + city.Substring(0, x) + "</li>";
                else
                    strHTML += "<li>" + city + "</li>";

            }
            strHTML += "</ul></li>";
        }
        return strHTML+"</ul>";
    }

    private string GetWeather()
    {
        string cityName = Server.UrlDecode(Request.QueryString["city"]);
        string strWeather = "";
        if (cityName == string.Empty)
        {
            strWeather = "城市名称怎么是空的？";
            return strWeather;
        }
        else
        {
            WeatherWebServiceSoapClient wws = new WeatherWebServiceSoapClient("WeatherWebServiceSoap121");
            string[] data;
            try
            {
                data = wws.getWeatherbyCityName(cityName);
            }
            catch
            {
                data = new string[1];
                data[0] = "这个服务不好使,改改代理试试.";
            }
            if (data.Length == 0)
                return "";

            foreach (string s in data)
            {
                if (s.Contains(".jpg") || s.Contains(".gif"))
                    continue;
                strWeather = strWeather + s + "<br>";
            }
            return strWeather + "<br />来自 <a href='http://www.webxml.com.cn/' target='_blank'>天气预报 Web 服务</a>";
        }
    }
}