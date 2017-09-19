using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP2
{
    public partial class GestionStagiaires : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Session[_Default.SESSION_PERSONNE] = null; //on ne veut pas garder la personne à modifier toujours dans la session
            this.Session[_Default.SESSION_ISNEW] = null; //on ne veut pas garder cela dans la session non plus

            if (this.Session[_Default.SESSION_UTILISATEUR] is Administrateur)
            {
                this.btnStages.Visible = false;
            }
            else if(this.Session[_Default.SESSION_UTILISATEUR] is Superviseur) 
            {
                this.btnSuperviseurs.Visible = false;
                this.btnAjouter.Visible = false;
                this.btnModifier.Visible = false;
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
        }

        protected void dgStagiaires_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtStagiaireSelect.Text = this.bd.GetStagiaire(Convert.ToInt16(this.dgStagiaires.SelectedDataKey.Value)).Nom;

            if (this.dgStagiaires.SelectedDataKey != null)
            {
                this.btnModifier.Enabled = true;
            }
            else
            {
                this.btnModifier.Enabled = false;
            }
        }

        protected void btnSuperviseurs_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/GestionSuperviseurs.aspx");
            return;
        }

        protected void btnStages_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/GestionStages.aspx");
            return;
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            this.Session[_Default.SESSION_PERSONNE] = new Stagiaire();
            this.Session[_Default.SESSION_ISNEW] = true;

            this.Response.Redirect("~/Personne.aspx");
            return;
        }

        protected void btnModifier_Click(object sender, EventArgs e)
        {
            int idTemp = (int)this.dgStagiaires.SelectedDataKey.Value;
            this.Session[_Default.SESSION_PERSONNE] = bd.GetStagiaire(idTemp);

            this.Response.Redirect("~/Personne.aspx");
            return;
        }
        private BDGestionStages bd;


    }
}