using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP2
{
    public partial class Personne : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!((this.Session[_Default.SESSION_UTILISATEUR] is Administrateur) || (this.Session[_Default.SESSION_UTILISATEUR] is Superviseur)))
            {
                this.Response.Redirect("~/Default.aspx");
                return;
            }

            if (!this.IsPostBack)
            {

                if (this.Session[_Default.SESSION_PERSONNE] is Superviseur)
                {
                    if (this.Session[_Default.SESSION_ISNEW]==null)
                    {

                        Superviseur supMod = (Superviseur)this.Session[_Default.SESSION_PERSONNE];

                        this.txtCourriel.Text = supMod.Courriel;
                        this.txtNom.Text = supMod.Nom;
                        this.txtTelephone.Text = supMod.Téléphone;
                        this.txtLogin.Text = supMod.NomUtilisateur;

                        this.btnModMotDePasse.Visible = true;
                        this.lblMotDePasse.Visible = false;
                        this.lblConfirmationMotDePasse.Visible = false;
                        this.txtMotDePasse.Visible = false;
                        this.txtConfirmationMotDePasse.Visible = false;
                        this.valMotDePasse.Enabled = false;
                        this.valConfirmationMotDePasse.Enabled = false;
                        this.valCompareMotDePasse.Enabled = false;
                    }
                }
                else if (this.Session[_Default.SESSION_PERSONNE] is Stagiaire)
                {
                    if (this.Session[_Default.SESSION_ISNEW]==null)
                    {
                        Stagiaire staMod = (Stagiaire)this.Session[_Default.SESSION_PERSONNE];

                        this.txtCourriel.Text = staMod.Courriel;
                        this.txtNom.Text = staMod.Nom;
                        this.txtTelephone.Text = staMod.Téléphone;
                        this.txtLogin.Text = staMod.NomUtilisateur;
                        this.txtMotDePasse.Text = staMod.MotDePasse;
                        this.txtConfirmationMotDePasse.Text = staMod.MotDePasse;

                        this.btnModMotDePasse.Visible = true;
                        this.lblMotDePasse.Visible = false;
                        this.lblConfirmationMotDePasse.Visible = false;
                        this.txtMotDePasse.Visible = false;
                        this.txtConfirmationMotDePasse.Visible = false;
                        this.valMotDePasse.Enabled = false;
                        this.valConfirmationMotDePasse.Enabled = false;
                        this.valCompareMotDePasse.Enabled = false;
                    }
                }
                else
                {
                    this.Response.Redirect("~/Default.aspx");//Si l'usager n'a pas de stagiaire, ni superviseur, ni une indication pour créer un nouveau stagiaire ou superviseur ça veut dire donc qu'il n'a pas le droit d'être là
                    return;
                }
            }
            if (this.bd == null)
            {
                this.bd = new BDGestionStages();
            }
        }
        private void Modifier()
        {
            if (this.Session[_Default.SESSION_PERSONNE] is Superviseur)
            {
                this.sup.Courriel = this.txtCourriel.Text;
                this.sup.Nom = this.txtNom.Text;
                this.sup.Téléphone = this.txtTelephone.Text;
                this.sup.NomUtilisateur = this.txtLogin.Text;
                if (this.txtMotDePasse.Visible)
                {
                    this.sup.MotDePasse = this.txtMotDePasse.Text;
                }
                else
                {
                    this.sup.MotDePasse = ((Superviseur)this.Session[_Default.SESSION_PERSONNE]).MotDePasse;
                }

            }
            else
            {
                this.sta.Courriel = this.txtCourriel.Text;
                this.sta.Nom = this.txtNom.Text;
                this.sta.Téléphone = this.txtTelephone.Text;
                this.sta.NomUtilisateur = this.txtLogin.Text;

                if (this.txtMotDePasse.Visible)
                {
                    this.sta.MotDePasse = this.txtMotDePasse.Text;
                }
                else
                {
                    this.sta.MotDePasse = ((Stagiaire)this.Session[_Default.SESSION_PERSONNE]).MotDePasse;
                }
            }
        }

        protected void valUserExists_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool exists = false;
            int idTemp;

            Administrateur admTemp = bd.GetAdministrateur();
            Superviseur supTemp = bd.GetSuperviseur(args.Value);
            Stagiaire staTemp = bd.GetStagiaire(args.Value);

            if (this.Session[_Default.SESSION_ISNEW]!=null)
            {
                exists = ((admTemp.NomUtilisateur==args.Value) || (supTemp!=null) || (staTemp!=null));
            }
            else
            {
                if(this.Session[_Default.SESSION_PERSONNE] is Superviseur)
                {
                    idTemp = ((Superviseur)this.Session[_Default.SESSION_PERSONNE]).Id;
                }
                else
                {
                    idTemp = ((Stagiaire)this.Session[_Default.SESSION_PERSONNE]).Id;
                }

                if (admTemp.NomUtilisateur==args.Value)
                {
                    exists = true;
                }
                else if(supTemp!=null)
                {
                    exists = supTemp.Id != idTemp;
                }
                else if(staTemp!=null)
                {
                    exists = staTemp.Id != idTemp;
                }
            }
            args.IsValid = !exists; //Si le login existe la validation ne passe pas
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            bd = new BDGestionStages();
            if (this.IsValid)
            {
                if (this.Session[_Default.SESSION_ISNEW]!=null)
                {
                    if (this.Session[_Default.SESSION_PERSONNE] is Superviseur)
                    {
                        this.sup = new Superviseur();
                        this.Modifier();
                        bd.Ajouter(sup);

                        bd.Sauvegarder();
                        this.Response.Redirect("~/GestionSuperviseurs.aspx");
                        return;
                    }
                    else
                    {
                        this.sta = new Stagiaire();
                        this.Modifier();
                        bd.Ajouter(sta);

                        bd.Sauvegarder();
                        this.Response.Redirect("~/GestionStagiaire.aspx");
                        return;
                    }
                }
                else
                {
                    if(this.Session[_Default.SESSION_PERSONNE] is Superviseur)
                    {
                        this.sup = this.bd.GetSuperviseur(((Superviseur)this.Session[_Default.SESSION_PERSONNE]).Id);
                        Modifier();

                        bd.Sauvegarder();
                        this.Response.Redirect("~/GestionSuperviseurs.aspx");
                        return;
                    }
                    else
                    {
                        this.sta = this.bd.GetStagiaire(((Stagiaire)this.Session[_Default.SESSION_PERSONNE]).Id);
                        Modifier();

                        bd.Sauvegarder();
                        this.Response.Redirect("~/GestionStagiaires.aspx");
                        return;
                    }
                }
            }

        }


        protected void btnAnnuler_Click(object sender, EventArgs e)
        {
            if (this.Session[_Default.SESSION_PERSONNE] is Superviseur)
            {
                this.Response.Redirect("~/GestionSuperviseurs.aspx");
                return;
            }
            else
            {
                this.Response.Redirect("~/GestionStagiaires.aspx");
                return;
            }
        }

        private BDGestionStages bd;
        private Superviseur sup;
        private Stagiaire sta;

        protected void btnModMotDePasse_Click(object sender, EventArgs e)
        {
            this.txtMotDePasse.Text = "";
            this.txtConfirmationMotDePasse.Text = "";

            this.lblMotDePasse.Visible = true;
            this.lblConfirmationMotDePasse.Visible = true;
            this.txtMotDePasse.Visible = true;
            this.txtConfirmationMotDePasse.Visible = true;
            this.valMotDePasse.Enabled = true;
            this.valConfirmationMotDePasse.Enabled = true;
            this.valCompareMotDePasse.Enabled = true;
        }
    }
}