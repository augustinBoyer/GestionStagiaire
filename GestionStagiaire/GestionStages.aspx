<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionStages.aspx.cs" Inherits="TP2.GestionStages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Gestion de stages</h2>
    <asp:LinqDataSource ID="dsStages" runat="server" ContextTypeName="TP2.GestionStagesDataContext" EntityTypeName="" Select="new (Id, Titre, Début, Fin, Commentaire, SupersiveurId, StagiaireId)" TableName="Stages">
        <WhereParameters>
            <asp:SessionParameter Name="newparameter" SessionField="id" />
        </WhereParameters>
    </asp:LinqDataSource>
        <p>
            <asp:Label ID="lblStageSelect" runat="server" Text="Stage selectioné :  "></asp:Label>
            <asp:TextBox ID="txtStageSelect" runat="server" Enabled="False"></asp:TextBox>
            <asp:Button ID="btnModifier" runat="server" Text="Modifier" Enabled="False" OnClick="btnModifier_Click" />
        </p>
    <asp:GridView ID="gvStages" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataSourceID="dsStages" RowHeaderColumn="Titre" DataKeyNames="Id" OnSelectedIndexChanged="gvStages_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Titre" HeaderText="Titre" ReadOnly="True" SortExpression="Titre" />
            <asp:BoundField DataField="Début" HeaderText="Début" ReadOnly="True" SortExpression="Début" DataFormatString="{0:M/d/yyyy}" />
            <asp:BoundField DataField="Fin" HeaderText="Fin" ReadOnly="True" SortExpression="Fin" DataFormatString="{0:M/d/yyyy}" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblCommentaire" runat="server" Text="Commentaire"></asp:Label>
    <br />
    <asp:TextBox ID="txtCommentaire" runat="server" Height="86px" ReadOnly="True" TextMode="MultiLine" Width="340px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblStage" runat="server"></asp:Label>
    <asp:Button ID="btnAjouter" runat="server" Text="Ajouter Stage" OnClick="btnAjouter_Click" />
        <p>
            <asp:Button ID="btnStagiaires" runat="server" Text="Stagiaires" OnClick="btnStagiaires_Click" />
        </p>
</asp:Content>

