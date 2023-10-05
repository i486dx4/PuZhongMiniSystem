using Microsoft.IdentityModel.Tokens;
using Microsoft.Web.WebView2.Core;
using PCSC;
using PCSC.Extensions;
using PCSC.Monitoring;
using PCSC.Exceptions;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Formats.Asn1;
using System.IO.Ports;
using System.Media;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq.Expressions;

namespace PuZhongMiniSystem {
    public partial class Form1 : Form {
        private string HOME_PAGE = "http://192.168.171.87";
        private SerialPort mySerialPort;
        private List<ToolStripMenuItem> ComItemList = new List<ToolStripMenuItem>();
        private int CheckedComItem = 0;
        private FormScanner formScanner = new FormScanner();
        private FormOutput formOutput = new FormOutput();
        private KeyBoardForm keyBoardForm;
        private PzBrowser pzBrowser;
        private SynchronizationContext uiContext;
        private string selectedComPortName = "COM3";
        private string predefinedPortName = string.Empty;
        private bool scannerNotFound = true;
        private DateTime lastScanTime;
        private String lastScanText;
        private SCardContext cardContext;
        private SCardReader cardReader;
        private bool enableNfcCardReader = false;
        private ACR122U acr122u = null;

        private ClientWebSocket clientWebSocket;
        private CancellationTokenSource cancellationTokenSource;

        public Form1() {
            InitializeComponent();
            uiContext = SynchronizationContext.Current;
            lastScanText = string.Empty;
            lastScanTime = DateTime.Now;

            clientWebSocket = new ClientWebSocket();
        }

        private async void ListenForWebSocketMessages() {
            var buffer = new byte[1024];
            while (clientWebSocket.State == WebSocketState.Open) {
                try {
                    var result = await clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Text) {
                        var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        // Process the received message
                        ProcessWebSocketMessage(message);
                    }
                } catch (Exception ex) {
                    MessageBox.Show($"WebSocket receive error: {ex.Message}");
                    break;
                }
            }
        }

        private void ProcessWebSocketMessage(string message) {
            // Perform action based on the received message.
            // For example, show an alert or perform some other operation.
            MessageBox.Show($"Received message from server: {message}");
        }

        /*

        private async Task ConnectToWebSocket() {
            try {
                await clientWebSocket.ConnectAsync(new Uri("ws://your_websocket_server_url"), CancellationToken.None);

                // Handle messages from the server
                clientWebSocket.MessageReceived += (sender, args) =>
                {
                    var message = Encoding.UTF8.GetString(args.Data);
                    switch (message) {
                        case "Hello, client!":
                            Label1.Text = "Server says hello!";
                            break;
                        case "Click the button":
                            Button1.Enabled = true;
                            break;
                    }
                };

            } catch (Exception ex) {
                MessageBox.Show("Error connecting to WebSocket server: " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */

        private void Form1_Load(object sender, EventArgs e) {
            int ComPort = 3;

            try {
                var portName = ConfigurationManager.AppSettings["portName"];
                if (portName != null && portName.Length > 0) {
                    predefinedPortName = portName;
                }
            } catch (Exception ex) {
                formOutput.appendText(ex.Message);
            }

            try {
                HOME_PAGE = ConfigurationManager.AppSettings["home"];
                webViewBrowser.Source = new System.Uri(HOME_PAGE);
            } catch (Exception ex) {
                formOutput.appendText(ex.Message);
            }

            try {
                var enableNfcReader = ConfigurationManager.AppSettings["nfcReader"];
                if (enableNfcReader != null && enableNfcReader == "true") {
                    enableNfcCardReader = true;
                }
            } catch (Exception ex) {
            }

            ComItemList.Add(cOM1ToolStripMenuItem);
            ComItemList.Add(cOM2ToolStripMenuItem);
            ComItemList.Add(cOM3ToolStripMenuItem);
            ComItemList.Add(cOM4ToolStripMenuItem);
            ComItemList.Add(cOM5ToolStripMenuItem);
            ComItemList.Add(cOM6ToolStripMenuItem);
            ComItemList.Add(cOM7ToolStripMenuItem);
            ComItemList.Add(cOM8ToolStripMenuItem);

            // selectComItem(ComPort);

            if (predefinedPortName != string.Empty) {
                selectComItemByName(predefinedPortName);
            } else {
                scannerDetection();
            }


            // var soundPlayer = new SoundPlayer();
            // soundPlayer.SoundLocation = "audio.wav";

            initializeNfc(true);

            // initializeWebView();
            pzBrowser = new PzBrowserImpl(webViewBrowser, HOME_PAGE, this, formOutput);


        }

        private void initializeNfc(bool onBoot) {
            if (enableNfcCardReader) {
                try {
                    var reader = new ACR122U();
                    reader.Init(false, 50, 4, 4, 200);  // NTAG213
                    reader.CardInserted += Acr122u_CardInserted;
                    reader.CardRemoved += Acr122u_CardRemoved;
                    this.acr122u = reader;

                    nfcReaderToolStripMenuItem.Text = "NFC 讀卡機已啟動";
                    nfcReaderToolStripMenuItem.Checked = true;
                } catch (Exception ex) {
                    acr122u = null;
                    nfcReaderToolStripMenuItem.Text = "啟動 NFC 讀卡機";
                    nfcReaderToolStripMenuItem.Checked = false;

                    if (! onBoot) {
                        MessageBox.Show("找不到 NFC 讀卡機, 系統只支援 ACR122U 或相容的讀卡機");
                    }
                }
            } else {
                nfcReaderToolStripMenuItem.Text = "NFC 讀卡功能停用";
                nfcReaderToolStripMenuItem.Enabled = false;
            }
            /*
            cardContext = new SCardContext();
            cardContext.Establish(SCardScope.System);

            string[] readerNames = cardContext.GetReaders();

            if (readerNames.Length > 0) {
                cardReader = new SCardReader(cardContext);
                cardReader.Connect(readerNames[0], SCardShareMode.Shared, SCardProtocol.T0 | SCardProtocol.T1);

                if (cardReader.ActiveProtocol == SCardProtocol.T0 || cardReader.ActiveProtocol == SCardProtocol.T1) {
                    // Start a background thread to continuously monitor for card insertion
                    // and read data from the card when detected.
                    var backgroundThread = new System.Threading.Thread(ReadNFCData);
                    backgroundThread.Start();
                }
            } else {
                MessageBox.Show("No NFC reader found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
            /*
            cardContext = new SCardContext();
            cardContext.Establish(SCardScope.System);

            string[] readerNames = cardContext.GetReaders();

            if (readerNames.Length > 0) {
                cardReader = new SCardReader(cardContext);
                cardReader.Connect(readerNames[0], SCardShareMode.Shared, SCardProtocol.T0 | SCardProtocol.T1);

                if (cardReader.ActiveProtocol == SCardProtocol.T0 || cardReader.ActiveProtocol == SCardProtocol.T1) {
                    isMonitoring = true;

                    // Start a background thread to continuously monitor for card presence
                    var monitorThread = new System.Threading.Thread(MonitorCardPresence);
                    monitorThread.Start();
                }
            } else {
                MessageBox.Show("No NFC reader found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }

        /*
        private void startMonitoringNFC() {
            using (var context = new SCardContext()) {
                context.Establish(SCardScope.System);

                var readerNames = context.GetReaders();
                if (readerNames == null || readerNames.Length == 0) {
                    MessageBox.Show("No NFC reader found.");
                    return;
                }

                var readerName = readerNames[0]; // Assuming only one reader is connected
                using (var reader = new SCardReader(context)) {
                    var sc = reader.Connect(readerName, SCardShareMode.Shared, SCardProtocol.Any);
                    if (sc != SCardError.Success) {
                        MessageBox.Show("Failed to connect to NFC reader.");
                        return;
                    }

                    var apdu = new CommandApdu(IsoCase.Case2Short, reader.ActiveProtocol) {
                        CLA = 0xFF,
                        Instruction = InstructionCode.GetData,
                        P1 = 0x00,
                        P2 = 0x00,
                        Le = 0 // Set the expected response length
                    };

                    reader.Transmit(apdu);

                    var responseApdu = new ResponseApdu(reader.Transmit(apdu));
                    if (responseApdu.SW1 == 0x90 && responseApdu.SW2 == 0x00) {
                        // Successfully read NFC data
                        textBoxOutput.Text = BitConverter.ToString(responseApdu.GetData());
                    } else {
                        MessageBox.Show("Failed to read NFC data.");
                    }

                    reader.Disconnect(SCardReaderDisposition.Leave);
                }
            }
        }
        */

        /*
        private void MonitorCardPresence() {
            while (isMonitoring) {

                // cardReader.Status
                var currentState = cardReader.GetStatus();
                if ((currentState.State & SCRState.Present) == SCRState.Present) {
                    string nfcData = ReadNFCData();
                    UpdateNFCDataUI(nfcData);
                }

                System.Threading.Thread.Sleep(1000); // Delay before checking again
            }
        }
        */

        /*
        private void OnCardStatusChanged(object sender, CardStatusEventArgs e) {
            if (e.State == SCRState.Present) {
                // Card is present, handle reading data here
                string nfcData = ReadNFCData();
                UpdateNFCDataUI(nfcData);
            }
        }
        */


        /*
        private string ReadNFCData() {
            while (true) {
                // cardReader.Status == SCardReaderState.EventState.CardIsPresent
                if (cardReader.Status == SCardReaderState.) {
                    var apdu = new CommandApdu(IsoCase.Case2Short, cardReader.ActiveProtocol) {
                        CLA = 0xFF,
                        INS = 0xCA,
                        P1 = 0x00,
                        P2 = 0x00,
                        Le = 256
                    };

                    var receivePci = new SCardPCI();
                    var receiveBuffer = new byte[256];
                    var responseApdu = new ResponseApdu(receiveBuffer, IsoCase.Case2Short, cardReader.ActiveProtocol);

                    cardReader.Transmit(apdu, receivePci, ref receiveBuffer);
                    string nfcData = Encoding.ASCII.GetString(responseApdu.GetData());

                    UpdateNFCDataUI(nfcData);
                }

                System.Threading.Thread.Sleep(1000); // Delay before checking again
            }
        }
        */

        private void Acr122u_CardInserted(PCSC.ICardReader reader) {
            // UpdateNFCDataUI("NFC 卡片插入");

            /*
            var uid = BitConverter.ToString(acr122u.GetUID(reader));
            UpdateNFCDataUI(uid);
            var ats = BitConverter.ToString(acr122u.GetATS(reader));
            UpdateNFCDataUI(ats);
            */

            var uid = acr122u.GetUIDvalue(reader);

            if (uid != 0) {
                UpdateNFCDataUI(String.Format("卡片內碼: {0,12:N0}", uid));
            } else {
                UpdateNFCDataUI("卡片內碼讀取失敗");
            }


            // Debug.WriteLine("Unique ID: " + BitConverter.ToString(acr122u.GetUID(reader)).Replace("-", ""));
            // string data = "Hello World";
            // Debug.WriteLine("Daten auf NFC Transponder schreiben: " + data);
            // bool ret = acr122u.WriteData(reader, Encoding.UTF8.GetBytes(data));
            // Debug.WriteLine("Schreibvorgang: " + (ret ? "erfolgreich" : "fehlgeschlagen"));
            // Debug.WriteLine("Daten von NFC Transponder auslesen: " + Encoding.UTF8.GetString(acr122u.ReadData(reader)));
        }

        private void Acr122u_CardRemoved() {
            // UpdateNFCDataUI("卡片移除");
        }

        private void UpdateNFCDataUI(string data) {
            this.Invoke((Action)(() => {
                formOutput.appendText(data);
            }));
            /*
            if (textBoxNFCData.InvokeRequired) {
                textBoxNFCData.Invoke(new Action<string>(UpdateNFCDataUI), data);
            } else {
                textBoxNFCData.Text = data;
            }
            */
        }

        /*
        public async void initializeWebView() {
            // await webViewBrowser.EnsureCoreWebView2Async();
            await webViewBrowser.EnsureCoreWebView2Async();

            // 取得 CoreWebView2Settings
            CoreWebView2Settings settings = webViewBrowser.CoreWebView2.Settings;

            // 允許自動播放音訊
            settings.AreDefaultContextMenusEnabled = true;
            // settings.
            settings.AreDevToolsEnabled = true; // 也可以打開開發者工具，便於除錯
            // settings.IsUserInteractionRequired = false;
            // settings.AllowUserInteractionForAudioPlayback = false;
            settings.AllowWebAudio = true;

            var webBrowserOptions = new WebBrowserOptions();
            webBrowserOptions.AllowWebAudioInInsecureContext = false;

            // 註冊 WebView2 的 NavigationCompleted 事件
            webViewBrowser.NavigationCompleted += WebView2_NavigationCompleted;

        }
        */

        public void scannerDetection() {
            string[] availablePorts = SerialPort.GetPortNames();

            if (availablePorts.Length == 0) {
                formOutput.appendText("找不到可用的 COM Port。");
                var f = new FormException("找不到可用的 COM Port。");
                f.ShowDialog();
                return;
            }

            foreach (string portName in availablePorts) {
                if (dectectingBarcodeScannerExists(portName)) {
                    formOutput.appendText("連接到 " + portName + " : " + portName);
                    selectComItemByName(portName);
                    return;
                }
            }

            startScannerToolStripMenuItem.Text = "偵測掃瞄器";
            startScannerToolStripMenuItem.Checked = false;

            var formEx = new FormException("找不到掃瞄器");
            formEx.ShowDialog();
        }

        public void forgroundWindow() {
            // this.WindowState = FormWindowState.Minimized;
            this.Show();
            // this.WindowState = FormWindowState.Normal;
            this.WindowState = FormWindowState.Maximized;
            this.Activate();
        }

        private async void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e) {
            SerialPort sp = (SerialPort)sender;
            var inData = sp.ReadExisting();
            var trimmed = inData.TrimEnd('\r', '\n');

            if (formScanner.showAsDialog) {
                this.Invoke((Action)(() => {
                    formScanner.appendText(trimmed);
                }));
            } else {
                try {
                    if (trimmed.Length > 6) {
                        var now = DateTime.Now;
                        var elapsedTime = now - lastScanTime;
                        var diffInSeconds = elapsedTime.TotalSeconds;

                        if (trimmed != lastScanText || diffInSeconds > 5) {
                            // formOutput.appendText("catch: " + trimmed);
                            // this.Invoke((Action)(() => {
                            //    pzBrowser.visit(trimmed);
                            // }));
                            // uiContext.Post(new SendOrPostCallback((_) => {
                            //    pzBrowser.visit(trimmed);
                            // }), null);
                            await Task.Run(() => {
                                this.Invoke(new Action(() => {
                                    pzBrowser.visit(trimmed);
                                }));
                            });
                        } else {
                            // formOutput.appendText("ignore (same): " + trimmed);
                        }

                        lastScanText = trimmed;
                        lastScanTime = now;
                        /*
                        uiContext.Post(new SendOrPostCallback((_) =>
                        {
                            pzBrowser.visit(trimmed);
                        }), null);
                        */
                    } else {
                        formOutput.appendText("ignore (short): " + trimmed);
                    }
                } catch (Exception ex) {
                    this.Invoke((Action)(() => {
                        formScanner.appendText(ex.Message);
                    }));
                }
            }
        }

        private bool dectectingBarcodeScannerExists(string portName) {
            if (portName == "COM1" || portName == "COM2") {
                return false;
            }

            try {
                using (SerialPort serialPort = new SerialPort(portName)) {
                    Debug.WriteLine("try port " + portName);

                    serialPort.BaudRate = 9600;
                    serialPort.Parity = Parity.None;
                    serialPort.StopBits = StopBits.One;
                    serialPort.DataBits = 8;
                    serialPort.Handshake = Handshake.None;

                    serialPort.Open();


                    // 在這裡添加一些程式碼來處理 Barcode Scanner 的回應，以確定它是否是你的目標設備。
                    // 例如，你可以讀取並解析它的回應，確認它的識別碼等等。

                    // 若成功辨識為 Barcode Scanner，則輸出 COM Port 資訊
                    // formOutput.appendText("找到 Barcode Scanner 連接在 COM Port: " + portName);
                    return true;
                }
            } catch (Exception ex) {
                // 若無法連接或處理 COM Port，可能不是 Barcode Scanner，忽略並繼續尋找下一個 COM Port。
                formOutput.appendText("無法連接到 " + portName + " : " + ex.Message);
            }
            return false;
        }

        private void startRecevingFromComPort(String portName) {
            try {
                mySerialPort = new SerialPort(portName);

                mySerialPort.BaudRate = 9600;
                mySerialPort.Parity = Parity.None;
                mySerialPort.StopBits = StopBits.One;
                mySerialPort.DataBits = 8;
                mySerialPort.Handshake = Handshake.None;

                mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

                mySerialPort.Open();

                scannerNotFound = false;
                startScannerToolStripMenuItem.Text = "停止掃瞄";
                startScannerToolStripMenuItem.Checked = true;
            } catch (Exception ex) {
                formOutput.appendText(ex.Message);
                var formEx = new FormException("無法連接到 " + ComItemList[CheckedComItem].Text + " 埠");
                scannerNotFound = true;
                startScannerToolStripMenuItem.Text = "偵測掃瞄器";
                startScannerToolStripMenuItem.Checked = false;
                formEx.ShowDialog();
            }
        }

        private void stopRecevingFromComPort() {
            if (mySerialPort != null) {
                mySerialPort.Close();
                startScannerToolStripMenuItem.Text = "啟動掃瞄";
                startScannerToolStripMenuItem.Checked = false;
            }
            mySerialPort = null;
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e) {
            webViewBrowser.CoreWebView2.Navigate(HOME_PAGE);
        }

        private void selectComItem(int comNumber) {
            stopRecevingFromComPort();

            for (int i = 0; i < ComItemList.Count; i++) {
                ComItemList[i].Checked = false;
            }
            ComItemList[comNumber - 1].Checked = true;
            CheckedComItem = comNumber - 1;

            selectedComPortName = ComItemList[CheckedComItem].Text;

            startRecevingFromComPort(selectedComPortName);
        }

        private void selectComItemByName(string portName) {
            stopRecevingFromComPort();

            for (int i = 0; i < ComItemList.Count; i++) {
                if (ComItemList[i].Text == portName) {
                    ComItemList[i].Checked = true;
                } else {
                    ComItemList[i].Checked = false;
                }
            }

            selectedComPortName = portName;
            startRecevingFromComPort(selectedComPortName);
        }

        private void cOM1ToolStripMenuItem_Click(object sender, EventArgs e) {
            selectComItem(1);
        }

        private void cOM2ToolStripMenuItem_Click(object sender, EventArgs e) {
            selectComItem(2);
        }

        private void cOM3ToolStripMenuItem_Click(object sender, EventArgs e) {
            selectComItem(3);
        }

        private void cOM4ToolStripMenuItem_Click(object sender, EventArgs e) {
            selectComItem(4);
        }

        private void cOM5ToolStripMenuItem_Click(object sender, EventArgs e) {
            selectComItem(5);
        }

        private void cOM6ToolStripMenuItem_Click(object sender, EventArgs e) {
            selectComItem(6);
        }

        private void cOM7ToolStripMenuItem_Click(object sender, EventArgs e) {
            selectComItem(7);
        }

        private void cOM8ToolStripMenuItem_Click(object sender, EventArgs e) {
            selectComItem(8);
        }

        private void browserVisit(ToolStripMenuItem menuItem) {
            webViewBrowser.CoreWebView2.Navigate((string)menuItem.Tag);
        }

        private void googleToolStripMenuItem_Click(object sender, EventArgs e) {
            browserVisit(googleToolStripMenuItem);
        }

        private void puZhongMiniSystemlStripMenuItem_Click(object sender, EventArgs e) {
            browserVisit(puZhongMiniSystemlStripMenuItem);
        }

        private void puZhongToolStripMenuItem_Click(object sender, EventArgs e) {
            browserVisit(puZhongToolStripMenuItem);
        }

        private void ctWorldToolStripMenuItem_Click(object sender, EventArgs e) {
            browserVisit(ctWorldToolStripMenuItem);
        }

        private void testingScannerToolStripMenuItem_Click(object sender, EventArgs e) {
            formScanner.ShowDialog();
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e) {

            DialogResult result = MessageBox.Show(
                "您確定要關閉應用程式嗎, 程式關掉就無法進行簽到退？", "關閉應用程式", MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes) {
                e.Cancel = true;


                if (clientWebSocket != null && clientWebSocket.State == WebSocketState.Open) {
                    await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Form closing", CancellationToken.None);
                    clientWebSocket.Dispose();
                }

                cardReader.Disconnect(SCardReaderDisposition.Leave);
                cardContext.Release();
                // Application.Exit();
            } else {
                e.Cancel = false;
            }
        }

        private void outputRecordToolStripMenuItem_Click(object sender, EventArgs e) {
            formOutput.ShowDialog();
        }

        private void startScannerToolStripMenuItem_Click(object sender, EventArgs e) {
            if (startScannerToolStripMenuItem.Checked) {
                stopRecevingFromComPort();
            } else {
                if (scannerNotFound) {
                    scannerDetection();
                } else {
                    startRecevingFromComPort(selectedComPortName);
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            var dialog = new FormAbout();
            dialog.ShowDialog();
            //MessageBox.Show("我想好好休息一陣子, 再會了, 各位菩薩. 這瀏覽器是有點陽春, 但主要目的是讓刷條碼有比較便利, 如果覺得不好用, 就用原本瀏覽器, 然後請把讀卡機調回鍵盤模式." +
            //    System.Environment.NewLine + System.Environment.NewLine + "2023 年 7 月 17 日");
        }

        private void keyboardToolStripMenuItem_Click(object sender, EventArgs e) {
            if (keyBoardForm == null) {
                keyBoardForm = new KeyBoardForm(pzBrowser);
                keyBoardForm.Show();
            } else {
                try {
                    keyBoardForm.Show();
                    keyBoardForm.Focus();
                } catch {
                    keyBoardForm = new KeyBoardForm(pzBrowser);
                    keyBoardForm.Show();
                }
            }
        }

        private void webViewBrowser_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            toolStripStatusLabel1.Text = webViewBrowser.Source.ToString();
        }

        private void usbModeToolStripMenuItem_Click(object sender, EventArgs e) {
            var dialog = new FormUSB();

            dialog.ShowDialog();
        }

        private void rS232ModeToolStripMenuItem_Click(object sender, EventArgs e) {
            var dialog = new FormRS232();

            dialog.ShowDialog();
        }

        private void nfcReaderToolStripMenuItem_Click(object sender, EventArgs e) {
            if (enableNfcCardReader) {
                if (acr122u == null) {
                    initializeNfc(false);
                }
            }
        }
    }
}