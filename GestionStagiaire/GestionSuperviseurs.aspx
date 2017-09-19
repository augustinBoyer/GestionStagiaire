<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionSuperviseurs.aspx.cs" Inherits="TP2.GestionSuperviseurs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Gestion de superviseurs</h2>
    <p>
        <asp:LinqDataSource ID="dsSuperviseurs" runat="server" ContextTypeName="TP2.GestionStagesDataContext" EntityTypeName="" Select="new (Nom, Téléphone, Courriel, Id)" TableName="Superviseurs" EnableInsert="True" EnableUpdate="True">
        </asp:LinqDataSource>
    <p>
        <asp:Label ID="lblSuperviseurSelect" runat="server" Text="Superviseur selectioné :  "></asp:Label>
        <asp:TextBox ID="txtSuperviseurSelect" runat="server" Enabled="False"></asp:TextBox>
        <asp:Button ID="btnModifier" runat="server" Text="Modifier" OnClick="btnModifier_Click" Enabled="False" />
    </p>
        <asp:GridView ID="dgSuperviseur" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="dsSuperviseurs" Width="257px" OnSelectedIndexChanged="dgSuperviseur_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Nom" HeaderText="Nom" ReadOnly="True" SortExpression="Nom" />
                <asp:BoundField DataField="Téléphone" HeaderText="Téléphone" ReadOnly="True" SortExpression="Téléphone" />
                <asp:BoundField DataField="Courriel" HeaderText="Courriel" ReadOnly="True" SortExpression="Courriel" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnAjouter" runat="server" OnClick="btnAjouter_Click" Text="Ajouter" />
    <p>
        <asp:Button ID="Stagiaires" runat="server" Text="Stagiaire" OnClick="Stagiaires_Click" />
    </p>
    </asp:Content>
