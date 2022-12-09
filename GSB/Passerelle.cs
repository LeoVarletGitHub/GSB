// ------------------------------------------
// Nom du fichier : Passerelle.cs
// Objet : classe Passerelle assurant l'alimentation des objets en mémoire
// Auteur :
// Date  : 
// ------------------------------------------

using System;
using System.Data;   // pour ParameterDirection
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using lesClasses;

namespace GSB
{
    static class Passerelle
    {

        private static MySqlConnection cnx;

        // Vérifier les paramètres de connexion et alimente l'objet globale leVisiteur
        static public bool seConnecter(string login, string mdp, out string message) {

            string chaineConnexion = $"Data Source=localhost;Database=gsb; User Id={login}; Password={mdp}";
            cnx = new MySqlConnection(chaineConnexion);
            bool ok = true;
            message = null;

            try {
                // etablit une connexion saut si une connexion existe déjà 
                cnx.Open();

            } catch (MySqlException e) {
                ok = false;
                if (e.Message.Contains("Accès refusé")) {
                    message = "Vos identifiants sont incorrects.";
                } else {
                    message = "Problème lors de la tentative de connexion au serveur.\n";
                    message += "Prière de contacter le service informatique";
                }
            } catch (Exception e) {
                message = e.ToString();
                ok = false;
            }

            if (ok) {
                // récupération des informations sur le visiteurs depuis la vue leVisiteur           
                MySqlCommand cmd = new MySqlCommand("Select nomPrenom from leVisiteur;", cnx);
                try {
                    Globale.nomVisiteur = cmd.ExecuteScalar().ToString();
                } catch (MySqlException e) {
                    message = "Erreur lors de la récupération de vos paramètres \n";
                    message += "Veuillez contacter le service informatique\n";
                    ok = false;
                }
            }
            if (ok) message = "Visiteur authentifié";
            return ok;
        }

        // se déconnecter
        static public void seDeConnecter() => cnx.Close();


        // chargement des données de la base dans les différentes collections statiques de la classe Globale 
        // dans cette méthode pas de bloc try catch car aucune erreur imprévisible en production ne doit se produire
        // en cas d'erreur en développement il faut laisser faire le debogueur de VS qui va signaler la ligne en erreur
        // le chargement des données concernant tous les visiteurs (médicament, type praticien, specialite, motif) ne doit être fait qu'une fois
        // si elles sont déja chargées on ne les recherche pas.
        // le chargement des données spécifiques au visiteur connecté doit se faire à chaque fois en vidant les anciennes données 
        static public void chargerDonnees()
        {
           
        }


        /// <summary>
        ///     Ajout d'une nouvelle visite
        /// </summary>
        /// <param name="idPraticien"></param>
        /// <param name="idMotif"></param>
        /// <param name="uneDate"></param>
        /// <param name="uneHeure"></param>
        /// <param name="message"></param>
        /// <returns>identifiant de la nouvelle visite ou 0 si erreur lors de la création</returns>
        static public int ajouterRendezVous(int idPraticien, int idMotif, DateTime uneDate, out string message)
        {
            message = string.Empty;
            return 0;
        }

        static public bool supprimerRendezVous(int idVisite, out string message)
        {
            message = string.Empty;
            return false;
        }

        static public bool modifierRendezVous(int idVisite, DateTime uneDateEtHeure, out string message)
        {
            message = string.Empty;
            return false;
        }

        static public bool enregistrerBilan(Visite uneVisite, out string message)
        {
            message = string.Empty;
            return false;
        }


        static public int ajouterPraticien(string nom, string prenom, string rue, string codePostal, string ville, string telephone, string email, string unType, string uneSpecialite, out string message)
        {
            message = string.Empty;
            
            return 0;
        }


        static public bool modifierPraticien(int id, string nom, string rue, string codePostal, string ville, string telephone, string email, string unType, string uneSpecialite, out string message)
        {
            message = string.Empty;
            
            return false;
        }

        static public bool supprimerPraticien(int id, out string message)
        {
            message = string.Empty;
            return false;
        }

    }
}
