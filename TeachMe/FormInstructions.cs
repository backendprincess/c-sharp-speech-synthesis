using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeachMe
{
    public partial class FormInstructions : Form
    {
        public FormInstructions()
        {
            InitializeComponent();
        }

        public void Show1()
        {
            this.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Boss.getFormMain().Show();
        }

        private void FormInstructions_Load(object sender, EventArgs e)
        {
            try
            {
                string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ("..\\..\\Instructions.txt")));
                using (StreamReader sr = new StreamReader(path))
                {
                    String line = sr.ReadToEnd();
                    richTextBoxInstructions.Text = line;
                }
            }
            catch (Exception exx)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(exx.Message);
            }
        }
    }
}
