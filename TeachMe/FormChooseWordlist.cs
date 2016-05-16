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
using System.Xml.Serialization;

namespace TeachMe
{
    public partial class FormChooseWordlist : Form
    {
        public FormChooseWordlist()
        {
            InitializeComponent();
        }

        private void FormChooseWordlist_Load(object sender, EventArgs e)
        {
            //repaintListBox();
        }

        public void Show1()
        {
            this.Show();
            repaintListBox();
        }

        private void listBoxWordlists_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Wordlists\\"));
            List<Word> words = Serialization.DeserializeXML(path + listBoxWordlists.GetItemText(listBoxWordlists.SelectedItem) + ".txt");
            listBoxPreview.Items.Clear();
            listBoxPreview.Items.AddRange(words.ToArray());
        }

        private void repaintListBox()
        {
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Wordlists\\"));
            string[] fileArray = Directory.GetFiles(path);
            List<string> wordlists = new List<string>();
            foreach (var filepath in fileArray)
            {
                wordlists.Add(getFilename(filepath));
            }
            listBoxWordlists.Items.Clear();
            listBoxPreview.Items.Clear();
            listBoxWordlists.Items.AddRange(wordlists.ToArray());
        }

        private string getFilename(string path)
        {
            int start = path.LastIndexOf("\\") + 1;
            int nameLength = path.Substring(start).IndexOf(".");
            return path.Substring(start, nameLength);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Boss.getFormMain().Show1();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Boss.getFormGame().setFilename(listBoxWordlists.GetItemText(listBoxWordlists.SelectedItem));
            this.Hide();
            Boss.getFormGame().Show1();
        }
    }
}
