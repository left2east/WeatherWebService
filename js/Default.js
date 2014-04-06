function tab(tabcontrol) {
var tb1 = document.getElementById('TextBox1');
if(tb1.style.color=="gray")
{
tb1.style.color="black";
tb1.value="北京";
}
tabcontrol.style.backgroundColor="black";
if(tabcontrol.id=="Sina")
document.getElementById("WeatherService").style.backgroundColor="white";
else
document.getElementById("Sina").style.backgroundColor="white";
btnClick();
}
function loadXMLDoc(pageLocation) {
var divName="SinaDiv";
if(pageLocation=="tree/abc.html")
divName="WeatherServiceDiv";
    document.getElementById(divName).innerHTML = "<img src='resources/1.gif' />";
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    document.getElementById(divName).innerHTML = xmlhttp.responseText;
                    if(divName=="WeatherServiceDiv")
                    applyTreeView();
                }
            }
            xmlhttp.open("GET", pageLocation, true);
            xmlhttp.send();
        }
        function textChange() {
            var tb1 = document.getElementById('TextBox1');
            if (tb1.style.color == 'gray') {
                tb1.style.color = 'black';
                tb1.value = '';
            }
        }
        
                function btnClick() {
                
        var tb1 = document.getElementById('TextBox1');
        if (tb1.style.color == 'gray') {
            alert('请先输入城市名称！');
            return false;
        }
        cityName = escape(tb1.value);
        if (tb1.value == '') {
            alert('请先输入城市名称！');
            return false;
        }
        var sourcename;
        if(document.getElementById("Sina").style.backgroundColor=="black")
        sourcename="SinaWeatherPage";
        else
        sourcename="WeatherServicePage";
        
        loadXMLDoc("ajax/"+sourcename+".aspx?city=" + cityName);
        return false;
        }
        function onFirstLoad() {
        document.getElementById("Sina").style.backgroundColor="black";
            var tb1 = document.getElementById('TextBox1');
            var cities = document.getElementById("Map").getElementsByTagName("area");
            for (var i = 0; i < cities.length; i++) {
                cities[i].onclick = function () { tb1.style.color = "black"; tb1.value = this.title; btnClick(); };
            }
            if (tb1.style.color == 'black') {
                return false;
            }
            else
                tb1.value = "输入城市名称，如：北京";
                loadXMLDoc("tree/abc.html");
            loadXMLDoc("ajax/SinaWeatherPage.aspx?city=%E5%8C%97%E4%BA%AC");
            var oTest = document.getElementById("form1");
            var newNode = document.createElement("audio");
            newNode.src = "resources/1.mp3";
            newNode.autoplay = "true";
            newNode.loop = "true";
            oTest.appendChild(newNode);
            //var newNode2 = document.createElement("img");
            //newNode2.src = "resources/1.gif";
            //newNode2.alt = "日常";
            //newNode2.style = "display:none";
            //newNode2.Id = "pic";
            //newNode.setAttribute("src","D:\\KuGou\\1.mp3");
            //newNode.setAttribute("loop","-1");            
            //oTest.appendChild(newNode2);           
        }
           function applyTreeView()
      {
        $("#navigation li ul li").click(function(){
        var tb1 = document.getElementById('TextBox1');
          tb1.style.color = "black"; tb1.value = this.innerText; btnClick();
        });


        $("#navigation li ul li").hover(function() {
		this.style.color="#00FFFF";
	}, function() {
    this.style.color="black";
	});


        // second example
	$("#navigation").treeview({
		persist: "location",
		collapsed: true,
		unique: true
        	});
      }