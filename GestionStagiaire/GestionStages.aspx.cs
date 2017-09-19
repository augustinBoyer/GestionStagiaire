using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP2
{
    public partial class GestionStages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Session[_Default.SESSION_PERSONNE] = null; //on ne veut pas garder la personne à modifier toujours dans la session
            this.Session[_Default.SESSION_ISNEW] = null; //on ne veut pas garder cela dans la session non plus
            this.Session[_Default.SESSION_STAGE] = null; //on ne veut pas garder cela dans la session non plus

            if (this.Session[_Default.SESSION_UTILISATEUR] is Superviseur)
            {
                Superviseur sup = (Superviseur)this.Session[_Default.SESSION_UTILISATEUR];
                this.dsStages.Where = "SupersiveurId =="+sup.Id.ToString();   
            }
            else if (this.Session[_Default.SESSION_UTILISATEUR] is Stagiaire)
            {
                Stagiaire sta = (Stagiaire)this.Session[_Default.SESSION_UTILISATEUR];
                this.dsStages.Where = "StagiaireId==" + sta.Id.ToString();

                this.btnStagiaires.Visible = false;
                this.btnAjouter.Visible = false;
                this.btnModifier.Visible = false;
                this.txtStageSelect.Visible = false;
            }
            else
            {
                this.Response.Redirect("~/Default.aspx");
                return;
            }

            if (this.bd == null)
            {
                this.bd = new BDGestionStages();
            }

            if(this.gvStages.Rows.Count==0)
            {
                this.lblStage.Text = "Vous n'avez aucun stage présentement<br />";
            }
        }

        protected void gvStages_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stage st = this.bd.GetStage(Convert.ToInt16(this.gvStages.SelectedDataKey.Value));

            this.txtStageSelect.Text = st.Titre;
            this.txtStageSelect.Text = st.Commentaire;


            if (this.gvStages.SelectedDataKey != null)
            {
                this.btnModifier.Enabled = true;
            }
            else
            {
                this.btnModifier.Enabled = false;
            }
        }

        protected void btnStagiaires_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/GestionStagiaires.aspx");
            return;
        }

        protected void btnModifier_Click(object sender, EventArgs e)
        {
            this.Session[_Default.SESSION_STAGE] = this.bd.GetStage((int)this.gvStages.SelectedDataKey.Value);
            this.Response.Redirect("~/Stage.aspx");
            return;
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Stage.aspx");
            return;
        }

        private BDGestionStages bd;
    }
}