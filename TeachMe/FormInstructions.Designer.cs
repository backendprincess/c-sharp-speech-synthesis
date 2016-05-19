namespace TeachMe
{
    partial class FormInstructions
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
            this.richTextBoxInstructions = new System.Windows.Forms.RichTextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBoxInstructions.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxInstructions.Name = "richTextBox1";
            this.richTextBoxInstructions.Size = new System.Drawing.Size(260, 253);
            this.richTextBoxInstructions.TabIndex = 0;
            this.richTextBoxInstructions.Text = "";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(90, 271);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(98, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back to menu";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FormInstructions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 306);
            this.ControlBox = false;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.richTextBoxInstructions);
            this.Name = "FormInstructions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeachMe";
            this.Load += new System.EventHandler(this.FormInstructions_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxInstructions;
        private System.Windows.Forms.Button btnBack;
    }
}