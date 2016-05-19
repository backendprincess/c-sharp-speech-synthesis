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
        private Dictionary<int, bool> submittedItems = new Dictionary<int, bool>();
        private int nOfCorrectAnswers = 0;
        private int cursor = 0;

        public FormGame()
        {
            InitializeComponent();
        }
        
        private string filename;
        public void setFilename(string filename) { this.filename = filename; }
        
        public void startInitAndShow()
        {
            this.Show();
            clearAll();
            fillWordlist();
            richTextBoxWordCounter.AppendText("1/" + words.Count);
            richTextBoxWordCounter.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void clearAll()
        {
            richTextBoxWordCounter.Clear();
            richTextBoxResultEntered.Clear();
            words.Clear();
            submittedItems.Clear();
            nOfCorrectAnswers = 0;
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
            if (submittedItems.Keys.Contains(cursor))
            {
                bool isCorrectAnswer;
                submittedItems.TryGetValue(cursor, out isCorrectAnswer);
                richTextBoxWordCounter.Clear();
                richTextBoxWordCounter.AppendText((cursor + 1) + "/" + words.Count);
                richTextBoxWordCounter.SelectionAlignment = HorizontalAlignment.Center;
                richTextBoxWordCounter.AppendText("\nYour word: " + words.ElementAt(cursor));
                richTextBoxWordCounter.SelectionAlignment = HorizontalAlignment.Center;

                if (isCorrectAnswer == true)
                {
                    richTextBoxWordCounter.AppendText("\nCorrect!");
                }
                else
                {
                    richTextBoxWordCounter.AppendText("\nWrong!");
                }
                btnSubmit.Enabled = false;
            }
            else
            {
                btnSubmit.Enabled = true;
                richTextBoxWordCounter.Clear();
                richTextBoxWordCounter.AppendText((cursor + 1) + "/" + words.Count);
            }
            richTextBoxWordCounter.SelectionAlignment = HorizontalAlignment.Center;
            richTextBoxResultEntered.Clear();
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
            string sanitized = sanitize(richTextBoxResultEntered.Text);
            if (sanitized.Length > 0)
            {
                richTextBoxWordCounter.Clear();
                richTextBoxWordCounter.AppendText((cursor + 1) + "/" + words.Count);
                richTextBoxWordCounter.SelectionAlignment = HorizontalAlignment.Center;
                richTextBoxWordCounter.AppendText("\nYour word: " + words.ElementAt(cursor));
                richTextBoxWordCounter.SelectionAlignment = HorizontalAlignment.Center;

                if (words.ElementAt(cursor).ToLower().Equals(sanitized))
                {
                    richTextBoxWordCounter.AppendText("\nCorrect!");
                    ++nOfCorrectAnswers;
                    submittedItems.Add(cursor, true);
                }
                else
                {
                    richTextBoxWordCounter.AppendText("\nWrong!");
                    submittedItems.Add(cursor, false);
                }
                richTextBoxWordCounter.SelectionAlignment = HorizontalAlignment.Center;
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
            DialogResult dialogResultEnsureCancelling = MessageBox.Show("Are you sure you want to cancel the test?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResultEnsureCancelling == DialogResult.Yes)
            {
                this.Hide();
                Boss.getFormMain().Show();
            }
        }

        private void btnSubmitAll_Click(object sender, EventArgs e)
        {
            DialogResult dialogResultEnsureFinishing = MessageBox.Show("Are you sure you want to finish the test?", "Confirm", MessageBoxButtons.YesNo);
            if (dialogResultEnsureFinishing == DialogResult.Yes)
            {
                MessageBox.Show("Your result: " + nOfCorrectAnswers + " out of " + words.Count);
                this.Hide();
                Boss.getFormMain().Show();
            }
        }
    }
}
