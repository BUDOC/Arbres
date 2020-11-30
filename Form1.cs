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
            this.button1.Visible = false;
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
        int k = -1;
        private void gere2noeuds(int K)
        {
            if (RbbNG.Checked)
            {
                Arbre[2 * K + 1] = ValeurDuNoeud;            // Ecrase du noeud gauche
            }
            if (RbND.Checked)
            {
                Arbre[2 * K + 2] = ValeurDuNoeud;            // Ecrase du noeud Droit
            }
            AfficheTablo();
            ActualiseListeNoeud();
        }

        private void BtValideChoix_Click(object sender, EventArgs e)
        {
            gere2noeuds(k);
            panel1.Visible = false;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
       {
            if(e.KeyCode==Keys.Enter)  // si le contenu du texbox est validé par ENTER
            {
                if (!RacineOk) {  // cas ou le noeud origine n'est pas créé
                    Arbre[0] = int.Parse(textBox1.Text);
                    AfficheTablo();
                    label1.Text = "Pour créer un noeud cliquez le père dans la liste puis indiquez la valeur puis Valider";
                    label2.Text="Valeur du noeud";
                    RacineOk = true;
                    listBox1.Visible = true;
                    ActualiseListeNoeud();
                }
                else
                // pour la suite on parcourt le tableau mais pas l'arbre 2eme temps
                {   //Ajoute un  noud fils (à gauche pas défaut)
                    AfficheTablo();
                    ActualiseListeNoeud();
                    // ajoute le noeud
                    ValeurDuNoeud= int.Parse(textBox1.Text);
                    noeudPere = int.Parse( tbChoixNoeud.Text);
                     k = -1;
                    do
                    {
                        k++;
                    } while (noeudPere != Arbre[k]);
                    // reste à tester si le N G existe et postionner à droite
                    // Si 2 N existent proposer l'effacement  d'un noeud
                    if (Arbre[2 * k + 1] == -1) 
                    { Arbre[2 * k + 1] = ValeurDuNoeud; }// Création du noeud gauche
                    else
                    {if (Arbre[2 * k + +2]==-1)
                        { Arbre[2 * k + 2] = ValeurDuNoeud; }// Création du noeud droit
                    // cas ou les deux noeuds existent
                        else // les 2 fils existent
                        {
                            panel1.Visible = true;
                           
                        }
                    }
                    AfficheTablo();
                    ActualiseListeNoeud();
                }
            }
        }
    }
}
