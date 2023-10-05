namespace PuZhongMiniSystem {
    partial class FormOutput {
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
            textBoxOutput = new TextBox();
            SuspendLayout();
            // 
            // textBoxOutput
            // 
            textBoxOutput.Dock = DockStyle.Fill;
            textBoxOutput.Location = new Point(0, 0);
            textBoxOutput.Multiline = true;
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.ReadOnly = true;
            textBoxOutput.Size = new Size(900, 518);
            textBoxOutput.TabIndex = 0;
            // 
            // FormOutput
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(900, 518);
            Controls.Add(textBoxOutput);
            Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FormOutput";
            Text = "Debugging Output";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxOutput;
    }
}