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
                if (Arbre[i] != -1) {
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
            bool NGE, NDE;
            Pile.Add(0);
            this.textBox2.Text = Arbre[0] + "\r\n";
            int c = 1;
            
            do
            {
                int cm = 0;
                int cpt = 0;
                for (int i = 0; i <= c - 1; i++) //de 0 à longueur de pile  corresponde aux noeud pères
                {
                    fin = false;
                    if (ExisteNG(Pile[i])) // ajoute à la pile le NG (rang du tableau)
                    {
                        Pile.Add(2*Pile[i]+1);
                        this.textBox2.Text = this.textBox2.Text + ValeurNG.ToString() + " ";
                        NGE = true;
                        cpt++;
                        affichePile();
                        MessageBox.Show("Pile +");
                    } else { NGE = false; }
                    if (ExisteND(Pile[i])) // ajoute à la pile le ND
                    {
                        Pile.Add(2*Pile[i]+2);
                        this.textBox2.Text = this.textBox2.Text + ValeurND.ToString() + " ";
                        NDE = true;
                       cpt++;
                        affichePile();
                        MessageBox.Show("Pile +");
                    } else { NDE = false; }
                    
                    Pile.RemoveAt(0);  // vire le premier élément de la pile
                    cm++;
                    affichePile();
                    MessageBox.Show("Pile -");
                }
                c = cpt;
                this.textBox2.Text = this.textBox2.Text + "\r\n";
                MessageBox.Show(" Nb Noeuds ajoutés "+c.ToString()+" Noeud supprimés : "+cm.ToString());
                if ( (NGE=false) && (NDE=false)) { fin = true; } 
               
            } while (!fin);

        }
        private void affichePile ()
        {
            this.listBox1.Items.Clear();
            this.listBox1.Visible = true;
            /*  foreach (int i in Pile)
              {
                  this.listBox1.Items.Add(Pile[i]);
              }*/
            for (int i = 0;i<= Pile.Count-1; i++ )
            { this.listBox1.Items.Add(Pile[i]); }

        }

        int ValeurNG, ValeurND;

        bool ExisteNG(int Ntab)
        {   if (2 * Ntab + 1 >= 33) { return false; }
            ValeurNG = Arbre[2 * Ntab + 1];
            if (ValeurNG!= -1) return true; else { return false; ; };           
        }
        bool ExisteND(int Ntab)
        {            
            if (2 * Ntab + 2 >= 33) { return false; }
            ValeurND = Arbre[2 * Ntab + 2];
            if (ValeurND != -1) return true; else { return false; } ;
        }
        private void ExploreArbreBinaire(int N, int sens) // 0 descente 1 Montéee
        {
            int c;
            affichePile();
            this.label1.Text = "sens";
            this.label2.Text = sens.ToString();
            MessageBox.Show("Entrée de ExploreArbrebinaire");
            Pile.Add(N);
           // MessageBox.Show("E2");            
            if (ExisteNG(N)&& sens==0) // descente et NG existe
            {
                textBox2.Text = textBox2.Text + Arbre[N].ToString() + "=> ";
                ExploreArbreBinaire(2*N+1,0);               
            }
            if (!ExisteNG(N) && sens == 0)// descente et pas de Noeud gauche
            {
                c = Pile.Count - 1;
                Pile.RemoveAt(c);                
                ExploreArbreBinaire(N , 1);
            }
                if ((sens==1)&& ExisteND(N))  // Remontée et ND existe
            {
                 c = Pile.Count - 1;
                Pile.RemoveAt(c);
                textBox2.Text = textBox2.Text + Arbre[N].ToString() + "=> ";
                 c = Pile.Count - 1;                
                Pile.Add(N);
                ExploreArbreBinaire(2 * N + 2,0);
            }
            if (!ExisteNG(N) && !ExisteND(N)) // aucun fils
            {                                  
                MessageBox.Show(N.ToString());                
                c = Pile.Count - 1;
                Pile.RemoveAt(c);// vire dernier element pile
                 c = Pile.Count - 1; // recupère Valeur du noeud Sup
                N = Pile[c];
                ExploreArbreBinaire(N - 2, 1);
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
                    if (a != -1 && Nivo <= 5 && exploreAgauche) //Fils G existe et condition "explore à geuche" vraie
                    {
                        Pile.Add(pos); //Empile
                        textBox2.Text = textBox2.Text +a.ToString() + "=> ";
                        Nivo++;
                         exploreAgauche = true; // renvoie continuer à explorer à gauche
                    }                                     
                        pos = 2 * Nivo + 2;
                        a = Arbre[pos];
                        if (a != -1 && Nivo <= 5 && exploreAgauche) // Fils droit existe Mais pas fils gauche et condition "expolre à gauche faussse'
                        {
                            Pile.Add(pos);//Empile
                            textBox2.Text = textBox2.Text + a.ToString() + "=> ";
                            exploreAgauche = false; // renvoie NE PAS continuer à explorer à gauche
                if (pos==Arbre.Length) { fin = true; } // fin du tableau atteinte
                            Nivo++;
                        }
                    if (Arbre[2*Nivo+1]==-1 && Arbre[2 * Nivo + 2] == -1)
                        {// Aucun fils
                            b = Pile.Count-1;
                            if (b < 0 || Nivo > 5) { fin = true; MessageBox.Show("condition de remontée"); } // condition de fin
                            // depile
                            Pile.RemoveAt(b);
                            exploreAgauche = false;
                            Nivo=Nivo-2;// renvoie NE PAS continuer à explorer à gauche                
                    }
            Explore(exploreAgauche);
                                           
        }

       // List<int> Pile2 = new List<int>();
        List<int> Pile = new List<int>();
        int Nivo = 0;
        int a = 0;
        int b = 0;
        int pos = 0;
       

        private void btPrefixé_Click(object sender, EventArgs e)
        {
            //Pile.Add(0);           
            // Explore(true);
            ExploreArbreBinaire(0,0);
        }

        private void button3_Click(object sender, EventArgs e)
        { 
            for (int i = 0; i <=32; i++)
            {
                Arbre[i] = i+100 ;
                
                
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
