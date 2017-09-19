<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionStagiaires.aspx.cs" Inherits="TP2.GestionStagiaires" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h2>Gestion de stagiaires</h2>
        <asp:LinqDataSource ID="dsStagiaires" runat="server" ContextTypeName="TP2.GestionStagesDataContext" EntityTypeName="" Select="new (Id, Nom, Téléphone, Courriel)" TableName="Stagiaires">
        </asp:LinqDataSource>
        <p>
            <asp:Label ID="lblStagiaireSelect" runat="server" Text="Stagiaire selectioné :  "></asp:Label>
            <asp:TextBox ID="txtStagiaireSelect" runat="server" Enabled="False"></asp:TextBox>
            <asp:Button ID="btnModifier" runat="server" Text="Modifier" Enabled="False" OnClick="btnModifier_Click" />
        </p>
        <asp:GridView ID="dgStagiaires" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataKeyNames="Id" DataSourceID="dsStagiaires" OnSelectedIndexChanged="dgStagiaires_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Nom" HeaderText="Nom" ReadOnly="True" SortExpression="Nom" />
                <asp:BoundField DataField="Téléphone" HeaderText="Téléphone" ReadOnly="True" SortExpression="Téléphone" />
                <asp:BoundField DataField="Courriel" HeaderText="Courriel" ReadOnly="True" SortExpression="Courriel" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnAjouter" runat="server" Text="Ajouter" OnClick="btnAjouter_Click" />
        <p>
            <asp:Button ID="btnSuperviseurs" runat="server" Text="Superviseurs" OnClick="btnSuperviseurs_Click" />
            <asp:Button ID="btnStages" runat="server" Text="Stages" OnClick="btnStages_Click" />
        </p>
</asp:Content>
