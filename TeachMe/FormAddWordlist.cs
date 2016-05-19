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
    public partial class FormAddWordlist : Form
    {
        public FormAddWordlist()
        {
            InitializeComponent();
        }

        private void FormAddWordlist_Load(object sender, EventArgs e) {  }

        public void initAndShow()
        {
            textBoxTitle.Clear();
            textBoxWord.Clear();
            listBoxWordlist.Items.Clear();
            this.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string word = textBoxWord.Text;
            if (word.Length > 0)
            {
                if (ifNotAlreadyAdded(word))
                {
                    listBoxWordlist.Items.Add(new Word(word));
                    textBoxWord.Clear();
                }
                else
                {
                    textBoxWord.Clear();
                    MessageBox.Show("This word is already added!");
                }
            }
        }

        private bool ifNotAlreadyAdded(string word)
        {
            bool res = true;
            foreach (var i in listBoxWordlist.Items)
            {
                if (i.ToString().Equals(word))
                {
                    res = false;
                    break;
                }
            }
            return res;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Boss.getFormWordlists().ShowAndRepaint();
        }

        private string oldPath;
        private void btnOK_Click(object sender, EventArgs e)
        {
            List<Word> words = getWords();
            if (words.Capacity > 0)
            {
                string title = textBoxTitle.Text.Length > 0 ? textBoxTitle.Text : ("Untitled" + (getCounter()+1));
                string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ("..\\..\\Wordlists\\" + title + ".txt")));
                if (File.Exists(oldPath))
                {
                    File.Delete(oldPath);
                }
                Serialization.SerializeXML(words, path);
            }
            this.Hide();
            Boss.getFormWordlists().ShowAndRepaint();
        }
        private string getFilename(string path)
        {
            int start = path.LastIndexOf("\\") + 1;
            int nameLength = path.Substring(start).IndexOf(".");
            return path.Substring(start, nameLength);
        }

        private int getCounter()
        {
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Wordlists\\"));
            string[] fileArray = Directory.GetFiles(path);
            int maxIndex = 1;
            int buff = 0;

            foreach (var file in fileArray)
            {
                if (getFilename(file).StartsWith("Untitled"))
                {
                    Int32.TryParse(getFilename(file).Substring(7), out buff);
                    maxIndex = maxIndex > buff ? maxIndex : buff;
                }
            }
            return maxIndex;
        }

        private List<Word> getWords()
        {
            List<Word> content = new List<Word>();
            foreach(var item in listBoxWordlist.Items)
            {
                content.Add(new Word(item.ToString()));
            }
            return content;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxWordlist.GetItemText(listBoxWordlist.SelectedItem).Length > 0)
            {
                listBoxWordlist.Items.Remove(listBoxWordlist.SelectedItem);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string selectedWord = listBoxWordlist.GetItemText(listBoxWordlist.SelectedItem);
            if (selectedWord.Length > 0)
            {
                listBoxWordlist.Items.Remove(listBoxWordlist.SelectedItem);
                textBoxWord.Text = selectedWord;
            }

        }

        public void editWordlist(string filename)
        {
            oldPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ("..\\..\\Wordlists\\" + filename + ".txt")));
            List<Word> words = Serialization.DeserializeXML(oldPath);
            textBoxTitle.Text = filename;
            listBoxWordlist.Items.Clear();
            listBoxWordlist.Items.AddRange(words.ToArray());
        }
    }
}
