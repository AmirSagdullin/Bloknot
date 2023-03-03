using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement; 

namespace Bloknot
{
    public partial class Form1 : Form
    {
        public int fontSize = 0;
        public FontStyle fs = FontStyle.Regular;
        public string filename;
        public bool isFileChanged;
        public FontSettings fontSetts;
        private int _fontSize = 0;
        private System.Drawing.FontStyle _fontStyle = FontStyle.Regular;
        private System.Drawing.Color _fontColor = Color.Black;
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            filename = "";
            isFileChanged= false;
            UpdateTextWithTitle();
            fontSetts = new FontSettings();
        }
        public void CreateNewDocument(object sender, EventArgs e)
        {
            SaveUnsavedFile();
            textBox1.Text = "";
            filename = "";
            isFileChanged = false;
            UpdateTextWithTitle();
        }
        public void OpenFile(object sender, EventArgs e)
        {
            SaveUnsavedFile();
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    textBox1.Text = sr.ReadToEnd();
                    sr.Close();
                    filename = openFileDialog1.FileName;
                    isFileChanged = false;
                }
                catch 
                {
                    MessageBox.Show("Невозможно открыть файл!");
                }
            }
            UpdateTextWithTitle();
        }
        public void SaveFile(string _filename)
        {
            if (_filename == "")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    _filename = saveFileDialog1.FileName;
                }
            }
            try
            {
                StreamWriter sw = new StreamWriter(_filename + ".txt");
                sw.Write(textBox1.Text);
                sw.Close();
                filename = _filename;
                isFileChanged = false;
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить файл!");
            }
            UpdateTextWithTitle();
        }
        public void Save(object sender, EventArgs e)
        {
            SaveFile(filename);
        }
        private void OnTextChanged(object sender, EventArgs e)
        {
            if (!isFileChanged) 
            {
                Text = Text.Replace('*',' ');
                isFileChanged = true;
                Text = "*" + Text; 
            }
        }
        public void UpdateTextWithTitle()
        {
            if (filename != "")
                Text = filename + " - Блокнот";
            else Text = "Безымянный - Блокнот";
        }
        public void SaveUnsavedFile()
        {
            if (isFileChanged)
            {
                DialogResult result = MessageBox.Show("Сохранить изменения в файле?", "Сохранение файла", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    SaveFile(filename);
                }
            }
        }
        public void CopyText()
        {
            Clipboard.SetText(textBox1.SelectedText);
        }
        public void CutText()
        {
            Clipboard.SetText(textBox1.SelectedText);
            textBox1.Text = textBox1.Text.Remove(textBox1.SelectionStart, textBox1.SelectionLength);
        }
        public void PasteText()
        {
            textBox1.Text = textBox1.Text.Substring(0, textBox1.SelectionStart) + Clipboard.GetText() + textBox1.Text.Substring(textBox1.SelectionStart, textBox1.Text.Length-textBox1.SelectionStart);
        }
        private void OnCopyClick(object sender, EventArgs e)
        {
            CopyText();
        }
        private void OnCutClick(object sender, EventArgs e)
        {
            CutText();
        }
        private void OnPasteClick(object sender, EventArgs e)
        {
            PasteText();
        }
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            SaveUnsavedFile();
        }
        private void OnFontClick(object sender, EventArgs e)
        {
            fontSetts = new FontSettings();
            fontSetts.Show();
        }

        private void OnFocus(object sender, EventArgs e)
        {
            if (!fontSetts.FontWasChanged)
            {
                _fontSize = fontSetts.fontSize;
                _fontStyle = fontSetts.fontStyle;
                _fontColor = fontSetts.fontColor;

                if (textBox1.SelectedText != String.Empty)
                {
                    textBox1.SelectionFont = new Font(textBox1.SelectionFont.FontFamily, _fontSize, _fontStyle);
                    textBox1.SelectionColor = _fontColor;
                }
                else
                {
                    textBox1.Font = new Font(textBox1.Font.FontFamily, _fontSize, _fontStyle);
                    textBox1.ForeColor = _fontColor;
                }
                fontSetts.Hide();
            }
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void onPrintClick(object sender, EventArgs e)
        {
            // объект для печати
            PrintDocument printDocument = new PrintDocument();

            // обработчик события печати
            printDocument.PrintPage += PrintPageHandler;

            // диалог настройки печати
            PrintDialog printDialog = new PrintDialog();

            // установка объекта печати для его настройки
            printDialog.Document = printDocument;

            // если в диалоге было нажато ОК
            if (printDialog.ShowDialog() == DialogResult.OK)
                printDialog.Document.Print(); // печатаем
        }
        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            // печать строки result
            e.Graphics.DrawString(textBox1.Text, textBox1.Font, Brushes.Black, 0, 0);
        }
    }
}
