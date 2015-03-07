using System;
using System.Windows.Forms;

namespace Gridden.View
{
    public partial class NewSpriteForm : Form
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public NewSpriteForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private string _fileName;
        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
            }
        }

        /// <summary>
        /// Event handler for clicking the "OK" button.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            // make sure the given character does not exist in the map AND not empty/a space
            bool valid = true;
            char newSpriteChar = this.charTextBox.Text.Length > 0 ? this.charTextBox.Text[0] : ' ';
            foreach (Sprite s in SheetEditor.Instance.GetSpritesFromSheet())
            {
                if (s.Char == newSpriteChar)
                {
                    valid = false;
                }
            }

            if (valid)
            {
                SheetEditor.Instance.AddSpriteToSheet(newSpriteChar, FileName);
                this.Close();
            }
            else
            {
                if (newSpriteChar != ' ')
                {
                    MessageBox.Show("That character already exists in the map - please enter a different one.");
                }
                else
                {
                    MessageBox.Show("Please enter a single character.");
                }
            }
        }
    }
}
