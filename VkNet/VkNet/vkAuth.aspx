<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vkAuth.aspx.cs" Inherits="VkNet.vkAuth" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 10px; top: 15px; position: absolute" Text="Login"></asp:Label>
            <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 262px; top: 15px; position: absolute" Text="Friends List"></asp:Label>
        </div>
        <asp:TextBox ID="log_textBox" runat="server" style="z-index: 1; left: 10px; top: 44px; position: absolute; margin-top: 0px" TextMode="Password"></asp:TextBox>
        <asp:TextBox ID="pass_textBox" runat="server" style="z-index: 1; left: 9px; top: 98px; position: absolute" TextMode="Password"></asp:TextBox>
        <asp:ListBox ID="ListBox1" runat="server" style="z-index: 1; left: 259px; top: 34px; position: absolute; height: 271px; width: 187px; margin-top: 4px"></asp:ListBox>
        <asp:Button ID="auth_Button" runat="server" OnClick="auth_Button_Click" style="z-index: 1; left: 8px; top: 133px; position: absolute" Text="Authorization" />
        <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 9px; top: 74px; position: absolute" Text="Password"></asp:Label>
        <asp:Label ID="Status_Label" runat="server" style="z-index: 1; left: 13px; top: 175px; position: absolute" Text="Login status:"></asp:Label>
    </form>
</body>
</html>
