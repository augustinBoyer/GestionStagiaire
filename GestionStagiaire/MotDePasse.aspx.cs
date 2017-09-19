using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP2
{
    public partial class MotDePasse : System.Web.UI.Page
    {
        protected void Comparer(string p_Mdp)
        {
            if (p_Mdp != this.txtAncienMot.Text)
            {
                this.valAncien.IsValid = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session[_Default.SESSION_UTILISATEUR] == null)
            {
                this.Response.Redirect("~/Default.aspx");
                return;
            }

            if (!this.IsPostBack)
            {
                Site s = (Site)Master;

                s.disableDisconnect();
                s.disableMotDePasse();
            }

            if (this.bd == null)
            {
                this.bd = new BDGestionStages();
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (this.Session[_Default.SESSION_UTILISATEUR] is Administrateur)
            {
                Administrateur isAdmin = this.bd.GetAdministrateur();

                Comparer(isAdmin.MotDePasse);

                if (this.IsValid)
                {
                    isAdmin.MotDePasse = this.txtNouveau.Text;

                    this.bd.Sauvegarder();

                    this.Response.Redirect("~/GestionSuperviseurs.aspx");
                    return;
                }
            }
            else if (this.Session[_Default.SESSION_UTILISATEUR] is Superviseur)
            {
                Superviseur isSup = this.bd.GetSuperviseur(((Superviseur)this.Session[_Default.SESSION_UTILISATEUR]).Id); ;

                Comparer(isSup.MotDePasse);

                if (this.IsValid)
                {
                    isSup.MotDePasse = this.txtNouveau.Text;

                    this.bd.Sauvegarder();

                    this.Response.Redirect("~/GestionStagiaires.aspx");
                    return;
                }
            }
            else
            {
                Stagiaire isSta = this.bd.GetStagiaire(((Stagiaire)this.Session[_Default.SESSION_UTILISATEUR]).Id); ;

                Comparer(isSta.MotDePasse);

                if (this.IsValid)
                {
                    isSta.MotDePasse = this.txtNouveau.Text;

                    this.bd.Sauvegarder();

                    this.Response.Redirect("~/GestionStages.aspx");
                    return;
                }

            }
        }

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {

            if (this.Session[_Default.SESSION_UTILISATEUR] is Administrateur)
            {
                this.Response.Redirect("~/GestionSuperviseurs.aspx");
                return;
            }

            else if (this.Session[_Default.SESSION_UTILISATEUR] is Superviseur)
            {
                this.Response.Redirect("~/GestionStagiaires.aspx");
                return;
            }
            else
            {
                this.Response.Redirect("~/GestionStages.aspx");
                return;
            }
            
        }
        BDGestionStages bd;
    }

    
}