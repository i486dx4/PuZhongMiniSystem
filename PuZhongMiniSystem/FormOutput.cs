using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuZhongMiniSystem {
    public partial class FormOutput : Form {
        private LinkedList<string> textList = new LinkedList<string>();
        public FormOutput() {
            InitializeComponent();
        }

        public void appendText(string text) {
            textList.AddFirst(text);

            if (textList.Count > 20) {
                textList.RemoveLast();
            }
            textBoxOutput.Text = string.Join(System.Environment.NewLine, textList);
        }
    }
}
