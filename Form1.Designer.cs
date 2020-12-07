
namespace Arbres
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.tbChoixNoeud = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtValideChoix = new System.Windows.Forms.Button();
            this.RBAnnuler = new System.Windows.Forms.RadioButton();
            this.RbND = new System.Windows.Forms.RadioButton();
            this.RbbNG = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.BtParcoursEnLargeur = new System.Windows.Forms.Button();
            this.btPrefixé = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tbNode = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(388, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Création arbre binaire à 5 niveaux";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(54, 162);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 22);
            this.textBox1.TabIndex = 3;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(407, 131);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(121, 276);
            this.listBox1.TabIndex = 4;
            this.listBox1.Visible = false;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(611, 3);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(49, 548);
            this.listBox2.TabIndex = 5;
            // 
            // tbChoixNoeud
            // 
            this.tbChoixNoeud.Location = new System.Drawing.Point(407, 423);
            this.tbChoixNoeud.Name = "tbChoixNoeud";
            this.tbChoixNoeud.Size = new System.Drawing.Size(121, 22);
            this.tbChoixNoeud.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtValideChoix);
            this.panel1.Controls.Add(this.RBAnnuler);
            this.panel1.Controls.Add(this.RbND);
            this.panel1.Controls.Add(this.RbbNG);
            this.panel1.Location = new System.Drawing.Point(38, 207);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 259);
            this.panel1.TabIndex = 7;
            this.panel1.Visible = false;
            // 
            // BtValideChoix
            // 
            this.BtValideChoix.Location = new System.Drawing.Point(60, 176);
            this.BtValideChoix.Name = "BtValideChoix";
            this.BtValideChoix.Size = new System.Drawing.Size(197, 23);
            this.BtValideChoix.TabIndex = 3;
            this.BtValideChoix.Text = "Valider le choix";
            this.BtValideChoix.UseVisualStyleBackColor = true;
            this.BtValideChoix.Click += new System.EventHandler(this.BtValideChoix_Click);
            // 
            // RBAnnuler
            // 
            this.RBAnnuler.AutoSize = true;
            this.RBAnnuler.Checked = true;
            this.RBAnnuler.Location = new System.Drawing.Point(60, 132);
            this.RBAnnuler.Name = "RBAnnuler";
            this.RBAnnuler.Size = new System.Drawing.Size(78, 21);
            this.RBAnnuler.TabIndex = 2;
            this.RBAnnuler.TabStop = true;
            this.RBAnnuler.Text = "Annuler";
            this.RBAnnuler.UseVisualStyleBackColor = true;
            // 
            // RbND
            // 
            this.RbND.AutoSize = true;
            this.RbND.Location = new System.Drawing.Point(60, 91);
            this.RbND.Name = "RbND";
            this.RbND.Size = new System.Drawing.Size(197, 21);
            this.RbND.TabIndex = 1;
            this.RbND.Text = "Changer ND (Noeud Droit)";
            this.RbND.UseVisualStyleBackColor = true;
            // 
            // RbbNG
            // 
            this.RbbNG.AutoSize = true;
            this.RbbNG.Location = new System.Drawing.Point(60, 53);
            this.RbbNG.Name = "RbbNG";
            this.RbbNG.Size = new System.Drawing.Size(218, 21);
            this.RbbNG.TabIndex = 0;
            this.RbbNG.Text = "Changer NG (Noeud Gauche)";
            this.RbbNG.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(696, 223);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(404, 276);
            this.textBox2.TabIndex = 8;
            // 
            // BtParcoursEnLargeur
            // 
            this.BtParcoursEnLargeur.Location = new System.Drawing.Point(764, 12);
            this.BtParcoursEnLargeur.Name = "BtParcoursEnLargeur";
            this.BtParcoursEnLargeur.Size = new System.Drawing.Size(259, 37);
            this.BtParcoursEnLargeur.TabIndex = 9;
            this.BtParcoursEnLargeur.Text = "Parcours en largeur";
            this.BtParcoursEnLargeur.UseVisualStyleBackColor = true;
            this.BtParcoursEnLargeur.Click += new System.EventHandler(this.BtParcoursEnLargeur_Click);
            // 
            // btPrefixé
            // 
            this.btPrefixé.Location = new System.Drawing.Point(696, 55);
            this.btPrefixé.Name = "btPrefixé";
            this.btPrefixé.Size = new System.Drawing.Size(327, 34);
            this.btPrefixé.TabIndex = 10;
            this.btPrefixé.Text = "Parcours en profondeur préfixé Récursif";
            this.btPrefixé.UseVisualStyleBackColor = true;
            this.btPrefixé.Click += new System.EventHandler(this.btPrefixé_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(220, 528);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(764, 505);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(259, 39);
            this.button3.TabIndex = 12;
            this.button3.Text = "Chargement d\'un arbre test";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(927, 196);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(146, 21);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "Avec commentaire";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(696, 96);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(327, 34);
            this.button4.TabIndex = 14;
            this.button4.Text = "Parcours en profondeur préfixé avec pile";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(38, 505);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(121, 97);
            this.treeView1.TabIndex = 15;
            this.treeView1.Click += new System.EventHandler(this.treeView1_Click);
            // 
            // tbNode
            // 
            this.tbNode.Location = new System.Drawing.Point(211, 558);
            this.tbNode.Name = "tbNode";
            this.tbNode.Size = new System.Drawing.Size(100, 22);
            this.tbNode.TabIndex = 16;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(0, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 17;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(220, 587);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 18;
            this.button6.Text = "voir";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(696, 136);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(327, 34);
            this.button7.TabIndex = 19;
            this.button7.Text = "Parcours en profondeur suffixé récursif";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 653);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.tbNode);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btPrefixé);
            this.Controls.Add(this.BtParcoursEnLargeur);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbChoixNoeud);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.TextBox tbChoixNoeud;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtValideChoix;
        private System.Windows.Forms.RadioButton RBAnnuler;
        private System.Windows.Forms.RadioButton RbND;
        private System.Windows.Forms.RadioButton RbbNG;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button BtParcoursEnLargeur;
        private System.Windows.Forms.Button btPrefixé;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox tbNode;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}

