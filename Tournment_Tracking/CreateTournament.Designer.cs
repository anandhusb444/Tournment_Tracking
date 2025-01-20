namespace Tournment_Tracking
{
    partial class CreateTournament
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
            this.label1 = new System.Windows.Forms.Label();
            this.textboxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tournamentFee = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.selectTeamBox = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.prizeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.deletebtn1 = new System.Windows.Forms.Button();
            this.deletebtn2 = new System.Windows.Forms.Button();
            this.addTournament = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create Tournament";
            // 
            // textboxName
            // 
            this.textboxName.Location = new System.Drawing.Point(15, 77);
            this.textboxName.Name = "textboxName";
            this.textboxName.Size = new System.Drawing.Size(209, 20);
            this.textboxName.TabIndex = 1;
            this.textboxName.Leave += new System.EventHandler(this.textboxName_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tournament Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Entry Fee";
            // 
            // tournamentFee
            // 
            this.tournamentFee.Location = new System.Drawing.Point(15, 135);
            this.tournamentFee.Name = "tournamentFee";
            this.tournamentFee.Size = new System.Drawing.Size(209, 20);
            this.tournamentFee.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Select Team";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 31);
            this.button1.TabIndex = 7;
            this.button1.Text = "Add Team";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(136, 228);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 33);
            this.button2.TabIndex = 8;
            this.button2.Text = "Create Prize";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // selectTeamBox
            // 
            this.selectTeamBox.FormattingEnabled = true;
            this.selectTeamBox.Location = new System.Drawing.Point(15, 187);
            this.selectTeamBox.Name = "selectTeamBox";
            this.selectTeamBox.Size = new System.Drawing.Size(209, 21);
            this.selectTeamBox.TabIndex = 9;
            this.selectTeamBox.SelectedIndexChanged += new System.EventHandler(this.selectTeamBox_SelectedIndexChanged);
            this.selectTeamBox.Click += new System.EventHandler(this.selectTeamBox_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(292, 38);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(220, 117);
            this.textBox3.TabIndex = 10;
            // 
            // prizeTextBox
            // 
            this.prizeTextBox.Location = new System.Drawing.Point(289, 190);
            this.prizeTextBox.Multiline = true;
            this.prizeTextBox.Name = "prizeTextBox";
            this.prizeTextBox.Size = new System.Drawing.Size(223, 112);
            this.prizeTextBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(289, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Teams/Players";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(289, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Prizes";
            // 
            // deletebtn1
            // 
            this.deletebtn1.Location = new System.Drawing.Point(518, 38);
            this.deletebtn1.Name = "deletebtn1";
            this.deletebtn1.Size = new System.Drawing.Size(75, 36);
            this.deletebtn1.TabIndex = 14;
            this.deletebtn1.Text = "Delete";
            this.deletebtn1.UseVisualStyleBackColor = true;
            this.deletebtn1.Click += new System.EventHandler(this.deletebtn1_Click);
            // 
            // deletebtn2
            // 
            this.deletebtn2.Location = new System.Drawing.Point(518, 190);
            this.deletebtn2.Name = "deletebtn2";
            this.deletebtn2.Size = new System.Drawing.Size(75, 39);
            this.deletebtn2.TabIndex = 15;
            this.deletebtn2.Text = "Delete";
            this.deletebtn2.UseVisualStyleBackColor = true;
            this.deletebtn2.Click += new System.EventHandler(this.deletebtn2_Click);
            // 
            // addTournament
            // 
            this.addTournament.Location = new System.Drawing.Point(15, 279);
            this.addTournament.Name = "addTournament";
            this.addTournament.Size = new System.Drawing.Size(209, 23);
            this.addTournament.TabIndex = 16;
            this.addTournament.Text = "Create Tournament";
            this.addTournament.UseVisualStyleBackColor = true;
            this.addTournament.Click += new System.EventHandler(this.addTournament_Click);
            // 
            // CreateTournament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 328);
            this.Controls.Add(this.addTournament);
            this.Controls.Add(this.deletebtn2);
            this.Controls.Add(this.deletebtn1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.prizeTextBox);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.selectTeamBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tournamentFee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textboxName);
            this.Controls.Add(this.label1);
            this.Name = "CreateTournament";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.Text = "CreateTournament";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textboxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tournamentFee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox selectTeamBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox prizeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button deletebtn1;
        private System.Windows.Forms.Button deletebtn2;
        private System.Windows.Forms.Button addTournament;
    }
}