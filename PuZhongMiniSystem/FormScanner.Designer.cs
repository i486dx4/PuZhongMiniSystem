namespace PuZhongMiniSystem {
    partial class FormScanner {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            menuStrip1 = new MenuStrip();
            clearToolStripMenuItem = new ToolStripMenuItem();
            textBoxScanner = new TextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { clearToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(460, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(89, 24);
            clearToolStripMenuItem.Text = " 資料清除";
            clearToolStripMenuItem.Click += clearToolStripMenuItem_Click;
            // 
            // textBoxScanner
            // 
            textBoxScanner.Dock = DockStyle.Fill;
            textBoxScanner.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxScanner.ImeMode = ImeMode.KatakanaHalf;
            textBoxScanner.Location = new Point(0, 28);
            textBoxScanner.Multiline = true;
            textBoxScanner.Name = "textBoxScanner";
            textBoxScanner.ReadOnly = true;
            textBoxScanner.Size = new Size(460, 232);
            textBoxScanner.TabIndex = 1;
            textBoxScanner.TabStop = false;
            // 
            // FormScanner
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(460, 260);
            Controls.Add(textBoxScanner);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            Name = "FormScanner";
            Text = "掃瞄測試";
            FormClosing += FormScanner_FormClosing;
            Load += FormScanner_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem clearToolStripMenuItem;
        private TextBox textBoxScanner;
    }
}