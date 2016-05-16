namespace TeachMe
{
    partial class FormMain
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
            this.btnGo = new System.Windows.Forms.Button();
            this.btnWordlists = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnInstructuions = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(96, 88);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnWordlists
            // 
            this.btnWordlists.Location = new System.Drawing.Point(96, 127);
            this.btnWordlists.Name = "btnWordlists";
            this.btnWordlists.Size = new System.Drawing.Size(75, 23);
            this.btnWordlists.TabIndex = 1;
            this.btnWordlists.Text = "Wordlists";
            this.btnWordlists.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnWordlists.UseVisualStyleBackColor = true;
            this.btnWordlists.Click += new System.EventHandler(this.btnWordlists_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(96, 255);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnInstructuions
            // 
            this.btnInstructuions.Location = new System.Drawing.Point(96, 167);
            this.btnInstructuions.Name = "btnInstructuions";
            this.btnInstructuions.Size = new System.Drawing.Size(75, 23);
            this.btnInstructuions.TabIndex = 3;
            this.btnInstructuions.Text = "Instructions";
            this.btnInstructuions.UseVisualStyleBackColor = true;
            this.btnInstructuions.Click += new System.EventHandler(this.btnInstructuions_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 306);
            this.ControlBox = false;
            this.Controls.Add(this.btnInstructuions);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnWordlists);
            this.Controls.Add(this.btnGo);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeachMe";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnWordlists;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnInstructuions;
    }
}