<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>天气预报</title>
    <script language="javascript" type="text/javascript" src="js/Default.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width='100%' style="table-layout:fixed;">
    <tr><td align="center" valign="middle" colspan="2" style="height:100px">
        <asp:TextBox ID="TextBox1" runat="server" onclick="textChange();" Width="152px" 
            ForeColor="Gray" AutoCompleteType="Search">输入城市名称，如：北京</asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="查看天气" />
        
    </td></tr>
     <tr>
     <td style="height:800px;border-style: solid; border-width: thin;">
        <div id="WeatherServiceDiv" style="width:100%;height:100%;overflow:auto;">
         <asp:Menu ID="Menu1" runat="server" onmenuitemclick="Menu1_MenuItemClick" 
                Orientation="Horizontal">
                 <Items>
                     <asp:MenuItem Text="Tab1" Value="0"></asp:MenuItem>
                     <asp:MenuItem Text="Tab2" Value="1"></asp:MenuItem>
                 </Items>
             </asp:Menu>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View2" runat="server">
                    asdfasdfsdf
                </asp:View>
                <asp:View ID="View1" runat="server">
                    asdfsafsad
                </asp:View>
            </asp:MultiView>
         </div></td>
     <td style="height:800px;border-style: solid; border-width: thin;">
         <div id="SinaDiv" style="width:100%;height:100%;overflow:auto;">
            
         </div></td>     
     </tr>
    </table>
    </div>
    </form>
</body>
</html>
