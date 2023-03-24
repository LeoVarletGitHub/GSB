﻿using lesClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSB
{
    public partial class FrmMoveDelVisite : FrmBase
    {
        public FrmMoveDelVisite()
        {
            InitializeComponent();
        }

        private void FrmMoveDel_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
            label3.Visible = false;
            messagelabel.Visible = false;
            dateTimePicker1.CustomFormat = "dddd dd MMMM yyyy HH:mm tt";
            dateTimePicker1.MinDate = DateTime.Now;
            parametrerComposant();
        }

        private void parametrerDgv(DataGridView dgv)
        {
            #region paramètrage concernant le datagridview dans son ensemble

            // Largeur : à contrôler avec la largeur des colonnes si elle est définie

            // style de bordure
            dgv.BorderStyle = BorderStyle.FixedSingle;

            // couleur de fond 
            dgv.BackgroundColor = Color.White;

            // couleur de texte  
            dgv.ForeColor = Color.Black;

            // police de caractères par défaut
            dgv.DefaultCellStyle.Font = new Font("Georgia", 10);

            // mode de sélection dans le composant : FullRowSelect, CellSelect ...
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // sélection multiple 
            dgv.MultiSelect = false;

            // l'utilisateur peut-il ajouter ou supprimer des lignes ?
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToAddRows = false;

            // L'utilisateur peut-il modifier le contenu des cellules ou est-elle réservée à la programmation ?
            dgv.EditMode = DataGridViewEditMode.EditProgrammatically;

            // l'utilisateur peut-il redimensionner les colonnes et les lignes ?
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;

            // l'utilisateur peut-il modifier l'ordre des colonnes ?
            dgv.AllowUserToOrderColumns = false;

            // le composant accepte t'il le 'déposer' dans un Glisser - Déposer ?
            dgv.AllowDrop = false;




            #endregion

            #region paramètrage concernant la ligne d'entête (les entêtes de chaque colonnes)

            // visibilité
            dgv.ColumnHeadersVisible = true;

            // bordure
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // style  [à adapter] (ici : noir sur fond transparent sans mise en évidence de la sélection)
            dgv.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle style = dgv.ColumnHeadersDefaultCellStyle;
            style.BackColor = Color.WhiteSmoke;
            style.ForeColor = Color.Black;
            style.SelectionBackColor = Color.WhiteSmoke;    // même couleur que backColor pour ne pas mettre en évidence la colonne sélectionnée
            style.SelectionForeColor = Color.Black;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.Font = new Font("Georgia", 10, FontStyle.Bold);


            // hauteur 
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ColumnHeadersHeight = 40;

            #endregion

            #region paramètrage concernant l'entête de ligne (la colonne d'entête ou le sélecteur)

            // visible 
            dgv.RowHeadersVisible = false;

            // style de bordure  
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;


            #endregion

            #region paramètrage au niveau des lignes

            // Hauteur 
            dgv.RowTemplate.Height = 30;

            #endregion

            #region paramètrage au niveau des cellules

            // style de bordure 
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // couleur de fond, ne pas utiliser transparent car la couleur de la ligne sélectionnée restera après sélection
            dgv.RowsDefaultCellStyle.BackColor = Color.White;

            // Couleur alternative appliquée une ligne sur deux
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 238, 238, 238);

            #endregion

            #region paramètrage au niveau de la zone sélectionnée

            // couleur de fond mettre la même que les cellules si on ne veut pas mettre la zone en évidence 
            dgv.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.Lavender;

            // couleur du texte
            dgv.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            #endregion

            #region paramètrage des colonnes

            // Nombre de colonne sans compter les colonnes ajoutées par la méthode Add
            dgv.ColumnCount = 5;

            // faut-il ajuster automatiquement la taille des colonnes à leur contenu (commenter la ligne si non)
            // dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // faut-il ajuster automatiquement la taille des colonnes par un ajustement proportionnel à la largeur totale (commenter la ligne si non)
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // description de chaque colonne  [partie à personnaliser] : visibilité, largeur, alignement cellule et entête si ellene correspond pas à la valeur par défaut
         
            dgv.Columns[0].Name = "Programmé le";

            dgv.Columns[0].Width = 175;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns[1].Name = "à";
            dgv.Columns[1].Width = 100;

            dgv.Columns[2].Name = "Sur";
            dgv.Columns[2].Width = 80;
            dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns[3].Name = "Chez";
            dgv.Columns[3].Width = 140;
            dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns[4].Visible = false;
            dgv.Columns[4].Name = "Id";

            // ajout d'une colonne contenant le bouton supprimer
            DataGridViewButtonColumn uneColonneBouton = new DataGridViewButtonColumn();
            uneColonneBouton.HeaderText = "Action";
            uneColonneBouton.Name = "Action";
            uneColonneBouton.Text = "Supprimer";
            uneColonneBouton.Width = 35;
            uneColonneBouton.UseColumnTextForButtonValue = true;
            dgv.Columns.Add(uneColonneBouton);

            // faut-il désactiver le tri sur toutes les colonnes ? (commenter les lignes si non)
            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            #endregion
        }

        private void parametrerComposant()
        {
            dataGridView1.Rows.Clear();
            parametrerDgv(dataGridView1);

            foreach (Visite visite in Globale.mesVisites)
            {
                dataGridView1.Rows.Add(visite.DateEtHeure.ToString("dddd-dd-MMMM-yyyy"), visite.DateEtHeure.ToString("HH:mm"), visite.LePraticien.Ville, visite.LePraticien.NomPrenom, visite.Id);
            }
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }
        private string message;
        private int id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                id = (int)dataGridView1[4, e.RowIndex].Value;
                // je le supprime de la table visite
                Passerelle.supprimerRendezVous(id, out message);
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                parametrerComposant();
                messagelabel.Text = message;
                messagelabel.Visible = true;
            }
            else
            {
                label4.Text = (string)dataGridView1[3, e.RowIndex].Value;
                label4.Visible = true;
                label3.Text = (string)dataGridView1[0, e.RowIndex].Value;
                label3.Visible = true;
                id = (int)dataGridView1[4, e.RowIndex].Value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Passerelle.modifierRendezVous(id, dateTimePicker1.Value.Date + dateTimePicker1.Value.TimeOfDay, out message);
            messagelabel.Text = message;
            messagelabel.Visible = true;
            Passerelle.chargerDonnees();
            dataGridView1.Rows.Clear();
            foreach (Visite visite in Globale.mesVisites)
            {
                dataGridView1.Rows.Add(visite.DateEtHeure.ToString("dddd-dd-MMMM-yyyy"), visite.DateEtHeure.ToString("HH:mm"), visite.LePraticien.Ville, visite.LePraticien.NomPrenom, visite.Id);
            }
        }
    }
}
