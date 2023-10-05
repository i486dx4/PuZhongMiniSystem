using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuZhongMiniSystem {
    public partial class FormScanner : Form {
        public bool showAsDialog {
            get; private set;
        } = false;

        public FormScanner() {
            InitializeComponent();
        }

        private void FormScanner_Load(object sender, EventArgs e) {
            textBoxScanner.Text = "";
            showAsDialog = true;
        }

        private void FormScanner_FormClosing(object sender, FormClosingEventArgs e) {
            textBoxScanner.Text = "";
            showAsDialog = false;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e) {
            textBoxScanner.Text = "";
        }

        public void appendText(string text) {
            textBoxScanner.Text += "[" + text + "]" + System.Environment.NewLine;
        }
    }
}
