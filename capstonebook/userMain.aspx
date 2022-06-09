<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userMain.aspx.cs" Inherits="capstonebook.userMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script language="C#" runat="server">
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <section>
            <%=Request.Cookies["UserID"].Value %>
            <asp:Label ID="LUserID" runat="server" Text="님 환영합니다."></asp:Label>
        </section>
        <asp:Button ID="Button1" runat="server" Text="지문등록" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />

        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    </form>
</body>
</html>
