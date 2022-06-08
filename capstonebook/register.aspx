<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="capstonebook.regiseter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 회원가입<br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ID :&nbsp;
            <asp:TextBox ID="id" runat="server"></asp:TextBox>
            <br />
&nbsp;&nbsp; password :
            <asp:TextBox ID="pw" runat="server"></asp:TextBox>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; name :
            <asp:TextBox ID="name" runat="server"></asp:TextBox>
            <br />
&nbsp;phonenumber :&nbsp;
            <asp:TextBox ID="phone" runat="server"></asp:TextBox>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; email :
            <asp:TextBox ID="email" runat="server"></asp:TextBox>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="FingerID" runat="server" Text="지문 ID : "></asp:Label>
            <asp:TextBox ID="Fingerbox" runat="server" Height="29px" Width="193px" ReadOnly="True"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="FingerprintEnroll" runat="server" Text="지문 등록" OnClick="FingerprintEnroll_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;
            </div>
        <p>
            <asp:Label ID="Label1" runat="server" Text="지문 저장할 곳"></asp:Label>
            <asp:TextBox ID="savefinger" runat="server" Height="29px" Width="193px"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="가입완료" OnClick="Button1_Click" />
        </p>
    </form>
</body>
</html>
