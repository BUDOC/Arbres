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
            textBox1.Visible = true;
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

        private void BtParcoursEnLargeur_Click(object sender, EventArgs e)
        {
            int a, b;
            textBox2.Text = "";
            if (Arbre[0]!=-1) { textBox2.Text = Arbre[0].ToString() + " => "; }
            for (int i=0;i<=5;i++)
            {
                a = Arbre[2 * i + 1];
                b= Arbre[2 * i + 2];
                if (a!=-1) { textBox2.Text = textBox2.Text + a.ToString() + " => ";  }
                if (b != -1) { textBox2.Text = textBox2.Text + b.ToString() + " => " ; }
            }
        }

        private void Explore(bool cote)
        {
            // Parcours de l'arbre en profondeur préfixé.
            // Utilisation d'une pile. Elles contient les noeuds visités
            // Reset pile
            // de la racine
            // Empiler Noeud racine (afficher dans le compte rendu du chemin)
            // 1 -cherche Noeud inf gauche tant que pas noeud différent de feuille (-1) ou profondeur Max atteinte
            // SI le NG existe alors empiler le noeud et reprendre à 1 (ajouter dans le compte rendu du chemin)
            // SINON  CHercher le fils droit 
            //   s'il existe Empiler fils droit pui reprendre en 1 (ajouter dans le compte rendu du chemin)
            // Sinon (-1 ou niveau max) Dépiler            
            // condition d'arret= il n'y  a plus de noeud droit (-1) .    
            //========================================================================                      
                    
                bool fin = false;
                bool exploreAgauche = cote;
               
                    MessageBox.Show("passage dans boucle Explore"); 
                    pos = 2 * Nivo + 1;
                    a = Arbre[pos];
                    if (a != -1 && Nivo <= 5 && exploreAgauche) //Fils G existe
                    {
                        Pile.Add(pos); //Empile
                        textBox2.Text = textBox2.Text +a.ToString() + "=> ";
                        Nivo++;
                         exploreAgauche = true;
            }
                    else
                    {
                        pos = 2 * Nivo + 2;
                        a = Arbre[pos];
                        if (a != -1 && Nivo <= 5) // Fils droit existe Mais pas fils gauche
                        {
                            Pile.Add(pos);//Empile
                            textBox2.Text = textBox2.Text + a.ToString() + "=> ";
                         exploreAgauche = false;
                        Nivo++;
                        }
                        else
                        {// Aucun fils
                            b = Pile.Count-1;
                            if (b < 0 || Nivo > 5) { fin = true; } // condition de fin
                            // depile
                            Pile.RemoveAt(b);
                            exploreAgauche = false;
                            Nivo=Nivo-2;
                        }
                    }
                Explore(exploreAgauche);                           
        }

        List<int> Pile = new List<int>();
        int Nivo = 0;
        int a = 0;
        int b = 0;
        int pos = 0;
       

        private void btPrefixé_Click(object sender, EventArgs e)
        {
            Pile.Add(0);
            textBox2.Text = Arbre[0].ToString() + "=> ";
            Explore(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 33; i++)
            {
                Arbre[i]=i+100;
                AfficheTablo();
            }
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
                    {if (Arbre[2 * k +2]==-1)
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
