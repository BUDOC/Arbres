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
        private bool RacineOk = false;
        int[] Arbre = new int[33];
        //================================
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = (Math.Pow(2, 5) + 1).ToString(); //33           
            for (int i = 0; i < 33; i++) //initialise le tableau
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
            for (int i = 0; i < 33; i++)
            {
                if (Arbre[i] != -1)
                {
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
        { }
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
            bool fin = false;
            Pile.Add(0);
            this.textBox2.Text = Arbre[0] + "\r\n";
            int c = 1;

            do
            {
                int cm = 0;
                int cpt = 0;
                int Memo;
                for (int i = 0; i <= c - 1; i++) //de 0 à longueur de pile  corresponde aux noeud pères
                {
                    fin = false;
                    if (ExisteNG(Pile[0])) // ajoute à la pile le NG (rang du tableau)
                    {
                        Pile.Add(2 * Pile[0] + 1);
                        this.textBox2.Text = this.textBox2.Text + ValeurNG.ToString() + " ";
                        cpt++;
                        affichePile();
                        if (commentaires) { MessageBox.Show("Pile + : Ajout du noeud Gauche " + ValeurNG.ToString()); }
                    }
                    if (ExisteND(Pile[0])) // ajoute à la pile le ND
                    {
                        Pile.Add(2 * Pile[0] + 2);
                        this.textBox2.Text = this.textBox2.Text + ValeurND.ToString() + " ";
                        cpt++;
                        affichePile();
                        if (commentaires) { MessageBox.Show("Pile + : Ajout du noeud Droit " + ValeurND.ToString()); }
                    }
                    Memo = Pile[0];
                    Pile.RemoveAt(0);  // vire le premier élément de la pile
                    cm++;
                    affichePile();
                    if (commentaires) { MessageBox.Show("Pile - : Suppression du noeud de bas de pile : " + Memo.ToString()); }
                }
                c = cpt; // indique au prochain tour de boucle le nombre de noeuds ajoutés donc de dépilages
                this.textBox2.Text = this.textBox2.Text + "\r\n";
                if (commentaires)
                { MessageBox.Show(" Nb Noeuds ajoutés = nb tours de boucle = " + c.ToString() + "    Noeuds supprimés = " + cm.ToString()); }
                if (cpt == 0)
                {
                    if (commentaires)
                    {
                        MessageBox.Show(" pas de fils => Arret de l'exploration");
                    }
                    fin = true;
                }  // fin si pas de noeud ajouté            
            } while (!fin);

        }
        private void affichePile()
        {
            this.listBox1.Items.Clear();
            this.listBox1.Visible = true;
            /*  foreach (int i in Pile)
              {
                  this.listBox1.Items.Add(Pile[i]);
              }*/
            for (int i = 0; i <= Pile.Count - 1; i++)
            { this.listBox1.Items.Add(Pile[i]); }

        }

        int ValeurNG, ValeurND,NG,ND;

        bool ExisteNG(int Ntab)
        {
            NG= 2 * Ntab +1;
            if ((2 * Ntab) + 1 >= 33) { return false; }
            ValeurNG = Arbre[2 * Ntab + 1];
            if (ValeurNG != -1)
            {
                if (commentaires)
                {
                    MessageBox.Show("Le fils gauche de " + Ntab.ToString() + " est " + ValeurNG.ToString());

                }
                return true;
            }
            else
            { return false; }
        }

        bool ExisteND(int Ntab)
        {
            if ((2 * Ntab) + 2 >= 33) { return false; }
            ValeurND = Arbre[2 * Ntab + 2];
            if (ValeurND != -1)
            {
                if (commentaires)
                {
                    MessageBox.Show("Le fils droit de " + Ntab.ToString() + " est " + ValeurND.ToString());
                }
                return true;
            }
            else { return false; };
        }
        private void ExploreArbreBinaire(int N)// parcours en profondeur
        {    if (commentaires)
            {
                MessageBox.Show("Expore arbre binaire noeud " + N.ToString());
            }
            if (ExisteNG(N) )
                {
                textBox2.Text = textBox2.Text + " => " + ValeurNG.ToString();
                ExploreArbreBinaire(ValeurNG);
                }
            else
            {
                if (ExisteND(N))
                {
                    textBox2.Text = textBox2.Text + " => " + ValeurND.ToString();
                    ExploreArbreBinaire(ValeurND);
                }
            }
        }

   
        List<int> Pile = new List<int>();



        private void btPrefixé_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            ExploreArbreBinaire(0); // 0 racine , 0 sens (descente)
        }
        private bool commentaires;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { commentaires = true; } else { commentaires = false; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 32; i++)
            {
                Arbre[i] = i + 200;

            }
            /*   Arbre[3] = -1;
               Arbre[2] = -1;
               Arbre[4] = -1;*/
            AfficheTablo();
            affichePile();

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)  // si le contenu du texbox est validé par ENTER
            {
                if (!RacineOk)
                {  // cas ou le noeud origine n'est pas créé
                    Arbre[0] = int.Parse(textBox1.Text);
                    AfficheTablo();
                    label1.Text = "Pour créer un noeud cliquez le père dans la liste puis indiquez la valeur puis Valider";
                    label2.Text = "Valeur du noeud";
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
                    ValeurDuNoeud = int.Parse(textBox1.Text);
                    noeudPere = int.Parse(tbChoixNoeud.Text);
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
                    {
                        if (Arbre[2 * k + 2] == -1)
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
