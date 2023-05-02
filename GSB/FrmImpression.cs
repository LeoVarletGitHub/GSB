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
    public partial class FrmImpression : FrmBase
    {
        public FrmImpression()
        {
            InitializeComponent();
        }

        private void FrmImpression_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now.AddDays(53);

            dateTimePicker2.MinDate = dateTimePicker1.Value.AddDays(7);
            dateTimePicker2.MaxDate = DateTime.Now.AddDays(60);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            printDocument1.DocumentName = "Rendez-vous sur une période";
            printDocument1.DefaultPageSettings.Landscape = false; // mode portrait
            printDialog1.Document = printDocument1;
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //printPanier.Print();
            }
                
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.WindowState = FormWindowState.Maximized;
            printPreviewDialog1.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            printDocument1.DocumentName = "Rendez-vous sur une période";
            printDocument1.DefaultPageSettings.Landscape = false; // mode portrait
            printDialog1.Document = printDocument1;
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // définition de la police, de la couleur et du format
            Font unePolice = new Font("Arial", 8);
            SolidBrush uneCouleur = new SolidBrush(Color.Black);
            StringFormat unFormat = new StringFormat();
            unFormat.LineAlignment = StringAlignment.Center;

            // imprimer l'encadrement du titre
            int x = 50;
            int y = 30;
            int largeur = 730;
            int hauteur = 30;
            Rectangle unRectangle = new Rectangle(x, y, largeur, hauteur); // x, y coin supérieur gauche
            Pen styleTrait = new Pen(Color.Black, 1);
            e.Graphics.DrawRectangle(styleTrait, unRectangle);
            // imprimer le titre centré dans l'encadrement 
            string texteAImprimer = "Mes rendez-vous entre le " + dateTimePicker1.Value.Date.ToLongDateString() + " et le " + dateTimePicker2.Value.Date.ToLongDateString();
            unFormat.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(texteAImprimer, unePolice, uneCouleur, unRectangle, unFormat);

            // impression de l'entête du tableau

            // Chaque colonne est associée à un rectangle pour permettre un alignement de son contenu

            // colonne Date
            x = 50;
            y = 70;
            largeur = 175;
            hauteur = 25;
            texteAImprimer = "Date";
            unRectangle = new Rectangle(x, y, largeur, hauteur);
            e.Graphics.DrawString(texteAImprimer, unePolice, uneCouleur, unRectangle, unFormat);

            // colonne Heure
            x = x + largeur;
            largeur = 60;
            texteAImprimer = "Heure";
            unRectangle = new Rectangle(x, y, largeur, hauteur);
            e.Graphics.DrawString(texteAImprimer, unePolice, uneCouleur, unRectangle, unFormat);

            // colonne Praticien
            x = x + largeur;
            largeur = 125;
            texteAImprimer = "Praticien";
            unRectangle = new Rectangle(x, y, largeur, hauteur);
            e.Graphics.DrawString(texteAImprimer, unePolice, uneCouleur, unRectangle, unFormat);

            // colonne Téléphone
            x = x + largeur;
            largeur = 125;
            texteAImprimer = "Téléphone";
            unRectangle = new Rectangle(x, y, largeur, hauteur);
            e.Graphics.DrawString(texteAImprimer, unePolice, uneCouleur, unRectangle, unFormat);

            // colonne Lieu
            x = x + largeur;
            largeur = 160;
            texteAImprimer = "Lieu";
            unRectangle = new Rectangle(x, y, largeur, hauteur);
            e.Graphics.DrawString(texteAImprimer, unePolice, uneCouleur, unRectangle, unFormat);

            // colonne Motif
            x = x + largeur;
            largeur = 150;
            texteAImprimer = "Motif";
            unRectangle = new Rectangle(x, y, largeur, hauteur);
            e.Graphics.DrawString(texteAImprimer, unePolice, uneCouleur, unRectangle, unFormat);

            // Impression du trait séparant l'entête du tableau du corps
            styleTrait = new Pen(Color.Black, 3);
            Point unPoint = new Point(50, 100);
            Point point2 = new Point(750, 100);
            e.Graphics.DrawLine(styleTrait, unPoint, point2);

            // Impression des lignes à partir de la lecture du panier
            unPoint += new Size(0, 15);
            hauteur = 35;
            foreach (Visite visite in Globale.mesVisites)
            {
                if(dateTimePicker1.Value.Date <= visite.DateEtHeure.Date && visite.DateEtHeure.Date <= dateTimePicker2.Value.Date)
                {
                    largeur = 175;
                    unRectangle = new Rectangle(unPoint.X, unPoint.Y, largeur, hauteur);
                    unFormat.LineAlignment = StringAlignment.Center;
                    e.Graphics.DrawString(visite.DateEtHeure.ToString("dddd-dd-MMMM-yyyy"), unePolice, uneCouleur, unRectangle, unFormat);


                    unPoint.X += largeur;
                    largeur = 60;
                    unRectangle = new Rectangle(unPoint.X, unPoint.Y, largeur, hauteur);
                    e.Graphics.DrawString(visite.DateEtHeure.ToString("HH:mm"), unePolice, uneCouleur, unRectangle, unFormat);

                    
                    unPoint.X += largeur;
                    largeur = 125;
                    unRectangle = new Rectangle(unPoint.X, unPoint.Y, largeur, hauteur);
                    e.Graphics.DrawString(visite.LePraticien.NomPrenom, unePolice, uneCouleur, unRectangle, unFormat);

                    
                    unPoint.X += largeur;
                    largeur = 125;
                    unRectangle = new Rectangle(unPoint.X, unPoint.Y, largeur, hauteur);
                    e.Graphics.DrawString(visite.LePraticien.Telephone, unePolice, uneCouleur, unRectangle, unFormat);


                    
                    unPoint.X += largeur;
                    largeur = 160;
                    unRectangle = new Rectangle(unPoint.X, unPoint.Y, largeur, hauteur);
                    e.Graphics.DrawString(visite.LePraticien.Ville + " " + visite.LePraticien.Rue, unePolice, uneCouleur, unRectangle, unFormat);

                    
                    unPoint.X += largeur;
                    largeur = 150;
                    unRectangle = new Rectangle(unPoint.X, unPoint.Y, largeur, hauteur);
                    e.Graphics.DrawString(visite.LeMotif.ToString(), unePolice, uneCouleur, unRectangle, unFormat);

                    // on se place au début de la ligne suivante 
                    unPoint.X = 50;
                    unPoint.Y += hauteur;
                }
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value.AddDays(7);
        }
    }
}
