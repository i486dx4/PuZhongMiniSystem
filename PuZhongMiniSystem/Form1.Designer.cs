namespace PuZhongMiniSystem {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            contextMenuStrip1 = new ContextMenuStrip(components);
            contextMenuStrip2 = new ContextMenuStrip(components);
            menuStrip1 = new MenuStrip();
            homeToolStripMenuItem = new ToolStripMenuItem();
            linkToolStripMenuItem = new ToolStripMenuItem();
            puZhongMiniSystemlStripMenuItem = new ToolStripMenuItem();
            puZhongToolStripMenuItem = new ToolStripMenuItem();
            ctWorldToolStripMenuItem = new ToolStripMenuItem();
            googleToolStripMenuItem = new ToolStripMenuItem();
            qrCodeToolStripMenuItem = new ToolStripMenuItem();
            portToolStripMenuItem = new ToolStripMenuItem();
            cOM1ToolStripMenuItem = new ToolStripMenuItem();
            cOM2ToolStripMenuItem = new ToolStripMenuItem();
            cOM3ToolStripMenuItem = new ToolStripMenuItem();
            cOM4ToolStripMenuItem = new ToolStripMenuItem();
            cOM5ToolStripMenuItem = new ToolStripMenuItem();
            cOM6ToolStripMenuItem = new ToolStripMenuItem();
            cOM7ToolStripMenuItem = new ToolStripMenuItem();
            cOM8ToolStripMenuItem = new ToolStripMenuItem();
            startScannerToolStripMenuItem = new ToolStripMenuItem();
            testingScannerToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            outputRecordToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            usbModeToolStripMenuItem = new ToolStripMenuItem();
            rS232ModeToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            nfcReaderToolStripMenuItem = new ToolStripMenuItem();
            keyboardToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            webViewBrowser = new Microsoft.Web.WebView2.WinForms.WebView2();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webViewBrowser).BeginInit();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, linkToolStripMenuItem, qrCodeToolStripMenuItem, keyboardToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1008, 33);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            homeToolStripMenuItem.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            homeToolStripMenuItem.Size = new Size(81, 29);
            homeToolStripMenuItem.Text = "回首頁";
            homeToolStripMenuItem.Click += homeToolStripMenuItem_Click;
            // 
            // linkToolStripMenuItem
            // 
            linkToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { puZhongMiniSystemlStripMenuItem, puZhongToolStripMenuItem, ctWorldToolStripMenuItem, googleToolStripMenuItem });
            linkToolStripMenuItem.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            linkToolStripMenuItem.Name = "linkToolStripMenuItem";
            linkToolStripMenuItem.Size = new Size(62, 29);
            linkToolStripMenuItem.Text = "連結";
            // 
            // puZhongMiniSystemlStripMenuItem
            // 
            puZhongMiniSystemlStripMenuItem.Name = "puZhongMiniSystemlStripMenuItem";
            puZhongMiniSystemlStripMenuItem.Size = new Size(236, 30);
            puZhongMiniSystemlStripMenuItem.Tag = "http://192.168.171.87";
            puZhongMiniSystemlStripMenuItem.Text = "普中精舍報到系統";
            puZhongMiniSystemlStripMenuItem.Click += puZhongMiniSystemlStripMenuItem_Click;
            // 
            // puZhongToolStripMenuItem
            // 
            puZhongToolStripMenuItem.Name = "puZhongToolStripMenuItem";
            puZhongToolStripMenuItem.Size = new Size(236, 30);
            puZhongToolStripMenuItem.Tag = "https://www.ctworld.org.tw/108/puzhong1/index.htm";
            puZhongToolStripMenuItem.Text = "普中精舍";
            puZhongToolStripMenuItem.Click += puZhongToolStripMenuItem_Click;
            // 
            // ctWorldToolStripMenuItem
            // 
            ctWorldToolStripMenuItem.Name = "ctWorldToolStripMenuItem";
            ctWorldToolStripMenuItem.Size = new Size(236, 30);
            ctWorldToolStripMenuItem.Tag = "https://www.ctworld.org.tw/";
            ctWorldToolStripMenuItem.Text = "中台禪寺";
            ctWorldToolStripMenuItem.Click += ctWorldToolStripMenuItem_Click;
            // 
            // googleToolStripMenuItem
            // 
            googleToolStripMenuItem.Name = "googleToolStripMenuItem";
            googleToolStripMenuItem.Size = new Size(236, 30);
            googleToolStripMenuItem.Tag = "https://www.google.com/";
            googleToolStripMenuItem.Text = "Google";
            googleToolStripMenuItem.Click += googleToolStripMenuItem_Click;
            // 
            // qrCodeToolStripMenuItem
            // 
            qrCodeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { portToolStripMenuItem, startScannerToolStripMenuItem, testingScannerToolStripMenuItem, toolStripSeparator1, outputRecordToolStripMenuItem, toolStripSeparator2, usbModeToolStripMenuItem, rS232ModeToolStripMenuItem, toolStripSeparator3, nfcReaderToolStripMenuItem });
            qrCodeToolStripMenuItem.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            qrCodeToolStripMenuItem.Name = "qrCodeToolStripMenuItem";
            qrCodeToolStripMenuItem.Size = new Size(157, 29);
            qrCodeToolStripMenuItem.Text = "二維條碼掃瞄器";
            // 
            // portToolStripMenuItem
            // 
            portToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cOM1ToolStripMenuItem, cOM2ToolStripMenuItem, cOM3ToolStripMenuItem, cOM4ToolStripMenuItem, cOM5ToolStripMenuItem, cOM6ToolStripMenuItem, cOM7ToolStripMenuItem, cOM8ToolStripMenuItem });
            portToolStripMenuItem.Name = "portToolStripMenuItem";
            portToolStripMenuItem.Size = new Size(222, 30);
            portToolStripMenuItem.Text = "通訊埠";
            // 
            // cOM1ToolStripMenuItem
            // 
            cOM1ToolStripMenuItem.Name = "cOM1ToolStripMenuItem";
            cOM1ToolStripMenuItem.Size = new Size(135, 30);
            cOM1ToolStripMenuItem.Text = "COM1";
            cOM1ToolStripMenuItem.Click += cOM1ToolStripMenuItem_Click;
            // 
            // cOM2ToolStripMenuItem
            // 
            cOM2ToolStripMenuItem.Name = "cOM2ToolStripMenuItem";
            cOM2ToolStripMenuItem.Size = new Size(135, 30);
            cOM2ToolStripMenuItem.Text = "COM2";
            cOM2ToolStripMenuItem.Click += cOM2ToolStripMenuItem_Click;
            // 
            // cOM3ToolStripMenuItem
            // 
            cOM3ToolStripMenuItem.Name = "cOM3ToolStripMenuItem";
            cOM3ToolStripMenuItem.Size = new Size(135, 30);
            cOM3ToolStripMenuItem.Text = "COM3";
            cOM3ToolStripMenuItem.Click += cOM3ToolStripMenuItem_Click;
            // 
            // cOM4ToolStripMenuItem
            // 
            cOM4ToolStripMenuItem.Name = "cOM4ToolStripMenuItem";
            cOM4ToolStripMenuItem.Size = new Size(135, 30);
            cOM4ToolStripMenuItem.Text = "COM4";
            cOM4ToolStripMenuItem.Click += cOM4ToolStripMenuItem_Click;
            // 
            // cOM5ToolStripMenuItem
            // 
            cOM5ToolStripMenuItem.Name = "cOM5ToolStripMenuItem";
            cOM5ToolStripMenuItem.Size = new Size(135, 30);
            cOM5ToolStripMenuItem.Text = "COM5";
            cOM5ToolStripMenuItem.Click += cOM5ToolStripMenuItem_Click;
            // 
            // cOM6ToolStripMenuItem
            // 
            cOM6ToolStripMenuItem.Name = "cOM6ToolStripMenuItem";
            cOM6ToolStripMenuItem.Size = new Size(135, 30);
            cOM6ToolStripMenuItem.Text = "COM6";
            cOM6ToolStripMenuItem.Click += cOM6ToolStripMenuItem_Click;
            // 
            // cOM7ToolStripMenuItem
            // 
            cOM7ToolStripMenuItem.Name = "cOM7ToolStripMenuItem";
            cOM7ToolStripMenuItem.Size = new Size(135, 30);
            cOM7ToolStripMenuItem.Text = "COM7";
            cOM7ToolStripMenuItem.Click += cOM7ToolStripMenuItem_Click;
            // 
            // cOM8ToolStripMenuItem
            // 
            cOM8ToolStripMenuItem.Name = "cOM8ToolStripMenuItem";
            cOM8ToolStripMenuItem.Size = new Size(135, 30);
            cOM8ToolStripMenuItem.Text = "COM8";
            cOM8ToolStripMenuItem.Click += cOM8ToolStripMenuItem_Click;
            // 
            // startScannerToolStripMenuItem
            // 
            startScannerToolStripMenuItem.Name = "startScannerToolStripMenuItem";
            startScannerToolStripMenuItem.Size = new Size(222, 30);
            startScannerToolStripMenuItem.Text = "啟動掃瞄";
            startScannerToolStripMenuItem.Click += startScannerToolStripMenuItem_Click;
            // 
            // testingScannerToolStripMenuItem
            // 
            testingScannerToolStripMenuItem.Name = "testingScannerToolStripMenuItem";
            testingScannerToolStripMenuItem.Size = new Size(222, 30);
            testingScannerToolStripMenuItem.Text = "掃瞄測試";
            testingScannerToolStripMenuItem.Click += testingScannerToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(219, 6);
            // 
            // outputRecordToolStripMenuItem
            // 
            outputRecordToolStripMenuItem.Name = "outputRecordToolStripMenuItem";
            outputRecordToolStripMenuItem.Size = new Size(222, 30);
            outputRecordToolStripMenuItem.Text = "執行記錄";
            outputRecordToolStripMenuItem.Click += outputRecordToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(219, 6);
            // 
            // usbModeToolStripMenuItem
            // 
            usbModeToolStripMenuItem.Name = "usbModeToolStripMenuItem";
            usbModeToolStripMenuItem.Size = new Size(222, 30);
            usbModeToolStripMenuItem.Text = "USB 模式";
            usbModeToolStripMenuItem.Click += usbModeToolStripMenuItem_Click;
            // 
            // rS232ModeToolStripMenuItem
            // 
            rS232ModeToolStripMenuItem.Name = "rS232ModeToolStripMenuItem";
            rS232ModeToolStripMenuItem.Size = new Size(222, 30);
            rS232ModeToolStripMenuItem.Text = "RS 232 模式";
            rS232ModeToolStripMenuItem.Click += rS232ModeToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(219, 6);
            // 
            // nfcReaderToolStripMenuItem
            // 
            nfcReaderToolStripMenuItem.Name = "nfcReaderToolStripMenuItem";
            nfcReaderToolStripMenuItem.Size = new Size(222, 30);
            nfcReaderToolStripMenuItem.Text = "啟動 NFC 讀卡機";
            nfcReaderToolStripMenuItem.Click += nfcReaderToolStripMenuItem_Click;
            // 
            // keyboardToolStripMenuItem
            // 
            keyboardToolStripMenuItem.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            keyboardToolStripMenuItem.Name = "keyboardToolStripMenuItem";
            keyboardToolStripMenuItem.Size = new Size(100, 29);
            keyboardToolStripMenuItem.Text = "鍵盤模擬";
            keyboardToolStripMenuItem.Click += keyboardToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(119, 29);
            aboutToolStripMenuItem.Text = "關於本程式";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 639);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1008, 22);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // webViewBrowser
            // 
            webViewBrowser.AllowExternalDrop = true;
            webViewBrowser.CreationProperties = null;
            webViewBrowser.DefaultBackgroundColor = Color.White;
            webViewBrowser.Dock = DockStyle.Fill;
            webViewBrowser.Location = new Point(0, 33);
            webViewBrowser.Name = "webViewBrowser";
            webViewBrowser.Size = new Size(1008, 606);
            webViewBrowser.Source = new Uri("http://192.168.171.87", UriKind.Absolute);
            webViewBrowser.TabIndex = 6;
            webViewBrowser.ZoomFactor = 1D;
            webViewBrowser.SourceChanged += webViewBrowser_SourceChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1008, 661);
            Controls.Add(webViewBrowser);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "普中精舍簽到系統專用";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webViewBrowser).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private ContextMenuStrip contextMenuStrip2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem homeToolStripMenuItem;
        private ToolStripMenuItem qrCodeToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem startScannerToolStripMenuItem;
        private ToolStripMenuItem testingScannerToolStripMenuItem;
        private StatusStrip statusStrip1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewBrowser;
        private ToolStripMenuItem portToolStripMenuItem;
        private ToolStripMenuItem cOM1ToolStripMenuItem;
        private ToolStripMenuItem cOM2ToolStripMenuItem;
        private ToolStripMenuItem cOM3ToolStripMenuItem;
        private ToolStripMenuItem cOM4ToolStripMenuItem;
        private ToolStripMenuItem cOM5ToolStripMenuItem;
        private ToolStripMenuItem cOM6ToolStripMenuItem;
        private ToolStripMenuItem cOM7ToolStripMenuItem;
        private ToolStripMenuItem cOM8ToolStripMenuItem;
        private ToolStripMenuItem linkToolStripMenuItem;
        private ToolStripMenuItem puZhongMiniSystemlStripMenuItem;
        private ToolStripMenuItem puZhongToolStripMenuItem;
        private ToolStripMenuItem ctWorldToolStripMenuItem;
        private ToolStripMenuItem googleToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem outputRecordToolStripMenuItem;
        private ToolStripMenuItem keyboardToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem usbModeToolStripMenuItem;
        private ToolStripMenuItem rS232ModeToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem nfcReaderToolStripMenuItem;
    }
}