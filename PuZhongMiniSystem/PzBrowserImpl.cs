using Microsoft.IdentityModel.Tokens;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuZhongMiniSystem {
    internal class PzBrowserImpl : PzBrowser {
        private WebView2 webView;
        private string baseUrl;
        private Form1 mainForm;
        private FormOutput formOutput;


        public PzBrowserImpl(WebView2 webView, string baseUrl, Form1 mainForm, FormOutput formOutput) { 
            this.webView = webView;
            this.baseUrl = baseUrl;
            this.mainForm = mainForm;
            this.formOutput = formOutput;
        }

        public void visit(string input) {

            formOutput.appendText(input);

            var url = baseUrl + "/desk/checkin-rs232/" + Base64UrlEncoder.Encode(input);

            formOutput.appendText(url);

            // webView.CoreWebView2.Navigate(url);
            webView.Source = new Uri(url);
            mainForm.forgroundWindow();
            webView.Focus();
        }
    }
}
