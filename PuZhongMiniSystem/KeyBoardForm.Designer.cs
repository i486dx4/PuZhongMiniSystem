namespace PuZhongMiniSystem {
    partial class KeyBoardForm {
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
            textBoxKeyboardInput = new TextBox();
            buttonEnter = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // textBoxKeyboardInput
            // 
            textBoxKeyboardInput.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxKeyboardInput.ImeMode = ImeMode.Alpha;
            textBoxKeyboardInput.Location = new Point(12, 85);
            textBoxKeyboardInput.Name = "textBoxKeyboardInput";
            textBoxKeyboardInput.Size = new Size(392, 50);
            textBoxKeyboardInput.TabIndex = 0;
            textBoxKeyboardInput.ImeModeChanged += textBoxKeyboardInput_ImeModeChanged;
            // 
            // buttonEnter
            // 
            buttonEnter.Location = new Point(410, 85);
            buttonEnter.Name = "buttonEnter";
            buttonEnter.Size = new Size(107, 50);
            buttonEnter.TabIndex = 1;
            buttonEnter.TabStop = false;
            buttonEnter.Text = "ENTER";
            buttonEnter.UseVisualStyleBackColor = true;
            buttonEnter.Click += buttonEnter_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(431, 42);
            label1.TabIndex = 2;
            label1.Text = "這個是程式設計師測試用的, 要用也可以, 掃瞄器需在 USB\r\n的模態下使用。";
            // 
            // KeyBoardForm
            // 
            AcceptButton = buttonEnter;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(537, 156);
            Controls.Add(label1);
            Controls.Add(buttonEnter);
            Controls.Add(textBoxKeyboardInput);
            Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "KeyBoardForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "普中迷你資訊系統 - 鍵盤輸入模擬";
            FormClosed += KeyBoardForm_FormClosed;
            Load += KeyBoardForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxKeyboardInput;
        private Button buttonEnter;
        private Label label1;
    }
}