using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP2
{
    public partial class Site : System.Web.UI.MasterPage
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session[_Default.SESSION_UTILISATEUR] is Administrateur)
            {
                Administrateur admin = (Administrateur)this.Session[_Default.SESSION_UTILISATEUR];
                this.lblNom.Text = "Bonjour " + admin.NomUtilisateur;
            }
            else if(this.Session[_Default.SESSION_UTILISATEUR] is Superviseur)
            {
                Superviseur sup = (Superviseur)this.Session[_Default.SESSION_UTILISATEUR];
                this.lblNom.Text = "Bonjour " + sup.NomUtilisateur;
            }
            else
            {
                Stagiaire sta = (Stagiaire)this.Session[_Default.SESSION_UTILISATEUR];
                this.lblNom.Text = "Bonjour " + sta.NomUtilisateur;
            }
            
        }

        protected void btnDeconnexion_Click(object sender, EventArgs e)
        {


            this.Session[_Default.SESSION_UTILISATEUR] = null;
            this.Session[_Default.SESSION_PERSONNE] = null;

            this.Response.Redirect("~/Default.aspx");
            return;
        }

        protected void lkbDeconnexion_Click(object sender, EventArgs e)
        {
            this.Session[_Default.SESSION_UTILISATEUR] = null; 
            this.Session[_Default.SESSION_PERSONNE] = null;

            this.Response.Redirect("~/Default.aspx");
        }

        protected void lkbMotDePasse_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/MotDePasse.aspx");
        }

        public void disableDisconnect()
        {
            this.lkbDeconnexion.Visible = false;
        }

        public void disableMotDePasse()
        {
            this.lkbMotDePasse.Visible = false;
        }
    }
}