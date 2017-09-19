<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MotDePasse.aspx.cs" Inherits="TP2.MotDePasse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Text="Ancien mot de passe :" Width="180px"></asp:Label>
    <asp:TextBox ID="txtAncienMot" TextMode="Password" runat="server"></asp:TextBox>
        <asp:CustomValidator ID="valAncien" runat="server" ErrorMessage="L'ancien mot de passe a été mal saisi !">*</asp:CustomValidator>
        <br />
        <br />
    </div>


    <div>

        <asp:Label ID="Label2" runat="server" Text="Nouveau mot de passe :" Width="180px"></asp:Label>

        <asp:TextBox ID="txtNouveau" TextMode="Password" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator ID="valNouveau" runat="server" ControlToValidate="txtNouveau" ErrorMessage="Le mot de passe ne peut pas être vide !">*</asp:RequiredFieldValidator>

        <br />

        <br />

    </div>

    <div>
        <asp:Label ID="Label3" runat="server" Text="Confirmer le mot de passe :" Width="180px"></asp:Label>
        <asp:TextBox ID="txtConfirmer" TextMode="Password" runat="server"></asp:TextBox>
        <asp:CompareValidator ID="valConfirmer" runat="server" ControlToCompare="txtNouveau" ControlToValidate="txtConfirmer" ErrorMessage="Les deux noueaux mots de passe doivent être équivalents !">*</asp:CompareValidator>
        <br />
    </div>
    <div>

        <asp:Button ID="btnOk" runat="server" Text="Confirmer" OnClick="btnOk_Click" />
        <asp:Button ID="btnAnnuler" runat="server" Text="Annuler" CausesValidation="False" OnClick="btnAnnuler_Click" />

        <br />
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

    </div>
</asp:Content>
