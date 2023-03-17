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
    public partial class FrmMedicament : FrmBase
    {
        private Medicament medicament1;
        public FrmMedicament()
        {
            InitializeComponent();
        }

        private void FrmMedicament_Load(object sender, EventArgs e)
        {
            foreach (Medicament medicament in Globale.lesMedicaments)
            {
                ListeMedicamentBox.Items.Add(medicament);
            }
        }

        private void ListeMedicamentBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            medicament1 = (Medicament)ListeMedicamentBox.SelectedItem;

            textBox1.Text = medicament1.LaFamille.Libelle;
            textBox2.Text = medicament1.Composition;
            textBox3.Text = medicament1.Effets;
            textBox4.Text = medicament1.ContreIndication;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
