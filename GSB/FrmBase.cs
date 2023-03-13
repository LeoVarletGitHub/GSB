// ------------------------------------------
// Nom du fichier : FrmBase.cs
// Objet : Formulaire de base hérité par tous les formulaires
//         afin de posséder la même ergonomie
// Auteur : 
// Date   : 
// ------------------------------------------

using System;
using System.Drawing;
using System.Windows.Forms;

namespace GSB {
    public partial class FrmBase : Form {
        private int fermeture = 0;


        public FrmBase() {
            InitializeComponent();
        }

        #region procédures événementielles
        // paramétrer les composants du formulaire au chargement
        private void FrmBase_Load(object sender, EventArgs e) {
            if (DesignMode) return;
            parametrerComposant();
        }


        // sur la fermeture du formulaire,
        // Si le visiteur a essayé de fermer la fenêtre par la croix ou encore par alt F4
        // on annule la demande pour obliger le visiteur à se déconnecter pour quitter ce formulaire 

        private void FrmBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4) e.Handled = true;
        }

        private void déconnexionToolStripMenuItem_Click(object sender, EventArgs e) {
            Globale.nomVisiteur = "";
            Passerelle.seDeConnecter();
            Globale.formulaireConnexion.Show();
            fermeture = 1;
            Close();
        }

        // ajout d'un rendez-vous
        private void programmerRendezVous_Click(object sender, EventArgs e) {
            FrmVisiteAjout unFrmSaisieVisite = new FrmVisiteAjout();
            unFrmSaisieVisite.Show();
            fermeture = 1;
            Close();
        }

        // déplacer un rendez vous (changement de date et heure)
        private void modifierRendezVous_Click(object sender, EventArgs e) {
            FrmMoveDelVisite unFrmMoveDelVisite = new FrmMoveDelVisite();
            unFrmMoveDelVisite.Show();
            fermeture = 1;
            Close();
        }

        // imprimer les rendez-vous sur une période donnée
        private void imprimerRendezvous_Click(object sender, EventArgs e) {
            FrmImpression unFrmImpression = new FrmImpression();
            unFrmImpression.Show();
            fermeture = 1;
            Close();


        }

        // clôturer une visite en enregistrant le bilan, les médicaments présentés et les échantillons fournis
        private void enregistrerBilan_Click(object sender, EventArgs e) {
            FrmBilan unFrmBilan = new FrmBilan();
            unFrmBilan.Show();
            fermeture = 1;
            Close();

        }

        // consulter l'ensemble des visites réalisées
        private void consulterVisite_Click(object sender, EventArgs e) {
            FrmConsul unFrmConsul = new FrmConsul();
            unFrmConsul.Show();
            fermeture = 1;
            Close();
        }

        // consultation des médicaments
        private void ficheMédicamentToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmMedicament unFrmMedicament = new FrmMedicament();
            unFrmMedicament.Show();
            fermeture = 1;
            Close();


        }

        // consulter la liste des praticiens gérés par le visiteur
        private void listePraticien_Click(object sender, EventArgs e) {
            FrmPraticienListe unFrmPraticien = new FrmPraticienListe();
            unFrmPraticien.Show();
            fermeture = 1;
            Close();


        }

        // ajouter un nouveau praticien
        private void nouveauPraticien_Click(object sender, EventArgs e) {
            FrmPraticienAjout unFrmPraticienAjout = new FrmPraticienAjout();
            unFrmPraticienAjout.Show();
            fermeture = 1;
            Close();


        }

        // Modifier les coordonnées d'un praticien
        private void modifierPraticien_Click(object sender, EventArgs e) {
            FrmModifPraticien unFrmModifPraticien = new FrmModifPraticien();
            unFrmModifPraticien.Show();
            fermeture = 1;
            Close();
        }

        #endregion

        #region procédure

        private void parametrerComposant() {

            Text = "Laboratoire pharmaceutique Galaxy-Swiss Bourdin - Gestion des visites";
            lblVisiteur.Text =  Globale.nomVisiteur;
            ControlBox = false;
            MaximizeBox = true;
            MinimizeBox = true;
            WindowState = FormWindowState.Maximized;
            KeyPreview = true;
            ShowInTaskbar = false;
            // il faut éventuellement désactiver certaines options du menu selon les données 
            // on ne peut pas déplacer un rendez-vous si le visiteur n'a aucun rendez vous 
            // on ne peut pas cloturer une visite si le visiteur n'a aucune visite à clôturer (tous les bilans sont déja renseignés
            // on ne peut pas visualiser toutes les visites s'il n'en existe aucune


        }




        #endregion

        private void FrmBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(fermeture == 0)
            {
                e.Cancel = true;
            }
        }
    }
}
