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
        
        private void déconnexionToolStripMenuItem_Click(object sender, EventArgs e) {
            Globale.nomVisiteur = "";
            Passerelle.seDeConnecter();
            Globale.formulaireConnexion.Show();
            Close();
        }

        // ajout d'un rendez-vous
        private void programmerRendezVous_Click(object sender, EventArgs e) {
            FrmVisiteAjout unFrmSaisieVisite = new FrmVisiteAjout();
            unFrmSaisieVisite.Show();
            Close();
        }

        // déplacer un rendez vous (changement de date et heure)
        private void modifierRendezVous_Click(object sender, EventArgs e) {


           
        }

        // imprimer les rendez-vous sur une période donnée
        private void imprimerRendezvous_Click(object sender, EventArgs e) {


            
        }

        // clôturer une visite en enregistrant le bilan, les médicaments présentés et les échantillons fournis
        private void enregistrerBilan_Click(object sender, EventArgs e) {

            
        }

        // consulter l'ensemble des visites réalisées
        private void consulterVisite_Click(object sender, EventArgs e) {
         
        }

        // consultation des médicaments
        private void ficheMédicamentToolStripMenuItem_Click(object sender, EventArgs e) {



        }

        // consulter l'ensemble des échantillons distribués par le visiteur connecté
        private void voirEchantillon_Click(object sender, EventArgs e) {


            
        }

        // consulter la liste des praticiens gérés par le visiteur
        private void listePraticien_Click(object sender, EventArgs e) {
            FrmPraticienListe unFrmPraticien = new FrmPraticienListe();
            unFrmPraticien.Show();
            Close();


        }

        // ajouter un nouveau praticien
        private void nouveauPraticien_Click(object sender, EventArgs e) {

         

        }

        // Modifier les coordonnées d'un praticien
        private void modifierPraticien_Click(object sender, EventArgs e) {


           
        }

        #endregion

        #region procédure

        private void parametrerComposant() {

            Text = "Laboratoire pharmaceutique Galaxy-Swiss Bourdin - Gestion des visites";
            lblVisiteur.Text =  Globale.nomVisiteur;
            ControlBox = true;
            MaximizeBox = true;
            MinimizeBox = true;
            WindowState = FormWindowState.Maximized;

            // il faut éventuellement désactiver certaines options du menu selon les données 
            // on ne peut pas déplacer un rendez-vous si le visiteur n'a aucun rendez vous 
            // on ne peut pas cloturer une visite si le visiteur n'a aucune visite à clôturer (tous les bilans sont déja renseignés
            // on ne peut pas visualiser toutes les visites s'il n'en existe aucune


        }

        #endregion


    }
}
