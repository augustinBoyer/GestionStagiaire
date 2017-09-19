<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP2._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Connexion</h1>
        <p>Utilisateur : <asp:TextBox ID="txtUser" runat="server"></asp:TextBox></p>
        <p>Mot de passe : <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></p>
        <p><asp:Button ID="btnOk" runat="server" Text="Connecter" OnClick="btnOk_Click" /><asp:Label ID="lblErreur" runat="server" ForeColor="Red"></asp:Label></p>

    </div>
    </form>
</body>
</html>
