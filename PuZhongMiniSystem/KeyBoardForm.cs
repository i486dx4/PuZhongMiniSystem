using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PuZhongMiniSystem {
    public partial class KeyBoardForm : Form {

        private PzBrowser browser;
        public KeyBoardForm(PzBrowser pzBrowser) {
            InitializeComponent();
            browser = pzBrowser;
        }

        private void KeyBoardForm_Load(object sender, EventArgs e) {
            textBoxKeyboardInput.Focus();
        }

        private void KeyBoardForm_FormClosed(object sender, FormClosedEventArgs e) {

        }

        /*
        private void textBoxKeyboardInput_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                browser.visit(textBoxKeyboardInput.Text.Trim());
                textBoxKeyboardInput.Text = string.Empty;
                textBoxKeyboardInput.Focus();
            }
        }
        */

        private void buttonEnter_Click(object sender, EventArgs e) {
            /*
            var trimmed = textBoxKeyboardInput.Text.TrimEnd('\r', '\n');

            if (trimmed.Length > 6) {
                browser.visit(trimmed);
                // forgroundWindow();
            }
            */
            browser.visit(textBoxKeyboardInput.Text.Trim());
            textBoxKeyboardInput.Text = string.Empty;
            textBoxKeyboardInput.Focus();
        }

        private void textBoxKeyboardInput_ImeModeChanged(object sender, EventArgs e) {
            textBoxKeyboardInput.ImeMode = ImeMode.Alpha;
        }
    }
}
