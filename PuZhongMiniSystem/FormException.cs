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

namespace PuZhongMiniSystem {
    public partial class FormException : Form {
        private string errorMessage;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public FormException(string errorMessage) {
            InitializeComponent();

            this.errorMessage = errorMessage;
        }

        private void FormException_Load(object sender, EventArgs e) {
            this.labelMessage.Text = errorMessage;

            timer.Interval = 2000;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }

        private void labelMessage_Click(object sender, EventArgs e) {

        }

        private void timer1_Tick(object sender, EventArgs e) {
            this.Close();
        }
    }
}
