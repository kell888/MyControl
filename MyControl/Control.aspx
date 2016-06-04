<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Control.aspx.cs" Inherits="MyControl._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>智能家居远程控制 -- 轻便生活，你值得拥有！</title>
</head>
<body>
    <form id="form1" runat="server">
<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    <div align="center" style="font-size:20pt; font-weight:bolder">
        <asp:Button ID="btnSend" runat="server" Text="打开K1" Width="160px" style="font-size:20pt; font-weight:bolder" 
            onclick="btnSend_Click" />&nbsp;&nbsp;
        <asp:Button ID="button1" runat="server" Text="打开K2" Width="160px" style="font-size:20pt; font-weight:bolder"
            onclick="button1_Click" />&nbsp;&nbsp;
        <asp:Button ID="button2" runat="server" Text="打开K3" Width="160px" style="font-size:20pt; font-weight:bolder"
            onclick="button2_Click" />&nbsp;&nbsp;
        <asp:Button ID="button3" runat="server" Text="打开K4" Width="160px" style="font-size:20pt; font-weight:bolder"
            onclick="button3_Click" /><br /><br />
        <asp:Button ID="button9" runat="server" Text="关闭K1" Width="160px" style="font-size:20pt; font-weight:bolder"
            onclick="button9_Click" Enabled="false" />&nbsp;&nbsp;
        <asp:Button ID="button8" runat="server" Text="关闭K2" Width="160px" style="font-size:20pt; font-weight:bolder"
            onclick="button8_Click" Enabled="false" />&nbsp;&nbsp;
        <asp:Button ID="button7" runat="server" Text="关闭K3" Width="160px" style="font-size:20pt; font-weight:bolder"
            onclick="button7_Click" Enabled="false" />&nbsp;&nbsp;
        <asp:Button ID="button5" runat="server" Text="关闭K4" Width="160px" style="font-size:20pt; font-weight:bolder"
            onclick="button5_Click" Enabled="false" /><br /><br /><br /><br />
        <asp:Button ID="button4" runat="server" Text="全部打开" Width="160px" style="font-size:20pt; font-weight:bolder" onclick="button4_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="button6" runat="server" Text="全部关闭" Width="160px" style="font-size:20pt; font-weight:bolder" onclick="button6_Click" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="QUIT" runat="server" Text="安全退出" Width="160px" 
            style="font-size:20pt; font-weight:bolder" onclick="QUIT_Click"></asp:Button>
    </div>
    </form>
</body>
</html>
