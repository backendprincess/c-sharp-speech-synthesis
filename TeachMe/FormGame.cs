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
using System.Speech.Synthesis;

namespace TeachMe
{
    public partial class FormGame : Form
    {
        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        private static List<string> words = new List<string>();
        private Dictionary<int, bool> submitted = new Dictionary<int, bool>();
        private int correct = 0;
        private int cursor = 0;

        public FormGame()
        {
            InitializeComponent();
        }
        
        private string filename;
        public void setFilename(string filename) { this.filename = filename; }
        
        private void Form1_Load(object sender, EventArgs e) { }

        public void Show1()
        {
            this.Show();
            clearAll();
            fillWordlist();
            richTextBox1.AppendText("1/" + words.Count);
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void clearAll()
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            words.Clear();
            submitted.Clear();
            correct = 0;
            cursor = 0;
        }

        private void fillWordlist()
        {
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Wordlists\\"));
            List<Word> wordlist = Serialization.DeserializeXML(path + filename + ".txt");
            foreach (var word in wordlist)
            {
                words.Add(word.ToString());
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            cursor = cursor > 0 ? (--cursor) : cursor;
            navBtnClicked_Repaint();
        }

        private void navBtnClicked_Repaint()
        {
            if (submitted.Keys.Contains(cursor))
            {
                bool isCorrectAnswer;
                submitted.TryGetValue(cursor, out isCorrectAnswer);
                richTextBox1.Clear();
                richTextBox1.AppendText((cursor + 1) + "/" + words.Count);
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
                richTextBox1.AppendText("\nYour word: " + words.ElementAt(cursor));
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

                if (isCorrectAnswer == true)
                {
                    richTextBox1.AppendText("\nCorrect!");
                }
                else
                {
                    richTextBox1.AppendText("\nWrong!");
                }
                btnSubmit.Enabled = false;
            }
            else
            {
                btnSubmit.Enabled = true;
                richTextBox1.Clear();
                richTextBox1.AppendText((cursor + 1) + "/" + words.Count);
            }
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox2.Clear();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            cursor = cursor < (words.Count - 1) ? (++cursor) : cursor;
            navBtnClicked_Repaint();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            synthesizer.SpeakAsync(words.ElementAt(cursor));
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string sanitized = sanitize(richTextBox2.Text);
            if (sanitized.Length > 0)
            {
                richTextBox1.Clear();
                richTextBox1.AppendText((cursor + 1) + "/" + words.Count);
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
                richTextBox1.AppendText("\nYour word: " + words.ElementAt(cursor));
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

                if (words.ElementAt(cursor).ToLower().Equals(sanitized))
                {
                    richTextBox1.AppendText("\nCorrect!");
                    ++correct;
                    submitted.Add(cursor, true);
                }
                else
                {
                    richTextBox1.AppendText("\nWrong!");
                    submitted.Add(cursor, false);
                }
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
                btnSubmit.Enabled = false;
            }
        }

        private string sanitize(string input)
        {
            string result = input.ToLower();
            return result;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel the test?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Hide();
                Boss.getFormMain().Show1();
            }
        }

        private void btnSubmitAll_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to finish the test?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Your result: " + correct + " out of " + words.Count);
                this.Hide();
                Boss.getFormMain().Show1();
            }
        }
    }
}
