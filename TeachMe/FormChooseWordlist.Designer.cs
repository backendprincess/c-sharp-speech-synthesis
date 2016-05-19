namespace TeachMe
{
    partial class FormChooseWordlist
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
            this.listBoxWordlists = new System.Windows.Forms.ListBox();
            this.labelChoose = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.listBoxPreview = new System.Windows.Forms.ListBox();
            this.labelPreview = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxWordlists
            // 
            this.listBoxWordlists.FormattingEnabled = true;
            this.listBoxWordlists.Location = new System.Drawing.Point(12, 66);
            this.listBoxWordlists.Name = "listBoxWordlists";
            this.listBoxWordlists.Size = new System.Drawing.Size(124, 199);
            this.listBoxWordlists.TabIndex = 0;
            this.listBoxWordlists.SelectedIndexChanged += new System.EventHandler(this.listBoxWordlists_SelectedIndexChanged);
            // 
            // labelChoose
            // 
            this.labelChoose.AutoSize = true;
            this.labelChoose.Location = new System.Drawing.Point(12, 29);
            this.labelChoose.Name = "labelChoose";
            this.labelChoose.Size = new System.Drawing.Size(130, 13);
            this.labelChoose.TabIndex = 1;
            this.labelChoose.Text = "Please, choose a wordlist:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 271);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(124, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(142, 271);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // listBoxPreview
            // 
            this.listBoxPreview.FormattingEnabled = true;
            this.listBoxPreview.Location = new System.Drawing.Point(142, 66);
            this.listBoxPreview.Name = "listBoxPreview";
            this.listBoxPreview.Size = new System.Drawing.Size(130, 199);
            this.listBoxPreview.TabIndex = 4;
            // 
            // labelPreview
            // 
            this.labelPreview.AutoSize = true;
            this.labelPreview.Location = new System.Drawing.Point(190, 29);
            this.labelPreview.Name = "labelPreview";
            this.labelPreview.Size = new System.Drawing.Size(48, 13);
            this.labelPreview.TabIndex = 5;
            this.labelPreview.Text = "Preview:";
            // 
            // FormChooseWordlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 306);
            this.ControlBox = false;
            this.Controls.Add(this.labelPreview);
            this.Controls.Add(this.listBoxPreview);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelChoose);
            this.Controls.Add(this.listBoxWordlists);
            this.Name = "FormChooseWordlist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeachMe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxWordlists;
        private System.Windows.Forms.Label labelChoose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox listBoxPreview;
        private System.Windows.Forms.Label labelPreview;
    }
}