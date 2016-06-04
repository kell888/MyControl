<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyControl.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无线控制平台，您的未来之选...</title>
</head>
<body>
    <form id="form1" runat="server"><br /><br /><br /><br /><br /><br /><br /><br />
    <div align="center" style="font-size:20pt; font-weight:bolder;">
        <font color="red"><asp:Label ID="Label2" runat="server" Text="密令错误，请重新输入！" Visible="false"></asp:Label></font>
        </div>
        <br /><br /><br /><br />
    <div align="center" style="font-size:20pt; font-weight:bolder;">
        <asp:Label ID="Label1" runat="server" Text="请输入密令：" style="vertical-align:top"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Height="30px"
            Width="160px" TextMode="Password" Font-Size="Large"></asp:TextBox>&nbsp;&nbsp;<br /><br />
        <asp:Button ID="Button1" runat="server" Text="单片机通道" 
            style="font-size:18pt; font-weight:bolder" Height="36px" 
            Width="150px" onclick="Button1_Click" />&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="小K通道" 
            style="font-size:18pt; font-weight:bolder" Height="36px" 
            Width="120px" onclick="Button2_Click" />
    </div>
    </form>
</body>
</html>
