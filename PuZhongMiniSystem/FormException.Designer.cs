namespace PuZhongMiniSystem {
    partial class FormException {
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
            labelMessage = new Label();
            SuspendLayout();
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            labelMessage.Location = new Point(25, 54);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(292, 45);
            labelMessage.TabIndex = 1;
            labelMessage.Text = "無法開啟 COM3 埠";
            labelMessage.Click += labelMessage_Click;
            // 
            // FormException
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(342, 171);
            Controls.Add(labelMessage);
            Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormException";
            Text = "執行錯誤";
            Load += FormException_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelMessage;
    }
}