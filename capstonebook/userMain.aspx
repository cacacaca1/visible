<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userMain.aspx.cs" Inherits="capstonebook.userMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script language="C#" runat="server">
        private void Page_Load(object sender, EventArgs e)
        {
            string trialUsername = null;
            HttpCookie objectUsername = null;
            if (Request.Form["trialUsername"] != null)
            {
                trialUsername = Request.Form["trialUsername"];
            }
            objectUsername = new HttpCookie("membershipUsername");
            objectUsername.Value = trialUsername;
            objectUsername.Expires = DateTime.Now.AddHours(12.0);
            Response.Cookies.Add(objectUsername);
            return;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <section>
            <%=Request.Cookies["membershipUsername"].Value %>
        </section>
    </form>
</body>
</html>
