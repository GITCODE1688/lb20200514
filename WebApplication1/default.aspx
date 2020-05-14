<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApplication1._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="26px" Width="737px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="發送訊息" OnClick="Button1_Click" />
        <br />
        <br />
        <br />
        <br />
        歷史發送<br />
        <asp:ListBox ID="ListBox1" runat="server" Width="740px"></asp:ListBox>
        <br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Width="47px"></asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server" Width="47px"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="發送貼圖" OnClick="Button2_Click" />
        <br />
        <br />
        <asp:TextBox ID="TextBox4" runat="server" Width="732px"></asp:TextBox>
        <asp:Button ID="Button3" runat="server" Text="發送圖片" OnClick="Button3_Click" />
        <br />
        <br />
        <br />
        <p><a href=UserID_View.aspx class="btn btn-primary btn-lg">User ID</a></p>
        <p><a href=UserID_View.aspx class="btn btn-primary btn-lg">
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="新增table" />
            <asp:Label ID="lbCreateMSG" runat="server" Height="200px" Text="Label" Width="800px"></asp:Label>
            </a></p>
        <p><a href=UserID_View.aspx class="btn btn-primary btn-lg">
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="新增row" />
            <asp:Label ID="lbinsertMSG" runat="server" Height="200px" Text="Label" Width="800px"></asp:Label>
            </a></p>
    </div>
    </form>
</body>
</html>
