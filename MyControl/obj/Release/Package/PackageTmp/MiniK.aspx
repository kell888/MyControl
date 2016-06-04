<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MiniK.aspx.cs" Inherits="MyControl.MiniK" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>远程控制 -- 世界尽在你手中！</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    <div align="center" style="font-size:16pt; font-weight:bolder">
            <asp:UpdatePanel ID="update" runat="server" UpdateMode="Always">
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="checkall" EventName="CheckedChanged" />
            <asp:AsyncPostBackTrigger ControlID="Switch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="TurnOff" EventName="Click" />
            <%--<asp:AsyncPostBackTrigger ControlID="select" EventName="CheckedChanged" />--%>
            </Triggers>
            <ContentTemplate>
            <asp:DataGrid ID="DataList1" runat="server" DataKeyField="设备ID" 
            ForeColor="#333333" Width="98%" OnItemDataBound="DataList1_ItemDataBound"><%-- onitemcreated="DataList1_ItemCreated">--%>
            <%--DataSourceID="ObjectDataSource1">--%>
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <AlternatingItemStyle BackColor="White" />
            <ItemStyle BackColor="#E3EAEB" />
            <SelectedItemStyle BackColor="#C5BBAF" ForeColor="#333333" Font-Bold="True" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <Columns>
            <asp:TemplateColumn>
            <ItemTemplate>
            <asp:CheckBox ID="select" OnCheckedChanged="select_onchanged" AutoPostBack="true" runat="server" />
            </ItemTemplate>
            </asp:TemplateColumn>
            <%--<asp:BoundColumn HeaderText="设备ID" DataField="kid" /> 
            <asp:BoundColumn HeaderText="设备名称" DataField="device_name" /> 
            <asp:BoundColumn HeaderText="MAC地址" DataField="device_mac" /> 
            <asp:BoundColumn HeaderText="设备类型" DataField="device_type" /> 
            <asp:BoundColumn HeaderText="所属用户" DataField="user_id" /> 
            <asp:BoundColumn HeaderText="设备状态" DataField="state" />--%>
            </Columns>
        </asp:DataGrid>
        <%-- <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetKList" 
            DataObjectTypeName="Konke.MiniK" TypeName="MyControl.Select">
        </asp:ObjectDataSource>--%>
        <br />
            <asp:CheckBox ID="checkall" OnCheckedChanged="chkall_onchanged" AutoPostBack="true" runat="server" Text="全选"></asp:CheckBox>
        <br />
        <br />
        <asp:Button runat="server" ID="Switch" Text="开启普通开关" style="font-size:20pt; font-weight:bolder" onclick="Switch_Click"/>&nbsp;
        <asp:Button runat="server" ID="TurnOff" Text="关闭普通开关" style="font-size:20pt; font-weight:bolder" onclick="TurnOff_Click"/>
                <br />
                <br />
                &nbsp;模式<asp:TextBox runat="server" ID="orderKT1" Text="" Width="33pt"></asp:TextBox>风速<asp:TextBox runat="server" ID="orderKT2" Text="" Width="33pt"></asp:TextBox>温度<asp:TextBox runat="server" ID="orderKT3" Text="" Width="33pt"></asp:TextBox>&nbsp;<asp:Button ID="SwitchKT1" runat="server" style="font-size:20pt; font-weight:bolder" Text="开空调" onclick="SwitchKT1_Click"/>&nbsp;
                <asp:Button runat="server" ID="SwitchKT0" style="font-size:20pt; font-weight:bolder" Text="关空调" onclick="SwitchKT0_Click"/>
                <br />
                普通遥控器命令<asp:TextBox runat="server" ID="order" Text="" Width="110pt"></asp:TextBox><asp:Button runat="server" ID="SwitchFS1" style="font-size:20pt; font-weight:bolder" Text="执行普通遥控器" onclick="DoControl_Click"/>
            </ContentTemplate>
            </asp:UpdatePanel>
        <br />
        <br />
        <font color="gray">开启或关闭前，请先勾选要操作的设备！</font><br />
        <br />
        <br />
        <asp:Button ID="QUIT" runat="server" Text="安全退出" Width="160px" 
            style="font-size:20pt; font-weight:bolder" onclick="QUIT_Click"></asp:Button>
    </div>
    </form>
</body>
</html>
