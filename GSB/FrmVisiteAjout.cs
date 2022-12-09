using lesClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSB {
    public partial class FrmVisiteAjout : FrmBase {
        public FrmVisiteAjout() {
            InitializeComponent();
        }

        private void FrmVisiteAjout_Load(object sender, EventArgs e) {
            parametrerComposant();
      
        }




        private void parametrerComposant() {
            this.lblTitre.Text = "Enregistrer un nouveau rendez-vous";

        }

        private void lblTitre_Click(object sender, EventArgs e)
        {

        }
    }
}
