using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeachMe
{
    public partial class FormMain : Form
    {        
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Boss.getFormMain().Hide();
            Boss.getFormChooseWordlist().ShowAndRepaint();
        }

        private void btnWordlists_Click(object sender, EventArgs e)
        {
            Boss.getFormMain().Hide();
            Boss.getFormWordlists().ShowAndRepaint();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogEnsureExit = MessageBox.Show("Are you sure you want to quit?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogEnsureExit == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void btnInstructuions_Click(object sender, EventArgs e)
        {
            this.Hide();
            Boss.getFormInstructions().Show1();
        }
    }
}
