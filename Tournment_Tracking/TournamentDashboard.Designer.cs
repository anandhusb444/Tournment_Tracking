namespace Tournment_Tracking
{
    partial class H1Tournament
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainHead = new System.Windows.Forms.Label();
            this.H2LoadExistngTournament = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tournamentShowBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // MainHead
            // 
            this.MainHead.AutoSize = true;
            this.MainHead.Location = new System.Drawing.Point(128, 9);
            this.MainHead.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.MainHead.MinimumSize = new System.Drawing.Size(183, 0);
            this.MainHead.Name = "MainHead";
            this.MainHead.Size = new System.Drawing.Size(210, 24);
            this.MainHead.TabIndex = 0;
            this.MainHead.Text = "Tournament Dashboard";
            // 
            // H2LoadExistngTournament
            // 
            this.H2LoadExistngTournament.AutoSize = true;
            this.H2LoadExistngTournament.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.H2LoadExistngTournament.Location = new System.Drawing.Point(148, 52);
            this.H2LoadExistngTournament.Name = "H2LoadExistngTournament";
            this.H2LoadExistngTournament.Size = new System.Drawing.Size(163, 16);
            this.H2LoadExistngTournament.TabIndex = 1;
            this.H2LoadExistngTournament.Text = "Load Existing Tournament";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(168, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Load tournament";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(100, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(257, 45);
            this.button2.TabIndex = 3;
            this.button2.Text = "Create Tournament";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tournamentShowBox
            // 
            this.tournamentShowBox.FormattingEnabled = true;
            this.tournamentShowBox.Location = new System.Drawing.Point(168, 80);
            this.tournamentShowBox.Name = "tournamentShowBox";
            this.tournamentShowBox.Size = new System.Drawing.Size(121, 32);
            this.tournamentShowBox.TabIndex = 4;
            this.tournamentShowBox.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // H1Tournament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 269);
            this.Controls.Add(this.tournamentShowBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.H2LoadExistngTournament);
            this.Controls.Add(this.MainHead);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "H1Tournament";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MainHead;
        private System.Windows.Forms.Label H2LoadExistngTournament;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox tournamentShowBox;
    }
}

