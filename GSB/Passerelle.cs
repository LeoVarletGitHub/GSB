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
using System.Windows.Forms;
using System.Linq;

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
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader curseur;
            if (Globale.lesMedicaments.Count == 0) { 
                cmd = new MySqlCommand("select * from medicament join famille f on f.id = medicament.idFamille", cnx);
                curseur = cmd.ExecuteReader();
                while (curseur.Read())
                {
                    Globale.lesMedicaments.Add(new Medicament(curseur.GetString(0), curseur.GetString(1), curseur.GetString(2), curseur.GetString(3), curseur.GetString(4), new Famille(curseur.GetString(5), curseur.GetString(7))));
                }
                curseur.Close();
                cmd = new MySqlCommand("select * from motif", cnx);
                curseur = cmd.ExecuteReader();
                while (curseur.Read())
                {
                    Globale.lesMotifs.Add(new Motif(curseur.GetInt32(0), curseur.GetString(1)));
                }
                curseur.Close();

                cmd = new MySqlCommand("select * from typepraticien", cnx);
                curseur = cmd.ExecuteReader();
                while (curseur.Read())
                {
                    Globale.lesTypes.Add(new TypePraticien(curseur.GetString(0), curseur.GetString(1)));
                }
                curseur.Close();

                cmd = new MySqlCommand("select * from specialite", cnx);
                curseur = cmd.ExecuteReader();
                while (curseur.Read())
                {
                    Globale.lesSpecialites.Add(new Specialite(curseur.GetString(0), curseur.GetString(1)));
                }
                curseur.Close();
            }
            cmd = new MySqlCommand("select * from mesvilles", cnx);
            curseur = cmd.ExecuteReader();
            while (curseur.Read())
            {
                Globale.mesVilles.Add(new Ville(curseur.GetString(0), curseur.GetString(1)));
            }
            curseur.Close();
            
            curseur.Close();
            
            cmd = new MySqlCommand("select * from mespraticiens", cnx);
            curseur = cmd.ExecuteReader();
            while (curseur.Read())
            {
                Globale.mesPraticiens.Add(new Praticien(curseur.GetInt32(0),curseur.GetString(1), curseur.GetString(2), curseur.GetString(3), curseur.GetString(4), curseur.GetString(5), curseur.GetString(6), curseur.GetString(7), new TypePraticien(curseur.GetString(8), curseur.GetString(9)), new Specialite(curseur.GetString(10), curseur.GetString(11)) ));
            }
            curseur.Close();

            List<Visite> lesVisites = new List<Visite>();
            cmd = new MySqlCommand("select id, dateEtHeure, bilan, motif, praticien, premierMedicament, secondMedicament from mesvisites", cnx);
            curseur = cmd.ExecuteReader();
            while (curseur.Read())
            {
                int id = curseur.GetInt32("id");
                DateTime dateEtHeure = curseur.GetDateTime("dateEtHeure");
                int idMotif = curseur.GetInt32("motif");
                int idPraticien = curseur.GetInt32("praticien");
                Praticien praticien = Globale.mesPraticiens.First(x => x.Id.Equals(idPraticien));
                Motif motif = Globale.lesMotifs.First(x => x.Id.Equals(idMotif));
                Globale.mesVisites.Add(new Visite(id, praticien, motif, dateEtHeure));
            }
            curseur.Close();
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
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "ajouterRendezVous";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnx;
            cmd.Parameters.AddWithValue("_idPraticien", idPraticien);
            cmd.Parameters.AddWithValue("_idMotif", idMotif);
            cmd.Parameters.AddWithValue("_dateEtHeure", uneDate);
            cmd.Parameters.Add("idVisite", MySqlDbType.Int32);
            cmd.Parameters["idVisite"].Direction = ParameterDirection.Output;
            try 
            {
                cmd.ExecuteNonQuery();
                int idVisite = int.Parse(cmd.Parameters["idVisite"].Value.ToString());
                return idVisite;
            } 
            catch (Exception ex)
            {
                message = ex.Message;
                return 0;
            }
        }

        static public bool supprimerRendezVous(int idVisite, out string message)
        {
            message = string.Empty;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "supprimerRendezVous";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnx;
            cmd.Parameters.AddWithValue("idVisite", idVisite);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        static public bool modifierRendezVous(int idVisite, DateTime uneDateEtHeure, out string message)
        {
            message = string.Empty;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "modifierRendezVous";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnx;
            cmd.Parameters.AddWithValue("idVisite", idVisite);
            cmd.Parameters.AddWithValue("_dateEtHeure", uneDateEtHeure);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        static public bool enregistrerBilan(Visite uneVisite, out string message)
        {
            message = string.Empty;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "enregistrerBilanVisite";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnx;
            cmd.Parameters.AddWithValue("_idVisite", uneVisite.Id);
            cmd.Parameters.AddWithValue("_bilan", uneVisite.Bilan);
            cmd.Parameters.AddWithValue("_premierMedicament", uneVisite.PremierMedicament);
            cmd.Parameters.AddWithValue("_secondMedicament", uneVisite.SecondMedicament);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }


        static public int ajouterPraticien(string nom, string prenom, string rue, string codePostal, string ville, string telephone, string email, string unType, string uneSpecialite, out string message)
        {
            message = string.Empty;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "ajouterRendezVous";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnx;
            cmd.Parameters.AddWithValue("_nom", nom);
            cmd.Parameters.AddWithValue("_prenom", prenom);
            cmd.Parameters.AddWithValue("_rue", rue);
            cmd.Parameters.AddWithValue("_codePostal", codePostal);
            cmd.Parameters.AddWithValue("_ville", ville);
            cmd.Parameters.AddWithValue("_telephone", telephone);
            cmd.Parameters.AddWithValue("_email", email);
            cmd.Parameters.AddWithValue("_idType", unType);
            cmd.Parameters.AddWithValue("_idSpecialite", uneSpecialite);
            cmd.Parameters.Add("idPraticien", MySqlDbType.Int32);
            cmd.Parameters["idPraticien"].Direction = ParameterDirection.Output;
            try
            {
                cmd.ExecuteNonQuery();
                int idVisite = int.Parse(cmd.Parameters["idPraticien"].Value.ToString());
                return idVisite;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return 0;
            }
        }


        static public bool modifierPraticien(int id, string nom, string rue, string codePostal, string ville, string telephone, string email, string unType, string uneSpecialite, out string message)
        {
            message = string.Empty;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "modifierPraticien";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnx;
            cmd.Parameters.AddWithValue("_id", id);
            cmd.Parameters.AddWithValue("_nom", nom);
            cmd.Parameters.AddWithValue("_rue", rue);
            cmd.Parameters.AddWithValue("_codePostal", codePostal);
            cmd.Parameters.AddWithValue("_ville", ville);
            cmd.Parameters.AddWithValue("_telephone", telephone);
            cmd.Parameters.AddWithValue("_email", email);
            cmd.Parameters.AddWithValue("_idType", unType);
            cmd.Parameters.AddWithValue("_idSpecialite", uneSpecialite);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        static public bool supprimerPraticien(int id, out string message)
        {
            message = string.Empty;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "supprimerPraticien";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnx;
            cmd.Parameters.AddWithValue("idPraticien", id);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

    }
}
