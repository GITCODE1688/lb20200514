<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserID_View.aspx.cs" Inherits="WebApplication1.GRIDVIEW_TEST" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="lcmdAdd" runat="server" OnClick="lcmdAdd_Click">新增</asp:LinkButton>
            &nbsp; &nbsp; &nbsp;
            <asp:Label ID="lblTotal" runat="server" ForeColor="Red" Text="Label"></asp:Label><br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True"
                OnPageIndexChanging="GridView1_PageIndexChanging"
                OnRowCancelingEdit="GridView1_RowCancelingEdit"
                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                OnSorting="GridView1_Sorting" OnRowDeleting="GridView1_RowDeleting" OnRowUpdated="GridView1_RowUpdated">
                <Columns>
                    <asp:TemplateField HeaderText="編輯">
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <EditItemTemplate>
                            <asp:LinkButton ID="lcmdUpdate" runat="server" CommandName="Update">更新</asp:LinkButton>
                            <asp:LinkButton ID="lcmdCancel_E" runat="server" CommandName="Cancel">取消</asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="lcmdSave" runat="server" OnClick="lcmdSave_Click">儲存</asp:LinkButton>
                            <asp:LinkButton ID="lcmdCancel_F" runat="server" OnClick="lcmdCancel_F_Click">取消</asp:LinkButton>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lcmdModify" runat="server" CommandName="Edit">修改</asp:LinkButton>
                            <asp:LinkButton ID="lcmdDelete" runat="server" CommandName="Delete">刪除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LINEID">
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <EditItemTemplate>
                            <asp:Label ID="LINEID_E" runat="server" Text='<%#Eval("LINEID") %>'></asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="LINEID_F" runat="server" Text='<%#Eval("LINEID") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LINEID" runat="server" Text='<%#Eval("LINEID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name" SortExpression="Name">
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                        <ControlStyle Width="150px" />
                        <EditItemTemplate>
                            <asp:TextBox ID="lblLastName_E" runat="server" Width="100%" Text='<%#Eval("Name") %>' Font-Strikeout="False"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="lblLastName_F" runat="server" Width="100%" Text='<%#Eval("Name") %>'></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CreateTime" SortExpression="CreateTime">
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                        <ControlStyle Width="150px" />
                        <EditItemTemplate>
                            <asp:Label ID="lblFirstName_E" runat="server" Width="100%" Text='<%#Eval("CreateTime") %>'></asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblFirstName_F" runat="server" Width="100%" Text='<%#Eval("CreateTime") %>'></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("CreateTime") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
            &nbsp;&nbsp; PWD:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Button ID="btnPwd" runat="server" OnClick="btnPwd_Click" Text="unlock" />
            <br />
&nbsp;
            SN:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtSN" runat="server"></asp:TextBox>
            <br />
            &nbsp;
            <asp:Label ID="lbCol1" runat="server" Text="Column1"></asp:Label>
&nbsp;<asp:TextBox ID="txtCol1" runat="server"></asp:TextBox>
            <br />
&nbsp;
            <asp:Label ID="lbCol2" runat="server" Text="Column2"></asp:Label>
&nbsp;<asp:TextBox ID="txtCol2" runat="server"></asp:TextBox>
            <br />
            &nbsp;
            <asp:Label ID="lbCol3" runat="server" Text="Column3"></asp:Label>
&nbsp;<asp:TextBox ID="txtCol3" runat="server"></asp:TextBox>
            <br />
&nbsp;
            <asp:Label ID="lbCol4" runat="server" Text="Column4"></asp:Label>
&nbsp;<asp:TextBox ID="txtCol4" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnInsert" runat="server" Text="Insert" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="UPDATE" />
&nbsp;&nbsp; &nbsp;
            <asp:Button ID="btnDel" runat="server" OnClick="btnDel_Click" Text="Delete" />
            <br />
            <asp:Label ID="lbUpdateMSG" runat="server" Height="400px" Text="Label" Width="800px"></asp:Label>
        </div>
    </form>
</body>
</html>
