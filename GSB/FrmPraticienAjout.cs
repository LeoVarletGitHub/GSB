using lesClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSB
{
    public partial class FrmPraticienAjout : FrmBase
    {
        public FrmPraticienAjout()
        {
            InitializeComponent();
        }

        private void FrmPraticienAjout_Load(object sender, EventArgs e)
        {
            foreach(TypePraticien type in Globale.lesTypes)
            {
                comboBoxType.Items.Add(type);
            }
            foreach(Specialite specialite in Globale.lesSpecialites)
            {
                comboBoxSpecialite.Items.Add(specialite);
            }
            foreach(Ville ville in Globale.mesVilles)
            {
                textBoxVille.AutoCompleteCustomSource.Add(ville.Nom);
            }
            
        }
        private string message;
        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            TypePraticien typeId = (TypePraticien)comboBoxType.SelectedItem;
            Specialite specialiteId = (Specialite)comboBoxSpecialite.SelectedItem;
            string codepostal = "";
            foreach(Ville ville in Globale.mesVilles)
            {
                if (ville.Nom == textBoxVille.Text)
                    codepostal = ville.Code;
            }
            Passerelle.ajouterPraticien(textBoxNom.Text, textBoxPrenom.Text, textBoxRue.Text, codepostal , textBoxVille.Text, textBoxTelephone.Text,textBoxEmail.Text, typeId.Id, specialiteId.Id, out message);
            labelMessage.Text = message;
            labelMessage.Visible = true;
        }
    }
}
