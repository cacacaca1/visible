<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userMain.aspx.cs" Inherits="capstonebook.userMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script language="C#" runat="server">
        private void Page_Load(object sender, EventArgs e)
        {
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <section>
            <%=Request.Cookies["UserID"].Value %>
            <%Response.Cookies["UserID"].Expires = DateTime.Today.AddDays(-1);%> <!-- java 구문을 따름, 서버에서 실행됨-->
            <asp:Label ID="LUserID" runat="server" Text="님 환영합니다."></asp:Label>
        </section>
    </form>
</body>
</html>
