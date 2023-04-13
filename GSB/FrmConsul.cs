using lesClasses;
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
    public partial class FrmConsul : FrmBase
    {
        public FrmConsul()
        {
            InitializeComponent();
        }

        private void FrmConsul_Load(object sender, EventArgs e)
        {
            parametrerComposant();
        }
        private void parametrerDgv1(DataGridView dgv)
        {
            #region paramètrage concernant le datagridview dans son ensemble

            // Largeur : à contrôler avec la largeur des colonnes si elle est définie
            dgv.Width = 380;

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
            dgv.ColumnCount = 4;

            // faut-il ajuster automatiquement la taille des colonnes à leur contenu (commenter la ligne si non)
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // faut-il ajuster automatiquement la taille des colonnes par un ajustement proportionnel à la largeur totale (commenter la ligne si non)
            //dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // description de chaque colonne  [partie à personnaliser] : visibilité, largeur, alignement cellule et entête si ellene correspond pas à la valeur par défaut

            dgv.Columns[0].Name = "Programmée le";

            dgv.Columns[0].Width = 85;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns[1].Name = "à";
            dgv.Columns[1].Width = 40;

            dgv.Columns[2].Name = "sur";
            dgv.Columns[2].Width = 95;

            dgv.Columns[3].Visible = false;
            dgv.Columns[3].Name = "Id";

            // faut-il désactiver le tri sur toutes les colonnes ? (commenter les lignes si non)
            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            #endregion
        }

        private void parametrerDgv2(DataGridView dgv)
        {
            #region paramètrage concernant le datagridview dans son ensemble

            // Largeur : à contrôler avec la largeur des colonnes si elle est définie
            dgv.Width = 120;

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
            dgv.ColumnHeadersVisible = false;

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
            dgv.ColumnCount = 2;

            // faut-il ajuster automatiquement la taille des colonnes à leur contenu (commenter la ligne si non)
            //dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // faut-il ajuster automatiquement la taille des colonnes par un ajustement proportionnel à la largeur totale (commenter la ligne si non)
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // description de chaque colonne  [partie à personnaliser] : visibilité, largeur, alignement cellule et entête si ellene correspond pas à la valeur par défaut

            dgv.Columns[0].Name = "id";
            dgv.Columns[0].Width = 85;

            dgv.Columns[1].Name = "quantité";
            dgv.Columns[1].Width = 40;


            // faut-il désactiver le tri sur toutes les colonnes ? (commenter les lignes si non)
            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            #endregion
        }

        private void parametrerComposant()
        {
            dataGridView1.Rows.Clear();
            parametrerDgv1(dataGridView1);
            foreach(Visite visite in Globale.mesVisites)
            {
                dataGridView1.Rows.Add(visite.DateEtHeure.ToString("dddd-dd-MMMM-yyyy"), visite.DateEtHeure.ToString("HH:mm"), visite.LePraticien.Ville, visite.Id);
            }
        }
        private int id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)dataGridView1[3, e.RowIndex].Value;
            parametrerDgv2(dataGridView2);
            foreach (Visite visite in Globale.mesVisites)
            {
                if(visite.Id == id)
                {
                    labelPraticien.Text = visite.LePraticien.NomPrenom;
                    labelPraticien.Visible = true;

                    labelRue.Text = visite.LePraticien.Rue;
                    labelRue.Visible = true;

                    labelTelephone.Text = visite.LePraticien.Telephone; 
                    labelTelephone.Visible = true;

                    labelEmail.Text = visite.LePraticien.Email;
                    labelEmail.Visible = true;

                    labelTypepraticien.Text = visite.LePraticien.Type.Libelle;
                    labelTypepraticien.Visible = true;
                    if(visite.LePraticien.Specialite == null)
                    {
                        labelSpécialité.Text = "Pas de spécialité";
                    }
                    else
                    {
                        labelSpécialité.Text = visite.LePraticien.Specialite.Libelle;
                    }
                    labelSpécialité.Visible = true;

                    labelMotif.Text = visite.LeMotif.ToString();
                    labelMotif.Visible = true;

                    textBox1.Text = "";
                    if(!(visite.Bilan == null))
                    {
                        textBox1.Text = visite.Bilan.ToString();
                    }

                    textBox2.Text = "";
                    if(!(visite.PremierMedicament == null))
                    {
                        textBox2.Text = visite.PremierMedicament.ToString();
                        
                    }
                    if (!(visite.SecondMedicament == null))
                    {
                        textBox2.Text = textBox2.Text + " , " + visite.SecondMedicament.ToString();
                    }
                }
            }
        }
    }
}
