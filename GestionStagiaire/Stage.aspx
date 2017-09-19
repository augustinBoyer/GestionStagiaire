<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Stage.aspx.cs" Inherits="TP2.Stage1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function validerDate(source, args)
        {
            if (args.SelectedDate == null)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <p>
            <asp:Label ID="lblTitre" runat="server" Text="Titre : "></asp:Label><asp:TextBox ID="txtTitre" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valTitre" runat="server" ControlToValidate="txtTitre" ErrorMessage="Le titre ne peut pas être vide">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="lblCommentaire" runat="server" Text="Commentaires : "></asp:Label></p>
        <p>&nbsp;<asp:TextBox ID="txtCommentaires" runat="server" Height="117px" TextMode="MultiLine" Width="263px"></asp:TextBox></p>        
        <p>
            <asp:Label ID="lblDateDebut" runat="server" Text="Date de début : "></asp:Label>
            <asp:TextBox ID="txtDateDebut" runat="server" Enabled="False"></asp:TextBox>
&nbsp;<asp:Button ID="btnDateDebut" runat="server" Text="Insérer date" OnClick="btnDateDebut_Click" CausesValidation="False" />
            <asp:RequiredFieldValidator ID="valDateDebut" runat="server" ErrorMessage="La date de début ne peut pas être vide" ControlToValidate="txtDateDebut">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="lblDateFin" runat="server" Text="Date de fin : "></asp:Label>
            <asp:TextBox ID="txtDateFin" runat="server" Enabled="False"></asp:TextBox>
            &nbsp;<asp:Button ID="btnFin" runat="server" Text="Insérer date" OnClick="btnFin_Click" CausesValidation="False" />
            <asp:RequiredFieldValidator ID="valDateFin" runat="server" ErrorMessage="La date de fin ne peut pas être vide" ControlToValidate="txtDateFin">*</asp:RequiredFieldValidator>
            <asp:RangeValidator ID="valCompareDates" runat="server" ControlToValidate="txtDateFin" ErrorMessage="La date de fin doit être plus grande ou égale à la date de début" Type="Date">*</asp:RangeValidator>
        </p>
        <p><asp:Calendar ID="dtpCalendrier" runat="server"></asp:Calendar></p>
        <p>
            <asp:Label ID="lblStagiaire" runat="server" Text="Stagiaire : "></asp:Label>
            <asp:TextBox ID="txtStagiaire" runat="server" Enabled="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valStagiaire" runat="server" ControlToValidate="txtStagiaire" ErrorMessage="Il faut choisir un stagiaire">*</asp:RequiredFieldValidator>
        </p>
        <asp:LinqDataSource ID="dsStagiaires" runat="server" ContextTypeName="TP2.GestionStagesDataContext" EntityTypeName="" Select="new (Id, Nom, Téléphone, Courriel)" TableName="Stagiaires"></asp:LinqDataSource>
        <asp:GridView ID="gvStagiaires" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="dsStagiaires" OnSelectedIndexChanged="gvStagiaires_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Nom" HeaderText="Nom" ReadOnly="True" SortExpression="Nom" />
                <asp:BoundField DataField="Téléphone" HeaderText="Téléphone" ReadOnly="True" SortExpression="Téléphone" />
                <asp:BoundField DataField="Courriel" HeaderText="Courriel" ReadOnly="True" SortExpression="Courriel" />
            </Columns>
        </asp:GridView>
        <p><asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_Click" /><asp:Button ID="btnCancel" runat="server" Text="Annuler" CausesValidation="False" OnClick="btnCancel_Click" /></p>
        
        
        <asp:ValidationSummary ID="valResume" runat="server" HeaderText="Veuillez corriger les erreurs suivantes :" />
    </div>
</asp:Content>
