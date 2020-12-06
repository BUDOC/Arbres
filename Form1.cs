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
        private void InitTablo()
        {
            for (int i = 0; i < 33; i++) //initialise le tableau
            {
                Arbre[i] = -1;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = (Math.Pow(2, 5) + 1).ToString(); //33           
            InitTablo();
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

        int ValeurNG, ValeurND, NG, ND;

        bool ExisteNG(int Ntab)
        {
            NG = 2 * Ntab + 1;
            if (NG > 30) { return false; }
            ValeurNG = Arbre[2 * Ntab + 1];
            if (ValeurNG != -1)
            {
                if (commentaires)
                {
                  //  MessageBox.Show("Le fils gauche de " + Ntab.ToString() + " est " + ValeurNG.ToString());
                }
                return true;
            }
            else
            { return false; }
        }

        bool ExisteND(int Ntab)
        {
            ND = (2 * Ntab) + 2;
            if (ND > 30) { return false; }
            ValeurND = Arbre[2 * Ntab + 2];
            if (ValeurND != -1)
            {
                if (commentaires)
                {
                  //  MessageBox.Show("Le fils droit de " + Ntab.ToString() + " est " + ValeurND.ToString());
                }
                return true;
            }
            else { return false; };
        }
        private void ExploreArbreBinaire(int N)// parcours en profondeur Recursif
        {
            if (commentaires)
            {
                MessageBox.Show("Expore arbre binaire noeud " + N.ToString());
            }
            // condition d'arret
            if (!ExisteND(N) && !ExisteNG(N)) { return; }
            if (ExisteNG(N))
            {
                //   textBox2.Text = textBox2.Text + " => " + ValeurNG.ToString();
                //  ExploreArbreBinaire(NG);
                String toto = ValeurNG.ToString();

                ExploreArbreBinaire(NG);
                textBox2.Text = textBox2.Text + " => " + toto;// ValeurNG.ToString();
                
            }
            if (ExisteND(N))
            {
                /*  textBox2.Text = textBox2.Text + " => " + ValeurND.ToString();
                  ExploreArbreBinaire(ND);
                */
                String toto = ValeurND.ToString();

                ExploreArbreBinaire(ND);
                textBox2.Text = textBox2.Text + " => " + toto;
            }
        }

        private void DepileHaut()
        {
            int plgp;
            plgp = Pile.Count - 1;
            if (plgp < 0)
            {
                MessageBox.Show("Dépilage par le bas impossible : Pile vide"); return;
            }
            Pile.RemoveAt(plgp);
            affichePile();
        }
        private void PP2(int N)
        {
            int lgp;
            Pile.Clear();
            textBox2.Clear();
            Pile.Add(N); // Ajoute Racine
            textBox2.Text = Arbre[N].ToString() ;
            affichePile();

            do
            {
                lgp = Pile.Count - 1;
                N = Pile[lgp];
                // les 3 cas ci-dessous s'excluent mutuellement
                if (ExisteNG(N))  // fils à gauche existe
                {
                    textBox2.Text = textBox2.Text + " => " + ValeurNG.ToString();
                    Pile.Add(NG); // NG en haut de pile
                    affichePile();
                    if (commentaires) { MessageBox.Show("NG exite donc on l'Ajoute  à la pile " + ValeurNG.ToString()); }
                }
                if (!ExisteNG(N) && ExisteND(N))
                {
                    DepileHaut();
                    Pile.Add(ND);
                    textBox2.Text = textBox2.Text + " => " + ValeurND.ToString();
                    affichePile();
                    if (commentaires) { MessageBox.Show("Pas de NG et un ND => on dépile et on Ajoute ce ND à la pile " + ValeurND.ToString()); }
                }

                if (!ExisteNG(N) && !ExisteND(N))
                {
                    if (commentaires)
                    {
                        MessageBox.Show("Pas de NG ni de ND (feuille)");
                    }

                     DepileHaut();
                    lgp = Pile.Count - 1;
                    if (lgp >= 0) { N = Pile[lgp]; } else { MessageBox.Show("Exploration terminée"); break; }
                   
                    N = Pile[lgp];
                    
                        if (ExisteND(N))  // Remplacer Père par fils droit si le père possède un fils droit
                        {
                            DepileHaut();
                            Pile.Add(ND);
                            textBox2.Text = textBox2.Text + " => " + ValeurND.ToString();

                            if (commentaires)
                            {
                                MessageBox.Show("Comme le père possédait un fils droit on remplace le père par ce fils droit");
                            }
                        }

                        affichePile();
                        if (commentaires)
                        {
                            MessageBox.Show("Remplacer Père par fils droit si noeud droit sinon dépiler haut 2 fois");
                        }
                  
                }
                lgp = Pile.Count - 1;
                if (lgp >= 0) { N = Pile[lgp]; } else { MessageBox.Show("Exploration terminée"); }
            } while (lgp >= 0);
        }

        private void Infixe(int N)
        {

        }

        List<int> Pile = new List<int>();



        private void btPrefixé_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            ExploreArbreBinaire(0); // 0 racine , 0 sens (descente)
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PP2(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.button3.PerformClick();
            this.button3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.treeView1.Nodes.Add(tbNode.Text);
           
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.tbNode.Text = this.treeView1.SelectedNode.Text;
        }

        private bool commentaires;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { commentaires = true; } else { commentaires = false; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InitTablo();
            for (int i = 0; i <= 30; i++)
            {
                Arbre[i] = i + 200;

            }
          //  Arbre[1] = -1;
           // Arbre[5] = -1;
          //  Arbre[6] = -1;
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
