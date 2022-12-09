// ------------------------------------------
// Nom du fichier : visite.cs
// Objet : Définition de la classe Visite
// Auteur : M. Verghote
// ------------------------------------------

using System;
using System.Collections.Generic;

namespace lesClasses
{
    [Serializable]
    public class Visite 
    {
        // la classe doit implémenter une méthode de comparaison car les objets Visite
        // seront utilisés dans une collection qui sera triée après chaque ajout
        // le critère de comparaison : DateEtHeure


        // attribut privé lesEchantillons : dictionnaire de médicament associé à une quantité
        private SortedDictionary<Medicament, int> lesEchantillons;

        // Propriétés automatiques Id, LePRaticien LeMotif DateetHeure Bilan PremierMedicament SecondMedicament
        public int Id { get; }

        public Praticien LePraticien { get; set; }
        public Motif LeMotif { get; set; }
        public DateTime DateEtHeure { get; private set; }
        public string Bilan { get; set; }
        public Medicament PremierMedicament { get; set; }
        public Medicament SecondMedicament { get; set; }


        // Constructeur : ne pas oublier la mise à jour de la relation bidirectionnelle
        public Visite(int id, Praticien unPraticien, Motif unMotif, DateTime uneDateEtHeure) {
         

        }


        // méthode enregistrerBilan : alimente les propriétés Bilan, PremierMedicament, SecondMedicament
        public void enregistrerBilan(string bilan, Medicament premierMedicament, Medicament secondMedicament) {
         
        }


        // méthode déplacer ; alimente la propriété DateEtHeure
        public void deplacer(DateTime uneDateEtHeure) {

        }

        // méthode ajouterEchantillon : ajoute un échantillon 
        // si le médicament est déjà dans le dictionnaire on cumule les quantités sinon ou ajoute
        public void ajouterEchantillon(Medicament unMedicament, int uneQuantite) {

        }


        // méthode supprimerEchantillon
        public void supprimerEchantillon(Medicament unMedicament) {

        }

 

        // définition d'un itérateur permettant de parcourir les éléments du dictionnaire lesEchantillons


    }
       
}
