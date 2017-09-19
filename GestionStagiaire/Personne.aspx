<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personne.aspx.cs" Inherits="TP2.Personne" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblNom" runat="server" Text="Nom" Width="100px"></asp:Label>
    <asp:TextBox ID="txtNom" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="valNom" runat="server" ErrorMessage="Le nom ne peut pas être vide" ControlToValidate="txtNom">*</asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="lblTelephone" runat="server" Text="Téléphone" Width="100px"></asp:Label>
    <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="valTelephoneVide" runat="server" ControlToValidate="txtTelephone" ErrorMessage="Le téléphone ne peut pas être vide">*</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="valTelephone" runat="server" ErrorMessage="Le téléphone n'est pas valide" ControlToValidate="txtTelephone" ValidationExpression="^[0-9]{3}-?[0-9]{3}-?[0-9]{4}">*</asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Label ID="lblCourriel" runat="server" Text="Courriel" Width="100px"></asp:Label>
    <asp:TextBox ID="txtCourriel" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="valCourrielVide" runat="server" ControlToValidate="txtCourriel" ErrorMessage="Le courriel ne peut pas être vide">*</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="valCourriel" runat="server" ControlToValidate="txtCourriel" ErrorMessage="Le courriel n'est pas valide" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
    <br />
<br />
<asp:Label ID="lblLogin" runat="server" Text="Nom de login :" Width="100px"></asp:Label>
<asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="valLogin" runat="server" ControlToValidate="txtLogin" ErrorMessage="Le login ne peut être vide !">*</asp:RequiredFieldValidator>
    <asp:CustomValidator ID="valUserExists" runat="server" ControlToValidate="txtLogin" ErrorMessage="ce login existe déjà" OnServerValidate="valUserExists_ServerValidate">*</asp:CustomValidator>
<br />
<br />
    <asp:Button ID="btnModMotDePasse" runat="server" Text="Modifier le mot de passe" Visible="False" CausesValidation="False" OnClick="btnModMotDePasse_Click" />
<br />
<br />
<asp:Label ID="lblMotDePasse" runat="server" Text="Mot de passe :" Width="100px"></asp:Label>
<asp:TextBox ID="txtMotDePasse" runat="server" TextMode="Password"></asp:TextBox>
<asp:RequiredFieldValidator ID="valMotDePasse" runat="server" ControlToValidate="txtMotDePasse" ErrorMessage="Le mot de passe ne peut pas être vide !">*</asp:RequiredFieldValidator>
    <br />
    <br />
    <br />
<asp:Label ID="lblConfirmationMotDePasse" runat="server" Text="Confirmation du mot de passe :" Width="100px"></asp:Label>
<asp:TextBox ID="txtConfirmationMotDePasse" runat="server" TextMode="Password"></asp:TextBox>
<asp:RequiredFieldValidator ID="valConfirmationMotDePasse" runat="server" ControlToValidate="txtConfirmationMotDePasse" ErrorMessage="La confirmation de mot passe ne peut pas être vide !">*</asp:RequiredFieldValidator>
    <asp:CompareValidator ID="valCompareMotDePasse" runat="server" ErrorMessage="La confirmation de mot de passe n'est pas valide" ControlToCompare="txtMotDePasse" ControlToValidate="txtConfirmationMotDePasse">*</asp:CompareValidator>
    <br />
    <br />
    <br />
    <asp:Button ID="btnOK" runat="server" Text="Ok" OnClick="btnOK_Click" />
    <asp:Button ID="btnAnnuler" runat="server" Text="Annuler" OnClick="btnAnnuler_Click" CausesValidation="False" />
    <br />
    <br />
    <br />
    <asp:ValidationSummary ID="valResumé" runat="server" HeaderText="Veuillez corriger les erreurs suivantes : " />
    </asp:Content>
