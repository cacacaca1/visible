<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="capstonebook.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="shut the fuck up"></asp:Label>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="연결" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="종료" />
        <asp:Label ID="Label2" runat="server" Text="COM포트"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label3" runat="server" Text="지문ID"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
        <asp:Button ID="enroll" runat="server" OnClick="Button3_Click" Text="등록" />
    </form>
</body>
</html>
