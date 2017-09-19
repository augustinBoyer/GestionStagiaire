using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP2
{
    public partial class GestionSuperviseurs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Session[_Default.SESSION_PERSONNE] = null; //on ne veut pas garder la personne à modifier toujours dans la session
            this.Session[_Default.SESSION_ISNEW] = null; //on ne veut pas garder cela dans la session non plus

            if (!(this.Session[_Default.SESSION_UTILISATEUR] is Administrateur))
            {
                this.Response.Redirect("~/Default.aspx");
                return;
            }

            if (this.bd == null)
            {
                this.bd = new BDGestionStages();
            }
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            this.Session[_Default.SESSION_PERSONNE] = new Superviseur();
            this.Session[_Default.SESSION_ISNEW] = true;

            this.Response.Redirect("~/Personne.aspx");
            return;
        }

        protected void btnModifier_Click(object sender, EventArgs e)
        {
            int idTemp = (int)this.dgSuperviseur.SelectedDataKey.Value;
            this.Session[_Default.SESSION_PERSONNE] = bd.GetSuperviseur(idTemp);

            this.Response.Redirect("~/Personne.aspx");
            return;
        }


        protected void Stagiaires_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/GestionStagiaires.aspx");
            return;
        }

        protected void dgSuperviseur_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtSuperviseurSelect.Text = this.bd.GetSuperviseur(Convert.ToInt16(this.dgSuperviseur.SelectedDataKey.Value)).Nom;

            if (this.dgSuperviseur.SelectedDataKey != null)
            {
                this.btnModifier.Enabled = true;
            }
            else
            {
                this.btnModifier.Enabled = false;
            }
        }


        private BDGestionStages bd;
    }


}