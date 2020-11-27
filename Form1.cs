using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arbres
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //================================
        private bool RacineOk=false;
        int[] Arbre = new int[33];
        //================================
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = (Math.Pow(2,5) + 1).ToString(); //33           
            for(int i=0; i<33;i++) //initialise le tableau
            {
                Arbre[i] = -1;
            }
            label2.Text = "Racine? (entier)";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }
        void ActualiseListeNoeud()
        {           
            listBox1.Items.Clear();
            for (int i=0; i<33;i++)
            {
                if (Arbre[i]!=-1) {
                    listBox1.Items.Add(Arbre[i]);
                //    MessageBox.Show(Arbre[i].ToString());
                }
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
           
        }
        private void AfficheTablo()
        {
            listBox2.Items.Clear();
          
            for (int i = 0; i < 33; i++)
            {
                listBox2.Items.Add(Arbre[i].ToString()); 
            }
        }
        int ValeurDuNoeud, noeudPere;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {               }

        private void listBox1_Click(object sender, EventArgs e)
        {
            tbChoixNoeud.Text = listBox1.SelectedItem.ToString();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
       {
            if(e.KeyCode==Keys.Enter)  // si le contenu du texbox est validé par ENTER
            {
                if (!RacineOk) { 
                    Arbre[0] = int.Parse(textBox1.Text);
                    AfficheTablo();
                    label1.Text = "Pour créer un noeud cliquez le père dans la liste puis indiquez la valeur puis Valider";
                    label2.Text="Valeur du noeud";
                    RacineOk = true;
                    listBox1.Visible = true;
                    ActualiseListeNoeud();
                }
                else
                {
                    AfficheTablo();
                    ActualiseListeNoeud();
                    // ajoute le noeud
                    ValeurDuNoeud= int.Parse(textBox1.Text);
                    noeudPere = int.Parse( tbChoixNoeud.Text);
                    int k = -1;
                    do
                    {
                        k++;
                    } while (noeudPere != Arbre[k]);
                    // reste à tester si le N G existe et postionner à droite
                    // Si 2 N existent proposer l'effacement  d'un noeud
                    Arbre[2 * k + 1] = ValeurDuNoeud;// Création du noeud gauche
                    AfficheTablo();
                    ActualiseListeNoeud();
                }
            }
        }
    }
}
