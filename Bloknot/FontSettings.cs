using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bloknot
{
    public partial class FontSettings : Form
    {
        public int fontSize = 0;
        public FontStyle fs = FontStyle.Regular;
        internal bool FontWasChanged = false;
        internal FontStyle fontStyle;
        internal Color fontColor;
        public Font defFont;
        private bool fontWasChanged = false;
        public FontSettings()
        {
            InitializeComponent();
            fontBox.SelectedItem = fontBox.Items[0];
            styleBox.SelectedItem = styleBox.Items[0];
            colorBox.SelectedItem = colorBox.Items[5];
            defFont = new Font(ExampleText.Font.FontFamily, 1, FontStyle.Regular);
        }

        private void OnFontChanged(object sender, EventArgs e)
        {
            ExampleText.Font = new Font(ExampleText.Font.FontFamily, int.Parse(fontBox.SelectedItem.ToString()), ExampleText.Font.Style);
            fontSize = int.Parse(fontBox.SelectedItem.ToString()); 
        }
        private void OnStyleChanged(object sender, EventArgs e)
        {
            FontStyle selected_style = new FontStyle();

            switch (styleBox.SelectedItem.ToString())
            {
                case "обычный":
                    selected_style = FontStyle.Regular;
                    break;
                case "курсив":
                    selected_style = FontStyle.Italic;
                    break;
                case "полужирный":
                    selected_style = FontStyle.Bold;
                    break;
                case "вычеркивание":
                    selected_style = FontStyle.Strikeout;
                    break;
                case "подчеркивание":
                    selected_style = FontStyle.Underline;
                    break;
                default:
                    break;
            }
            ExampleText.Font = new Font(ExampleText.Font.FontFamily, int.Parse(fontBox.SelectedItem.ToString()), selected_style);
            fontStyle = ExampleText.Font.Style;
            checkFontChanging();
            defFont = ExampleText.Font;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void onColorChanged(object sender, EventArgs e)
        {
            Color selected_color = new Color();

            switch (colorBox.SelectedItem.ToString())
            {
                case "красный":
                    selected_color = Color.Red;
                    break;
                case "синий":
                    selected_color = Color.Blue;
                    break;
                case "зеленый":
                    selected_color = Color.Green;
                    break;
                case "желтый":
                    selected_color = Color.Yellow;
                    break;
                case "белый":
                    selected_color = Color.White;
                    break;
                case "черный":
                    selected_color = Color.Black;
                    break;
                default:
                    break;
            }

            ExampleText.Font = new Font(ExampleText.Font.FontFamily, int.Parse(fontBox.SelectedItem.ToString()), fontStyle);
            ExampleText.ForeColor = selected_color;
            fontColor = selected_color;
            checkFontChanging();
            defFont = ExampleText.Font;
        }
        private void checkFontChanging()
        {
            if (!ExampleText.Font.Equals(defFont))
            {
                fontWasChanged = true;
            }
        }
    }
}
