using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP2
{
    public partial class _Default : System.Web.UI.Page
    {
        public static string SESSION_UTILISATEUR = "utilisateur";
        public static string SESSION_PERSONNE = "personne";
        public static string SESSION_STAGE = "stage";
        public static string SESSION_ISNEW = "isNew";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            string erreur = "* login ou mot de passe pas corrects";

            if (this.txtUser.Text == "")
            {
                this.lblErreur.Text = erreur;
            }
            else
            {
                bd = new BDGestionStages();

                Superviseur sup = bd.GetSuperviseur(this.txtUser.Text);
                Stagiaire sta = bd.GetStagiaire(this.txtUser.Text);
                Administrateur adm = bd.GetAdministrateur();

                if (adm.NomUtilisateur == txtUser.Text)
                {
                    if (adm.MotDePasse == txtPassword.Text)
                    {
                        this.Session[SESSION_UTILISATEUR] = adm;

                        this.Response.Redirect("~/GestionSuperviseurs.aspx");
                        return;
                    }
                    else
                    {
                        this.lblErreur.Text = "L'accès n'est pas accordé";
                        this.lblErreur.Text = erreur;
                    }
                }
                else if (sup != null)
                {
                    if (sup.MotDePasse == txtPassword.Text)
                    {
                        this.Session[SESSION_UTILISATEUR] = sup;

                        this.Response.Redirect("~/GestionStagiaires.aspx");
                        return;
                    }
                    else
                    {
                        this.lblErreur.Text = erreur;
                    }
                }
                else if (sta != null)
                {
                    if (sta.MotDePasse == txtPassword.Text)
                    {
                        this.Session[SESSION_UTILISATEUR] = sta;

                        this.Response.Redirect("~/GestionStages.aspx");
                        return;
                    }
                    else
                    {
                        this.lblErreur.Text = erreur;
                    }
                }
                else
                {
                    this.lblErreur.Text = erreur;
                }
            }
        }

            
        BDGestionStages bd;
    }
}
