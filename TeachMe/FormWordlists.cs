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
    public partial class FormWordlists : Form
    {
        public FormWordlists()
        {
            InitializeComponent();
        }

        public void ShowAndRepaint()
        {
            this.Show();
            repaintListBox();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Boss.getFormWordlists().Hide();
            Boss.getFormMain().Show();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Wordlists\\"));
                List<Word> words = Serialization.DeserializeXML(path + listBox1.GetItemText(listBox1.SelectedItem) + ".txt");
                string wordlist = "";
                foreach (var word in words)
                {
                    wordlist += (word.ToString() + "\n");
                }
                MessageBox.Show(wordlist, listBox1.GetItemText(listBox1.SelectedItem));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Boss.getFormWordlists().Hide();
            Boss.getFormAddWordlist().initAndShow();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
             if (listBox1.SelectedItem != null)
            {
                DialogResult dialogResult = MessageBox.Show(("Are you sure you want to delete " + listBox1.GetItemText(listBox1.SelectedItem) + "?"), "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    deleteWordlist(listBox1.GetItemText(listBox1.SelectedItem));
                }
            }
        }

        private void deleteWordlist(string filename)
        {
            deleteFile(filename);
            repaintListBox();
        }

        private void deleteFile(string filename)
        {
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ("..\\..\\Wordlists\\" + filename + ".txt")));
            if (File.Exists(path))
            {                
                File.Delete(path);
            }
            // TODO: FileNotFound
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
            listBox1.Items.Clear();
            listBox1.Items.AddRange(wordlists.ToArray());
        }

        private string getFilename(string path)
        {
            int start = path.LastIndexOf("\\") + 1;
            int nameLength = path.Substring(start).IndexOf(".");
            return path.Substring(start, nameLength);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormAddWordlist faw = Boss.getFormAddWordlist();
            if (listBox1.SelectedItem != null)
            {
                faw.editWordlist(listBox1.GetItemText(listBox1.SelectedItem));
            }
            faw.Show();
            //this.Close();
            this.Hide();
        }
    }
}
