namespace TestUCModel
{
    partial class Form9
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
            this.Short = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Complete = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Objectives = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Scope = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ADZ = new System.Windows.Forms.TextBox();
            this.RelatedUC = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Short
            // 
            this.Short.Location = new System.Drawing.Point(27, 93);
            this.Short.Name = "Short";
            this.Short.Size = new System.Drawing.Size(556, 71);
            this.Short.TabIndex = 2;
            this.Short.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Short description";
            // 
            // Complete
            // 
            this.Complete.Location = new System.Drawing.Point(27, 199);
            this.Complete.Name = "Complete";
            this.Complete.Size = new System.Drawing.Size(556, 96);
            this.Complete.TabIndex = 4;
            this.Complete.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Complete description";
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(27, 42);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(269, 20);
            this.ID.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "ID of Use Case";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Objective(s)";
            // 
            // Objectives
            // 
            this.Objectives.Location = new System.Drawing.Point(27, 329);
            this.Objectives.Name = "Objectives";
            this.Objectives.Size = new System.Drawing.Size(269, 48);
            this.Objectives.TabIndex = 9;
            this.Objectives.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(311, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Scope";
            // 
            // Scope
            // 
            this.Scope.Location = new System.Drawing.Point(314, 329);
            this.Scope.Name = "Scope";
            this.Scope.Size = new System.Drawing.Size(269, 48);
            this.Scope.TabIndex = 11;
            this.Scope.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 391);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Area/Domain/Zone";
            // 
            // ADZ
            // 
            this.ADZ.Location = new System.Drawing.Point(29, 407);
            this.ADZ.Name = "ADZ";
            this.ADZ.Size = new System.Drawing.Size(267, 20);
            this.ADZ.TabIndex = 14;
            // 
            // RelatedUC
            // 
            this.RelatedUC.Location = new System.Drawing.Point(316, 407);
            this.RelatedUC.Name = "RelatedUC";
            this.RelatedUC.Size = new System.Drawing.Size(267, 20);
            this.RelatedUC.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(313, 391);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Related Use Cases";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(508, 446);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 493);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.RelatedUC);
            this.Controls.Add(this.ADZ);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Scope);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Objectives);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Complete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Short);
            this.Name = "Form9";
            this.Text = "New Use Case";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox ID;
        public System.Windows.Forms.RichTextBox Short;
        public System.Windows.Forms.RichTextBox Complete;
        public System.Windows.Forms.RichTextBox Objectives;
        public System.Windows.Forms.RichTextBox Scope;
        public System.Windows.Forms.TextBox ADZ;
        public System.Windows.Forms.TextBox RelatedUC;
    }
}