<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="capstonebook.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 로그인<br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ID :
            <asp:TextBox ID="IDText" runat="server"></asp:TextBox>
            <br /> 
&nbsp;password :
            <asp:TextBox ID="PWText" TextMode="Password" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Button ID="LoginButton1" runat="server" OnClick="LoginButton1_Click" Text="로그인" />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="RegisterButton3" runat="server" OnClick="RegisterButton3_Click" Text="회원가입" />
        </div>
    </form>
</body>
</html>
