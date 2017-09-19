using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP2
{
    public partial class Stage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(this.Session[_Default.SESSION_UTILISATEUR] is Superviseur))
            {
                this.Response.Redirect("~/Default.aspx");
                return;
            }

            if (this.bd == null)
            {
                this.bd = new BDGestionStages();
            }

            if (!IsPostBack)
            {
                this.dtpCalendrier.SelectedDate = DateTime.Today;

                if (this.Session[_Default.SESSION_STAGE] != null) //on vérifie s'il s'agit d'une modification
                {
                    Stage tempStage = (Stage)this.Session[_Default.SESSION_STAGE];

                    this.txtTitre.Text = tempStage.Titre;
                    this.txtCommentaires.Text = tempStage.Commentaire;
                    this.txtDateDebut.Text = tempStage.Début.ToShortDateString();
                    this.txtDateFin.Text = tempStage.Fin.ToShortDateString();

                    Stagiaire tempStagiaire = bd.GetStagiaire(tempStage.StagiaireId);
                    this.Session[_Default.SESSION_PERSONNE] = tempStagiaire;
                    this.txtStagiaire.Text = tempStagiaire.Nom;

                    this.valCompareDates.MinimumValue = tempStage.Début.ToShortDateString();
                }
                else
                {
                    this.valCompareDates.MinimumValue = this.dtpCalendrier.SelectedDate.ToShortDateString();
                }
                this.valCompareDates.MaximumValue = DateTime.MaxValue.ToShortDateString();
                
            }
        }
        protected void Modifier()
        {
            this.monStage.Titre = this.txtTitre.Text;
            this.monStage.Commentaire = this.txtCommentaires.Text;
            this.monStage.Début = Convert.ToDateTime(this.txtDateDebut.Text);
            this.monStage.Fin = Convert.ToDateTime(this.txtDateFin.Text);
            this.monStage.SupersiveurId = ((Superviseur)this.Session[_Default.SESSION_UTILISATEUR]).Id;
            this.monStage.StagiaireId = ((Stagiaire)this.Session[_Default.SESSION_PERSONNE]).Id;
        }

        protected void btnDateDebut_Click(object sender, EventArgs e)
        {
            if (dtpCalendrier.SelectedDate !=null)
            {
                this.txtDateDebut.Text = this.dtpCalendrier.SelectedDate.ToShortDateString();

                this.valCompareDates.MinimumValue = this.dtpCalendrier.SelectedDate.ToShortDateString();
            }
        }

        protected void btnFin_Click(object sender, EventArgs e)
        {
            if (dtpCalendrier.SelectedDate != null)
            {
                this.txtDateFin.Text = dtpCalendrier.SelectedDate.ToShortDateString();
            }
        }

        protected void gvStagiaires_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)this.gvStagiaires.SelectedDataKey.Value;
            Stagiaire tempStagiaire = bd.GetStagiaire(id);
            this.txtStagiaire.Text = tempStagiaire.Nom;
            this.Session[_Default.SESSION_PERSONNE] = tempStagiaire;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                if (this.Session[_Default.SESSION_STAGE]!=null)//Si C'est une modification
                {
                    this.monStage = bd.GetStage(((Stage)this.Session[_Default.SESSION_STAGE]).Id);
                    this.Modifier();

                    bd.Sauvegarder();
                    this.Response.Redirect("~/GestionStages.aspx");
                    return;
                }
                else
                {
                    this.monStage = new Stage();
                    this.Modifier();

                    bd.Ajouter(this.monStage, ((Superviseur)this.Session[_Default.SESSION_UTILISATEUR]).Id, ((Stagiaire)this.Session[_Default.SESSION_PERSONNE]).Id);
                    bd.Sauvegarder();
                    this.Response.Redirect("~/GestionStages.aspx");
                    return;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/GestionStages.aspx");
            return;
        }

        BDGestionStages bd;
        Stage monStage;
    }
}